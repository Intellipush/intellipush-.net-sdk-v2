using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Intellipush.Notifications
{
    [DataContract]
    public abstract class BaseJSONObject
    {

        [DataMember(Name = "api_secret", EmitDefaultValue = false)]
        private string api_secret = IntellipushConfig.API_SECRET;


        public string ToJSON()
        {
            StringBuilder jsonString = new StringBuilder();
            MemoryStream ms = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(this.GetType()); // Try to identify 
            ser.WriteObject(ms, this);

            ms.Position = 0;
            StreamReader sr = new StreamReader(ms);

            jsonString.Append(sr.ReadToEnd().ToString());

            sr.Close();
            ms.Close();

            return jsonString.ToString();
        }
    }
}
