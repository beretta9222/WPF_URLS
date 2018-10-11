using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Wpf_Urls.Model
{
    /// <summary>
    /// Class for view result
    /// </summary>
    public class DataClass
    {
        /// <summary>
        /// URL
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Count urls in current url
        /// </summary>
        public int UrlsCount { get; set; }
        /// <summary>
        /// Count urls in current url
        /// </summary>
        public int Avg { get; set; }
        /// <summary>
        /// Calculate counts urls in current url
        /// </summary>
        /// <param name="urls">array urls</param>
        /// <param name="list">output data for view</param>
        public static void getUrlsCount(string[] urls, ref List<DataClass> list)
        {
            try
            {
                List<DataClass> data = new List<DataClass>();
                Parallel.ForEach(urls, x =>
                 {
                     string res = GetCode(x);
                     int count = new Regex("<a ").Matches(res).Count;
                     data.Add(new DataClass() { Name = x, UrlsCount = count });
                 });
                list = data;
            }
            catch (Exception ex)
            {
                Log.WriteLod(ex.StackTrace);
            }
        }

        /// <summary>
        /// get code
        /// </summary>
        /// <param name="urlAddress">url of page</param>
        /// <returns>code of page</returns>
        private static string GetCode(string urlAddress)
        {
            string data = "";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    using (Stream receiveStream = response.GetResponseStream())
                    using (StreamReader readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet)))
                    {
                        data = readStream.ReadToEnd();
                        response.Close();
                        readStream.Close();
                    }
                }
                return data;
            }
            catch (Exception ex)
            {
                Log.WriteLod(ex.StackTrace);
                return "";
            }
        }
    }
}
