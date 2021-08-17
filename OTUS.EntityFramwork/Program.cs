namespace OTUS.EntityFramwork
{
    partial class Program
    {
        static void Main(string[] args)
        {
            IDBManager avitoDBManager = new AvitoDBManager();
            IClient avitoConsoleClient = new AvitoConsoleClient(avitoDBManager);

            var avitoApp = new AvitoApplication(avitoConsoleClient);
            avitoApp.Run();
        }
    }
}