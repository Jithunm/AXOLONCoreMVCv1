using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using AXOLONCoreMVCv1.Models;

#nullable disable

namespace AXOLONCoreMVCv1.Data
{
    public partial class AXOLON_DBContext : DbContext
    {
        public AXOLON_DBContext()
        {
        }

        public AXOLON_DBContext(DbContextOptions<AXOLON_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblDocumentDetail> TblDocumentDetails { get; set; }
        public virtual DbSet<TblEmployee> TblEmployees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-NHE6A8GN;Initial Catalog=AXOLON_DB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TblDocumentDetail>(entity =>
            {
                entity.HasKey(e => e.DocumentNumber)
                    .HasName("PK_TblDoucumentDetails");

                entity.Property(e => e.DocumentNumber).IsFixedLength(true);

                entity.Property(e => e.Attachment).IsFixedLength(true);

                entity.Property(e => e.DocumentType).IsFixedLength(true);

                entity.Property(e => e.IssuePlace).IsFixedLength(true);

                entity.Property(e => e.Remarks).IsFixedLength(true);
            });

            modelBuilder.Entity<TblEmployee>(entity =>
            {
                entity.HasKey(e => e.EmployeeId)
                    .HasName("PK__TBL_Empl__7AD04FF17D57D17D");

                entity.Property(e => e.EmployeeId).ValueGeneratedNever();

                entity.Property(e => e.EmployeeName).IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
