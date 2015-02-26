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
    public abstract class Notification : BaseJSONObject
    {
        [DataMember(Name = "notification_id", EmitDefaultValue = false)]
        private int _Id;

        [DataMember(Name = "method", EmitDefaultValue = false)]
        private string _Method;

        [DataMember(Name = "text_message", EmitDefaultValue = false)]
        private string _TextMessage;

        [DataMember(Name = "html_message", EmitDefaultValue = false)]
        private string _HtmlMessage;

        [DataMember(Name = "date", EmitDefaultValue = false)]
        private string _Date;

        [DataMember(Name = "time", EmitDefaultValue = false)]
        private string _Time;

        [DataMember(Name = "repeat", EmitDefaultValue = false)]
        private string _Repeat;

        [DataMember(Name = "contact_id", EmitDefaultValue = false)]
        private int _ContactId;

        [DataMember(Name = "contactlist_id", EmitDefaultValue = false)]
        private int _ContactlistId;

        [DataMember(Name = "contactlist_filter", EmitDefaultValue = false)]
        private Filter _ContactlistFilter;

        [DataMember(Name = "two_way_session", EmitDefaultValue = false)]
        private string _TwoWaySession;

        [DataMember(Name = "single_target_countrycode", EmitDefaultValue = false)]
        private string _AreaCode;

        [DataMember(Name = "single_target", EmitDefaultValue = false)]
        private string _PhoneNumber;

        [DataMember(Name = "items", EmitDefaultValue = false)]
        private int _Items;

        [DataMember(Name = "page", EmitDefaultValue = false)]
        private int _Page;

        public Notification()
        {

        }

        public int Id
        {
            get { return this._Id; }
            set { this._Id = value; }
        }

        public string Method
        {
            get { return this._Method; }
            set { this._Method = value; }
        }
        public string TextMessage
        {
            get { return this._TextMessage; }
            set { this._TextMessage = value; }
        }
        public string HtmlMessage
        {
            get { return this._HtmlMessage; }
            set { this._HtmlMessage = value; }
        }
        public string Date
        {
            get { return this._Date; }
            set { this._Date = value; }
        }
        public string Time
        {
            get { return this._Time; }
            set { this._Time = value; }
        }
        public string Repeat
        {
            get { return this._Repeat; }
            set { this._Repeat = value; }
        }
        public int ContactId
        {
            get { return this._ContactId; }
            set { this._ContactId = value; }
        }
        public int ContactlistId
        {
            get { return this._ContactlistId; }
            set { this._ContactlistId = value; }
        }
        public Filter ContactlistFilter
        {
            get { return this._ContactlistFilter; }
            set { this._ContactlistFilter = value; }
        }
        public string TwoWaySession
        {
            get { return this._TwoWaySession; }
            set { this._TwoWaySession = value; }
        }
        public string AreaCode
        {
            get { return this._AreaCode; }
            set { this._AreaCode = value; }
        }
        public string PhoneNumber
        {
            get { return this._PhoneNumber; }
            set { this._PhoneNumber = value; }
        }
        public int Items
        {
            get { return this._Items; }
            set { this._Items = value; }
        }
        public int Page
        {
            get { return this._Page; }
            set { this._Page = value; }
        }

        public void When(string when = "now")
        {
            this.Date = when;
            this.Time = when;
        }

        public void When(DateTime when)
        {
            // TODO: Confirm format
            this.Date = when.ToString("yyyy-MM-dd");
            this.Time = when.ToString("HH:mm");
        }

    }
}
