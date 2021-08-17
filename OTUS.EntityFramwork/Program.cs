namespace OTUS.EntityFramwork
{
    partial class Program
    {
        static void Main(string[] args)
        {
            var avManager = new AvitoDBManager();
            IClient avConsole = new AvitoConsoleClient(avManager);

            var app = new AvitoApplication(avConsole);
            app.Run();
        }
    }
}