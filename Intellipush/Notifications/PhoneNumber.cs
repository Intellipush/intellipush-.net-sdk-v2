using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Intellipush.Notifications
{
    [DataContract]
    public class PhoneNumber
    {
        [DataMember(Name = "areacode")]
        private string _AreaCode;

        [DataMember(Name = "phonenumber")]
        private string _PhoneNumber;

        public PhoneNumber(string AreaCode, string PhoneNumber)
        {
            this._AreaCode = AreaCode;
            this._PhoneNumber = PhoneNumber;
        }

        public string Phone
        {
            get
            {
                return this._PhoneNumber;
            }
        }

        public string Area
        {
            get
            {
                return this._AreaCode;
            }
        }

    }
}
