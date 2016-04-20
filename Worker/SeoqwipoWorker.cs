using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Web;
using JejuReservation.Entity;
using JejuReservation.Manager;
using Newtonsoft.Json.Linq;

namespace JejuReservation.Worker
{
    internal class SeoqwipoWorker : BackgroundWorker
    {
        public Booking Booking = new Booking();
        public bool IsSuccess;

        public SeoqwipoWorker()
        {
            WorkerReportsProgress = true;
            WorkerSupportsCancellation = true;
        }

        public IList<Site> Sites { private get; set; }

        public int Interval { private get; set; }

        protected override void OnDoWork(DoWorkEventArgs e)
        {
            while (!CancellationPending)
            {
                try
                {
                    string cookie = SeogwipoHttpClientManager.GetCoockie();

                    string message = "";

                    foreach (Site site in Sites)
                    {
                        try
                        {
                            if (CancellationPending)
                            {
                                CancelAsync();
                                break;
                            }

                            //var paramerter = string.Format("fidx={0}&startdate=2014-05-30&enddate=2014-05-31&s_index=&discount=false","");
                            string paramerter =
                                string.Format("fidx={0}&startdate={1}&enddate={2}&s_index=&discount=false",
                                    site.SiteNumber,
                                    Booking.StartDate.ToString("yyyy-MM-dd"),
                                    Booking.EndDate.ToString("yyyy-MM-dd")
                                    );

                            string response = SeogwipoHttpClientManager.Check(paramerter, site.SiteNumber, cookie);

                            if (response.Contains("r_state\":1"))
                            {
                                JObject jObject = JObject.Parse(response);
                                var price = jObject["tot_price"].Value<string>();
                                var info = jObject["info"].Value<string>();
                                //mode=write&send=1&slt_resv=20&txt_start=2014-06-20&txt_end=2014-06-21&txt_name=김태권&txt_add=서울 강북구 송천동&txt_tel=010&txt_tel1=8226&txt_tel2=7979&txt_email=&txt_man=4&txt_bankname=&txt_bank=&txt_bankcode=&txt_price=107000&txt_info=2014년06월20일~2014년06월21일(1박2일)<br/>06월20일(금요일/주말):107000원<br/> 합계:107000원<br/>&submit=확인
                                //"mode=write&send=1&slt_resv=7&txt_start=2014-05-30&txt_end=2014-05-31&txt_name=%EA%B9%80%ED%83%9C%EA%B6%8C&txt_add=%EC%84%9C%EC%9A%B8%EC%8B%9C+%EA%B0%95%EB%B6%81%EA%B5%AC+%EC%86%A1%EC%B2%9C%EB%8F%99+%EB%AF%B8%EC%95%84%EB%8F%99%EB%B6%80+%EC%84%BC%ED%8A%B8%EB%A0%88%EB%B9%8C+104-1404&txt_tel=010&txt_tel1=8226&txt_tel2=7979&txt_email=tkv80@naver.com&txt_man=4&txt_bankname=%EA%B9%80%ED%83%9C%EA%B6%8C&txt_bank=%EA%B8%B0%EC%97%85%EC%9D%80%ED%96%89&txt_bankcode=550-002841-02-015&txt_price=120000&txt_info=2014%EB%85%8405%EC%9B%9430%EC%9D%BC%7E2014%EB%85%8405%EC%9B%9431%EC%9D%BC%281%EB%B0%952%EC%9D%BC%29%3Cbr%2F%3E05%EC%9B%9430%EC%9D%BC%28%EA%B8%88%EC%9A%94%EC%9D%BC%2F%EC%A3%BC%EB%A7%90%29%3A120000%EC%9B%90%3Cbr%2F%3E+%ED%95%A9%EA%B3%84%3A120000%EC%9B%90%3Cbr%2F%3E&submit=%ED%99%95%EC%9D%B8";
                                string[] tel = Booking.Tel.Split('-');
                                string paramter =
                                    string.Format(
                                        "mode=write&send=1&slt_resv={0}&txt_start={1}&txt_end={2}&txt_name={3}&txt_add={4}&txt_tel={5}&txt_tel1={6}&txt_tel2={7}&txt_email=&txt_man={8}&txt_bankname=&txt_bank=&txt_bankcode=&txt_price={9}&txt_info={10}&submit={11}",
                                        site.SiteNumber,
                                        Booking.StartDate.ToString("yyyy-MM-dd"),
                                        Booking.EndDate.ToString("yyyy-MM-dd"),
                                        HttpUtility.UrlEncode(Booking.Name),
                                        HttpUtility.UrlEncode(Booking.Address),
                                        tel[0],
                                        tel[1],
                                        tel[2],
                                        Booking.People,
                                        price,
                                        HttpUtility.UrlEncode(info),
                                        HttpUtility.UrlEncode("확인")
                                        );
                                response = SeogwipoHttpClientManager.AddBooking(paramter, site.SiteNumber, cookie);

                                if (response.Contains("예약접수되었습니다."))
                                {
                                    message = string.Format("{1}일 {2}사이트 {3} - {0}\r\n",
                                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                        Booking.StartDate,
                                        site.SiteName,
                                        "서귀포휴양림"
                                        );
                                    IsSuccess = true;

                                    new GcmManager().SendNotification(message, "캠핑예약");

                                    CancelAsync();
                                }
                            }
                            else
                            {
                                message = string.Format("{0} - 실패 {1}\r\n", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                    site.SiteName);
                            }
                        }
                        catch (WebException webExcp)
                        {
                            var sr = new StreamReader(webExcp.Response.GetResponseStream(),
                                Encoding.GetEncoding("euc-kr"));
                            message = string.Format("{0} - 에러 {1} {2}\r\n", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                site.SiteName, sr.ReadToEnd());
                        }
                        catch (Exception ex)
                        {
                            message = string.Format("{0} - 에러 {1} {2}\r\n", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                site.SiteName, ex.Message);
                        }

                        ReportProgress(0, message);

                        Thread.Sleep(300);
                    }

                    Thread.Sleep(Interval*1000);
                }
                catch (Exception ex)
                {
                    ReportProgress(0, ex.Message);
                }
            }
        }
    }
}