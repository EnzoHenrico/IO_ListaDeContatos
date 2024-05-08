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

        public override string ToString()
        {
            string listInString = "";
            
            foreach (var contact in this.contacts)
            {
                listInString += contact + "\n";
            }
            return listInString;
        }

        public void SaveOnFile(string path, string file)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var writer = new StreamWriter(path + file);

            foreach (var contact in this.contacts)
            {
                writer.WriteLine(contact.ToString());
            }
            writer.Close();
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

        private Contact? GetContactByName(string contactName)
        {
            return this.contacts.Find(contact => contact.Name == contactName);
        }

        public string? GetContactString(string contactName)
        {
            var contact = GetContactByName(contactName);

            if (contact == null)
            {
                return null;
            }

            return contact.ToString();
        }

        public bool UpdateName(string contactName, string newName)
        {
            var contact = GetContactByName(contactName);
            
            if (contact == null)
            {
                return false;
            }

            contact.Name = newName;
            return true;
        }

        public bool UpdateEmail(string contactName, string newEmail)
        {
            var contact = GetContactByName(contactName);

            if (contact == null)
            {
                return false;
            }

            contact.Email = newEmail;
            return true;
        }

        public bool UpdatePhones(string contactName, string newPhoneNumber, int index = 0)
        {
            var contact = GetContactByName(contactName);

            if (contact == null)
            {
                return false;
            }

            contact.PhoneNumbers.Insert(index, new PhoneNumber(newPhoneNumber));
            return true;
        }

        public bool UpdateAddress(string contactName, ContactAddress newContactAddress)
        {
            var contact = GetContactByName(contactName);

            if (contact == null)
            {
                return false;
            }

            contact.ContactAddress = newContactAddress;
            return true;
        }

        public bool ContainsContact(string contactName)
        {
            return this.contacts.Find(contact => contact.Name == contactName) != null;
        }

        public bool IsEmpty()
        {
            return this.contacts.Count == 0;
        }
    }
}
