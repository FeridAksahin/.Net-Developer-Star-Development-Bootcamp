using Armator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Armator
{
    internal class Process
    {
        List<Ship> ship = new List<Ship>();
        string[] products = { "Demir", "Metal", "Bakır" };
        public void shipArt()
        {
            string[] ar = {"                        |----.___",
"                                |----.___'",
"              ._________________|_______________.",
"              |####|    |####|    |####|   |####|",
"              |####|    |####|    |####|    |####|       .",
"              |####|    |####|    |####|    |####|     /|_____.",
"  __          |####|    |####|    |####|    |####|   |  Ferid  ..|",
"(  '.         '####|    '####|    '####|    '####|   '.  .vvv'",
" '@ |          |####.    |####.    |####.    |####|    ||",
"  | |          '####.    '####.    '####.    '####.    ||",
" /  |         /####.    /####.    /####.    /####.     |'.",
"|    |       '####/    '####/    '####/    '####/      |  |",
"|     |  .  /####|____/####|____/####|____/####|      |    |",
"|      |//   .#'#. .*'*. .#'#. .*'*. .#'#. .*'*.     |      |",
" |     //-...#'#'#-*'*'*-#'#'#-*'*'*-#'#'#-*'*'*-...'        |",
"  |   //     '#'#' '*'*' '#'#' '*'*' '#'#' '*'*'             |",
"   './/                                                     .'",
"   _//'._                                                _.'",
"  /  /   '----------------------------------------------'"};
            foreach (string i in ar)
            {
                Console.WriteLine(i);
            }
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine();
            }
        }

        public void Questions()
        {
            shipArt();
            int num;
            Console.WriteLine("Select the action you want to do");
            Console.WriteLine("*******************************************");
            Console.WriteLine("(1) Registering a New Ship");
            Console.WriteLine("(2) Enter the ship route");
            //Console.WriteLine("(2) Deleting Ship");
            Console.WriteLine("(3) Product Process");
            Console.WriteLine("(4) Listing the Ships");
            num = Convert.ToInt32(Console.ReadLine());
            if (num == 1)
            {
                RegisterShip();
            }
            else if (num == 2)
            {
                Route();
            }
            else if (num == 3)
            {
                ProductProcess();
            }
            else if (num == 4)
            {
                List();
            }
            else
            {
                Console.WriteLine("Enter 1-4 number");
                Questions();
            }

        }
        public void RegisterShip() //gemi kaydı metodu
        {
            shipArt();
            Ship sh = new Ship();
            Console.Write("Enter ship name : ");
            string shipName = Console.ReadLine();
            Console.Write("Enter ship Capacity : ");
            int shipCapacity = Convert.ToInt32(Console.ReadLine());
            sh.Name = shipName;
            sh.Capacity = shipCapacity;
            ship.Add(sh);
            Questions();
        }
        public void Route() //rota işlemleri metodu
        {
            Console.WriteLine("*******************************************");
            foreach (var i in ship)
            {
                Console.WriteLine(i.Name);
            }
            Console.WriteLine("Which ship? Enter ship name.");
            string inputShipName = Console.ReadLine();
            int count = 0; //girilen gemi ismi yoksa eğer 
            foreach (var i in ship)
            {
                if (inputShipName.ToLower() == i.Name.ToLower() || inputShipName.ToUpper() == i.Name.ToUpper() || inputShipName == i.Name)
                {

                    // ROUTE 01  START
                    Console.WriteLine("Write route 1. : ");
                    string port01 = Console.ReadLine();
                    i.Port01 = port01;
                    Console.WriteLine("Enter the entry date of route one.");
                    Console.Write("Enter a month: ");
                    int monthEntryPort01 = int.Parse(Console.ReadLine());
                    Console.Write("Enter a day: ");
                    int dayEntryPort01 = int.Parse(Console.ReadLine());
                    Console.Write("Enter a year: ");
                    int yearEntryPort01 = int.Parse(Console.ReadLine());

                    DateTime entryRoute01Date = new DateTime(yearEntryPort01, monthEntryPort01, dayEntryPort01);



                    Console.WriteLine("Enter the exit date of route one.");
                    Console.Write("Enter a month: ");
                    int monthExitPort01 = int.Parse(Console.ReadLine());
                    Console.Write("Enter a day: ");
                    int dayExitPort01 = int.Parse(Console.ReadLine());
                    Console.Write("Enter a year: ");
                    int yearExitPort01 = int.Parse(Console.ReadLine());

                    DateTime exitRoute01Date = new DateTime(yearExitPort01, monthExitPort01, dayExitPort01);


                    if (yearExitPort01 < yearEntryPort01 || yearExitPort01 == yearEntryPort01 && monthExitPort01 == monthEntryPort01 && dayEntryPort01 > dayExitPort01 ||
                        yearExitPort01 == yearEntryPort01 && monthExitPort01 < monthEntryPort01 && dayEntryPort01 == dayExitPort01)
                    {//eğer giriş yılı çıkış yılından büyükse veya giriş çıkışın ayları ve yılları eşit fakat girin gün tarihi çıkışın gün tarihinden büyükse veya giriş ve çıkışın gün ve yılları eşit fakat
                        //girişin ay tarihi büyükse çıkışın ay tarihinden ise tarih yazımı yanlışı vardır.
                        Console.WriteLine("Giriş tarihi çıkış tarihinden sonra olamaz. Tekrar deneyiniz.");
                        Route();
                    }
                    else
                    {
                        i.route01Enter = entryRoute01Date;
                        i.route01Exit = entryRoute01Date;
                    }
                    // ROUTE 01  END

                    //1998 1996 -> 1998 1998 03 03 06 03 -> 1998 1998 

                    // ROUTE 02  START

                    Console.WriteLine("Write route 2. : ");
                    string port02 = Console.ReadLine();
                    i.Port02 = port02;
                    Console.WriteLine("Enter the entry date of route second.");
                    Console.Write("Enter a month: ");
                    int monthEntryPort02 = int.Parse(Console.ReadLine());
                    Console.Write("Enter a day: ");
                    int dayEntryPort02 = int.Parse(Console.ReadLine());
                    Console.Write("Enter a year: ");
                    int yearEntryPort02 = int.Parse(Console.ReadLine());

                    DateTime entryRoute02Date = new DateTime(yearEntryPort02, monthEntryPort02, dayEntryPort02);



                    Console.WriteLine("Enter the exit date of route second.");
                    Console.Write("Enter a month: ");
                    int monthExitPort02 = int.Parse(Console.ReadLine());
                    Console.Write("Enter a day: ");
                    int dayExitPort02 = int.Parse(Console.ReadLine());
                    Console.Write("Enter a year: ");
                    int yearExitPort02 = int.Parse(Console.ReadLine());

                    DateTime exitRoute02Date = new DateTime(yearExitPort02, monthExitPort02, dayExitPort02);


                    if (yearExitPort02 < yearEntryPort02 || yearExitPort02 == yearEntryPort02 && monthExitPort02 == monthEntryPort02 && dayEntryPort02 > dayExitPort02 ||
                        yearExitPort02 == yearEntryPort02 && monthExitPort02 < monthEntryPort02 && dayEntryPort02 == dayExitPort02)
                    {//eğer giriş yılı çıkış yılından büyükse veya giriş çıkışın ayları ve yılları eşit fakat girin gün tarihi çıkışın gün tarihinden büyükse veya giriş ve çıkışın gün ve yılları eşit fakat
                        //girişin ay tarihi büyükse çıkışın ay tarihinden ise tarih yazımı yanlışı vardır.
                        Console.WriteLine("Giriş tarihi çıkış tarihinden sonra olamaz. Tekrar deneyiniz.");
                        Route();
                    }
                    else
                    {
                        i.route02Enter = entryRoute02Date;
                        i.route02Exit = entryRoute02Date;
                    }

                    // ROUTE 02  END


                    // ROUTE 03  START

                    Console.WriteLine("Write route 3. : ");
                    string port03 = Console.ReadLine();
                    i.Port03 = port03;
                    Console.WriteLine("Enter the entry date of route 3.");
                    Console.Write("Enter a month: ");
                    int monthEntryPort03 = int.Parse(Console.ReadLine());
                    Console.Write("Enter a day: ");
                    int dayEntryPort03 = int.Parse(Console.ReadLine());
                    Console.Write("Enter a year: ");
                    int yearEntryPort03 = int.Parse(Console.ReadLine());

                    DateTime entryRoute03Date = new DateTime(yearEntryPort03, monthEntryPort03, dayEntryPort03);



                    Console.WriteLine("Enter the exit date of route 3.");
                    Console.Write("Enter a month: ");
                    int monthExitPort03 = int.Parse(Console.ReadLine());
                    Console.Write("Enter a day: ");
                    int dayExitPort03 = int.Parse(Console.ReadLine());
                    Console.Write("Enter a year: ");
                    int yearExitPort03 = int.Parse(Console.ReadLine());

                    DateTime exitRoute03Date = new DateTime(yearExitPort03, monthExitPort03, dayExitPort03);

                    if (yearExitPort03 < yearEntryPort03 || yearExitPort03 == yearEntryPort03 && monthExitPort03 == monthEntryPort03 && dayEntryPort03 > dayExitPort03 ||
                   yearExitPort03 == yearEntryPort03 && monthExitPort03 < monthEntryPort03 && dayEntryPort03 == dayExitPort03)
                    {//eğer giriş yılı çıkış yılından büyükse veya giriş çıkışın ayları ve yılları eşit fakat girin gün tarihi çıkışın gün tarihinden büyükse veya giriş ve çıkışın gün ve yılları eşit fakat
                        //girişin ay tarihi büyükse çıkışın ay tarihinden ise tarih yazımı yanlışı vardır.
                        Console.WriteLine("Giriş tarihi çıkış tarihinden sonra olamaz. Tekrar deneyiniz.");
                        Route();
                    }
                    else
                    {
                        i.route03Enter = entryRoute03Date;
                        i.route03Exit = entryRoute03Date;
                    }
                    // ROUTE 03  END
                    count++;
                }

            }
            if (count == 0)
            {
                Console.WriteLine("{0} İsminde bir gemi bulunamadı. Tekrar denemek ister misiniz? (y/n)", inputShipName);
                string yesOrNo = Console.ReadLine();
                if (yesOrNo == "n")
                {
                    Questions();
                }
                if (yesOrNo == "y")
                {
                    Route();
                }
            }
            else
            {
                shipArt();
                Console.WriteLine("Gemi bilgileri başarıyla eklendi.");
                Questions();

            }




        }

        public void ProductProcess() //Ürün işlemleri metodu
        {
            Console.WriteLine("*******************************************");
            foreach (var i in ship)
            {
                Console.WriteLine(i.Name);
            }
            Console.WriteLine("Which ship? Enter ship name.");
            string inputShipName = Console.ReadLine();
            int countProduct = 0; //istenilen ürün var mı
            int countShipName = 0; //seçilen gemi var mı
            foreach (var i in ship)
            {
                if (inputShipName.ToLower() == i.Name.ToLower() || inputShipName.ToUpper() == i.Name.ToUpper() || inputShipName == i.Name)
                {
                    countShipName++;
                    foreach(string j in products)
                    {
                        Console.WriteLine(j);
                    }
                    Console.WriteLine();
                    Console.WriteLine("Enter the name of the product you want to buy or give away.");
                    string inputProductName = Console.ReadLine();
                    foreach (string item in products)
                    {
                        if (inputProductName.ToLower() == item || inputProductName.ToUpper() == item || inputProductName == item)
                        {
                            countProduct++;
                            Console.WriteLine("What do you want to do?");
                            Console.WriteLine("(1) The product will be loaded on the ship.");
                            Console.WriteLine("(2) The product will be delivered from the ship.");
                            short answer = Convert.ToInt16(Console.ReadLine());
                            if(answer == 1)
                            {
                                Console.WriteLine("How much do you want to upload? Capacity of the ship: {0}", i.Capacity);
                                Console.Write("Enter amount: ");
                                int amount = Convert.ToInt32(Console.ReadLine());
                                if (i.Capacity < amount)
                                {
                                    Console.WriteLine("The ship exceeds its capacity, try again.");
                                }
                                else
                                {
                                    i.amountOfReceivedProduct = amount;
                                    i.Capacity = i.Capacity - i.amountOfReceivedProduct;
                                    Console.WriteLine("The new capacity of the ship: "+ i.Capacity);
                                    Console.WriteLine("Amount received: {0}", i.amountOfReceivedProduct);
                                }
                            }else if(answer == 2)
                            {
                                Console.WriteLine("How much do you want to delivered? Capacity of the ship: {0}", i.Capacity);
                                //Zaman sorunundan dolayı geçtim burayı
                                Questions();
                            }
                            else
                            {
                                Console.WriteLine("You must enter 1 or 2, try again.");
                                ProductProcess();
                            }
                        }

                    }
                    if(countProduct>0 && countShipName > 0)
                    {
                        Console.WriteLine("İşlemler başarılı.");
                        Questions();
                        
                    }
                    else
                    {
                        Console.WriteLine("Ürün bulunamadı veya gemi ismi bulunamadı. Tekrar deneyiniz");
                        ProductProcess();
                    }
                
                     

                }
            }
        }
        public void List() //listeleme metodu
        {
            foreach(var item in ship)
            {
                Console.WriteLine("Ship Name : {0}", item.Name);
                Console.WriteLine("Ship Capacity : {0}", item.Capacity);
                Console.WriteLine("Ship Route 01 Name : {0}", item.Port01);
                Console.WriteLine("Ship Route 01 Entry Date: {0}", item.route01Enter);
                Console.WriteLine("Ship Route 01 Exit Date: {0}", item.route01Exit);
                Console.WriteLine("Ship Route 02 Name : {0}", item.Port02);
                Console.WriteLine("Ship Route 02 Entry Date: {0}", item.route02Enter);
                Console.WriteLine("Ship Route 02 Exit Date: {0}", item.route02Exit);
                Console.WriteLine("Ship Route 03 Name : {0}", item.Port03);
                Console.WriteLine("Ship Route 03 Entry Date: {0}", item.route03Enter);
                Console.WriteLine("Ship Route 03 Exit Date: {0}", item.route03Exit);
                shipArt();
            }
        } 
    }
}
