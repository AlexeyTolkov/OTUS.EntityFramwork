using System;
using System.Collections.Generic;
using System.Linq;

public class Category : IUserInput
{
    public int Id { get; set; }
    public string Name { get; set; }

    public virtual ICollection<Advertisement> Advertisement { get; set; }
    public Category()
    {
        Advertisement = new List<Advertisement>();
    }
    public override string ToString()
    {
        return $"Категория: {Name}";
    }
    public void ParseFromCSV(string input, string delimeter = ";")
    {
        var listOfFields = input.Split(delimeter).ToList();
        if (listOfFields.Count == GetTableFields().Count)
        {
            Name = listOfFields[0];
        }
    }

    public List<string> GetTableFields()
    {
        return new List<string>() { "Name" };
    }

    public void SaveChanges(AvitoContext db)
    {
        if (db != null)
        {
            db.Categories.Add(this);
            db.SaveChanges();
            Console.WriteLine("Запись добавлена..");
        }
    }
}