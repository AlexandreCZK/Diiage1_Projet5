using Groupe1.Webzine.Entity;
using Microsoft.EntityFrameworkCore;

namespace Groupe1.Webzine.EntitiesContext
{
    public class WebzineDbContext : DbContext
    {
        public WebzineDbContext(DbContextOptions<WebzineDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artiste>()
                .HasKey(a => a.IdArtiste)
                .HasName("PK_Artiste");

            modelBuilder.Entity<Artiste>()
                .Property(a => a.IdArtiste)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Commentaire>()
               .HasKey(c => c.IdCommentaire)
               .HasName("PK_Commentaire");
            modelBuilder.Entity<Commentaire>()
                .Property(c => c.IdCommentaire)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Style>()
              .HasKey(s => s.IdStyle)
              .HasName("PK_Style");
            modelBuilder.Entity<Style>()
                .Property(s => s.IdStyle)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Titre>()
              .HasKey(t => t.IdTitre)
              .HasName("PK_Titre");
            modelBuilder.Entity<Titre>()
                .Property(t => t.IdTitre)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<TitreStyle>()
                .HasKey(ts => new { ts.IdStyle, ts.IdTitre });

            modelBuilder.Entity<Titre>()
                .HasOne<Artiste>(t => t.Artiste)
                .WithMany(a => a.Titres)
                .HasForeignKey(t => t.IdArtiste)
                .HasConstraintName("FK_TitreArtisteID");

            modelBuilder.Entity<Commentaire>()
                .HasOne<Titre>(c => c.Titre)
                .WithMany(t => t.Commentaires)
                .HasForeignKey(c => c.IdTitre)
                .HasConstraintName("FK_CommentaireTitreID");
        }

        //entities
        /// <summary>
        /// DbSet Artiste
        /// </summary>
        public DbSet<Artiste> Artistes { get; set; }

        /// <summary>
        /// DbSet Commentaire
        /// </summary>
        public DbSet<Commentaire> Commentaires { get; set; }

        /// <summary>
        /// DbSet Style
        /// </summary>
        public DbSet<Style> Styles { get; set; }

        /// <summary>
        /// DbSet Titre
        /// </summary>
        public DbSet<Titre> Titres { get; set; }

        /// <summary>
        /// DbSet TitresStyle
        /// </summary>
        public DbSet<TitreStyle> TitresStyles { get; set; }
    }
}

