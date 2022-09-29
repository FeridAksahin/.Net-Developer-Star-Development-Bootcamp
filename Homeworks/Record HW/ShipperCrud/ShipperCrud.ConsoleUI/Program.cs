using ShipperCrud.ConsoleUI.Dtos;
using ShipperCrud.DataAcces.Contexts;

namespace ShipperCrud.ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string x = "";
           

            do
            {
                Console.WriteLine("Yapmak istediğiniz işlemi seçin");
                Console.WriteLine("1-Veri Eklemek");
                Console.WriteLine("2-Veri Güncellemek");
                Console.WriteLine("3-Veri Silmek");
                Console.WriteLine("-1 Çıkış");
                NorthwindContext context = new NorthwindContext();
                 x = Console.ReadLine();

                if (x == "1")
                {
                    ShipperDto shipperDto = new ShipperDto();
                    Console.WriteLine("Shipper Telefon No giriniz");
                    shipperDto.Phone = Console.ReadLine();
                    Console.WriteLine("Shipper CompanyName Giriniz");
                    shipperDto.CompanyName = Console.ReadLine();



                    context.Shippers.Add(new DataAcces.Models.Shipper() { CompanyName = shipperDto.CompanyName, Phone = shipperDto.Phone });
                    if (context.SaveChanges() > 0)
                    {
                        Console.WriteLine("İşlem Başarılı");
                    }

                }
                else if (x == "2")
                {
                    var shipperList = context.Shippers.ToList();
                    foreach (var item in shipperList)
                    {
                        Console.WriteLine(item.ShipperId);
                        Console.WriteLine(item.Phone);
                        Console.WriteLine(item.CompanyName);
                        Console.WriteLine("---------------------------");
                    }
                    Console.WriteLine("Güncellenecek olan shipper ıd seçiniz");
                    var shipperId = Convert.ToInt32(Console.ReadLine());
                    var entity = context.Shippers.Find(shipperId);

                    ShipperDto shipperDto = new ShipperDto();
                    Console.WriteLine("Shipper Telefon No giriniz");
                    shipperDto.Phone = Console.ReadLine();
                    Console.WriteLine("Shipper CompanyName Giriniz");
                    shipperDto.CompanyName = Console.ReadLine();

                    entity.CompanyName = shipperDto.CompanyName;
                    entity.Phone = shipperDto.Phone;
                    if (context.SaveChanges() > 0)
                    {
                        Console.WriteLine("İşlem Başarılı");
                    }



                }
                else if (x == "3")
                {
                    var shipperList = context.Shippers.ToList();
                    foreach (var item in shipperList)
                    {
                        Console.WriteLine(item.ShipperId);
                        Console.WriteLine(item.Phone);
                        Console.WriteLine(item.CompanyName);
                        Console.WriteLine("---------------------------");
                    }
                    Console.WriteLine("Silinecek olan shipper ıd seçiniz");
                    var shipperId = Convert.ToInt32(Console.ReadLine());
                    var deleted = context.Shippers.Find(shipperId);
                    context.Shippers.Remove(deleted);
                    if (context.SaveChanges() > 0)
                    {
                        Console.WriteLine("İşlem Başarılı");
                    }

                }
                else 
                {
                    if (x!="-1")
                    {
                        Console.WriteLine("Hatalı giriş");
                    }
                    
                }
            } while (x!="-1");

            Console.WriteLine("Çıkış Yapıldı");
           
           

           
        }
    }
}