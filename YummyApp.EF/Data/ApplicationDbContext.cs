using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using YummyApp.Core.Models.HomeModels;
using YummyApp.Core.Models.AdminModels;
using Microsoft.AspNetCore.Identity;

namespace YummyApp.EF.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<MenuCategory>().HasData(
                new MenuCategory {Id = 1, Name = "Breakfast" },
                new MenuCategory {Id = 2, Name = "Lunch" },
                new MenuCategory {Id = 3, Name = "Dinner" }
                );

            // *** Add Role ***

                //GUID 
            string ADMIN_ROLE_ID = "777be5d1-ad6a-4632-a0ee-23e28493a5ed";
            string CHEF_ROLE_ID = "7d7aa759-69fc-45f5-8b48-b7c7c3552501";
            string USER_ROLE_ID = "f2e024b4-8f6e-40a8-bbf2-2faa1418ab79";

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = ADMIN_ROLE_ID,
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR",
                    ConcurrencyStamp = ADMIN_ROLE_ID
                },
                new IdentityRole
                {
                    Id = CHEF_ROLE_ID,
                    Name = "Chef",
                    NormalizedName = "CHEF",
                    ConcurrencyStamp = CHEF_ROLE_ID
                },
                new IdentityRole
                {
                    Id = USER_ROLE_ID,
                    Name = "User",
                    NormalizedName = "USER",
                    ConcurrencyStamp = USER_ROLE_ID
                }
                );


            // *** Add Admin User ***

                //GUID
            string ADMIN_ID = "a65e2d46-2033-4d15-81fc-6ad50d3e904b";

            var AdminUser = new ApplicationUser
            {
                Id = ADMIN_ID,
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                FirstName = "Admin",
                LastName = "Admin",
                JobTitle = "Master Admin",
                PhoneNumber = "1234567890", 
                UserName = "admin@admin.com",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                UserType = UserType.Administrator   
            };

                //Password Hasher
            PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
            AdminUser.PasswordHash = passwordHasher.HashPassword(AdminUser, "admin");

            builder.Entity<ApplicationUser>().HasData(AdminUser);


            // *** Add Role To Admin User ***

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { 
                    RoleId = ADMIN_ROLE_ID, 
                    UserId = ADMIN_ID 
                }
                );

            base.OnModelCreating(builder);
        }

        public DbSet<MenuCategory> MenuCategories { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<PhotoAlbum> PhotoAlbums { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Event> Events { get; set; }



    }
}