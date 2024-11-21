using Microsoft.EntityFrameworkCore;
using AppEmployee.Models;

namespace AppEmployee.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<EmploymentStatus> EmploymentStatuses { get; set; }
        public DbSet<WorkUnit> WorkUnits { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeHistory> EmployeeHistory { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Pengaturan relasi antara Employee dan EmployeeHistory
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.EmployeeHistories) // Pastikan Employee memiliki koleksi EmployeeHistories
                .WithOne(eh => eh.Employee) // Menghubungkan dengan Employee
                .HasForeignKey(eh => eh.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade); // Menghapus history ketika employee dihapus

            // Pengaturan relasi untuk EmployeeHistory
            modelBuilder.Entity<EmployeeHistory>()
                .HasOne(eh => eh.EmploymentStatus)
                .WithMany()
                .HasForeignKey(eh => eh.EmploymentStatusId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EmployeeHistory>()
                .HasOne(eh => eh.WorkUnit)
                .WithMany()
                .HasForeignKey(eh => eh.WorkUnitId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EmployeeHistory>()
                .HasOne(eh => eh.Position)
                .WithMany()
                .HasForeignKey(eh => eh.PositionId)
                .OnDelete(DeleteBehavior.Restrict);

            // Mengatur batasan unik untuk EmployeeNumber
            modelBuilder.Entity<Employee>()
                .HasIndex(e => e.EmployeeNumber)
                .IsUnique();
        }

    }
}
