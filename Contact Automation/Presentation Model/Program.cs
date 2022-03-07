using Contact_Automation.Business_Model;
using Contact_Automation.Data_Model;

namespace Contact_Automation;

public class Program
{
    public static void Main(string[] args)
    {
        ContactOperations business = new ContactOperations();
        business.SaveDefaultContacts();
        while (true)
        {
            Console.WriteLine("LÜTFEN YAPMAK İSTEDİĞİNİZ İŞLEMİ SEÇİNİZ :)");
            Console.WriteLine("*******************************************");
            Console.WriteLine("(1) Yeni Numara Kaydetmek");
            Console.WriteLine("(2) Var olan Numarayı Silmek");
            Console.WriteLine("(3) Var olan Numarayı Güncelleme");
            Console.WriteLine("(4) Rehberi Listelemek");
            Console.WriteLine("(5) Rehberde Arama Yapmak");
            var choose = Convert.ToInt16(Console.ReadLine());
            switch (choose)
            {
                case 1:
                {
                    Console.Clear();
                    Console.Write("Lütfen İsim Giriniz:");
                    var isim = Console.ReadLine();
                    Console.WriteLine();
                    Console.Write("Lütfen Soyisim Giriniz:");
                    var soyisim = Console.ReadLine();
                    Console.WriteLine();
                    Console.Write("Lütfen Telefon Numarası Giriniz:");
                    var numara = Console.ReadLine();
                    Console.WriteLine();
                    var newContact = new ContactInfo()
                    {
                        Name = isim,
                        SurName = soyisim,
                        Number = numara
                    };
                    business.SaveContactInformation(newContact);
                    break;
                }
                case 2:
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.Write("Lütfen numarasını silmek istediğiniz kişinin adını ya da soyadını giriniz: ");
                        var isimVeyaSoyisim = Console.ReadLine();
                        var response = business.RemoveContactInformationByNameOrSurNme(isimVeyaSoyisim);
                        if (response)
                        {
                            break;
                        }
                    } 
                    break;
                }
                case 3:
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.Write("Lütfen numarasını güncellemek istediğiniz kişinin adını ya da soyadını giriniz: ");
                        var isimVeyaSoyisim = Console.ReadLine();
                        var response = business.UpdateContactInformationByNameOrSurname(isimVeyaSoyisim);
                        if (response)
                        {
                            break;
                        }
                    }
                    break;
                }
                case 4:
                {
                    Console.Clear();
                    Console.WriteLine("Telefon Rehberi:");
                    Console.WriteLine("*******************");
                    foreach (var contactInfo in business.GetAllContacts())
                    {
                        Console.WriteLine("İsim: {"+contactInfo.Name+"}");
                        Console.WriteLine("Soyisim: {"+contactInfo.SurName+"}");
                        Console.WriteLine("Telefon Numarası: {"+contactInfo.Number+"}");
                        Console.WriteLine("-");
                    }
                    break;
                }
                case 5:
                {
                    Console.Clear();
                    Console.WriteLine("Arama Yapmak istediğiniz tipi seçiniz.");
                    Console.WriteLine("**************************************");
                    business.SearchContactInformation();
                    break;
                }
            }
        }
    }
}