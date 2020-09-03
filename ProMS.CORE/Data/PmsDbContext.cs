using Microsoft.EntityFrameworkCore;
using ProMS.CORE.Models.Project;
using ProMS.CORE.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProMS.CORE.Data
{
    public sealed class PmsDbContext : DbContext
    {
        public PmsDbContext(DbContextOptions<PmsDbContext> options) :
            base(options)
        { }

        public DbSet<UserModel> Users { get; set; }

        public DbSet<ProjectModel> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>().HasData(
                    new UserModel
                    {
                        Id = 1,
                        Username = "befx",
                        Password = "UJEs6M6$",
                        Firstname = "ბესიკ",
                        Lastname = "ქრისტესიაშვილი",
                        Email = "besysfx@gmail.com",
                        PhoneNum = "+995595191690",
                        SkypeContact = "besusfx",
                        DoB = new DateTime(1989, 04, 24).Date.ToString(),
                        RoleMember = PmsUserRoles.Admin.ToString(),
                        Projects = null
                    });
            modelBuilder.Entity<UserModel>().HasData(
                   new UserModel
                   {
                       Id = 2,
                       Username = "nucci95",
                       Password = "NUCiko26",
                       Firstname = "ნინო",
                       Lastname = "ჭუმბურიძე",
                       Email = "nuci.chumburidze.95@gmail.com",
                       PhoneNum = "+995598191670",
                       SkypeContact = "nucci.95",
                       DoB = new DateTime(1995, 05, 01).Date.ToString(),
                       RoleMember = PmsUserRoles.Manager.ToString(),
                       Projects = null
                   });
            modelBuilder.Entity<UserModel>().HasData(
                   new UserModel
                   {
                       Id = 3,
                       Username = "test123",
                       Password = "Test1234",
                       Firstname = "testUser",
                       Lastname = "TestUser",
                       Email = "testUser@gmail.com",
                       PhoneNum = "+995598123456",
                       SkypeContact = "test.123",
                       DoB = new DateTime(1995, 05, 01).Date.ToString(),
                       RoleMember = PmsUserRoles.Client.ToString(),
                       Projects = null
                   });

            base.OnModelCreating(modelBuilder);
        }
    } 
}
