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
            optionsBuilder.UseOracle(@"Data Source=192.168.1.100:1521/orcl;User Id = C##BLOCKCHAIN; Password = BLOCKCHAIN");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("C##BLOCKCHAIN");
        }
    }
    
}
