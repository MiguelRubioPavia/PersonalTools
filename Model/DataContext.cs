using Microsoft.EntityFrameworkCore;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DataContext : DbContext
    {
        public DbSet<FamilyGroup> FamilyGroups { get; set; }
        public DbSet<Family> Families { get; set; }
        public DbSet<SubFamily> SubFamilies { get; set; }
        public DbSet<FinanceMovement> FinanceMovements { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Database", "PersonalToolsDB.db");
            optionsBuilder.UseSqlite($"Data Source={path}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FinanceMovement>()
                .HasOne(r => r.BreakDown)
                .WithMany(r => r.BreakDownDetails)
                .HasForeignKey(r => r.BreakDownId);
        }
    }
}