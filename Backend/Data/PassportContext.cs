using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PassportWebApplication.Models;
using System.Reflection.Emit;

namespace PassportWebApplication.Data
{
    public class PassportContext : IdentityDbContext<PassportUser>  
    {
        public PassportContext( DbContextOptions<PassportContext> options):base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<ServiceRquired> ServiceRquireds { get; set; }
        public DbSet<ApplicantDetails> ApplicantDetails { get; set; }
        public DbSet<FamilyDetails> FamilyDetails { get; set; }
        public DbSet<ResidentialDetails> ResidentialDetails { get; set; }
        public DbSet<EmergencyDetails> EmergencyDetails { get; set; }
        public DbSet<OtherDetails> OtherDetails { get; set; }
        public DbSet<Documents> Documents { get; set; }
        public DbSet<MasterDetails> MasterDetails { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            List<IdentityRole> Roles = new List<IdentityRole>
            {
                new IdentityRole(){
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole(){
                    Name = "User",
                    NormalizedName = "USER"
                }
            };
            builder.Entity<IdentityRole>().HasData(Roles);  //adding admin and user role in role table

            builder.Entity<MasterDetails>()
                                    .HasOne(md => md.User)  // Specify the navigation property
                                    .WithMany(u => u.Applications)  // Specify the inverse navigation property
                                    .HasForeignKey(md => md.UserId);
           
        }

    }
}
