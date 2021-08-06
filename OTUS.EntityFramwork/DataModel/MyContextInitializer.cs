using System.Collections.Generic;
using System.Data.Entity;

class MyContextInitializer : DropCreateDatabaseAlways<AvitoContext>
{
    protected override void Seed(AvitoContext db)
    {
        System.Console.WriteLine("Инициализация БД..");

        // создаем продавцев
        Seller seller1 = new Seller { Name = "Пётр Иванов", Phone = "+79876543210", Email = "seller1@mail.ru" };
        Seller seller2 = new Seller { Name = "Темофей Завгорудний", Phone = "+79876543211", Email = "seller2@mail.ru" };
        Seller seller3 = new Seller { Name = "Алексей Толков", Phone = "+79876543212", Email = "seller3@mail.ru" };
        Seller seller4 = new Seller { Name = "Тимофей Прокопьев", Phone = "+79876543213", Email = "seller4@mail.ru" };
        Seller seller5 = new Seller { Name = "Марья Стервятникова", Phone = "+79876543214", Email = "seller5@mail.ru" };
        db.Sellers.AddRange(new List<Seller> { seller1, seller2, seller3, seller4, seller5 });

        // заполняем категории товаров
        Category cat1 = new Category { Name = "Телефоны" };
        Category cat2 = new Category { Name = "Автомобили" };
        Category cat3 = new Category { Name = "Недвижимость" };
        Category cat4 = new Category { Name = "Антиквариат" };
        Category cat5 = new Category { Name = "Скот" };
        db.Categories.AddRange(new List<Category> { cat1, cat2, cat3, cat4, cat5 });

        // заводим объявления
        Advertisement ad1 = new Advertisement { Description = "Nokia Тройка - надежный аппарат. Не заменим, в современной России!", Price = 1000f, Seller = seller1, Category = cat1 };
        Advertisement ad2 = new Advertisement { Description = "Лада седан вишневая - не битая, не крашеная, 1987гв", Price = 40000f, Seller = seller2, Category = cat2 };
        Advertisement ad3 = new Advertisement { Description = "Дача с насаждениями, 6 соток, дом 20кв.м., п.Желуди", Price = 300000f, Seller = seller3, Category = cat3 };
        Advertisement ad4 = new Advertisement { Description = "Картина неизвестного писателя, очень ценная! Обмен не интересует!", Price = 500f, Seller = seller4, Category = cat4 };
        Advertisement ad5 = new Advertisement { Description = "Корова Машка, 7 лет, удой шикарный! Торг!", Price = 50000f, Seller = seller5, Category = cat5 };
        Advertisement ad6 = new Advertisement { Description = "Кролики домашние: Петька и Ванька!", Price = 100f, Seller = seller5, Category = cat5 };
        db.Advertisements.AddRange(new List<Advertisement> { ad1, ad2, ad3, ad4, ad5, ad6 });

        db.SaveChanges();
    }
}