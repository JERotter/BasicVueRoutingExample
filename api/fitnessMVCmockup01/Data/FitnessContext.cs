using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using fitnessMVCmockup01.Models;

namespace fitnessMVCmockup01.Data
{
    public partial class FitnessContext : DbContext
    {
        public FitnessContext()
        {
        }

        public FitnessContext(DbContextOptions<FitnessContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contact> Contacts { get; set; } = null!;
        public virtual DbSet<Goal> Goals { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Workout> Workouts { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("Contact");

                entity.Property(e => e.ContactEmail).HasMaxLength(250);

                entity.Property(e => e.ContactMessage).HasMaxLength(500);

                entity.Property(e => e.ContactName).HasMaxLength(250);
            });

            modelBuilder.Entity<Goal>(entity =>
            {
                entity.ToTable("Goal");

                entity.Property(e => e.GoalDescription).HasMaxLength(500);

                entity.Property(e => e.GoalName).HasMaxLength(250);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserEmail).HasMaxLength(250);

                entity.Property(e => e.UserName).HasMaxLength(250);

                entity.Property(e => e.UserPassword).HasMaxLength(250);
            });

            modelBuilder.Entity<Workout>(entity =>
            {
                entity.ToTable("Workout");

                entity.Property(e => e.WorkoutDescription).HasMaxLength(500);

                entity.Property(e => e.WorkoutName).HasMaxLength(250);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
