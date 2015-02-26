using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Intellipush.Notifications
{
    class Response
    {
        private bool success;
        private string status_message;
        private JObject jo;

        public Response(string jsonString)
        {
            jo = JObject.Parse(jsonString);
            success = (bool)jo.GetValue("success");
            status_message = (string)jo.GetValue("status_message");
        }

        public Sms getResponseAsSms()
        {
            return new Sms(jo["data"].Value<JObject>());
        }

        public Contact getResponseAsContact()
        {
            return new Contact(jo["data"].Value<JObject>());
        }

        public ContactList getResponseAsContactList()
        {
            return new ContactList(jo["data"].Value<JObject>());
        }

        public string StatusMessage
        {
            get
            {
                return this.status_message;
            }
        }

        public bool Success
        {
            get
            {
                return this.success;
            }
        }

    }
}
