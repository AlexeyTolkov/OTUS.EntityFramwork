namespace OTUS.EntityFramwork
{
    public class AvitoApplication
    {
        private readonly IClient _avClient;

        public AvitoApplication(IClient avClient)
        {
            _avClient = avClient;
        }

        public void Run()
        {
            _avClient.StartUI();
        }
    }
}