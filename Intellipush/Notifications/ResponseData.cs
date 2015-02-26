using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intellipush.Notifications
{
    class ResponseData
    {
        /*  Handle data from response.
         "data": {
                "text_message": "Hello World",
                "html_message": "",
                "date": "now",
                "time": "now",
                "method": "sms",
                "repeat": "",
                "single_target_countrycode": "0047",
                "single_target": "97774628",
                "contact_id": "",
                "contactlist_id": "",
                "contactlist_filter": "",
                "use_sendername": true,
                "two_way_session": "",
                "id": "38708"
            },
         */
        private string text_message;
        private string html_message;
        private string date;
        private string time;
        private string method;
        private string repeat;
        private string single_target_countrycode;
        private string single_target;
        private string contact_id;
        private string contactlist_id;
        private string contactlist_filter;
        private bool use_sendername;
        private string two_way_session;
        private string id;

        public ResponseData(JObject jo)
        {
            text_message = (string)jo.GetValue("text_message");
            html_message = (string)jo.GetValue("html_message");
            date = (string)jo.GetValue("date");
            time = (string)jo.GetValue("time");
            method = (string)jo.GetValue("method");
            repeat = (string)jo.GetValue("repeat");
            single_target_countrycode = (string)jo.GetValue("single_target_countrycode");
            single_target = (string)jo.GetValue("single_target");
            contact_id = (string)jo.GetValue("contact_id");
            contactlist_id = (string)jo.GetValue("contactlist_id");
            contactlist_filter = (string)jo.GetValue("contactlist_filter");
            use_sendername = (bool)jo.GetValue("use_sendername");
            two_way_session = (string)jo.GetValue("two_way_session");
            id = (string)jo.GetValue("id");
        }

        public string Id
        {
            get
            {
                return this.id;
            }
        }

        public string TextMessage
        {
            get
            {
                return this.text_message;
            }
        }

        public string HtmlMessage
        {
            get
            {
                return this.html_message;
            }
        }

        public string Date
        {
            get
            {
                return this.date;
            }
        }

        public string Time
        {
            get
            {
                return this.time;
            }
        }

        public string Method
        {
            get
            {
                return this.method;
            }
        }

        public string Repeat
        {
            get
            {
                return this.repeat;
            }
        }

        public string SingleTargetCountrycode
        {
            get
            {
                return this.single_target_countrycode;
            }
        }

        public string SingleTarget
        {
            get
            {
                return this.single_target;
            }
        }

        public string ContactId
        {
            get
            {
                return this.contact_id;
            }
        }
        public string ContactlistId
        {
            get
            {
                return this.contactlist_id;
            }
        }
        public string ContactlistFilter
        {
            get
            {
                return this.contactlist_filter;
            }
        }
        public bool UseSendername
        {
            get
            {
                return this.use_sendername;
            }
        }
        public string TwoWaySession
        {
            get
            {
                return this.two_way_session;
            }
        }
    }
}
