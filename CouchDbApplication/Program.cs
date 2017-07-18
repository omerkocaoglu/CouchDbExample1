using CouchDbApplication.Entity;
using CouchDbApplication.Generic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CouchDbApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            //BusinessService bs = new BusinessService();
            //bs.DeleteDatabase();
            byte[] data;
            Console.WriteLine("Müşteri Yönetim Paneline Hoşgeldiniz... Rahatla dostummm bende :)");
            Console.WriteLine("-----------------------------------------------------------------");
            while (true)
            {
                Console.Write("\n");
                Console.WriteLine("Müşteri eklemek için     ==> 1");
                Console.WriteLine("Müşteri güncellemek için ==> 2");
                Console.WriteLine("Müşteri silmek için      ==> 3");
                Console.WriteLine("Müşteri listesi için     ==> 4");
                Console.Write("Menü seçim (Çıkmak [E]): ");
                string selection = Console.ReadLine();
                selection = selection.ToUpper();
                GenericProperty<Business, EntityAttributes> genericProperty = new GenericProperty<Business, EntityAttributes>();
                PropertyInfo[] specificProperties = genericProperty.GetProperties();
                BusinessService businessService = new BusinessService();
                switch (selection)
                {
                    case "1":
                        Console.Write("\n");
                        Business busines = new Business();
                        List<string> values = new List<string>();
                        for (int i = 0; i < specificProperties.Length; i++)
                        {
                            Console.Write(specificProperties[i].CustomAttributes.Where(x => x.AttributeType.Name == "DisplayNameAttribute").FirstOrDefault().ConstructorArguments[0].Value + ": ");
                            string variable = Console.ReadLine();
                            if (variable != null & variable != "")
                            {
                                values.Add(variable);
                            }
                            else
                            {
                                i--;
                                continue;
                            }
                        }
                        busines.Id = values[0];
                        busines.Name = values[1];
                        busines.Surname = values[2];
                        busines.Department = values[3];
                        busines.Birthdate = values[4];
                        busines.Phone = values[5];
                        busines.City = values[6];
                        busines.Country = values[7];
                        businessService.InsertBusinessman(busines);
                        Console.WriteLine("Müşteri kaydı başarıyla yapıldı.Devam etmek için [ENTER] tuşuna basınız...");
                        Console.ReadLine();
                        break;
                    case "2":
                        Console.Write("\n");
                        Console.Write("Güncellemek istediğiniz müşteri Id'sini giriniz: ");
                        string businessId = Console.ReadLine();
                        if (businessId != null & businessId != "")
                        {
                            Business updatingBusiness = businessService.GetById(businessId);
                            Console.WriteLine("Güncellenmek istenen müşteri bilgileri");
                            Console.WriteLine("--------------------------------------");
                            Console.WriteLine("    Id: " + updatingBusiness.Id);
                            Console.WriteLine("(1) Ad: " + updatingBusiness.Name);
                            Console.WriteLine("(2) Soyad: " + updatingBusiness.Surname);
                            Console.WriteLine("(3) Bölüm: " + updatingBusiness.Department);
                            Console.WriteLine("(4) Doğum Tarihi: " + updatingBusiness.Birthdate);
                            Console.WriteLine("(5) Telefon No: " + updatingBusiness.Phone);
                            Console.WriteLine("(6) Şehir: " + updatingBusiness.City);
                            Console.WriteLine("(7) Ülke: " + updatingBusiness.Country);
                            while (true)
                            {
                                Console.Write("\n");
                                Console.Write("Güncellemek istenen bilgiyi seçiniz (Çıkmak için [E]): ");
                                string item = Console.ReadLine();
                                if (item.ToUpper() != "E")
                                {
                                    if (item != null & item != "")
                                    {
                                        if (Convert.ToInt32(item) >= 1 && Convert.ToInt32(item) < 8)
                                        {
                                            Console.Write("Yeni değer: ");
                                            string newValue = Console.ReadLine();
                                            if (newValue != null & newValue != "")
                                            {
                                                data = new byte[1024];
                                                data = ASCIIEncoding.Default.GetBytes(item + newValue);
                                                businessService.UpdateBusinessman(businessId, data);
                                                Console.WriteLine("Güncelleme işlemi tamamlandı...");
                                                break;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        break;
                    case "3":
                        Console.Write("\n");
                        Console.Write("Silmek istediğiniz müşteri Id'sini giriniz: ");
                        string deletedBusinessId = Console.ReadLine();
                        if (deletedBusinessId != null & deletedBusinessId != "")
                        {
                            businessService.DeleteBusinessman(deletedBusinessId);
                            Console.WriteLine("Müşteri silme işlemi başarıyla gerçekleştirilmiştir...");
                        }
                        break;
                    case "4":
                        Console.Write("\n");
                        List<Business> businessList = businessService.GetAll();
                        Console.WriteLine("Veritabanında kayıtlı müşteri sayısı: " + businessList.Count);
                        Console.WriteLine("---------------------------------------");
                        for (int i = 0; i < businessList.Count; i++)
                        {
                            Console.Write("\n");
                            Console.WriteLine("Id: " + businessList[i].Id);
                            Console.WriteLine("Ad: " + businessList[i].Name);
                            Console.WriteLine("Soyad: " + businessList[i].Surname);
                            Console.WriteLine("Bölüm: " + businessList[i].Department);
                            Console.WriteLine("Doğum Tarihi: " + businessList[i].Birthdate);
                            Console.WriteLine("Telefon No: " + businessList[i].Phone);
                            Console.WriteLine("Şehir: " + businessList[i].City);
                            Console.WriteLine("Ülke: " + businessList[i].Country);
                        }
                        break;
                    case "E":
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
