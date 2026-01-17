using Morent.Core.Entities;

namespace Morent.Infrastructure.Data;
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
  public DbSet<Car> Cars => Set<Car>();
  public DbSet<CarCompany> CarCompanies => Set<CarCompany>();
  public DbSet<CarReview> CarReviews => Set<CarReview>();
  public DbSet<CarTransaction> CarTransactions => Set<CarTransaction>();
  public DbSet<CarType> CarTypes => Set<CarType>();
  public DbSet<Location> Locations => Set<Location>();
  public DbSet<User> Users => Set<User>();
  public DbSet<UserPreference> UserPreferences => Set<UserPreference>();

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    
    modelBuilder.Entity<CarReview>()
      .HasOne(r => r.Car)
      .WithMany(u => u.Reviews)
      .HasForeignKey(r => r.CarId)
      .OnDelete(DeleteBehavior.Cascade);

    modelBuilder.Entity<CarReview>()
      .HasOne(r => r.User)
      .WithMany()
      .HasForeignKey(r => r.UserId)
      .OnDelete(DeleteBehavior.Restrict);
    
    modelBuilder.Entity<CarTransaction>()
      .HasOne(t => t.PickupLocation)
      .WithMany()
      .HasForeignKey(t => t.PickupLocationId)
      .OnDelete(DeleteBehavior.Restrict);

    modelBuilder.Entity<CarTransaction>()
      .HasOne(t => t.DropOfLocation)
      .WithMany()
      .HasForeignKey(t => t.DropOfLocationId)
      .OnDelete(DeleteBehavior.Restrict);
    
    modelBuilder.Entity<CarTransaction>()
      .HasOne(t => t.Renter)
      .WithMany()
      .HasForeignKey(t => t.RenterId)
      .OnDelete(DeleteBehavior.Restrict);

    modelBuilder.Entity<UserPreference>()
      .HasOne(r => r.User)
      .WithMany(u => u.Preferences)
      .HasForeignKey(r => r.UserId)
      .OnDelete(DeleteBehavior.Restrict);
    
    modelBuilder.Entity<UserPreference>()
      .HasOne(r => r.Car)
      .WithMany()
      .HasForeignKey(r => r.CarId)
      .OnDelete(DeleteBehavior.Restrict);
  }

  public override int SaveChanges() =>
        SaveChangesAsync().GetAwaiter().GetResult();
}
