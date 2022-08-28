using Microsoft.EntityFrameworkCore;
using Models;

public class MessagesContext : DbContext
{
    public DbSet<Message> Messages { get; set; }

    public string DbPath { get; }

    public MessagesContext(DbContextOptions<MessagesContext> options)
        : base(options)
    {
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=db;Database=master;User=sa;Password=1234;");
    }
}
