using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockchainClient.Models
{
    public class ApplicationContext : DbContext
    {

       
        public DbSet<Blockchain> Blockchains { get; set; }
        public DbSet<Block> Blocks { get; set; }
        public DbSet<User> BlockchainUser { get; set; }


       
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=SQL5097.site4now.net;Initial Catalog=DB_A6B093_witsky;User Id=DB_A6B093_witsky_admin;Password=5027028Pepsi");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("C##BLOCKCHAIN");
        }
    }
    
}
