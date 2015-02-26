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
    public class Filter
    {
        [DataMember(Name = "age", EmitDefaultValue = false)]
        private string _age;

        [DataMember(Name = "sex", EmitDefaultValue = false)]
        private string _sex;

        [DataMember(Name = "country", EmitDefaultValue = false)]
        private string _country;

        [DataMember(Name = "company", EmitDefaultValue = false)]
        private string _company;

        [DataMember(Name = "param1", EmitDefaultValue = false)]
        private string _param1;

        [DataMember(Name = "param2", EmitDefaultValue = false)]
        private string _param2;

        [DataMember(Name = "param3", EmitDefaultValue = false)]
        private string _param3;

        public Filter()
        {

        }

        public string ToJSON()
        {
            string jsonString = "";
            MemoryStream ms = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Filter));
            ser.WriteObject(ms, this);

            ms.Position = 0;
            StreamReader sr = new StreamReader(ms);

            jsonString = sr.ReadToEnd().ToString();

            sr.Close();
            ms.Close();

            return jsonString;
        }

        public string Age
        {
            get { return this._age; }
            set { this._age = value; }
        }
        public string Sex
        {
            get { return this._sex; }
            set { this._sex = value; }
        }
        public string Country
        {
            get { return this._country; }
            set { this._country = value; }
        }
        public string Company
        {
            get { return this._company; }
            set { this._company = value; }
        }
        public string Param1
        {
            get { return this._param1; }
            set { this._param1 = value; }
        }
        public string Param2
        {
            get { return this._param2; }
            set { this._param2 = value; }
        }
        public string Param3
        {
            get { return this._param3; }
            set { this._param3 = value; }
        }

    }
}
