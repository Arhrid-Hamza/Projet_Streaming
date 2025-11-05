using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Projet_Streaming.Models;

namespace Projet_Streaming.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSets for all models
        public DbSet<Personne> Personnes { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Abonne> Abonnes { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<SuperAdmin> SuperAdmins { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Profil> Profils { get; set; }
        public DbSet<Historique> Historiques { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Watchlist> Watchlists { get; set; }
        public DbSet<Contenu> Contenus { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Serie> Series { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<ContentGenre> ContentGenres { get; set; }
        public DbSet<Abonnement> Abonnements { get; set; }
        public DbSet<Paiement> Paiements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure composite key for ContentGenre
            modelBuilder.Entity<ContentGenre>()
                .HasKey(cg => new { cg.ContenuId, cg.GenreId });

            // Configure composite key for Watchlist
            modelBuilder.Entity<Watchlist>()
                .HasKey(w => new { w.UtilisateurId, w.ContenuId });

            // Configure TPH for Personne inheritance
            modelBuilder.Entity<Personne>()
                .HasDiscriminator<string>("Discriminator")
                .HasValue<Utilisateur>("Utilisateur")
                .HasValue<Abonne>("Abonne")
                .HasValue<Admin>("Admin")
                .HasValue<SuperAdmin>("SuperAdmin")
                .HasValue<Guest>("Guest");

            // Configure TPH for Contenu inheritance
            modelBuilder.Entity<Contenu>()
                .HasDiscriminator<string>("Discriminator")
                .HasValue<Film>("Film")
                .HasValue<Serie>("Serie");

            // Configure relationships
            modelBuilder.Entity<Contenu>()
                .HasOne(c => c.Categorie)
                .WithMany(cat => cat.Contenus)
                .HasForeignKey(c => c.CategorieId);

            modelBuilder.Entity<ContentGenre>()
                .HasOne(cg => cg.Contenu)
                .WithMany(c => c.ContentGenres)
                .HasForeignKey(cg => cg.ContenuId);

            modelBuilder.Entity<ContentGenre>()
                .HasOne(cg => cg.Genre)
                .WithMany(g => g.ContentGenres)
                .HasForeignKey(cg => cg.GenreId);

            modelBuilder.Entity<Episode>()
                .HasOne(e => e.Serie)
                .WithMany(s => s.Episodes)
                .HasForeignKey(e => e.SerieId);

            modelBuilder.Entity<Utilisateur>()
                .HasMany(u => u.Profils)
                .WithOne(p => p.Utilisateur)
                .HasForeignKey(p => p.UtilisateurId);

            modelBuilder.Entity<Utilisateur>()
                .HasMany(u => u.Historiques)
                .WithOne(h => h.Utilisateur)
                .HasForeignKey(h => h.UtilisateurId);

            modelBuilder.Entity<Utilisateur>()
                .HasMany(u => u.WatchlistItems)
                .WithOne(w => w.Utilisateur)
                .HasForeignKey(w => w.UtilisateurId);

            modelBuilder.Entity<Utilisateur>()
                .HasMany(u => u.Ratings)
                .WithOne(r => r.Utilisateur)
                .HasForeignKey(r => r.UtilisateurId);

            modelBuilder.Entity<Historique>()
                .HasOne(h => h.Contenu)
                .WithMany()
                .HasForeignKey(h => h.ContenuId);

            modelBuilder.Entity<Historique>()
                .HasOne(h => h.Episode)
                .WithMany()
                .HasForeignKey(h => h.EpisodeId);

            modelBuilder.Entity<Rating>()
                .HasOne(r => r.Contenu)
                .WithMany()
                .HasForeignKey(r => r.ContenuId);

            modelBuilder.Entity<Watchlist>()
                .HasOne(w => w.Contenu)
                .WithMany()
                .HasForeignKey(w => w.ContenuId);

            modelBuilder.Entity<Abonne>()
                .HasOne(a => a.Abonnement)
                .WithMany()
                .HasForeignKey(a => a.AbonnementId);

            modelBuilder.Entity<Abonne>()
                .HasMany(a => a.Paiements)
                .WithOne(p => p.Abonne)
                .HasForeignKey(p => p.AbonneId);
        }
    }
}
