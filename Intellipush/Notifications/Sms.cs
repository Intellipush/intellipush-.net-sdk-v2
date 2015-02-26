using Newtonsoft.Json.Linq;
using Intellipush.Http;
using Intellipush.Notifications;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Intellipush.Notifications
{
    [DataContract]
    public class Sms : Notification
    {
        private Batch batch;
        private List<PhoneNumber> phoneNumbers;

        public Sms()
        {
            // Create a empty sms object.
            this.Method = "sms";
        }

        public Sms(int id)
        {
            this.Id = id;
            this.Method = "sms";
        }

        public Sms(string message, PhoneNumber phoneNumber)
        {
            this.TextMessage = message;
            this.AreaCode = phoneNumber.Area;
            this.PhoneNumber = phoneNumber.Phone;
            this.Method = "sms";
            this.When("now");
        }

        public Sms(string message, List<PhoneNumber> phoneNumbers)
        {
            batch = new Batch();
            foreach (var phoneNumber in phoneNumbers)
            {
                batch.addNotification(new Sms(message, phoneNumber));
            }
        }

        public Sms(JObject jo)
        {
            throw new System.NotImplementedException("Method is not implemented.");
        }

        public void Receivers(List<PhoneNumber> phoneNumbers)
        {
            this.phoneNumbers = phoneNumbers;
        }

        public void Receiver(PhoneNumber phoneNumber)
        {
            this.AreaCode = phoneNumber.Area;
            this.PhoneNumber = phoneNumber.Phone;
        }

        public List<PhoneNumber> getReceivers()
        {
            return this.phoneNumbers;
        }

        public string Create()
        {
            this.Method = "sms";

            if (this.Date == null || this.Time == null)
            {
                this.When("now");
            }

            if (batch != null || (phoneNumbers != null && phoneNumbers.Count > 0))
            {
                batch = new Batch();
                foreach (var phoneNumber in phoneNumbers)
                {
                    // Duplicate it self and modify receiver
                    Sms sms = (Sms)this.MemberwiseClone();
                    sms.Receivers(null); // Stop duplications
                    sms.AreaCode = phoneNumber.Area;
                    sms.PhoneNumber = phoneNumber.Phone;
                    batch.addNotification(sms);
                }

                // A batch is created when list of numbers is provided.
                return batch.Create();
            }

            List<KeyValuePair<string, string>> values = IntellipushConfig.getDefaultKeyValuePair();

            string newData = Security.EncryptRJ256(this.ToJSON(), IntellipushConfig.API_SECRET, IntellipushConfig.API_SECRET);

            values.Add(new KeyValuePair<string, string>("enc_request", newData));
            return HttpHandler.postToAPIResource(values, IntellipushConfig.Notification.Create);
        }

        public string Delete()
        {
            if (this.Id <= 0)
            {
                throw new Exception("No id provided.");
            }

            List<KeyValuePair<string, string>> values = IntellipushConfig.getDefaultKeyValuePair();

            string newData = Security.EncryptRJ256(this.ToJSON(), IntellipushConfig.API_SECRET, IntellipushConfig.API_SECRET);

            values.Add(new KeyValuePair<string, string>("enc_request", newData));
            return HttpHandler.postToAPIResource(values, IntellipushConfig.Notification.Delete);
        }

        public string Get()
        {
            if (this.Id <= 0)
            {
                throw new Exception("No id provided.");
            }

            List<KeyValuePair<string, string>> values = IntellipushConfig.getDefaultKeyValuePair();

            string newData = Security.EncryptRJ256(this.ToJSON(), IntellipushConfig.API_SECRET, IntellipushConfig.API_SECRET);

            values.Add(new KeyValuePair<string, string>("enc_request", newData));
            return HttpHandler.postToAPIResource(values, IntellipushConfig.Notification.Get);
        }

        public string Update()
        {
            if (this.Id <= 0)
            {
                throw new Exception("No id provided.");
            }

            List<KeyValuePair<string, string>> values = IntellipushConfig.getDefaultKeyValuePair();

            string newData = Security.EncryptRJ256(this.ToJSON(), IntellipushConfig.API_SECRET, IntellipushConfig.API_SECRET);

            values.Add(new KeyValuePair<string, string>("enc_request", newData));
            return HttpHandler.postToAPIResource(values, IntellipushConfig.Notification.Update);
        }

        public string GetUnsendt()
        {

            List<KeyValuePair<string, string>> values = IntellipushConfig.getDefaultKeyValuePair();

            string newData = Security.EncryptRJ256(this.ToJSON(), IntellipushConfig.API_SECRET, IntellipushConfig.API_SECRET);

            values.Add(new KeyValuePair<string, string>("enc_request", newData));
            return HttpHandler.postToAPIResource(values, IntellipushConfig.Notification.GetUnsent);
        }

        public string GetSendt()
        {

            List<KeyValuePair<string, string>> values = IntellipushConfig.getDefaultKeyValuePair();

            string newData = Security.EncryptRJ256(this.ToJSON(), IntellipushConfig.API_SECRET, IntellipushConfig.API_SECRET);

            values.Add(new KeyValuePair<string, string>("enc_request", newData));
            return HttpHandler.postToAPIResource(values, IntellipushConfig.Notification.GetSent);
        }

    }
}
