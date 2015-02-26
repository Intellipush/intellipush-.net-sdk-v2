using Intellipush.Http;
using Intellipush.Notifications;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Intellipush
{
    [DataContract]
    public class User : BaseJSONObject
    {

        //[DataMember(Name = "api_secret", EmitDefaultValue = false)]
        //private string api_secret = IntellipushConfig.API_SECRET;

        public User()
        {

        }

        //public string ToJSON()
        //{
        //    string jsonString = "";
        //    MemoryStream ms = new MemoryStream();
        //    DataContractJsonSerializer ser = new DataContractJsonSerializer(this.GetType());
        //    ser.WriteObject(ms, this);

        //    ms.Position = 0;
        //    StreamReader sr = new StreamReader(ms);

        //    jsonString = sr.ReadToEnd().ToString();

        //    sr.Close();
        //    ms.Close();

        //    return jsonString;
        //}

        public string GetAccount()
        {
            List<KeyValuePair<string, string>> values = IntellipushConfig.getDefaultKeyValuePair();

            string newData = Security.EncryptRJ256(this.ToJSON(), IntellipushConfig.API_SECRET, IntellipushConfig.API_SECRET);

            values.Add(new KeyValuePair<string, string>("enc_request", newData));
            return HttpHandler.postToAPIResource(values, IntellipushConfig.User.Get);
        }


    }
}
