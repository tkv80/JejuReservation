using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using JejuReservation.Entity;

namespace JejuReservation.Manager
{
    public static class JeolmulHttpClientManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="cookie"></param>
        /// <returns></returns>
        public static IList<Site> GetSites(string parameter, string cookie)
        {
            try
            {
                /*

                var cookieSplit = cookie.Split('=');

                HttpWebRequest httpWRequest =
                    (HttpWebRequest)
                        WebRequest.Create("http://jeolmul.jejusi.go.kr/include/reservation/res_03_list.asp");
                httpWRequest.Method = "Post";
                httpWRequest.UserAgent =
                    "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/35.0.1916.114 Safari/537.36";
                httpWRequest.ContentLength = parameter.Length;
                httpWRequest.ContentType = "application/x-www-form-urlencoded";
                httpWRequest.Host = "jeolmul.jejusi.go.kr";
                httpWRequest.Referer = "http://jeolmul.jejusi.go.kr/reservation.asp?location=003";
                httpWRequest.Headers.Add("Origin", "http://jeolmul.jejusi.go.kr");
                httpWRequest.CookieContainer = new CookieContainer();
                httpWRequest.CookieContainer.Add(new Cookie(cookieSplit[0], cookieSplit[1].Replace("; path", ""), "/",
                    "jeolmul.jejusi.go.kr"));

                var sw = new StreamWriter(httpWRequest.GetRequestStream());
                sw.Write(parameter);
                sw.Close();

                var theResponse = (HttpWebResponse) httpWRequest.GetResponse();
                var sr = new StreamReader(theResponse.GetResponseStream(), Encoding.GetEncoding("euc-kr"));

                var resultHtml = sr.ReadToEnd();
                var makeHtml = resultHtml.Substring(resultHtml.IndexOf("<table"),
                    resultHtml.IndexOf("</table>", resultHtml.IndexOf("<table")) - resultHtml.IndexOf("<table"));
                var splitData = makeHtml.Split('\n');

                */
                IList<Site> sites = new List<Site>();
                // <td width="150" class="line">
                /*
                var i = 1;
                foreach (var data in splitData)
                {
                    if (i == 18)
                    {
                        break;
                    }

                    if (data.Contains("<td width=\"150\" class=\"line\">"))
                    {
                        sites.Add(new Site()
                        {
                            SiteName = data.Replace("<td width=\"150\" class=\"line\">","").Replace("</td>","").Trim(),
                            SiteNumber = i.ToString("300"),
                        });
                        i++;
                    }
                }
                */

                sites.Add(new Site {SiteName = "다래실 4명", SiteNumber = "301",});
                sites.Add(new Site {SiteName = "머루실 4명", SiteNumber = "302",});
                sites.Add(new Site {SiteName = "산딸기실 4명", SiteNumber = "303",});
                sites.Add(new Site {SiteName = "오미자실 4명", SiteNumber = "304",});
                sites.Add(new Site {SiteName = "금낭화실 4명", SiteNumber = "305",});

                sites.Add(new Site {SiteName = "국화실 6명", SiteNumber = "306",});
                sites.Add(new Site {SiteName = "둥굴레실 6명", SiteNumber = "307",});
                sites.Add(new Site {SiteName = "춘란실  6명", SiteNumber = "308",});
                sites.Add(new Site {SiteName = "왕벚나무실2층 6명", SiteNumber = "309",});
                sites.Add(new Site {SiteName = "수선화실 6명", SiteNumber = "310",});
                sites.Add(new Site {SiteName = "새우란실 6명", SiteNumber = "331",});
                sites.Add(new Site {SiteName = "산수국실 6명", SiteNumber = "332",});
                sites.Add(new Site {SiteName = "복수초실 6명", SiteNumber = "333",});
                sites.Add(new Site {SiteName = "바람꽃실 6명", SiteNumber = "334",});
                sites.Add(new Site {SiteName = "제비꽃실 6명", SiteNumber = "335",});

                //sites.Add(new Site() { SiteName = "구상나무실 8명", SiteNumber = "311", });
                //sites.Add(new Site() { SiteName = "삼나무실 8명", SiteNumber = "312", });
                //sites.Add(new Site() { SiteName = "소나무실 8명", SiteNumber = "313", });
                //sites.Add(new Site() { SiteName = "벚나무실 8명", SiteNumber = "314", });


                return sites;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="cookie"></param>
        /// <returns></returns>
        public static string AddBooking(string parameter, string cookie)
        {
            var cookieSplit = cookie.Split('=');

            var httpWRequest =
                (HttpWebRequest) WebRequest.Create("http://jeolmul.jejusi.go.kr/reservation.asp?location=002_03");

            httpWRequest.Host = "jeolmul.jejusi.go.kr";
            httpWRequest.KeepAlive = true;
            httpWRequest.ContentLength = parameter.Length;
            httpWRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            httpWRequest.Headers.Add("Origin", "http://jeolmul.jejusi.go.kr");
            httpWRequest.UserAgent = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.1; WOW64; Trident/6.0)";
            httpWRequest.ContentType = "application/x-www-form-urlencoded";
            httpWRequest.Referer = "http://jeolmul.jejusi.go.kr/reservation.asp?location=002_02";

            httpWRequest.Headers.Add("Accept-Encoding", "gzip,deflate,sdch");

            httpWRequest.Headers.Add("Accept-Language", "en,en-US;q=0.8,ko;q=0.6");

            httpWRequest.Method = "Post";
            httpWRequest.CookieContainer = new CookieContainer();
            httpWRequest.CookieContainer.Add(new Cookie(cookieSplit[0], cookieSplit[1].Replace("; path", ""), "/",
                "jeolmul.jejusi.go.kr"));

            var sw = new StreamWriter(httpWRequest.GetRequestStream());
            sw.Write(parameter);
            sw.Close();

            var theResponse = (HttpWebResponse) httpWRequest.GetResponse();
            var sr = new StreamReader(theResponse.GetResponseStream(), Encoding.GetEncoding("euc-kr"));

            return sr.ReadToEnd();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="siteNumber"></param>
        /// <param name="cookie"></param>
        /// <returns></returns>
        public static string Check(string parameter, string siteNumber, string cookie)
        {
            try
            {
                string[] cookieSplit = cookie.Split('=');

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
            catch (Exception ex)
            {
                throw;
            }
            //
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetCoockie()
        {
            var httpWRequest = (HttpWebRequest) WebRequest.Create("http://jeolmul.jejusi.go.kr/");
            httpWRequest.Accept = "text/html, application/xhtml+xml, /*/";
            httpWRequest.UserAgent =
                "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/35.0.1916.114 Safari/537.36";
            httpWRequest.Method = "Get";

            var theResponse = (HttpWebResponse) httpWRequest.GetResponse();
            var sr = new StreamReader(theResponse.GetResponseStream());
            string resultHtml = sr.ReadToEnd();

            return theResponse.Headers.GetValues("Set-Cookie").FirstOrDefault();
        }
    }
}