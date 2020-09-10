using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.SessionState;

namespace PlatformExcercise.Data
{
    public class ServicesDataRepository
    {

        public static string GetSessionId()
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://test.proplatform.net/services/ips");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{\"header\":" +
                    "{\"method\": \"Login\"," +
                    "\"language\": \"sl-SI\"," +
                    "\"appVersion\": \"5.0.0\"," +
                    "\"sessionId\": null}," +
                    "\"data\":" +
                    "{\"username\": \"test\"," +
                    "\"password\": \"McYE4dpo\"}}";

                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                JObject json = JObject.Parse(result);
                string sessionId = (string)json["data"]["sessionId"];
                return sessionId;
            }

            
        }

        public static JObject GetProducts()
        {

            string sessionId = GetSessionId();
            Debug.WriteLine(sessionId);

            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://test.proplatform.net/services/ips");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{\"header\":" +
                    "{\"method\": \"GetItems\"," +
                    "\"language\": \"sl-SI\"," +
                    "\"appVersion\": \"5.0.0\"," +
                    "\"sessionId\": \""+ sessionId + "\"}," +
                    "\"data\":" +
                    "{\"key\": \"products\",}}";

                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                JObject json = JObject.Parse(result);
                return json;
            }
        }
    }
}