using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contact_Automation.Data_Model;

namespace Contact_Automation.Business_Model
{
    public class ContactOperations
    {
        private ContactRepository _contactRepository = new ContactRepository();

        public void SaveDefaultContacts()
        {
            _contactRepository.SetDefaultContacts();
        }
        public void SaveContactInformation(ContactInfo o)
        {
            if (string.IsNullOrWhiteSpace(o.Name))
            {
                throw new Exception("Contact must have name.");
            }
            _contactRepository.Save(o);
        }

        public List<ContactInfo> GetAllContacts()
        {
            return _contactRepository.GetAll();
        }

        public bool RemoveContactInformationByNameOrSurNme(string? nameOrSurname)
        { 
            var contactToRemove = _contactRepository.GetAll().Where(x => (x.Name.ToLower().Equals(nameOrSurname.ToLower())) 
                                                                         || (x.SurName.ToLower().Equals(nameOrSurname.ToLower()))).ToArray();
            if(contactToRemove.Length > 0)
            {
                Console.WriteLine($"{contactToRemove[0].Name} isimli kişi rehberden silinmek üzere, onaylıyor musunuz? (y/n)");
                var response = Console.ReadLine();
                if (response is "y")
                {
                    _contactRepository.Remove(contactToRemove[0]);
                    Console.WriteLine("Silindi.");
                    return true;
                }

            }
            else
            {
                Console.WriteLine("Aradığınız kriterlere uygun veri rehberi bulunamadı. Lütfen bir seçim yapınız.");
                Console.WriteLine("* Silmeyi sonlandırmak için : (1)");
                Console.WriteLine("* Yeniden denemek için      : (2)");
                var response = Console.ReadLine();
                return response == "1";
            }

            return true;
        }

        public bool UpdateContactInformationByNameOrSurname(string? nameOrSurname)
        {

            var contactToUpdate = _contactRepository.GetAll().Where(contact =>
                contact.Name.ToLower().Equals(nameOrSurname?.ToLower()) ||
                contact.SurName.ToLower().Equals(nameOrSurname?.ToLower())).ToArray();

            if (contactToUpdate.Length > 0)
            {
                var newModel = new ContactInfo();
                Console.WriteLine("Yenilemek istediğiniz numarayı giriniz.");
                var numberToUpdate = Console.ReadLine();
                newModel.Name = contactToUpdate[0].Name; 
                newModel.SurName = contactToUpdate[0].SurName;
                newModel.Number = numberToUpdate;
                _contactRepository.Update(contactToUpdate[0], newModel);
                Console.WriteLine("Güncellendi.");
                return true;
            }

            Console.WriteLine("Aradığınız kriterlere uygun veri rehberi bulunamadı. Lütfen bir seçim yapınız.");
            Console.WriteLine("* Silmeyi sonlandırmak için : (1)");
            Console.WriteLine("* Yeniden denemek için      : (2)");
            var response = Console.ReadLine();
            return response == "1";

        }

        public void SearchContactInformation()
        {
            var contactInfos = new List<ContactInfo>();
            Console.WriteLine("İsim veya soyisime göre arama yapmak için: (1)");
            Console.WriteLine("Telefon numarasına göre arama yapmak için: (2)");
            var response = Console.ReadLine();
            if (response is "1")
            {
                Console.Write("Aramak istediğiniz isim ve ya soyismi giriniz: ");
                var nameOrSurname = Console.ReadLine();
                contactInfos = _contactRepository.GetAll().Where(x => (x.Name.ToLower().Equals(nameOrSurname.ToLower()))
                                                                             || (x.SurName.ToLower().Equals(nameOrSurname.ToLower()))).ToList();
            }
            else
            {
                Console.Write("Arama Yapmak istediğiniz telefon numarasını giriniz");
                var telephoneNumber = Console.ReadLine();
                contactInfos = _contactRepository.GetAll().Where(x => x.Number.Equals(telephoneNumber)).ToList();
            }
            if (contactInfos.Count > 0)
            {
                foreach (var contact in contactInfos)
                {
                    Console.WriteLine("İsim: " + contact.Name);
                    Console.WriteLine("Soyisim: " + contact.SurName);
                    Console.WriteLine("Telefon Numarası: " + contact.Number);
                    Console.WriteLine("--");
                }
            }
            else
            {
                Console.WriteLine("Kişi rehberde bulunamadı");
            }
        }
    }
}
