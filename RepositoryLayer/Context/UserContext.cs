using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Context
{
    public class UserContext : DbContext
    {
     
        public UserContext(DbContextOptions options) : base(options)
       {

            }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=IN-BMYKYD3;Database=FundooNotesDB;Trusted_Connection=True");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
               .HasIndex(u => u.Email)
               .IsUnique();


            modelBuilder.Entity<Collaboration>().HasKey(sc => new { sc.UserId, sc.Id });
            modelBuilder.Entity<Label>().HasKey(sc => new { sc.LabelId });



            modelBuilder.Entity<Collaboration>()
                .HasOne<User>(sc => sc.User)
                .WithMany(s => s.Collaborations)
                .HasForeignKey(sc => sc.UserId);


            modelBuilder.Entity<Collaboration>()
                .HasOne<Notes>(sc => sc.Notes)
                .WithMany(s => s.Collaborations)
                .HasForeignKey(sc => sc.Id);

            modelBuilder.Entity<Label>()
                .HasOne<User>(sc => sc.User)
                .WithMany(s => s.Labels)
                .HasForeignKey(sc => sc.UserId);

            modelBuilder.Entity<Label>()
                .HasOne<Notes>(sc => sc.Notes)
                .WithMany(s => s.Labels)
                .HasForeignKey(sc => sc.Id);

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

            modelBuilder.Entity<Notes>().HasData(new Entity.Notes
            {
                Id = 1,
                Title = "New Note",
                Message = "Hello, this is my new note",
                Image = "abc.jpg",
                Color = "White",
                IsPin = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                AddReminder = DateTime.MinValue,
                UserId = 15,
                IsArchive = false,
                IsNote = true,
                IsTrash = false

            });
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Notes> Notes { get; set; }
        public DbSet<Collaboration> Collaborations { get; set; }
        public DbSet<Label> Labels { get; set; }



    }
}


    //public class UserContext : DbContext
    //{
    //    public UserContext(DbContextOptions options) : base(options)
    //    {

    //    }
    //    public DbSet<User> Users { get; set; }

    //    public DbSet<Notes> Notes { get; set; }


    //    protected override void OnModelCreating(ModelBuilder modelBuilder)
    //    {
    //        modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();

    //        modelBuilder.Entity<User>().HasData(new User
    //        {
    //            UserId = 1,
    //            FirstName = "Uncle",
    //            LastName = "Bob",
    //            Email = "uncle.bob@gmail.com",
    //            Password = "1234",
    //            CreatedAt = new DateTime(2020, 02, 02),
    //            ModifiedAt = new DateTime(2020, 02, 02)

    //        }, new User
    //        {
    //            UserId = 2,
    //            FirstName = "Aunty",
    //            LastName = "Bob",
    //            Email = "aunty.bob@gmail.com",
    //            Password = "1234",
    //            CreatedAt = new DateTime(2020, 02, 02),
    //            ModifiedAt = new DateTime(2020, 02, 02)
    //        }
    //        );

    //        modelBuilder.Entity<Notes>().HasData(new Entity.Notes
    //        {
    //            Id = 1,
    //            Title = "FirstNote",
    //            Message = "This is my first note",
    //            Image = "image1",
    //            Color = "Blue",
    //            IsPin = false,
    //            CreatedDate = DateTime.Now,
    //            ModifiedDate = DateTime.Now,
    //            AddReminder = DateTime.MinValue,
    //            UserId = 3,
    //            IsArchive = false,
    //            IsNote = false,
    //            IsTrash = false,

    //        });


    //    }

    //}


