using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intellipush
{
    public class IntellipushConfig
    {

        private static string api_appid = "";
        private static string api_secret = "";

        public static string SDK
        {
            get
            {
                return Properties.Resources.SDK;
            }
        }
        public static string VERSION
        {
            get
            {
                return Properties.Resources.VERSION;
            }
        }
        public static string APPID
        {
            get
            {
                return api_appid;
            }
            set
            {
                api_appid = value;
            }
        }
        public static string API_SECRET
        {
            get
            {
                return api_secret;
            }
            set
            {
                api_secret = value;
            }
        }
        public static string API_URL
        {
            get
            {
                return Properties.Resources.API_URL;
            }
        }

        public static List<KeyValuePair<string, string>> getDefaultKeyValuePair() {
            /* Used to construct default KeyValuePair for alle requests to the API. */
            List<KeyValuePair<string, string>> values = new List<KeyValuePair<string, string>>();
            values.Add(new KeyValuePair<string, string>("appID", IntellipushConfig.APPID));
            values.Add(new KeyValuePair<string, string>("s", IntellipushConfig.SDK));
            values.Add(new KeyValuePair<string, string>("v", IntellipushConfig.VERSION));

            return values;
        }

        public static NotificationPath Notification
        {
            get
            {
                return new NotificationPath();
            }
        }
        public static ContactPath Contact
        {
            get
            {
                return new ContactPath();
            }
        }

        public static ContactListPath ContactList
        {
            get
            {
                return new ContactListPath();
            }
        }

        public static UserPath User
        {
            get
            {
                return new UserPath();
            }
        }
    }

    /*
     Setup the configuration for Notification, Contact and ContactList
     */

    public class UserPath
    {
        public string Get
        {
            get { return "user"; }
        }
    }

    public class NotificationPath
    {
        public string Create
        {
            get { return "notification/createNotification"; }
        }
        public string CreateBatch
        {
            get { return "notification/createBatch"; }
        }
        public string Update
        {
            get { return "notification/updateNotification"; }
        }
        public string Delete
        {
            get { return "notification/deleteNotification"; }
        }
        public string Get
        {
            get { return "notification/getNotification"; }
        }
        public string GetUnsent
        {
            get { return "notification/getUnsendtNotifications"; }
        }
        public string GetSent
        {
            get { return "notification/getSendtNotifications"; }
        }
        public string Status
        {
            get { return "notification/getNotificationStatus"; }
        }
    }

    public class ContactPath
    {
        public string Create
        {
            get { return "contact/createContact"; }
        }
        public string Update
        {
            get { return "contact/updateContact"; }
        }
        public string Delete
        {
            get { return "contact/deleteContact"; }
        }
        public string Get
        {
            get { return "contact/getContact"; }
        }
        public string GetContacts
        {
            get { return "contact/getContacts"; }
        }
    }

    public class ContactListPath
    {
        public string Create
        {
            get { return "contactlist/createContactlist"; }
        }
        public string Update
        {
            get { return "contactlist/updateContactlist"; }
        }
        public string Delete
        {
            get { return "contactlist/deleteContactlist"; }
        }
        public string GetContactlist
        {
            get { return "contactlist/getContactlist"; }
        }
        public string GetContactlists
        {
            get { return "contactlist/getContactlists"; }
        }
        public string GetContacts
        {
            get { return "contactlist/getContactsInContactlist"; }
        }
        public string GetContactsAmount
        {
            get { return "contactlist/getNumberOfFilteredContactsInContactlist"; }
        }
        public string GetContactsNotIn
        {
            get { return "contactlist/searchContactsNotInContactlist"; }
        }
        public string AddContact
        {
            get { return "contactlist/addContactToContactlist"; }
        }
        public string RemoveContact
        {
            get { return "contactlist/removeContactFromContactlist"; }
        }
    }

}
