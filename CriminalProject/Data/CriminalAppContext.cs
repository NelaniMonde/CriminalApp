using CriminalProject.Models;
using CriminalProject.UserActivityClasses;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CriminalProject.Data
{
    public class CriminalAppContext :IdentityDbContext
    {
        public CriminalAppContext(DbContextOptions<CriminalAppContext>options):base(options) 
        {
        
        
        
        }

      // public DbSet<Managers> Managers { get; set; }


        public DbSet<UserActivityLog> UserActivityLogs { get; set; }
        public DbSet<Suspects> Suspects { get; set; }
        public DbSet<CriminalRecords> CriminalRecord { get; set; }

        public DbSet<Manager> Managers { get; set; }

       // public DbSet<Cases> Case { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }  

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Incase of user login errors
            base.OnModelCreating(modelBuilder); 

            //Configuring one to many relationship between suspects and Criminal records
            modelBuilder.Entity<Suspects>()
                 .HasMany(a => a.CriminalRecords)
                 .WithOne(a => a.Suspects)
                 .HasForeignKey(a => a.SuspectNo)
                 .IsRequired();


            modelBuilder.Entity<Manager>()
                .HasMany(a => a.Criminals)
                .WithOne(a => a.Manager)
                .HasForeignKey(a => a.ManagerNoForeign)
                .IsRequired();



        }

      
    }
}
