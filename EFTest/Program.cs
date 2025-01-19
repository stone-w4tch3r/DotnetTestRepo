using Microsoft.EntityFrameworkCore;

namespace EFTest;

class Program
{
    static void Main()
    {
        using var context = new AppDbContext();
        
        context.Database.Migrate();

        try
        {
            // A query that includes a custom C# method call
            var results = context.Items.Where(_ => true);

            var materialized = results.ToArray();

        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    // A custom method that cannot be translated to SQL
    static bool CustomMethod(string input)
    {
        return true;
    }
}

public class AppDbContext : DbContext
{
    public DbSet<Item> Items { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=app.db");
    }
}

public class Item
{
    public int Id { get; set; }
    public string Name { get; set; }
}