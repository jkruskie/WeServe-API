using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WeServe.Models;

namespace WeServe.Data
{
    /// <summary>
    /// The database context for the WeServe application.
    /// </summary>
    /// <author>Justin Kruskie</author>
    /// <date>07/28/2023</date>
    public class WeServeContext : DbContext
    {
        /// <summary>
        /// Create a new instance of the WeServeContext.
        /// </summary>
        /// <param name="options"></param>
        /// <author>Justin Kruskie</author>
        /// <date>07/28/2023</date>
        public WeServeContext(DbContextOptions<WeServeContext> options) : base(options) { }

        /// <summary>
        /// The users in the database.
        /// </summary>
        /// <author>Justin Kruskie</author>
        /// <date>07/28/2023</date>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// The organizations in the database.
        /// </summary>
        /// <author>Justin Kruskie</author>
        /// <date>08/02/2023</date>
        public DbSet<Organization> Organizations { get; set; }

        /// <summary>
        /// Configure the models for the database context.
        /// </summary>
        /// <param name="modelBuilder"></param>
        /// <author>Justin Kruskie</author>
        /// <date>07/28/2023</date>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the models
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Organization>().ToTable("Organizations");

            // User belongs to an organization
            modelBuilder.Entity<User>()
                .HasOne(u => u.Organization)
                .WithMany(o => o.Users)
                .HasForeignKey(u => u.OrganizationId);

            // Organization has many users
            modelBuilder.Entity<Organization>()
                .HasMany(o => o.Users)
                .WithOne(u => u.Organization)
                .HasForeignKey(u => u.OrganizationId);

            // Default password
            var password = "password123$";
            // Hash the password
            var passwordHasher = new PasswordHasher<User>();
            var passwordHash = passwordHasher.HashPassword(null, password);

            // Seed the database
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FirstName = "Justin",
                    LastName = "Kruskie",
                    Email = "justin@jkruskie.com",
                    NormalizedEmail = "JUSTIN@JKRUSKIE.COM",
                    Role = "Admin",
                    PasswordHash = passwordHash
                },
                new User
                {
                    Id = 2,
                    FirstName = "Student",
                    LastName = "Account",
                    Email = "student@weserve.com",
                    NormalizedEmail = "STUDENT@WESERVE.COM",
                    Role = "Student",
                    PasswordHash = passwordHash
                },
                new User
                {
                    Id = 3,
                    FirstName = "Organization",
                    LastName = "Account",
                    Email = "organization@weserve.com",
                    NormalizedEmail = "ORGANIZATION@WESERVE.COM",
                    Role = "Organization",
                    OrganizationId = 1,
                    PasswordHash = passwordHash
                },
                new User
                {
                    Id = 4,
                    FirstName = "Moderator",
                    LastName = "Account",
                    Email = "moderator@weserve.com",
                    NormalizedEmail = "MODERATOR@WESERVE.COM",
                    Role = "Moderator",
                    PasswordHash = passwordHash
                },
                new User
                {
                    Id = 5,
                    FirstName = "Admin",
                    LastName = "Account",
                    Email = "admin@weserve.com",
                    NormalizedEmail = "ADMIN@WESERVE.COM",
                    Role = "Admin",
                    PasswordHash = passwordHash
                }
            );

            modelBuilder.Entity<Organization>().HasData(
                new Organization
                {
                    Id = 1,
                    Name = "Organization 1",
                    Description = "This is the first organization.",
                    Website = "https://www.google.com",
                    Email = "email@me.com",
                    PhoneNumber = "1234567890",
                    AddressLine1 = "123 Main St.",
                    City = "City",
                    State = "State",
                    ZipCode = "12345"
                },
                new Organization
                {
                    Id = 2,
                    Name = "Organization 2",
                    Description = "This is the second organization.",
                    Website = "https://www.google.com",
                    Email = "email@me.com",
                    PhoneNumber = "1234567890",
                    AddressLine1 = "123 Main St.",
                    City = "City",
                    State = "State",
                    ZipCode = "12345"
                }
            );
        }
    }
}
