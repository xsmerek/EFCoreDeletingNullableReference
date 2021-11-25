using Microsoft.EntityFrameworkCore;

namespace EFCoreDeletingNullableReference
{
    public partial class EFCoreDeletingNullableReferenceContext : DbContext
    {
        public EFCoreDeletingNullableReferenceContext()
        {
        }

        public EFCoreDeletingNullableReferenceContext(DbContextOptions<EFCoreDeletingNullableReferenceContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    @"Data Source = localhost; Database = EFCoreDeletingNullableReference; User Id=Test; Password=Test;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasKey("Id");

                entity.Property(e => e.Name).HasMaxLength(100).IsRequired(false);
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasKey("Id");

                entity.Property(e => e.Name).HasMaxLength(100).IsRequired(false);
            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasKey("Id");

                entity.Property(e => e.Name).HasMaxLength(100).IsRequired(false);

                entity.Property<int?>("PersonId").HasMaxLength(100).IsRequired(false);
                entity.HasOne<Person>()
                    .WithOne(p => p.Car)
                    .HasForeignKey<Car>("PersonId")
                    .OnDelete(DeleteBehavior.Cascade);

                entity.Property<int?>("CompanyId").HasMaxLength(100).IsRequired(false);
                entity.HasOne<Company>()
                    .WithOne(c => c.Car)
                    .HasForeignKey<Car>("CompanyId")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}