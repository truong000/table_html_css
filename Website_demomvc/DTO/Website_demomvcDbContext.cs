﻿using Microsoft.EntityFrameworkCore;
using Website_demomvc.DTO;
using Website_demomvc.Models.Account;

namespace Website_demomvc.DAO
{
    public class Website_demomvcDbContext : DbContext
    {
        public Website_demomvcDbContext(DbContextOptions<Website_demomvcDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Account> Accounts { get; set; }                                          
        public DbSet<Website_demomvc.Models.Account.RegisterViewModel>? RegisterViewModel { get; set; }
        public DbSet<Website_demomvc.Models.Account.LoginViewModel>? LoginViewModel { get; set; }
    }
}

