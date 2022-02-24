using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL;

public class ApplicationDbContext : IdentityDbContext<AppUser, IdentityRole, string>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public virtual DbSet<BeerMark> BeerMarks { get; set; }

    public virtual DbSet<ProductionUnit> ProductionUnits { get; set; }

    public virtual DbSet<ProductionHistory> ProductionHistories { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<ProductionUnit>().HasCheckConstraint("CHECK_ProductionUnit_State", "State in (0,1)");
        base.OnModelCreating(builder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=../DB/BeerlandDB.db");
    }
}