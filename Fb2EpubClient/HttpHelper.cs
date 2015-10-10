using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Fb2EpubClient
{
    public struct LinkItem
    {
        public string Href;
        public string Text;

        public override string ToString()
        {
            return Href + "\n\t" + Text;
        }
    }

    static class LinkFinder
    {
        public static List<LinkItem> Find(string file)
        {
            List<LinkItem> list = new List<LinkItem>();

            // 1.
            // Find all matches in file.
            MatchCollection m1 = Regex.Matches(file, @"(<a.*?>.*?</a>)",
                RegexOptions.Singleline);

            // 2.
            // Loop over each match.
            foreach (Match m in m1)
            {
                string value = m.Groups[1].Value;
                LinkItem i = new LinkItem();

                // 3.
                // Get href attribute.
                Match m2 = Regex.Match(value, @"href=\""(.*?)\""",
                RegexOptions.Singleline);
                if (m2.Success)
                {
                    i.Href = m2.Groups[1].Value;
                }

                // 4.
                // Remove inner tags from text.
                string t = Regex.Replace(value, @"\s*<.*?>\s*", "",
                RegexOptions.Singleline);
                i.Text = t;

                list.Add(i);
            }
            return list;
        }
    }


    public struct UploadedFile
    {
        public string FileName;
        public string ParamName;
        public string ContentType;
    }

    public static class HttpHelper
    {
        public static string UploadFileViaFormData(
            string url, 
            List<UploadedFile> files,
            NameValueCollection parameters)
        {
            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            byte[] firstBoundaryBytes = System.Text.Encoding.ASCII.GetBytes("--" + boundary + "\r\n");
            byte[] endOfLine = System.Text.Encoding.UTF8.GetBytes("\r\n");

            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.ContentType = "multipart/form-data; boundary=" + boundary;
            request.Method = "POST";
            request.UserAgent = ".NET Application";
            request.KeepAlive = true;
            request.Credentials = System.Net.CredentialCache.DefaultCredentials;

            Stream rs = request.GetRequestStream();

            rs.Write(firstBoundaryBytes, 0, firstBoundaryBytes.Length);

            string headerTemplate =
                "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\n" +
                "Content-Type: {2}\r\n\r\n";
            foreach (UploadedFile file in files)
            {
                rs.Write(firstBoundaryBytes, 0, firstBoundaryBytes.Length);

                string header = string.Format(
                    headerTemplate, 
                    file.ParamName, 
                    Uri.EscapeUriString(Path.GetFileName(file.FileName)), 
                    file.ContentType);

                byte[] headerBytes = System.Text.Encoding.UTF8.GetBytes(header);
                rs.Write(headerBytes, 0, headerBytes.Length);

                FileStream fileStream = new FileStream(file.FileName, FileMode.Open, FileAccess.Read);
                byte[] buffer = new byte[4096];
                int bytesRead = 0;
                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    rs.Write(buffer, 0, bytesRead);
                }
                fileStream.Close();

                rs.Write(endOfLine, 0, endOfLine.Length);
            }

            string formdataTemplate = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";
            foreach (string key in parameters.Keys)
            {
                rs.Write(firstBoundaryBytes, 0, firstBoundaryBytes.Length);
                string formItem = string.Format(formdataTemplate, key, parameters[key]);
                byte[] formItemBytes = System.Text.Encoding.UTF8.GetBytes(formItem);
                rs.Write(formItemBytes, 0, formItemBytes.Length);
                rs.Write(endOfLine, 0, endOfLine.Length);
            }

            byte[] trailer = System.Text.Encoding.ASCII.GetBytes("--" + boundary + "--\r\n");
            rs.Write(trailer, 0, trailer.Length);
            rs.Close();

            WebResponse response = null;
            Uri responseUri = null;
            string responseString = null;
            try
            {
                response = request.GetResponse();
                responseUri = response.ResponseUri;
                Stream respStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(respStream);
                responseString = reader.ReadToEnd();
                Debug.WriteLine(string.Format("File uploaded, server response is:\n{0}",
                    responseString));
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error while uploading file: " + e.Message);
                Debug.WriteLine("Details: " + e.ToString());

                if (response != null)
                {
                    response.Close();
                    response = null;
                }
            }
            finally
            {
                request = null;
            }
            return responseString;
        }

        /// <summary>
        /// Trys to download file by specified URI to the target path.
        /// </summary>
        /// <param name="uri">File URI</param>
        /// <param name="path">Target path</param>
        /// <returns>True if download completed successfully, otherwise false.</returns>
        public static bool TryDownloadFile(Uri uri, string path)
        {
            using (WebClient client = new WebClient())
            {
                try
                {
                    client.DownloadFile(uri, path);
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }

        public static void DownloadFileAsync(Uri uri, string path)
        {
            using (WebClient client = new WebClient())
            {
                client.DownloadFileAsync(uri, path);
            }
        }

        public static bool ConvertBookFb2Epub(string fileName, string outputPath)
        {
            string newFileName = Path.Combine(
                outputPath, 
                Path.GetFileNameWithoutExtension(fileName) + ".epub");

            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("fontfamily", "None");

            List<UploadedFile> files = new List<UploadedFile>();
            files.Add(new UploadedFile()
            {
                FileName = fileName,
                ParamName = "fb2",
                ContentType = "application/octet-stream"
            });

            string responseString = null;
            try
            {
                responseString = HttpHelper.UploadFileViaFormData(
                    url: "http://fb2epub.com/en/convert",
                    files: files,
                    parameters: parameters);
            }
            catch
            {
                return false;
            }

            // wait for some time until book is converted on server
            System.Threading.Thread.Sleep(5000);

            List<LinkItem> links = LinkFinder.Find(responseString);

            // DANGER HERE! Links can be changed in future.
            Uri downloadUri = new Uri("http://fb2epub.com" + links[0].Href + "/download");

            // five attempts to download file.
            bool isDownloaded = false;
            for (int i = 0; i <= 5; i++)
            {
                isDownloaded = TryDownloadFile(downloadUri, newFileName);
                if (isDownloaded) break;
                System.Threading.Thread.Sleep(5000);
            }
            return isDownloaded;
        }

        public static void ConvertBookFb2Epub(string fileName)
        {
            ConvertBookFb2Epub(fileName, Path.GetDirectoryName(fileName));
        }
    }
}
