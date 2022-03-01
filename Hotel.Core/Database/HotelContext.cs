using Hotel.Core.Models;
using Hotel.Core.Models.ValueAddedService;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Core.Database;

public class HotelContext : DbContext
{
    public DbSet<Guest> Guests { get; set; }
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Apartment> Apartments { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<IValueAddedService> AddedServices { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder opts)
    {
        var dbCredentials = CredentialLoader.LoadDatabase();
        switch (dbCredentials.DbType)
        {
            case CredentialLoader.DatabaseType.MySQL:
                opts.UseMySQL($"Server={dbCredentials.Hostname};" +
                              $"database={dbCredentials.DatabaseName};" +
                              $"user={dbCredentials.Username};" +
                              $"password={dbCredentials.Password}");
                break;
            case CredentialLoader.DatabaseType.MongoDB:
                throw new NotImplementedException("This type of database (MongoDB) is currently unsupported");
                break;
            case CredentialLoader.DatabaseType.MicrosoftSQL:
            case CredentialLoader.DatabaseType.MsSQL:
                throw new NotImplementedException("This type of database (Microsoft-SQL) is currently unsupported");
                break;
            default:
                throw new NotImplementedException("This type of database is currently unsupported");
        }
    }
}