using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using GeekHunters.Entities;

namespace GeekHunters.Repositories
{
    public partial class GeekHuntersContext : DbContext
    {
        public GeekHuntersContext(DbContextOptions<GeekHuntersContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Skill> Skill { get; set; }
        public virtual DbSet<Candidate> Candidate { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Skill>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("Name")
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<Candidate>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.FirstName).HasMaxLength(150);

                entity.Property(e => e.LastName).HasMaxLength(150);

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.Candidate)
                    .HasForeignKey(d => d.SkillId);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime"); ;

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime"); ;
            });
        }
    }
}
