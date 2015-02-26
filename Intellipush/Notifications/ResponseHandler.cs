using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Intellipush.Notifications
{
    class ResponseHandler
    {

        public static Response GetSMSResponse(string jsonResponse) {
            MemoryStream ms = new MemoryStream(System.Text.ASCIIEncoding.ASCII.GetBytes(jsonResponse));
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Response));

            return (Response)ser.ReadObject(ms);
        }

    }
}
