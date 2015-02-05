using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace smslib
{
    public class SMSClient
    {

        private string customerKey = "";
        private string applicationKey = "";

        // Settings

        private const string API_URL = "http://192.168.1.138";

        public SMSClient(string customerKey, string applicationKey)
        {
            this.customerKey = customerKey;
            this.applicationKey = applicationKey;
        }

        public string postToUrl()
        {
            var request = (HttpWebRequest)WebRequest.Create(API_URL);

            var list = new List<KeyValuePair<string, string>>();


            list.Add(new KeyValuePair<string,string>("asd", "asd"));

            var postData = "thing1=hello";
            postData += "&thing2=world";
            var data = Encoding.ASCII.GetBytes(postData);

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return responseString;
        }


    }
}
