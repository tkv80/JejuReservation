using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using JejuReservation.Entity;

namespace JejuReservation.Manager
{
    internal static class SeogwipoHttpClientManager
    {
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public static IList<Site> GetSites()
        {
            var httpWRequest = (HttpWebRequest) WebRequest.Create("http://huyang3.seogwipo.go.kr/resv/booking/adds/ ");
            httpWRequest.Accept = "text/html, application/xhtml+xml, /*/";
            httpWRequest.Method = "Get";

            var theResponse = (HttpWebResponse) httpWRequest.GetResponse();
            var sr = new StreamReader(theResponse.GetResponseStream());

            string resultHtml = sr.ReadToEnd();


            if (resultHtml.Contains("폭주로")) return null;

            try
            {
                string makeHtml =
                    resultHtml.Substring(resultHtml.IndexOf("<option value='1'    >", StringComparison.Ordinal),
                        resultHtml.IndexOf("</select>",
                            resultHtml.IndexOf("<option value='1'    >", StringComparison.Ordinal),
                            StringComparison.Ordinal) -
                        resultHtml.IndexOf("<option value='1'    >", StringComparison.Ordinal));
                string[] splitData = makeHtml.Split('\n');

                IList<Site> sites = new List<Site>();
                for (int i = 0; i < splitData.Length - 2; i += 2)
                {
                    string data = splitData[i].Replace("<option value='", "");
                    data = data.Replace("option>", "").Trim();

                    string[] splitData2 = data.Split('\'');

                    sites.Add(new Site
                    {
                        SiteNumber = splitData2[0],
                        SiteName = splitData2[1].Trim().Replace(">", "").Replace("</", "")
                    });
                }
                return sites;
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"사이트 죽음");
                return null;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="siteNumber"></param>
        /// <param name="cookie"></param>
        /// <returns></returns>
        public static string AddBooking(string parameter, string siteNumber, string cookie)
        {
            var cookieSplit = cookie.Split('=');

            var httpWRequest = (HttpWebRequest) WebRequest.Create("http://huyang3.seogwipo.go.kr/resv/booking/adds");

            httpWRequest.Host = "huyang3.seogwipo.go.kr";
            httpWRequest.KeepAlive = true;
            httpWRequest.ContentLength = parameter.Length;
            httpWRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            httpWRequest.Headers.Add("Origin", "http://huyang3.seogwipo.go.kr");
            httpWRequest.UserAgent = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.1; WOW64; Trident/6.0)";
            httpWRequest.ContentType = "application/x-www-form-urlencoded";
            httpWRequest.Referer = string.Format("http://huyang3.seogwipo.go.kr/resv/booking/adds/{0}", siteNumber);

            httpWRequest.Headers.Add("Accept-Encoding", "gzip,deflate,sdch");

            httpWRequest.Headers.Add("Accept-Language", "en,en-US;q=0.8,ko;q=0.6");

            httpWRequest.Method = "Post";
            httpWRequest.CookieContainer = new CookieContainer();
            httpWRequest.CookieContainer.Add(new Cookie(cookieSplit[0], cookieSplit[1].Replace("; path", ""), "/",
                "huyang3.seogwipo.go.kr"));

            var sw = new StreamWriter(httpWRequest.GetRequestStream());
            sw.Write(parameter);
            sw.Close();

            var theResponse = (HttpWebResponse) httpWRequest.GetResponse();
            var sr = new StreamReader(theResponse.GetResponseStream());

            return sr.ReadToEnd();
        }

        /// <summary>
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="siteNumber"></param>
        /// <param name="cookie"></param>
        /// <returns></returns>
        public static string Check(string parameter, string siteNumber, string cookie)
        {
            var cookieSplit = cookie.Split('=');

            var httpWRequest =
                (HttpWebRequest) WebRequest.Create("http://huyang3.seogwipo.go.kr/resv/booking/resv_check");
            httpWRequest.Accept = "/*/";
            httpWRequest.Referer = string.Format("http://huyang3.seogwipo.go.kr/resv/booking/adds/{0}", siteNumber);
            httpWRequest.Headers.Add("Accept-Encoding", "gzip, deflate");
            httpWRequest.UserAgent = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.1; WOW64; Trident/6.0)";
            httpWRequest.Host = "huyang3.seogwipo.go.kr";
            httpWRequest.Headers.Add("Accept-Language", "ko-KR");
            httpWRequest.Headers.Add("X-Requested-With", "XMLHttpRequest");
            httpWRequest.Headers.Add("Accept-Encoding", "gzip, deflate");
            httpWRequest.ContentType = "application/x-www-form-urlencoded";
            httpWRequest.KeepAlive = true;
            httpWRequest.Method = "Post";
            httpWRequest.ContentLength = parameter.Length;
            httpWRequest.CookieContainer = new CookieContainer();
            httpWRequest.CookieContainer.Add(new Cookie(cookieSplit[0], cookieSplit[1].Replace("; path", ""), "/",
                "huyang3.seogwipo.go.kr"));

            var sw = new StreamWriter(httpWRequest.GetRequestStream());
            sw.Write(parameter);
            sw.Close();

            var theResponse = (HttpWebResponse) httpWRequest.GetResponse();
            var sr = new StreamReader(theResponse.GetResponseStream());

            return sr.ReadToEnd();
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public static string GetCoockie()
        {
            var httpWRequest = (HttpWebRequest) WebRequest.Create("http://huyang3.seogwipo.go.kr/resv/booking ");
            httpWRequest.Accept = "text/html, application/xhtml+xml, /*/";
            httpWRequest.Method = "Get";

            var theResponse = (HttpWebResponse) httpWRequest.GetResponse();
            var sr = new StreamReader(theResponse.GetResponseStream());
            sr.ReadToEnd();

            return theResponse.Headers.GetValues("Set-Cookie").FirstOrDefault();
        }
    }
}