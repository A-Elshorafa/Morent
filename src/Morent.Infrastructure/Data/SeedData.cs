namespace Morent.Infrastructure.Data;

public static class SeedData
{
  public const int NUMBER_OF_CONTRIBUTORS = 27; // including the 2 below

  public static async Task InitializeAsync(AppDbContext dbContext)
  {
    //if (await dbContext.Contributors.AnyAsync()) return; // DB has been seeded
  }
}
