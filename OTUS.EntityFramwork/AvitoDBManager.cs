using System;

namespace OTUS.EntityFramwork
{
    public class AvitoDBManager : IDBManager
    {
        public void ShowAllData()
        {
            using (AvitoContext db = new AvitoContext())
            {
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

        public void AddRecordToTable(AvitoContext db, IUserInput tableContext)
        {
            tableContext.ShowTableFields();

            var userInput = Console.ReadLine();
            if (userInput != "")
            { 
                tableContext.ParseFromCSV(userInput);
                tableContext.SaveChanges(db);
            }
        }
    }
}