using Medic.Logs.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Runtime.InteropServices;

namespace Medic.Logs
{
    public class MedicLoggerContext : DbContext
    {
        public MedicLoggerContext(DbContextOptions<MedicLoggerContext> options)
            : base (options)
        {

        }

        public DbSet<Log> Logs { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Log>(l =>
            {
                l.HasKey(l => l.Id);

                l.Property(l => l.Message).HasMaxLength(500);

                l.Property(l => l.InnerExceptionMessage).HasMaxLength(500);

                l.Property(l => l.StackTrace).HasMaxLength(5000);

                l.Property(l => l.Source).HasMaxLength(100);

                l.Property(l => l.Date).IsRequired();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
