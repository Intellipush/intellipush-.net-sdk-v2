using Intellipush;
using Intellipush.Notifications;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testapplication
{
    class TestAllActions
    {

        static void Main(string[] args)
        {
            IntellipushConfig.APPID = "yyyyyyy"; // Edit to your api appid
            IntellipushConfig.API_SECRET = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx"; // Edit to your api secret

            string countrycode = "0047"; // Norway
            string phone = "zzzzzzzz";

            #region Reserved variables
            string response;
            Sms sms;
            dynamic jo;
            Contact contact;
            Filter filter;
            ContactList contactlist;
            JArray ja;
            #endregion

            /*
                    Create a SMS with two recievers
             */
            List<PhoneNumber> receivers = new List<PhoneNumber>();
            receivers.Add(new PhoneNumber(countrycode, phone));
            receivers.Add(new PhoneNumber(countrycode, phone));

            sms = new Sms();
            sms.Receivers(receivers);
            sms.TextMessage = "Hei hei! :)";
            sms.When(DateTime.Now.AddMinutes(20));

            response = sms.Create();
            ja = JArray.Parse(response);
            jo = ja.First().Value<JObject>(); // Get first SMS in batch
            Assert.AreEqual((bool)jo.success, true);

            int notification_id = jo.data.id;

            /*
                    Get notification status
             */
            response = new Status(notification_id).GetStatus();
            jo = JObject.Parse(response);
            Assert.AreEqual((bool)jo.success, true);

            /*
                    Creating SMS with no message
             */
            sms = new Sms();
            sms.AreaCode = countrycode;
            sms.PhoneNumber = phone;
            sms.When(DateTime.Now.AddMinutes(10));
            response = sms.Create();
            jo = JObject.Parse(response);
            Assert.AreEqual((bool)jo.success, false);


            /*
                    Creating SMS with no specified time (default is 'now')
             */
            response = new Sms("Hello World", new PhoneNumber(countrycode, phone)).Create();
            jo = JObject.Parse(response);
            Assert.AreEqual((bool)jo.success, true);

            /*
                    Creating a SMS with repeat
             */
            sms = new Sms("This message will repeat daily", new PhoneNumber(countrycode, phone));
            sms.Repeat = "daily";
            sms.When(DateTime.Now.AddMinutes(10));
            response = sms.Create();

            jo = JObject.Parse(response);
            Assert.AreEqual((bool)jo.success, true);

            int repeat_notification_id = jo.data.id;

            /*
                    Deleting repeated message
             */
            response = new Sms(repeat_notification_id).Delete();
            jo = JObject.Parse(response);
            Assert.AreEqual((bool)jo.success, true);

            /*
                    Create sms with repeat without specified time
             */
            sms = new Sms();
            sms.TextMessage = "Hei hei :)";
            sms.Receiver(new PhoneNumber(countrycode, phone));
            sms.Repeat = "daily";
            response = sms.Create();

            jo = JObject.Parse(response);

            Assert.AreEqual((bool)jo.success, false);
            Assert.AreEqual((int)jo.errorcode, 407);


            /*
                    Fetching a SMS
             */
            sms = new Sms(notification_id);
            response = sms.Get();

            /*
                    Fetch a unknown notification
             */
            response = new Sms(1234567890).Get();
            jo = JObject.Parse(response);

            Assert.AreEqual((bool)jo.success, false);
            Assert.AreEqual((int)jo.errorcode, 401);

            /*
                    Update SMS
             */
            sms = new Sms(notification_id);
            sms.TextMessage = "Hello! This is an updated notification!";
            sms.When(DateTime.Now.AddMinutes(50));
            sms.Repeat = "";
            response = sms.Update();

            jo = JObject.Parse(response);

            Assert.AreEqual((bool)jo.success, true);

            /*
                    Delete SMS
             */
            sms = new Sms(notification_id);
            response = sms.Delete();
            jo = JObject.Parse(response);
            Assert.AreEqual((bool)jo.success, true);


            /*
                    Create a contact
             */
            contact = new Contact("Girly Girl");
            contact.CountryCode = countrycode;
            contact.PhoneNumber = phone;
            contact.Company = "Intellipush";
            contact.Sex = "female";

            response = contact.Create();
            jo = JObject.Parse(response);
            Assert.AreEqual((bool)jo.success, true);

            int contact_id = jo.data.id;

            /*
                    Create another contact
             */
            contact = new Contact("Manly Man", countrycode, phone);
            contact.Company = "Intellipush";
            contact.Sex = "male";
            response = contact.Create();

            jo = JObject.Parse(response);
            Assert.AreEqual((bool)jo.success, true);

            int contact_id2 = jo.data.id;

            /*
                    Reading a contact
             */
            contact = new Contact(contact_id);
            response = contact.GetContact();
            jo = JObject.Parse(response);
            Assert.AreEqual((bool)jo.success, true);

            /*
                    Updating a contact
             */
            contact = new Contact(contact_id2);
            contact.Name = "Updated Manly Man";
            response = contact.Update();
            jo = JObject.Parse(response);
            Assert.AreEqual((bool)jo.success, true);

            /*
                    Reading female contacts
             */
            contact = new Contact();
            filter = new Filter();
            filter.Sex = "female";

            contact.Filter = filter;
            contact.Items = 20;
            contact.Page = 1;
            contact.Query = "";

            response = contact.GetContacts();
            jo = JObject.Parse(response);
            Assert.AreEqual((bool)jo.success, true);

            /*
                    Creating a contactlist
            */
            contactlist = new ContactList("newList");
            response = contactlist.Create();
            jo = JObject.Parse(response);
            Assert.AreEqual((bool)jo.success, true);

            int contactlist_id = jo.data.id;

            /*
                    Fetch a contactlist
             */
            contactlist = new ContactList(contactlist_id);
            response = contactlist.GetContactList();
            jo = JObject.Parse(response);
            Assert.AreEqual((bool)jo.success, true);

            /*
                    Updating a contactlist
             */
            contactlist = new ContactList();
            contactlist.Id = contactlist_id;
            contactlist.Name = "Advanced Contactlist";
            response = contactlist.Update();
            jo = JObject.Parse(response);
            Assert.AreEqual((bool)jo.success, true);

            /*
                    Get contacts in contactlist 1
             */
            contactlist = new ContactList(contactlist_id);
            contactlist.Items = 1;
            contactlist.Page = 1;
            contactlist.Query = "";

            response = contactlist.GetContactsInList();
            jo = JObject.Parse(response);
            Assert.AreEqual((bool)jo.success, true);

            /*
                    Get contacts in contactlist 2
             */
            filter = new Filter();
            filter.Sex = "female";
            contactlist = new ContactList(contactlist_id);
            contactlist.Items = 2;
            contactlist.Page = 2;
            contactlist.Query = "";
            contactlist.Filter = filter;

            response = contactlist.GetContactsInList();
            jo = JObject.Parse(response);
            Assert.AreEqual((bool)jo.success, true);

            /*
                    Get number of female contacts in contactlist
             */
            filter = new Filter();
            filter.Sex = "female";
            contactlist = new ContactList(78);
            contactlist.Filter = filter;
            response = contactlist.GetContactsAmountInList();
            jo = JObject.Parse(response);
            Assert.AreEqual((bool)jo.success, true);

            /*
                    Search contacts that are not in the contactlist
             */
            contactlist = new ContactList(contactlist_id);
            contactlist.Items = 2;
            contactlist.Page = 1;
            contactlist.Query = "arne";
            response = contactlist.GetContactsNotInAList();
            jo = JObject.Parse(response);
            Assert.AreEqual((bool)jo.success, true);

            /*
                    Add two contacts to a contactlist
             */
            contactlist = new ContactList(contactlist_id);
            response = contactlist.AddContact(contact_id);
            jo = JObject.Parse(response);
            Assert.AreEqual((bool)jo.success, true);

            response = contactlist.AddContact(contact_id2);
            jo = JObject.Parse(response);
            Assert.AreEqual((bool)jo.success, true);

            /*
                    Get user account
             */
            User user = new User();
            response = user.GetAccount();
            jo = JObject.Parse(response);
            Assert.AreEqual((bool)jo.success, true);

            /*
                    Creating a batch
             */
            Batch batch = new Batch();

            sms = new Sms("Hello World", new PhoneNumber(countrycode, phone));
            sms.When(DateTime.Now.AddMinutes(20));

            batch.addNotification(sms);
            batch.addNotification(new Sms("Hello world!", new PhoneNumber(countrycode, phone)));

            response = batch.Create();

            ja = JArray.Parse(response);
            jo = ja.First().Value<JObject>(); // Get first SMS in batch
            Assert.AreEqual((bool)jo.success, true);

            /*
                    Creating a batch of sms with to many receivers
             */
            List<PhoneNumber> list = new List<PhoneNumber>();
            // Add 1001 receivers.
            for (int i = 0; i < 1001; i++)
            {
                list.Add(new PhoneNumber(countrycode, phone));
            }

            sms = new Sms();
            sms.TextMessage = "Hello to you all!";
            sms.When(DateTime.Now.AddMinutes(40));
            sms.Receivers(list); // Using a list of receivers will create a batch.
            response = sms.Create();
            jo = JObject.Parse(response);
            Assert.AreEqual((bool)jo.success, false);
            Assert.AreEqual((int)jo.errorcode, 410);

            /*
                    Get unsendt sms's
             */
            sms = new Sms();
            sms.Items = 20;
            sms.Page = 1;
            response = sms.GetUnsendt();
            jo = JObject.Parse(response);
            Assert.AreEqual((bool)jo.success, true);

            /*
                    Get sendt sms's
             */
            sms = new Sms();
            sms.Items = 10;
            sms.Page = 1;
            response = sms.GetSendt();
            jo = JObject.Parse(response);
            Assert.AreEqual((bool)jo.success, true);

            /*
                    Send sms to contact
             */
            sms = new Sms();
            sms.ContactId = contact_id;
            sms.TextMessage = "Hello World!";
            sms.When(DateTime.Now.AddDays(1));
            sms.Repeat = "daily";
            response = sms.Create();
            jo = JObject.Parse(response);
            Assert.AreEqual((bool)jo.success, true);

            int notification_id_repeat = jo.data.id;


            /*
                    Delete sms to contact
             */
            response = new Sms(notification_id_repeat).Delete();

            /*
                    Send sms to contactlist
             */
            sms = new Sms();
            sms.ContactlistId = contactlist_id;
            sms.TextMessage = "Hello World!";
            sms.When(DateTime.Now.AddDays(1));
            response = sms.Create();
            jo = JObject.Parse(response);
            Assert.AreEqual((bool)jo.success, true);

            /*
                    Send sms to contactlist with filter
             */
            filter = new Filter();
            filter.Sex = "female";
            sms = new Sms();
            sms.ContactlistId = contactlist_id;
            sms.ContactlistFilter = filter;
            sms.TextMessage = "Hello World";
            sms.When(DateTime.Now.AddDays(1));
            response = sms.Create();
            jo = JObject.Parse(response);
            Assert.AreEqual((bool)jo.success, true);

            /*
                    Remove contact from contactlist
             */
            contactlist = new ContactList(contactlist_id);
            response = contactlist.RemoveContact(contact_id);
            jo = JObject.Parse(response);
            Assert.AreEqual((bool)jo.success, true);

            /*
                    Deleting contact
             */
            contact = new Contact(contact_id);
            response = contact.Delete();
            jo = JObject.Parse(response);
            Assert.AreEqual((bool)jo.success, true);

            /*
                    Deleting contactlist
             */
            contactlist = new ContactList(contactlist_id);
            response = contactlist.Delete();
            jo = JObject.Parse(response);
            Assert.AreEqual((bool)jo.success, true);



        }

    }
}
