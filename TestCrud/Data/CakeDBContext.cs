using Microsoft.EntityFrameworkCore;
using TestCrud.Data.Entities;

namespace TestCrud.Data
{
    public class CakeDBContext : DbContext
    {
        public DbSet<Cake> Cakes { get; set; }
        public CakeDBContext(DbContextOptions<CakeDBContext> options) : base(options)
        {
        }
    }
}
