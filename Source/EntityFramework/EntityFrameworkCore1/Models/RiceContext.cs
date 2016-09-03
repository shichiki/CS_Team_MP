using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EntityFrameworkCore1.Models
{
    public partial class RiceContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlite(@"Filename=G:\Code\CS_Team_MP\SQL\Rice.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClassAssertion>(entity =>
            {
                entity.HasIndex(e => e.NamedIndividualId)
                    .HasName("sqlite_autoindex_ClassAssertion_1")
                    .IsUnique();

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.ClassAssertionClass)
                    .HasForeignKey(d => d.ClassId);

                entity.HasOne(d => d.NamedIndividual)
                    .WithOne(p => p.ClassAssertionNamedIndividual)
                    .HasForeignKey<ClassAssertion>(d => d.NamedIndividualId);
            });

            modelBuilder.Entity<DataPropertyAssertion>(entity =>
            {
                entity.Property(e => e.LiteralDatatypeIri).IsRequired();

                entity.Property(e => e.LiteralValue).IsRequired();

                entity.HasOne(d => d.DataProperty)
                    .WithMany(p => p.DataPropertyAssertionDataProperty)
                    .HasForeignKey(d => d.DataPropertyId);

                entity.HasOne(d => d.NamedIndividual)
                    .WithMany(p => p.DataPropertyAssertionNamedIndividual)
                    .HasForeignKey(d => d.NamedIndividualId);
            });

            modelBuilder.Entity<DataPropertyDomain>(entity =>
            {
                entity.HasOne(d => d.Class)
                    .WithMany(p => p.DataPropertyDomainClass)
                    .HasForeignKey(d => d.ClassId);

                entity.HasOne(d => d.DataProperty)
                    .WithMany(p => p.DataPropertyDomainDataProperty)
                    .HasForeignKey(d => d.DataPropertyId);
            });

            modelBuilder.Entity<DataPropertyRange>(entity =>
            {
                entity.HasIndex(e => e.DataPropertyId)
                    .HasName("sqlite_autoindex_DataPropertyRange_1")
                    .IsUnique();

                entity.Property(e => e.DatatypeAbbreviatedIri).IsRequired();

                entity.HasOne(d => d.DataProperty)
                    .WithOne(p => p.DataPropertyRange)
                    .HasForeignKey<DataPropertyRange>(d => d.DataPropertyId);
            });

            modelBuilder.Entity<Declaration>(entity =>
            {
                entity.HasIndex(e => e.Iri)
                    .HasName("sqlite_autoindex_Declaration_1")
                    .IsUnique();

                entity.Property(e => e.Iri).IsRequired();

                entity.Property(e => e.Type).IsRequired();
            });

            modelBuilder.Entity<Keyword>(entity =>
            {
                entity.HasIndex(e => e.DeclarationId)
                    .HasName("sqlite_autoindex_Keyword_1")
                    .IsUnique();

                entity.Property(e => e.Definition).IsRequired();

                entity.Property(e => e.VietnameseName).IsRequired();

                entity.HasOne(d => d.Declaration)
                    .WithOne(p => p.Keyword)
                    .HasForeignKey<Keyword>(d => d.DeclarationId);
            });

            modelBuilder.Entity<ObjectPropertyAssertion>(entity =>
            {
                entity.HasOne(d => d.NamedIndividualId1Navigation)
                    .WithMany(p => p.ObjectPropertyAssertionNamedIndividualId1Navigation)
                    .HasForeignKey(d => d.NamedIndividualId1);

                entity.HasOne(d => d.NamedIndividualId2Navigation)
                    .WithMany(p => p.ObjectPropertyAssertionNamedIndividualId2Navigation)
                    .HasForeignKey(d => d.NamedIndividualId2);

                entity.HasOne(d => d.ObjectProperty)
                    .WithMany(p => p.ObjectPropertyAssertionObjectProperty)
                    .HasForeignKey(d => d.ObjectPropertyId);
            });

            modelBuilder.Entity<ObjectPropertyDomain>(entity =>
            {
                entity.HasOne(d => d.Class)
                    .WithMany(p => p.ObjectPropertyDomainClass)
                    .HasForeignKey(d => d.ClassId);

                entity.HasOne(d => d.ObjectProperty)
                    .WithMany(p => p.ObjectPropertyDomainObjectProperty)
                    .HasForeignKey(d => d.ObjectPropertyId);
            });

            modelBuilder.Entity<ObjectPropertyRange>(entity =>
            {
                entity.HasOne(d => d.Class)
                    .WithMany(p => p.ObjectPropertyRangeClass)
                    .HasForeignKey(d => d.ClassId);

                entity.HasOne(d => d.ObjectProperty)
                    .WithMany(p => p.ObjectPropertyRangeObjectProperty)
                    .HasForeignKey(d => d.ObjectPropertyId);
            });
        }

        public virtual DbSet<ClassAssertion> ClassAssertion { get; set; }
        public virtual DbSet<DataPropertyAssertion> DataPropertyAssertion { get; set; }
        public virtual DbSet<DataPropertyDomain> DataPropertyDomain { get; set; }
        public virtual DbSet<DataPropertyRange> DataPropertyRange { get; set; }
        public virtual DbSet<Declaration> Declaration { get; set; }
        public virtual DbSet<Keyword> Keyword { get; set; }
        public virtual DbSet<ObjectPropertyAssertion> ObjectPropertyAssertion { get; set; }
        public virtual DbSet<ObjectPropertyDomain> ObjectPropertyDomain { get; set; }
        public virtual DbSet<ObjectPropertyRange> ObjectPropertyRange { get; set; }
    }
}