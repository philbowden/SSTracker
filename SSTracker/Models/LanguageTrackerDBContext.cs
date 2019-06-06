using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SSTracker.Models
{
    public partial class LanguageTrackerDBContext : DbContext
    {
        public LanguageTrackerDBContext()
        {
        }

        public LanguageTrackerDBContext(DbContextOptions<LanguageTrackerDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actfl> ACTFL { get; set; }
        public virtual DbSet<Class> Class { get; set; }
        public virtual DbSet<Enrollment> Enrollment { get; set; }
        public virtual DbSet<Student> Student { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=LanguageTrackerDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Actfl>(entity =>
            {
                entity.HasKey(e => new { e.YearQuarterID, e.ItemNumber, e.SID })
                    .HasName("PK__ACTFL__D3894825F4871BE5");

                entity.ToTable("ACTFL");

                entity.Property(e => e.YearQuarterID)
                    .HasColumnName("YearQuarterID")
                    .HasMaxLength(4);

                entity.Property(e => e.ItemNumber).HasMaxLength(4);

                entity.Property(e => e.SID)
                    .HasColumnName("SID")
                    .HasMaxLength(9);

                entity.Property(e => e.Language).HasMaxLength(10);

                entity.Property(e => e.PROF_LVL)
                    .HasColumnName("PROF_LVL")
                    .HasMaxLength(10);

                entity.Property(e => e.PROF_SCR)
                    .HasColumnName("PROF_SCR")
                    .HasMaxLength(2);

                entity.Property(e => e.PROF_TYPE)
                    .HasColumnName("PROF_TYPE")
                    .HasMaxLength(10);

                entity.HasOne(d => d.S)
                    .WithMany(p => p.Actfl)
                    .HasForeignKey(d => d.SID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ACTFL_Enrollment");
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.Property(e => e.ClassID)
                    .HasColumnName("ClassID")
                    .HasMaxLength(8)
                    .ValueGeneratedNever();

                entity.Property(e => e.CourseID)
                    .HasColumnName("CourseID")
                    .HasMaxLength(10);

                entity.Property(e => e.InstructorName).HasMaxLength(30);

                entity.Property(e => e.ItemNumber)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.Property(e => e.YearQuarterID)
                    .IsRequired()
                    .HasColumnName("YearQuarterID")
                    .HasMaxLength(4);
            });

            modelBuilder.Entity<Enrollment>(entity =>
            {
                entity.HasKey(e => e.SID);

                entity.Property(e => e.SID)
                    .HasColumnName("SID")
                    .HasMaxLength(9)
                    .ValueGeneratedNever();

                entity.Property(e => e.ClassID)
                    .HasColumnName("ClassID")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.YearQuarterID)
                    .IsRequired()
                    .HasColumnName("YearQuarterID")
                    .HasMaxLength(4)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.SID)
                    .HasName("PK_SID");

                entity.Property(e => e.SID)
                    .HasColumnName("SID")
                    .HasMaxLength(9)
                    .ValueGeneratedNever();

                entity.Property(e => e.FullName).HasMaxLength(22);
            });
        }
    }
}
