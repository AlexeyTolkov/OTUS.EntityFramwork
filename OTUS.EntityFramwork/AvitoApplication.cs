namespace OTUS.EntityFramwork
{
    public class AvitoApplication
    {
        private readonly IClient _avConsole;

        public AvitoApplication(IClient avConsole)
        {
            _avConsole = avConsole;
        }

        public void Run()
        {
            _avConsole.StartUI();
        }
    }
}