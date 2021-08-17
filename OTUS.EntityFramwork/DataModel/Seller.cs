using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

public class Seller : IUserInput
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }

    public virtual ICollection<Advertisement> Advertisement { get; set; }
    public Seller()
    {
        Advertisement = new List<Advertisement>();
    }
    public override string ToString()
    {
        return $"Продавец: {Name}; {Phone}; {Email}";
    }
    public void ParseFromCSV(string input, string delimeter = ";")
    {
        var listOfFields = input.Split(delimeter).ToList();
        if (listOfFields.Count == GetTableFields().Count)
        {
            Name = listOfFields[0];
            Phone = listOfFields[1];
            Email = listOfFields[2];
        }
    }

    public List<string> GetTableFields()
    {
        return new List<string>() { "Name", "Phone", "Email" };
    }

    public void SaveChanges(AvitoContext db)
    {
        if (db != null)
        {
            db.Sellers.Add(this);
            db.SaveChanges();
            Console.WriteLine("Запись добавлена..");
        }
    }
}