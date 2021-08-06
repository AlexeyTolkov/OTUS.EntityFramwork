using System;
using System.Linq;
using System.Threading.Tasks;

namespace OTUS.EntityFramwork
{
    class Program
    {
        static void Main(string[] args)
        {
            //var avConsole = new AvitoConsoleClient();
            //var avManager = new AvitoDBManager();

            //var app = avitoApplication();


            Console.WriteLine("СПИСОК ДЕЙСТВИЙ:");
            Console.WriteLine("[1] Вывод данных");
            Console.WriteLine("[2] Пользовательский ввод");
            Console.WriteLine("[3] Выход");
            var command = Console.ReadLine();

            while (command != "3")
            {
                switch (command)
                {
                    case "1":
                        ShowAllDataAsync();
                        break;

                    case "2":
                        using (var db = new AvitoContext())
                        {
                            AddRecordToTable(db);
                        }
                        break;

                    default:
                        Console.WriteLine("Команда не распознана");
                        break;
                }

                command = Console.ReadLine();
            }
        }

        private static void AddRecordToTable(AvitoContext db)
        {
            Console.WriteLine("Таблицы:");
            Console.WriteLine("[1] Продавцы");
            Console.WriteLine("[2] Категории");
            Console.WriteLine("[3] Объявления");

            var command = Console.ReadLine();
            switch (command)
            {
                case "1":
                    var seller = new Seller();
                    GetUserInput(seller);
                    
                    db.Sellers.Add(seller);
                    db.SaveChanges();

                    Console.WriteLine("Запись добавлена..");
                    break;

                case "2":
                    var category = new Category();
                    GetUserInput(category);

                    db.Categories.Add(category);
                    db.SaveChanges();

                    Console.WriteLine("Запись добавлена..");
                    break;

                case "3":
                    var advertisement = new Advertisement();
                    GetUserInput(advertisement);

                    db.Advertisements.Add(advertisement);
                    db.SaveChanges();

                    Console.WriteLine("Запись добавлена..");
                    break;

                default:
                    Console.WriteLine("Команда не распознана");
                    break;
            }
        }

        private static void GetUserInput(IUserInput table)
        {
            table.ShowTableFields();

            var userInput = Console.ReadLine();
            table.ParseFromCSV(userInput);
        }

        private static void ShowAllData()
        {
            using (AvitoContext db = new AvitoContext())
            {
                /*var catGroups = db.Advertisements.GroupBy(p => p.Category); 
                foreach (var catGroup in catGroups)
                {
                    Console.WriteLine(catGroup.Key);
                    foreach (var advert in catGroup)
                    {
                        Console.WriteLine("\t" + advert);
                        Console.WriteLine("\t\t" + advert.Seller);
                    }
                }*/
                
                foreach (var cat in db.Categories)
                {
                    Console.WriteLine(cat);
                }

                foreach (var seller in db.Sellers)
                {
                    Console.WriteLine(seller);
                }

                foreach (var ad in db.Advertisements)
                {
                    Console.WriteLine(ad);
                }
            }
        }
        private static void ShowAllDataAsync()
        {
            Task.Run(ShowAllData);
        }
    }
}