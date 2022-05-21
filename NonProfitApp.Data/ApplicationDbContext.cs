using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NonProfitApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace NonProfitApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
            {

            }
        public DbSet<UserEntity> Users { get; set; }       
        
        public DbSet<EventEntity> Events { get; set; }
        public DbSet<NonPEntity> NPEntities { get; set; }
        
    }
}
