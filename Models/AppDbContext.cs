using EmployeeMangement.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;  // Only the necessary using directive

public class AppDbContext : IdentityDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    // Add DbSets here
    public DbSet<Employee> Employees { get; set; }
    //part 51  applying seed data inside database inser  data into database//
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //part 64 idintity//
        base.OnModelCreating(modelBuilder);
        //part 64 idinty error migration
        modelBuilder.Seed();
    }
}