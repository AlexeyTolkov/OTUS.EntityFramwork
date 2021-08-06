using System.Collections.Generic;
using System.Linq;

public class Advertisement : IUserInput
{
    public int Id { get; set; }
    public string Description { get; set; }
    public float Price { get; set; }
    public int? SellerId { get; set; }
    public virtual Seller Seller { get; set; }
    public int? CategoryId { get; set; }
    public virtual Category Category { get; set; }
    public override string ToString()
    {
        return $"Объявление: {Id}; {Description}; <{Seller}>; <{Category}>; Цена: {Price}RUB";
    }
    
    public void ParseFromCSV(string input, string delimeter = ";")
    {
        var listOfFields = input.Split(delimeter).ToList();
        if (listOfFields.Count == GetTableFields().Count)
        {
            Description = listOfFields[0];
            Price = float.Parse(listOfFields[1]);
            SellerId = int.Parse(listOfFields[2]);
            CategoryId = int.Parse(listOfFields[3]);
        }
    }

    public List<string> GetTableFields()
    {
        return new List<string>() { "Description", "Price", "SellerId", "CategoryId" };
    }
}