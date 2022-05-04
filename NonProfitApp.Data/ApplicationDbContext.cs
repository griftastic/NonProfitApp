using Microsoft.EntityFrameworkCore;
using NonProfitApp.Data.Entities;

namespace NonProfitApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : base(options)
        {

        }
        public DbSet<UserEntity> Users { get; set; }
    }
}