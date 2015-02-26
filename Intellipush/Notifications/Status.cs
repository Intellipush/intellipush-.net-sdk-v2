using Intellipush.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Intellipush.Notifications
{
    [DataContract]
    public class Status : BaseJSONObject
    {

        [DataMember(Name = "notification_id_array", EmitDefaultValue = false)]
        private int notification_id;

        public Status(int id)
        {
            this.notification_id = id;
        }

        public int Id
        {
            get
            {
                return this.notification_id;
            }
            set
            {
                this.notification_id = value;
            }
        }

        public string GetStatus() {
            List<KeyValuePair<string, string>> values = IntellipushConfig.getDefaultKeyValuePair();

            string newData = Security.EncryptRJ256(this.ToJSON(), IntellipushConfig.API_SECRET, IntellipushConfig.API_SECRET);

            values.Add(new KeyValuePair<string, string>("enc_request", newData));
            return HttpHandler.postToAPIResource(values, IntellipushConfig.Notification.Status);
        }



    }
}
