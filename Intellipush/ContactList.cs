using Newtonsoft.Json.Linq;
using Intellipush.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Intellipush.Notifications;

namespace Intellipush
{
    [DataContract]
    public class ContactList : BaseJSONObject
    {

        [DataMember(Name = "contactlist_id", EmitDefaultValue = false)]
        private int contactlist_id;

        [DataMember(Name = "contactlist_name", EmitDefaultValue = false)]
        private string contactlist_name;

        [DataMember(Name = "page", EmitDefaultValue = false)]
        private int page;

        [DataMember(Name = "items", EmitDefaultValue = false)]
        private int items;

        [DataMember(Name = "query", EmitDefaultValue = false)]
        private string query;

        [DataMember(Name = "amount", EmitDefaultValue = false)]
        private bool amount;

        [DataMember(Name = "contactlist_filter", EmitDefaultValue = false)]
        private Filter contactlist_filter;

        [DataMember(Name = "contact_id", EmitDefaultValue = false)]
        private int contact_id;


        public ContactList()
        {

        }

        public ContactList(int id)
        {
            this.Id = id;
        }

        public ContactList(string name)
        {
            this.Name = name;
        }

        public ContactList(JObject jo)
        {
            /* Build a contact from JSON */
            contactlist_id = (int)jo.GetValue("id");
            contactlist_name = (string)jo.GetValue("contactlist_name");
            page = (int)jo.GetValue("page");
            items = (int)jo.GetValue("items");
            query = (string)jo.GetValue("query");
            amount = (bool)jo.GetValue("amount");
        }

        public int Id
        {
            get { return this.contactlist_id; }
            set { this.contactlist_id = value; }
        }
        public string Name
        {
            get { return this.contactlist_name; }
            set { this.contactlist_name = value; }
        }
        public int Page
        {
            get { return this.page; }
            set { this.page = value; }
        }
        public int Items
        {
            get { return this.items; }
            set { this.items = value; }
        }
        public string Query
        {
            get { return this.query; }
            set { this.query = value; }
        }
        public bool Amount
        {
            get { return this.amount; }
            set { this.amount = value; }
        }
        public Filter Filter
        {
            get { return this.contactlist_filter; }
            set { this.contactlist_filter = value; }
        }
        public int ContactId
        {
            get { return this.contact_id; }
            set { this.contact_id = value; }
        }



        public string Create()
        {
            if (this.Name == null || this.Name.Equals(""))
            {
                throw new Exception("No name provided.");
            }

            List<KeyValuePair<string, string>> values = IntellipushConfig.getDefaultKeyValuePair();

            string newData = Security.EncryptRJ256(this.ToJSON(), IntellipushConfig.API_SECRET, IntellipushConfig.API_SECRET);

            values.Add(new KeyValuePair<string, string>("enc_request", newData));
            return HttpHandler.postToAPIResource(values, IntellipushConfig.ContactList.Create);
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
            return HttpHandler.postToAPIResource(values, IntellipushConfig.ContactList.Update);
        }

        public string GetContactList(int id = -1)
        {
            if (id > 0)
            {
                this.Id = id;
            }

            if (this.Id <= 0)
            {
                throw new Exception("No id provided.");
            }

            List<KeyValuePair<string, string>> values = IntellipushConfig.getDefaultKeyValuePair();

            string newData = Security.EncryptRJ256(this.ToJSON(), IntellipushConfig.API_SECRET, IntellipushConfig.API_SECRET);

            values.Add(new KeyValuePair<string, string>("enc_request", newData));
            return HttpHandler.postToAPIResource(values, IntellipushConfig.ContactList.GetContactlist);
        }

        public string GetContactsInList(int id = -1)
        {
            if (id > 0)
            {
                this.Id = id;
            }

            if (this.Id <= 0)
            {
                throw new Exception("No id provided.");
            }

            List<KeyValuePair<string, string>> values = IntellipushConfig.getDefaultKeyValuePair();

            string newData = Security.EncryptRJ256(this.ToJSON(), IntellipushConfig.API_SECRET, IntellipushConfig.API_SECRET);

            values.Add(new KeyValuePair<string, string>("enc_request", newData));
            return HttpHandler.postToAPIResource(values, IntellipushConfig.ContactList.GetContacts);
        }

        public string GetContactsAmountInList(int id = -1)
        {
            if (id > 0)
            {
                this.Id = id;
            }

            if (this.Id <= 0)
            {
                throw new Exception("No id provided.");
            }

            List<KeyValuePair<string, string>> values = IntellipushConfig.getDefaultKeyValuePair();

            string newData = Security.EncryptRJ256(this.ToJSON(), IntellipushConfig.API_SECRET, IntellipushConfig.API_SECRET);

            values.Add(new KeyValuePair<string, string>("enc_request", newData));
            return HttpHandler.postToAPIResource(values, IntellipushConfig.ContactList.GetContactsAmount);
        }

        public string GetContactsNotInAList()
        {

            List<KeyValuePair<string, string>> values = IntellipushConfig.getDefaultKeyValuePair();

            string newData = Security.EncryptRJ256(this.ToJSON(), IntellipushConfig.API_SECRET, IntellipushConfig.API_SECRET);

            values.Add(new KeyValuePair<string, string>("enc_request", newData));
            return HttpHandler.postToAPIResource(values, IntellipushConfig.ContactList.GetContactsNotIn);
        }

        public string AddContact(int contact_id)
        {
            if (contact_id > 0)
            {
                this.ContactId = contact_id;
            }

            if (this.ContactId <= 0)
            {
                throw new Exception("No id provided.");
            }

            List<KeyValuePair<string, string>> values = IntellipushConfig.getDefaultKeyValuePair();

            string newData = Security.EncryptRJ256(this.ToJSON(), IntellipushConfig.API_SECRET, IntellipushConfig.API_SECRET);

            values.Add(new KeyValuePair<string, string>("enc_request", newData));
            return HttpHandler.postToAPIResource(values, IntellipushConfig.ContactList.AddContact);
        }

        public string RemoveContact(int contact_id)
        {
            if (contact_id > 0)
            {
                this.ContactId = contact_id;
            }

            if (this.ContactId <= 0)
            {
                throw new Exception("No id provided.");
            }

            List<KeyValuePair<string, string>> values = IntellipushConfig.getDefaultKeyValuePair();

            string newData = Security.EncryptRJ256(this.ToJSON(), IntellipushConfig.API_SECRET, IntellipushConfig.API_SECRET);

            values.Add(new KeyValuePair<string, string>("enc_request", newData));
            return HttpHandler.postToAPIResource(values, IntellipushConfig.ContactList.RemoveContact);
        }

        public string Delete(int id = -1)
        {
            if (id > 0)
            {
                this.Id = id;
            }

            if (this.Id <= 0)
            {
                throw new Exception("No id provided.");
            }

            List<KeyValuePair<string, string>> values = IntellipushConfig.getDefaultKeyValuePair();

            string newData = Security.EncryptRJ256(this.ToJSON(), IntellipushConfig.API_SECRET, IntellipushConfig.API_SECRET);

            values.Add(new KeyValuePair<string, string>("enc_request", newData));
            return HttpHandler.postToAPIResource(values, IntellipushConfig.ContactList.Delete);
        }


    }
}
