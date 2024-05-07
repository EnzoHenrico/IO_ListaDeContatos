using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquivoDeContatos
{
    internal class PhoneBook
    {
        List<Contact> contacts;

        public PhoneBook()
        {
            contacts = new List<Contact>();
        }

        public void AddContact(Contact contact)
        {
            this.contacts.Add(contact);
            this.contacts.Sort();
        }

        public bool RemoveContactByName(string contactName)
        {
            var target = this.contacts.Find(contact => contact.Name == contactName);
            return this.contacts.Remove(target);
        }

        public Contact? FindContactByName(string contactName)
        {
            return this.contacts.Find(contact => contact.Name == contactName);
        }

        public bool IsEmpty()
        {
            return this.contacts.Count == 0;
        }
    }
}
