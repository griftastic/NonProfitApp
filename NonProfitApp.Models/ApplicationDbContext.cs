using Microsoft.EntityFrameworkCore;
using NonProfitApp.Data.Entities;

namespace NonProfitApp.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet <UserEntity> Volunteer {get;set;}
    }
}