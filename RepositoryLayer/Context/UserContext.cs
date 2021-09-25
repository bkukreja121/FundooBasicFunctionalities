
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;




namespace RepositoryLayer.Context
{
    public class UserContext:DbContext
    {
        public UserContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
               .HasIndex(u => u.Email)
               .IsUnique();

            modelBuilder.Entity<User>().HasData(new User
            {
                UserId = 1,
                FirstName = "Uncle",
                LastName = "Bob",
                Email = "uncle.bob@gmail.com",
                Password = "1234",
                CreatedAt = new DateTime(2020, 02, 02),
                ModifiedAt = new DateTime(2020, 02, 02)

            }, new User
            {
                UserId = 2,
                FirstName = "Aunty",
                LastName = "Bob",
                Email = "aunty.bob@gmail.com",
                Password = "1234",
                CreatedAt = new DateTime(2020, 02, 02),
                ModifiedAt = new DateTime(2020, 02, 02)
            });


        }
        
    }
    
}
