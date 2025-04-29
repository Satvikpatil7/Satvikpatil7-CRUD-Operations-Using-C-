using Microsoft.EntityFrameworkCore;
using TodoApi.Models; // Import the Item model from the correct namespace

namespace TodoApi
{
    // This class represents the SQLite database context
    public class DummyDataContext : DbContext
    {
        // Constructor to initialize the context with options
        public DummyDataContext(DbContextOptions<DummyDataContext> options) : base(options) { }

        // Define DbSet properties for the tables in your database
        public DbSet<Item> Items { get; set; }

        // Add more DbSets for other entities if needed
    }
}
