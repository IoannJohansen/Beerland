using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<BeerMark> BeerMarks { get; set; }

        public virtual DbSet<ProductionStatistic> ProductionStatictics { get; set; }
        
        public virtual DbSet<User> Users { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=../DB/BeerlandDB.db");
        }
    }
}
