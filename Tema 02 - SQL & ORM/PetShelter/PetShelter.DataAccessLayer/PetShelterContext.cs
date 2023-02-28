using Microsoft.EntityFrameworkCore;
using PetShelter.DataAccessLayer.Configuration;
using PetShelter.DataAccessLayer.Models;

namespace PetShelter.DataAccessLayer;

public class PetShelterContext : DbContext
{
    public DbSet<Pet> Pets { get; set; }
    public DbSet<Person> Persons { get; set; }
    public DbSet<Donation> Donations { get; set; }

    public DbSet<Fundraiser> Fundraisers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PetShelterDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        //optionsBuilder.UseSqlServer(@"Server=localhost;Database=PetShelter;Trusted_Connection=True;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PetConfiguration());
        modelBuilder.ApplyConfiguration(new PersonConfiguration());
        modelBuilder.ApplyConfiguration(new DonationConfiguration());
    }
}