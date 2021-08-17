namespace OTUS.EntityFramwork
{
    public interface IDBManager
    {
        public void ShowAllData();
        public void AddRecordToTable(AvitoContext db, IUserInput tableContext);
    }
}