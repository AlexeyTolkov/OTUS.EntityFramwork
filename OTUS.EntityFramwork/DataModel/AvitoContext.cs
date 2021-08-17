using System.Data.Entity;

public class AvitoContext : DbContext
{
    public AvitoContext()
        : base("MSSQL_Avito_AdDB")
    {
        Database.SetInitializer<AvitoContext>(new MyContextInitializer());
    }

    public DbSet<Advertisement> Advertisements { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Seller> Sellers { get; set; }
}