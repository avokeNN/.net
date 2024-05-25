using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Viktorina.Models;

public class DataBase : DbContext
{
    private readonly IConfiguration _configuration;

    public DbSet<Users> Users { get; set; }
    public DbSet<Quizzes> Quizzes { get; set; }
    public DbSet<Questions> Questions { get; set; }
    public DbSet<Answers> Answers { get; set; }
    public DbSet<Participant_Responses> Participant_Responses { get; set; }
    public DbSet<Role> Roles { get; set; } // Corrected DbSet property name to Roles

    public DataBase(DbContextOptions<DataBase> options, IConfiguration configuration)
    : base(options)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Configure your model here if needed
    }
}
