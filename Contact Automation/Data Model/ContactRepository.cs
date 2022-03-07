using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Automation.Data_Model
{
    public class ContactRepository
    {
        private List<ContactInfo> contacts = new List<ContactInfo>();

        public void SetDefaultContacts()
        {
            contacts.Add(new ContactInfo()
            {
                Name = "jamshid",
                SurName = "karimov",
                Number = "+90123456789"
            });
            contacts.Add(new ContactInfo()
            {
                Name = "ali",
                SurName = "veli",
                Number = "+900123543123"
            });
            contacts.Add(new ContactInfo()
            {
                Name = "Murat",
                SurName = "Can",
                Number = "+900123543123"
            });
            contacts.Add(new ContactInfo()
            {
                Name = "Barış",
                SurName = "Ateş",
                Number = "+903512543123"
            });
            contacts.Add(new ContactInfo()
            {
                Name = "Armağan",
                SurName = "şişik",
                Number = "+90016531543123"
            });
        }
        public void Save(ContactInfo contact)
        {
            if (string.IsNullOrWhiteSpace(contact.Name))
            {
                throw new Exception("Contact must have name.");
            }
            contacts.Add(contact);
        }

        public List<ContactInfo> GetAll()
        {
            return contacts;
        }

        public void Remove(ContactInfo o)
        {
            contacts.Remove(o);
        }

        public void Update(ContactInfo oldItem,ContactInfo newItem)
        {
            contacts.Remove(oldItem);
            contacts.Add(newItem);
        }
    }
}
