using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace VacationManager.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Vacation> Vacations { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ApplicationDbContext;");
            optionBuilder.UseLazyLoadingProxies();
        }
    }
}
