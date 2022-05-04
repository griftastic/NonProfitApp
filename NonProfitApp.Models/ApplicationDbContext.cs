using Microsoft.EntityFrameworkCore;
using NonProfitApp.Data.Entities;

namespace NonProfitApp.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options)
        :base(options)
        {
            
        }
        public DbSet <UserEntity> Volunteer {get;set;}
    }
}