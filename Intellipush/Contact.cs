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
    public class Contact : BaseJSONObject
    {

        [DataMember(Name = "contact_id", EmitDefaultValue = false)]
        private int contact_id;

        [DataMember(Name = "name", EmitDefaultValue = false)]
        private string name;

        [DataMember(Name = "company", EmitDefaultValue = false)]
        private string company;

        [DataMember(Name = "dob", EmitDefaultValue = false)]
        private string dob;

        [DataMember(Name = "sex", EmitDefaultValue = false)]
        private string sex;

        [DataMember(Name = "zipcode", EmitDefaultValue = false)]
        private string zipcode;

        [DataMember(Name = "country", EmitDefaultValue = false)]
        private string country;

        [DataMember(Name = "phonenumber", EmitDefaultValue = false)]
        private string phonenumber;

        [DataMember(Name = "countrycode", EmitDefaultValue = false)]
        private string countrycode;

        [DataMember(Name = "email", EmitDefaultValue = false)]
        private string email;

        [DataMember(Name = "facebook", EmitDefaultValue = false)]
        private string facebook;

        [DataMember(Name = "twitter", EmitDefaultValue = false)]
        private string twitter;

        [DataMember(Name = "param1", EmitDefaultValue = false)]
        private string param1;

        [DataMember(Name = "param2", EmitDefaultValue = false)]
        private string param2;

        [DataMember(Name = "param3", EmitDefaultValue = false)]
        private string param3;

        [DataMember(Name = "contactFilter", EmitDefaultValue = false)]
        private Filter filter;

        // Vars for pagination
        [DataMember(Name = "items", EmitDefaultValue = false)]
        private int items;

        [DataMember(Name = "page", EmitDefaultValue = false)]
        private int page;

        [DataMember(Name = "query", EmitDefaultValue = false)]
        private string query;


        public Contact()
        {
            // Empty object.
        }

        public Contact(int id)
        {
            this.Id = id;
        }

        public Contact(string name)
        {
            this.name = name;
        }

        public Contact(string name, string countrycode, string phonenumber)
        {
            this.name = name;
            this.countrycode = countrycode;
            this.phonenumber = phonenumber;
        }

        public Contact(string name, string countrycode, string phonenumber, string email)
        {
            this.name = name;
            this.countrycode = countrycode;
            this.phonenumber = phonenumber;
            this.email = email;
        }

        public Contact(JObject jo)
        {
            /* Build a contact from JSON */
            contact_id = (int)jo.GetValue("id");
            name = (string)jo.GetValue("name");
            dob = (string)jo.GetValue("dob");
            sex = (string)jo.GetValue("sex");
            company = (string)jo.GetValue("company");
            zipcode = (string)jo.GetValue("zipcode");
            country = (string)jo.GetValue("country");
            countrycode = (string)jo.GetValue("countrycode");
            phonenumber = (string)jo.GetValue("phonenumber");
            email = (string)jo.GetValue("email");
            facebook = (string)jo.GetValue("facebook");
            twitter = (string)jo.GetValue("twitter");
            param1 = (string)jo.GetValue("param1");
            param2 = (string)jo.GetValue("param2");
            param3 = (string)jo.GetValue("param3");
        }

        public int Id
        {
            get { return this.contact_id; }
            set { this.contact_id = value; }
        }
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public string Dob
        {
            get { return this.dob; }
            set { this.dob = value; }
        }
        public string Sex
        {
            get { return this.sex; }
            set { this.sex = value; }
        }
        public string ZipCode
        {
            get { return this.zipcode; }
            set { this.zipcode = value; }
        }
        public string Country
        {
            get { return this.country; }
            set { this.country = value; }
        }
        public string Company
        {
            get { return this.company; }
            set { this.company = value; }
        }
        public string CountryCode
        {
            get { return this.countrycode; }
            set { this.countrycode = value; }
        }
        public string PhoneNumber
        {
            get { return this.phonenumber; }
            set { this.phonenumber = value; }
        }
        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }
        public string Facebook
        {
            get { return this.facebook; }
            set { this.facebook = value; }
        }
        public string Twitter
        {
            get { return this.twitter; }
            set { this.twitter = value; }
        }
        public string Param1
        {
            get { return this.param1; }
            set { this.param1 = value; }
        }
        public string Param2
        {
            get { return this.param2; }
            set { this.param2 = value; }
        }
        public string Param3
        {
            get { return this.param3; }
            set { this.param3 = value; }
        }
        public Filter Filter
        {
            get { return this.filter; }
            set { this.filter = value; }
        }

        public int Items
        {
            get { return this.items; }
            set { this.items = value; }
        }
        public int Page
        {
            get { return this.page; }
            set { this.page = value; }
        }
        public string Query
        {
            get { return this.query; }
            set { this.query = value; }
        }
        
        public string Create()
        {
            List<KeyValuePair<string, string>> values = IntellipushConfig.getDefaultKeyValuePair();

            string newData = Security.EncryptRJ256(this.ToJSON(), IntellipushConfig.API_SECRET, IntellipushConfig.API_SECRET);

            values.Add(new KeyValuePair<string, string>("enc_request", newData));
            return HttpHandler.postToAPIResource(values, IntellipushConfig.Contact.Create);
        }

        public string Update()
        {
            if (contact_id.Equals(""))
            {
                throw new Exception("No id provided.");
            }

            List<KeyValuePair<string, string>> values = IntellipushConfig.getDefaultKeyValuePair();

            string newData = Security.EncryptRJ256(this.ToJSON(), IntellipushConfig.API_SECRET, IntellipushConfig.API_SECRET);

            values.Add(new KeyValuePair<string, string>("enc_request", newData));
            return HttpHandler.postToAPIResource(values, IntellipushConfig.Contact.Update);
        }

        public string Delete()
        {
            if (contact_id.Equals(""))
            {
                throw new Exception("No id provided.");
            }

            List<KeyValuePair<string, string>> values = IntellipushConfig.getDefaultKeyValuePair();

            string newData = Security.EncryptRJ256(this.ToJSON(), IntellipushConfig.API_SECRET, IntellipushConfig.API_SECRET);

            values.Add(new KeyValuePair<string, string>("enc_request", newData));
            return HttpHandler.postToAPIResource(values, IntellipushConfig.Contact.Delete);
        }

        public string GetContact()
        {
            if (contact_id.Equals(""))
            {
                throw new Exception("No id provided.");
            }

            List<KeyValuePair<string, string>> values = IntellipushConfig.getDefaultKeyValuePair();

            string newData = Security.EncryptRJ256(this.ToJSON(), IntellipushConfig.API_SECRET, IntellipushConfig.API_SECRET);

            values.Add(new KeyValuePair<string, string>("enc_request", newData));
            return HttpHandler.postToAPIResource(values, IntellipushConfig.Contact.Get);
        }

        public string GetContacts()
        {
            if (this.Items <= 0 || this.Page <= 0 || this.Filter == null)
            {
                throw new Exception("Retrieving contacts requires 'Items', 'Page' and 'Filter' to allow pagination of results.");
            }

            List<KeyValuePair<string, string>> values = IntellipushConfig.getDefaultKeyValuePair();

            string newData = Security.EncryptRJ256(this.ToJSON(), IntellipushConfig.API_SECRET, IntellipushConfig.API_SECRET);

            values.Add(new KeyValuePair<string, string>("enc_request", newData));
            return HttpHandler.postToAPIResource(values, IntellipushConfig.Contact.GetContacts);
        }
    }
}
