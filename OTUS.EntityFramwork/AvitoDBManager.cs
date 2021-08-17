using System;
using System.Threading.Tasks;

namespace OTUS.EntityFramwork
{
    public class AvitoDBManager 
    {
        public void ShowAllDataAsync()
        {
            Task.Run(ShowAllData);
        }

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

        public void AddRecordToTable(AvitoContext db, IUserInput table)
        {
            //GetUserInput(table); //TODO: rewrite

            table.ShowTableFields();
            var userInput = Console.ReadLine();
            table.ParseFromCSV(userInput);

            table.SaveChanges(db);
        }
    }
}