using System;
using System.Collections.Generic;
using System.Data.Entity;

internal interface IUserInput
{
    public void ParseFromCSV(string input, string delimeter = ";");

    public List<string> GetTableFields();
    public void ShowTableFields()
    {
        string userPatternString = string.Join(";", GetTableFields());
        Console.WriteLine($"Формат ввода: {userPatternString}");
    }
    public void SaveChanges(DbContext db);
}