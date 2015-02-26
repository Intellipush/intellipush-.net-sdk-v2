using Intellipush.Http;
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
    [KnownType(typeof(Sms))]
    public class Batch : BaseJSONObject
    {

        [DataMember(Name = "batch", EmitDefaultValue = false)]
        private List<Notification> listNotifications;

        public Batch()
        {
            listNotifications = new List<Notification>();
        }

        public void addNotification(Sms sms)
        {
            if (sms.getReceivers() != null && sms.getReceivers().Count > 0)
            { 
                // If sms contains multiple receivers. 
                foreach (PhoneNumber phoneNumber in sms.getReceivers())
                {
                    // Duplicate and modify receiver
                    Sms s = sms;
                    s.AreaCode = phoneNumber.Area;
                    s.PhoneNumber = phoneNumber.Phone;
                    listNotifications.Add(s);
                }
            } else {
                listNotifications.Add(sms);
            }
            
        }

        public string Create()
        {
            List<KeyValuePair<string, string>> values = IntellipushConfig.getDefaultKeyValuePair();

            string newData = Security.EncryptRJ256(this.ToJSON(), IntellipushConfig.API_SECRET, IntellipushConfig.API_SECRET);

            values.Add(new KeyValuePair<string, string>("enc_request", newData));
            return HttpHandler.postToAPIResource(values, IntellipushConfig.Notification.CreateBatch);
        }

    }
}
