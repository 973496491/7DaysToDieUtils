
using _7DaysToDieUtils.Const;
using _7DaysToDieUtils.Entity;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace _7DaysToDieUtils.Utils
{
    public class HttpApi
    {
        public static BaseEntity<T> Request<T>(string url, string body, string method = "POST")
        {
            BaseEntity<T> entity;
            var resp = HttpPost(url, body, method);
            if (resp.Equals(""))
            {
                return null;
            }
            entity = JsonConvert.DeserializeObject<BaseEntity<T>>(resp);
            return entity;
        }

        /// <summary>
        /// 调用WEBAPI方法
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="body">参数</param>
        /// <returns></returns>
        public static string HttpPost(string url, string body, string method = "POST")
        {
            try
            {
                Encoding encoding = Encoding.UTF8;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Config.GetBaseUrl() + url);
                request.Method = method;
                request.Accept = "text/html, application/xhtml+xml, */*";
                request.ContentType = "application/json";

                byte[] buffer = encoding.GetBytes(body);
                request.ContentLength = buffer.Length;
                if (method.Equals("POST"))
                {
                    request.GetRequestStream().Write(buffer, 0, buffer.Length);
                }
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    return reader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {

                HttpWebResponse response = (HttpWebResponse)ex.Response;
                if (response != null)
                {
                    Console.WriteLine("Error code: {0}", response.StatusCode);

                    using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default))
                    {
                        string text = reader.ReadToEnd();
                        DialogUtils.ShowErrorDialog(new Exception(text));
                        return "";
                    }
                }
                else
                {
                    DialogUtils.ShowErrorDialog(ex);
                    return "";
                }
            }
        }
    }
}
