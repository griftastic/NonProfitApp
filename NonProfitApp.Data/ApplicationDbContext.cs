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
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, DbSet<NPEnitiy> nonProfit)
            : base(options)
        {
            NonProfit = nonProfit;
        }
        public DbSet<UserEntity> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
       
        
        public DbSet<EventEntity> Events { get; set; }
        

        public ApplicationDbContext(DbSet<NPEnitiy> nonProfit)
        {
            NonProfit = nonProfit;
        }
        public DbSet<NPEnitiy> NonProfit { get; set; }
    }
}
