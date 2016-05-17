using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SerializerPerson
{
    [Serializable]
    class Person : IDeserializationCallback
    {
        private string name;
        private string address;
        private string phone;
        private DateTime dateTime;
        [NonSerialized]
        private int serialNumber;

        public Person(string name, string address, string phone)
        {
            this.name = name;
            this.address = address;
            this.phone = phone;
            this.dateTime = DateTime.Now;

        }


     

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string Phone
        {
            get { return phone; }
            set { phone= value; }
        }


        public int SerialNumber
        {
            get { return serialNumber; }
            set { serialNumber = value; }
        }

        public void OnDeserialization(object sender)
        {
            string filename = "person1.dat";
            var numb = Regex.Matches(filename, "\\d{1,2}");
            foreach (var n in numb)
            {
                SerialNumber = (int) n;
            }
        }
    }
}
