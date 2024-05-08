using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquivoDeContatos
{
    internal class Contact
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public List<PhoneNumber> PhoneNumbers { get; set; }
        public ContactAddress ContactAddress { get; set; }

        public Contact(string name, string phone)
        {
            this.Name = name;
            this.PhoneNumbers = new List<PhoneNumber>
            {
                new PhoneNumber(phone)
            };
        }

        public override string ToString()
        {
            string phonesString = " ";

            foreach (var phone in PhoneNumbers)
            {
                phonesString += phone + " ";
            }

            return $"{Name},{phonesString},{Email},{ContactAddress}";
        }

        public void AddPhoneNumber(string phone)
        {
            this.PhoneNumbers.Add(new(phone));
        }
    }
}
