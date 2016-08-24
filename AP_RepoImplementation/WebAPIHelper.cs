using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AP_RepoImplementation
{
    public class WebApiHelper
    {
        private static string baseUrl = "https://ws1.appointment-plus.com/";
        private static string authInfo = "appointplus395/42:0183c59972626a190a39190fd900499ad3664d71";

        //public async Task<string> CallApi()
        public static string CallApi()
        {
            string json = "";
            var url = baseUrl + "Appointments/GetAppointments";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

            httpWebRequest.Method = "GET";
            httpWebRequest.Accept = "application/json";
            httpWebRequest.Headers.Add("Authorization", "Basic " + authInfo);
            HttpWebResponse httpResponse = null;
            try
            {
                //httpResponse = (HttpWebResponse)(await httpWebRequest.GetResponseAsync());
                httpResponse = (HttpWebResponse)(httpWebRequest.GetResponse());
                using (Stream responseStream = httpResponse.GetResponseStream())
                {
                    if (responseStream != null) json = new StreamReader(responseStream).ReadToEnd();
                }
            }
            finally
            {
                if (httpResponse != null) httpResponse.Close();
            }
            return json;
        }

        public static void CallApi1()
        {
            HttpWebRequest restRequest;
            HttpWebResponse restResponse;
            XmlDocument xDoc = new XmlDocument();

            // use the static Create method of the WebRequest object
            // casting the returned WebRequest to an HttpWebRequest
            restRequest = (HttpWebRequest)WebRequest.Create(baseUrl + "Appointments/GetAppointments");


            // use Site ID and API Key as username:password for HTTP
            // Basic Authorization and add Authorization HTTP header
            authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
            restRequest.Headers.Add("Authorization", "Basic " + authInfo);

            // use POST method and set POST vars
            restRequest.Method = WebRequestMethods.Http.Post;
            restRequest.ContentType = "application/x-www-form-urlencoded";
            string postData = "response_type=json&start_date=20150823&end_date=20150825";
            restRequest.ContentLength = postData.Length;
            StreamWriter postStream = new StreamWriter(restRequest.GetRequestStream());
            postStream.Write(postData);
            postStream.Close();
            // use the GetResponse method to obtain a WebResponse object
            // for the request casting to an HttpWebResponse
            restResponse = (HttpWebResponse)restRequest.GetResponse();

            // since we are expecting XML back, we can load the
            // XML document directly from the GetResponseStream()
            // method of the HttpWebResponse
            if (restResponse.GetResponseStream() != null)
            {
                xDoc.Load(restResponse.GetResponseStream());
            }

        }
    }
}
