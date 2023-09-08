using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace iBosAssesmentAPI.Models;

public partial class IBosDbContext : DbContext
{
    public IBosDbContext()
    {
    }

    public IBosDbContext(DbContextOptions<IBosDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblEmployee> TblEmployees { get; set; }

    public virtual DbSet<TblEmployeeAttendance> TblEmployeeAttendances { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\Sqlexpress;Database=iBosDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblEmployee>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tblEmployee");

            entity.Property(e => e.EmployeeCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("employeeCode");
            entity.Property(e => e.EmployeeId)
                .HasColumnName("employeeId");
            entity.Property(e => e.EmployeeName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("employeeName");
            entity.Property(e => e.EmployeeSalary)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("employeeSalary");
            entity.Property(e => e.SupervisorId)
                .HasColumnName("supervisorId");
        });

        modelBuilder.Entity<TblEmployeeAttendance>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tblEmployeeAttendance");

            entity.Property(e => e.AttendanceDate)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("attendanceDate");
            entity.Property(e => e.EmployeeId).HasColumnName("employeeId");
            entity.Property(e => e.IsAbsent).HasColumnName("isAbsent");
            entity.Property(e => e.IsOffday).HasColumnName("isOffday");
            entity.Property(e => e.IsPresent).HasColumnName("isPresent");
        });

        OnModelCreatingPartial(modelBuilder);
    }


    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

}
