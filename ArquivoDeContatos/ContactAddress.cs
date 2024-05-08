using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ArquivoDeContatos
{
    internal class ContactAddress
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        public ContactAddress(string street, string city, string state, string zip)
        {
            this.Street = street;
            this.City = city;
            this.State = state;
            this.Zip = zip;
        }

        public override string ToString()
        {
            return $"{Street} {City} {State} {Zip}";
        }
    }
}
