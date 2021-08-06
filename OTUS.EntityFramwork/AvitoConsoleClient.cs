using System;

namespace OTUS.EntityFramwork
{
    partial class AvitoConsoleClient : IConsoleClient
    {
        private ConsoleMenuScreen _currentMenuScreen;
        delegate void MenuHandler(string command);
        event MenuHandler CommandInput;

        public AvitoConsoleClient()
        {
            _currentMenuScreen = ConsoleMenuScreen.Main;
        }

        private void DrawScreen()
        {
            switch (_currentMenuScreen)
            {
                case ConsoleMenuScreen.Main:
                    Console.WriteLine("СПИСОК ДЕЙСТВИЙ:");
                    Console.WriteLine("[1] Вывод данных");
                    Console.WriteLine("[2] Пользовательский ввод");
                    Console.WriteLine("[3] Выход");

                    CommandInput = MainMenuSelect;
                    break;

                case ConsoleMenuScreen.UserInput:
                    Console.WriteLine("Таблицы:");
                    Console.WriteLine("[1] Продавцы");
                    Console.WriteLine("[2] Категории");
                    Console.WriteLine("[3] Объявления");

                    CommandInput = ;
                    break;

                default:
                    throw new ArgumentException();
            }  
        }

        public void GiveABestUserExperienceEver()
        {
            var command = "" ;
            while (command != "3")
            {
                DrawScreen();
                command = Console.ReadLine();
                CommandInput?.Invoke(command);
            }
        }

        private void MainMenuSelect(string command)
        {
            switch (command)
            {
                case "1":
                    //_avitoDBManager.ShowAllDataAsync()
                    break;

                case "2":
                    /*using (var db = new AvitoContext())
                    {
                        AddRecordToTable(db);
                    }*/
                    _currentMenuScreen = ConsoleMenuScreen.UserInput;
                    break;

                default:
                    Console.WriteLine("Команда не распознана");
                    break;
            }
        }

        private void UserInputMenuSelect(string command)
        {
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
    }
}