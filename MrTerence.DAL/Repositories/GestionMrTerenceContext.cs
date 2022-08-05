using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MrTerenceWebAPI.DAL.Entities;

namespace MrTerenceWebAPI.DAL
{
    public partial class GestionMrTerenceContext : DbContext
    {
        public GestionMrTerenceContext()
        {
        }

        public GestionMrTerenceContext(DbContextOptions<GestionMrTerenceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Adresse> Adresses { get; set; } = null!;
        public virtual DbSet<Bouteille> Bouteilles { get; set; } = null!;
        public virtual DbSet<Emplacement> Emplacements { get; set; } = null!;
        public virtual DbSet<Fournisseur> Fournisseurs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-AP4GFC3\\SQLEXPRESS;Database=GestionMrTerence;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adresse>(entity =>
            {
                entity.ToTable("Adresse");

                entity.Property(e => e.Pays).HasMaxLength(50);

                entity.Property(e => e.Rue).HasMaxLength(50);

                entity.Property(e => e.Ville).HasMaxLength(50);

                entity.HasOne(d => d.Fournisseur)
                    .WithMany(p => p.Adresses)
                    .HasForeignKey(d => d.FournisseurId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FkAdresseFournisseur");
            });

            modelBuilder.Entity<Bouteille>(entity =>
            {

                entity.ToTable("Bouteille");

                entity.Property(e => e.BouteilleId).ValueGeneratedOnAdd();

                entity.Property(e => e.Degree).HasColumnType("decimal(7, 1)");

                entity.Property(e => e.Label).HasMaxLength(50);

                entity.Property(e => e.Marque).HasMaxLength(50);

                entity.Property(e => e.MiseEnBouteille).HasColumnType("datetime");

                entity.Property(e => e.Origine).HasMaxLength(50);

                entity.Property(e => e.Pays).HasMaxLength(50);

                entity.Property(e => e.Review).HasMaxLength(100);

                entity.Property(e => e.Volume).HasColumnType("decimal(7, 2)");

                entity.HasOne(d => d.Emplacement)
                    .WithMany()
                    .HasForeignKey(d => d.EmplacementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkEmplacementBouteille");

                entity.HasOne(d => d.Fournisseur)
                    .WithMany()
                    .HasForeignKey(d => d.FournisseurId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkFournisseurBouteille");
            });

            modelBuilder.Entity<Emplacement>(entity =>
            {
                entity.ToTable("Emplacement");

                entity.Property(e => e.Casier).HasMaxLength(50);

                entity.Property(e => e.Etagere).HasMaxLength(50);
            });

            modelBuilder.Entity<Fournisseur>(entity =>
            {
                entity.ToTable("Fournisseur");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Fax).HasMaxLength(50);

                entity.Property(e => e.Nom).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.Prenom).HasMaxLength(50);

                entity.Property(e => e.Website).HasMaxLength(50);

                entity.HasOne(d => d.Adresse)
                    .WithMany(p => p.Fournisseurs)
                    .HasForeignKey(d => d.AdresseId)
                    .HasConstraintName("FkFournisseurAdresse");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
