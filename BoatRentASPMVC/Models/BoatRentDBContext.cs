using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BoatRentASPMVC.Models
{
    public partial class BoatRentDBContext : DbContext
    {
        public BoatRentDBContext()
        {
        }

        public BoatRentDBContext(DbContextOptions<BoatRentDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BoatRegister> BoatRegisters { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BoatRegister>(entity =>
            {
                entity.ToTable("BoatRegister");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BoatName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
