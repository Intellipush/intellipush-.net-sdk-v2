using smslib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testapplication
{
    class Program
    {
        static void Main(string[] args)
        {
            SMSClient c = new SMSClient("", "");
            Console.WriteLine(c.postToUrl());

            Console.ReadKey();
        }
    }
}
