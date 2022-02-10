using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {}

        public virtual DbSet<BeerMark> BeerMarks { get; set; }

        public virtual DbSet<ProductionStatistic> ProductionStatictics { get; set; }
        
        public virtual DbSet<AppUser> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=../DB/BeerlandDB.db");
        }
    }
}