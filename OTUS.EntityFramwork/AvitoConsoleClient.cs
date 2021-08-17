using System;

namespace OTUS.EntityFramwork
{
    partial class AvitoConsoleClient : IClient
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

        public void StartUI()
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
                    _avitoDBManager.ShowAllData();
                    break;

                case "2":
                    _currentMenuScreen = ConsoleMenuScreen.UserInput;
                    break;

                case "q":
                    break;

                default:
                    Console.WriteLine("Команда не распознана");
                    break;
            }
        }

        private void UserInputMenuSelect(string command)
        {
            using (var db = new AvitoContext())
            {
                switch (command)
                {
                    case "1":
                        _avitoDBManager.AddRecordToTable(db, new Seller());
                        break;

                    case "2":
                        _avitoDBManager.AddRecordToTable(db, new Category());
                        break;

                    case "3":
                        _avitoDBManager.AddRecordToTable(db, new Advertisement());
                        break;

                    default:
                        Console.WriteLine("Команда не распознана");
                        break;
                }

                this.ChangeScreen(ConsoleMenuScreen.Main);
            }
        }

        private void ChangeScreen(ConsoleMenuScreen goToScreen)
        {
            _currentMenuScreen = goToScreen;
        }
    }
}