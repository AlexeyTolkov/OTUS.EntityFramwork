using System;

namespace OTUS.EntityFramwork
{
    partial class AvitoConsoleClient : IConsoleClient
    {
        enum ConsoleMenuScreen
        {
            Main = 0,
            UserInput = 1
        }

        private AvitoDBManager _avitoDBManager;
        private ConsoleMenuScreen _currentMenuScreen;
        delegate void MenuHandler(string command);
        event MenuHandler CommandInput;

        public AvitoConsoleClient(AvitoDBManager avitoDBManager)
        {
            _avitoDBManager = avitoDBManager;
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
                    Console.WriteLine("[q] Выход");

                    CommandInput = MainMenuSelect;
                    break;

                case ConsoleMenuScreen.UserInput:
                    Console.WriteLine("Таблицы:");
                    Console.WriteLine("[1] Продавцы");
                    Console.WriteLine("[2] Категории");
                    Console.WriteLine("[3] Объявления");

                    CommandInput = UserInputMenuSelect;
                    break;

                default:
                    throw new ArgumentException();
            }  
        }

        public void GiveABestUserExperienceEver()
        {
            var command = "" ;
            while (command.ToLower() != "q")
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
                    _avitoDBManager.ShowAllDataAsync();
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
            var db = new AvitoContext();
            switch (command)
            {
                case "1":
                    var seller = new Seller();
                    _avitoDBManager.AddRecordToTable(db, seller);
                    break;

                case "2":
                    var category = new Category();
                    _avitoDBManager.AddRecordToTable(db, category);
                    break;

                case "3":
                    var advertisement = new Advertisement();
                    _avitoDBManager.AddRecordToTable(db, advertisement);
                    break;

                default:
                    Console.WriteLine("Команда не распознана");
                    break;
            }
        }
    }
}