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
            optionsBuilder.UseSqlServer(@"www");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("C##BLOCKCHAIN");
        }
    }
    
}
