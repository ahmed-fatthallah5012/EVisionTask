using Microsoft.EntityFrameworkCore;

namespace DomainModel.Models
{
    public sealed class SystemContext : DbContext
    {
        public SystemContext()
        {
            Database.Migrate();
        }

        public SystemContext(DbContextOptions<SystemContext> options):base(options)
        {
            Database.Migrate();
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasData(
                     new Customer
                     {
                         CustomerId = 1,
                         CustomerName = "Customer1",
                         Address = "Cairo, Nasr City"
                     },
                     new Customer
                     {
                         CustomerId = 2,
                         CustomerName = "Customer2",
                         Address = "Cairo, Maadi"
                     },
                     new Customer
                     {
                         CustomerId = 3,
                         CustomerName = "Customer3",
                         Address = "Cairo, 5th Settlement"
                     }
                    );
            });
            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.HasOne(c => c.Customer)
                    .WithMany(c => c.Vehicles)
                    .HasForeignKey(c => c.CustomerId)
                    .IsRequired()
                    .HasConstraintName("PK_Vehicle_Customer");

                entity.HasData(
                    new Vehicle
                    {
                        CustomerId = 1,
                        VehicleId = "YS2R4X20005399401",
                        RegisterNumber = "ABC123"
                    },
                    new Vehicle
                    {
                        CustomerId = 1,
                        VehicleId = "VLUR4X20009093588",
                        RegisterNumber = "DEF456"
                    },
                    new Vehicle
                    {
                        CustomerId = 1,
                        VehicleId = "VLUR4X20009048066",
                        RegisterNumber = "GHI789"
                    },
                    new Vehicle
                    {
                        CustomerId = 2,
                        VehicleId = "YS2R4X20005388011",
                        RegisterNumber = "JKL012"
                    },
                    new Vehicle
                    {
                        CustomerId = 2,
                        VehicleId = "YS2R4X20005387949",
                        RegisterNumber = "MNO345"
                    },
                    new Vehicle
                    {
                        CustomerId = 3,
                        VehicleId = "YS2R4X20005387765",
                        RegisterNumber = "PQR678"
                    },
                    new Vehicle
                    {
                        CustomerId = 3,
                        VehicleId = "YS2R4X20005387055",
                        RegisterNumber = "STU901"
                    }
                );
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}