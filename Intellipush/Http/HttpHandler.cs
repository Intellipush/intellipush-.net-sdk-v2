using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Intellipush.Http
{
    class HttpHandler
    {
        /*
         *  Handles all POST request to the API.
         */
        public static string postToAPIResource(List<KeyValuePair<string, string>> listPostData, string resourceExtention = null)
        {

            HttpWebRequest request;
            if (resourceExtention == null)
            {
                request = (HttpWebRequest)WebRequest.Create(IntellipushConfig.API_URL);
            }
            else
            {
                request = (HttpWebRequest)WebRequest.Create(IntellipushConfig.API_URL + resourceExtention);
            }

            var postData = "";

            if (listPostData != null)
            {
                var firstEntry = true;
                foreach (KeyValuePair<string, string> keyPair in listPostData)
                {
                    if (firstEntry)
                    {
                        postData += keyPair.Key + "=" + keyPair.Value;
                    }
                    else
                    {
                        postData += "&" + keyPair.Key + "=" + keyPair.Value;
                    }
                    firstEntry = false;
                }
            }

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

        public static string postToAPIResourceASD(List<KeyValuePair<string, string>> listPostData, string resourceExtention = null)
        {
            string certPath = @"C:\ip_gd_bundle.crt";
            X509Certificate myCert = X509Certificate.CreateFromCertFile(certPath);

            HttpWebRequest request;
            if (resourceExtention == null)
            {
                request = (HttpWebRequest)WebRequest.Create(IntellipushConfig.API_URL);
            }
            else
            {
                request = (HttpWebRequest)WebRequest.Create(IntellipushConfig.API_URL + resourceExtention);
            }

            request.ClientCertificates.Add(myCert);

            var postData = "";

            if (listPostData != null)
            {
                var firstEntry = true;
                foreach (KeyValuePair<string, string> keyPair in listPostData)
                {
                    if (firstEntry)
                    {
                        postData += keyPair.Key + "=" + keyPair.Value;
                    }
                    else
                    {
                        postData += "&" + keyPair.Key + "=" + keyPair.Value;
                    }
                    firstEntry = false;
                }
            }
            //Debug.WriteLine(postData);

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
