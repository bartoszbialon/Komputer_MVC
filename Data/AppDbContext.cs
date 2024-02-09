using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<ComputerEntity> Computers { get; set; }
        public DbSet<ProducerEntity> Producers { get; set; }    
        public DbSet<TypeEntity> Types { get; set; }


        private string DbPath { get; set; }

        public AppDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "computers.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //// ADMIN ////
            string ADMIN_ID = Guid.NewGuid().ToString();
            string ADMIN_ROLE_ID = Guid.NewGuid().ToString();


            // Dodanie roli administratora
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "admin",
                NormalizedName = "ADMIN",
                Id = ADMIN_ROLE_ID,
                ConcurrencyStamp = ADMIN_ROLE_ID
            });

            // Utworzenie administratora jako użytkownika
            var admin = new IdentityUser
            {
                Id = ADMIN_ID,
                Email = "adam@wsei.edu.pl",
                EmailConfirmed = true,
                UserName = "adam",
                NormalizedUserName = "ADAM",
                NormalizedEmail = "ADAM@WSEI.EDU.PL"
            };

            // Hashowanie hasła
            PasswordHasher<IdentityUser> ph = new PasswordHasher<IdentityUser>();
            admin.PasswordHash = ph.HashPassword(admin, "1234abcd!@#$ABCD");


            // Zapisanie użytkownika
            modelBuilder.Entity<IdentityUser>().HasData(admin);

            // Przypisanie roli administratora użytkownikowi
            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasData(new IdentityUserRole<string>
                {
                    RoleId = ADMIN_ROLE_ID,
                    UserId = ADMIN_ID
                });



            //// USER ////
            string USER_ID = Guid.NewGuid().ToString();
            string USER_ROLE_ID = Guid.NewGuid().ToString();

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "user",
                NormalizedName = "USER",
                Id = USER_ROLE_ID,
                ConcurrencyStamp = USER_ROLE_ID
            });

            var user = new IdentityUser
            {
                Id = USER_ID,
                Email = "jan@microsoft.wsei.edu.pl",
                EmailConfirmed = true,
                UserName = "jan",
                NormalizedUserName = "JAN",
                NormalizedEmail = "JAN@MICROSOFT.WSEI.EDU.PL"
            };

            PasswordHasher<IdentityUser> userPh = new PasswordHasher<IdentityUser>();
            user.PasswordHash = userPh.HashPassword(user, "cEkLb#ns#4");

            modelBuilder.Entity<IdentityUser>().HasData(user);

            modelBuilder.Entity<IdentityUserRole<string>>() 
                .HasData(new IdentityUserRole<string>
                {
                    RoleId = USER_ROLE_ID,
                    UserId = USER_ID   
                });


            modelBuilder.Entity<ComputerEntity>()
                .HasOne(e => e.Producer)
                .WithMany(e => e.Computers)
                .HasForeignKey(e => e.ProducerId);

            modelBuilder.Entity<ComputerEntity>()
                .HasOne(e => e.Type)
                .WithMany(e => e.Computers)
                .HasForeignKey(e => e.TypeId);

            modelBuilder.Entity<TypeEntity>().HasData(
                new TypeEntity { TypeId = 1, TypeName = "Laptop"},
                new TypeEntity { TypeId = 2, TypeName = "Komputer stacjonarny"},
                new TypeEntity { TypeId = 3, TypeName = "Komputer do gier" },
                new TypeEntity { TypeId = 4, TypeName = "Chromebook" },
                new TypeEntity { TypeId = 5, TypeName = "Ultrabook" },  
                new TypeEntity { TypeId = 6, TypeName = "All-In-One" }
                );

            modelBuilder.Entity<ProducerEntity>().HasData(
                new ProducerEntity { ProducerId = 1, Name = "Dell", OriginCountry = "USA", FoundationYear = new DateTime(1984, 2, 1), Description = "Dell Inc. to amerykańska firma zajmująca się produkcją komputerów, w tym laptopów.", Street = "One Dell Way", City = "Round Rock", PostalCode = "78682", Region = "Texas" },
                new ProducerEntity { ProducerId = 2, Name = "HP", OriginCountry = "USA", FoundationYear = new DateTime(1939, 1, 1), Description = "HP Inc. to amerykańska firma zajmująca się produkcją sprzętu komputerowego, w tym komputerów stacjonarnych.", Street = "1501 Page Mill Road", City = "Palo Alto", PostalCode = "94304", Region = "California" },
                new ProducerEntity { ProducerId = 3, Name = "Alienware", OriginCountry = "USA", FoundationYear = new DateTime(1996, 1, 1), Description = "Alienware to marka komputerów do gier i akcesoriów, należąca do Dell Inc.", Street = "One Dell Way", City = "Round Rock", PostalCode = "78682", Region = "Texas" },
                new ProducerEntity { ProducerId = 4, Name = "Google", OriginCountry = "USA", FoundationYear = new DateTime(1998, 9, 4), Description = "Google LLC to globalna firma technologiczna, znana m.in. z systemu operacyjnego Chrome OS, który jest używany w Chromebookach.", Street = "1600 Amphitheatre Parkway", City = "Mountain View", PostalCode = "94043", Region = "California" },
                new ProducerEntity { ProducerId = 5, Name = "Asus", OriginCountry = "Taiwan", FoundationYear = new DateTime(1989, 4, 2), Description = "AsusTek Computer Inc. to tajwańska firma zajmująca się produkcją sprzętu komputerowego, w tym Ultrabooków.", Street = "No. 15, Li-Te Road", City = "Beitou District", PostalCode = "112", Region = "Taipei" },
                new ProducerEntity { ProducerId = 6, Name = "Apple", OriginCountry = "USA", FoundationYear = new DateTime(1976, 4, 1), Description = "Apple Inc. to amerykańska firma technologiczna, która produkuje m.in. komputery All-In-One, takie jak iMac.", Street = "1 Apple Park Way", City = "Cupertino", PostalCode = "95014", Region = "California" }
                );

            modelBuilder.Entity<ComputerEntity>().HasData(
                new ComputerEntity { ComputerId = 1, Name = "Dell XPS 13", Processor = "Intel Core i7", Memory = "16 GB DDR4", HardDrive = "512 GB SSD", GraphicsCard = "Intel Iris Xe Graphics", ProductionDate = new DateTime(2023, 5, 15), TypeId = 1, ProducerId = 1 },
                new ComputerEntity { ComputerId = 2, Name = "HP Pavilion Desktop", Processor = "AMD Ryzen 7", Memory = "32 GB DDR4", HardDrive = "1 TB SSD", GraphicsCard = "NVIDIA GeForce RTX 3060", ProductionDate = new DateTime(2023, 8, 20), TypeId = 2, ProducerId = 2 },
                new ComputerEntity { ComputerId = 3, Name = "Alienware Aurora R12", Processor = "Intel Core i9", Memory = "64 GB DDR4", HardDrive = "2 TB NVMe SSD", GraphicsCard = "NVIDIA GeForce RTX 3080", ProductionDate = new DateTime(2023, 7, 10), TypeId = 3, ProducerId = 3 },
                new ComputerEntity { ComputerId = 4, Name = "Google Pixelbook Go", Processor = "Intel Core i5", Memory = "8 GB RAM", HardDrive = "128 GB SSD", GraphicsCard = "Intel UHD Graphics 615", ProductionDate = new DateTime(2023, 9, 5), TypeId = 4, ProducerId = 4 },
                new ComputerEntity { ComputerId = 5, Name = "Asus ZenBook 14", Processor = "Intel Core i7", Memory = "16 GB LPDDR4X", HardDrive = "1 TB PCIe SSD", GraphicsCard = "Intel Iris Xe Graphics", ProductionDate = new DateTime(2023, 6, 25), TypeId = 5, ProducerId = 5 },
                new ComputerEntity { ComputerId = 6, Name = "Apple iMac 27-inch", Processor = "Apple M1", Memory = "16 GB unified memory", HardDrive = "512 GB SSD", GraphicsCard = "Apple M1 GPU", ProductionDate = new DateTime(2023, 4, 30), TypeId = 6, ProducerId = 6 }
                );
        }

    }
}
