using System;
using AwesomeShop.BusinessLogic.Accounts.Interfaces;
using Microsoft.EntityFrameworkCore;
using AwesomeShop.Data.Models;

namespace AwesomeShop.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IHasher _hasher;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHasher hasher)
            : base(options)
        {
            _hasher = hasher;
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<DeliveryCountry> DeliveryCountries { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<User> Members { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<DeliveryCountry>(entity =>
            {
                entity.ToTable("DeliveryCountry");

                entity.HasIndex(e => e.CountryName, "UQ__Delivery__E056F20110CD0BBF")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ManufacturerId).HasColumnName("ManufacturerID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Manufacturer)
                    .WithMany(p => p.DeliveryCountries)
                    .HasForeignKey(d => d.ManufacturerId)
                    .HasConstraintName("FK_ProductsManufacturers_Products");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.DeliveryCountries)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_ProductsManufacturers_Categories");
            });

            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(35);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(35);

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(45);
            });

            

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Cost).HasColumnType("money");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.CreationDate).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.HasMany(product => product.Categories).WithMany(category => category.Products);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Members");

            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(25);
            });

            var testData = new TestData(_hasher);
            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasData(testData.AdminRole, testData.MemberRole);
            });
            
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Members_Roles");

                entity.HasData(testData.Admin);
            });
        }

    }

    public class TestData
    {
        public User Admin { get; }
        
        public Role AdminRole { get; }
        
        public Role MemberRole { get; }

        public TestData(IHasher hasher)
        {
            AdminRole = new()
            {
                Name = "Admin",
                Id = Guid.NewGuid()
            };
            
            MemberRole = new()
            {
                Name = "Member",
                Id = Guid.NewGuid()
            };

            Admin = new()
            {
                Id = Guid.NewGuid(),
                BirthDate = new(2000, 1, 1),
                Username = "admin",
                RoleId = AdminRole.Id
            };
            Admin.PasswordHash = hasher.HashPassword(Admin, "password");
        }
    }
}
