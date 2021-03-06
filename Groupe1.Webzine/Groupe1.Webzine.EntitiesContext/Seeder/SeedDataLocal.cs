using Groupe1.Webzine.Entity.Factory;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Groupe1.Webzine.EntitiesContext.Seeder
{
    public class SeedDataLocal
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = new WebzineDbContext(
               serviceProvider.GetRequiredService<
                   DbContextOptions<WebzineDbContext>>());

            AjoutArtiste(context);
            AjoutTitre(context);
            AjoutCommentaire(context);
            AjoutStyle(context);
            AjoutTitreStyle(context);
        }
        private static void AjoutArtiste(WebzineDbContext context)
        {
            var artistes = LocalArtisteFactory.CreerArtistes();
            foreach (var item in artistes)
            {
                context.Artistes.Add(new Entity.Artiste
                {
                    Biographie = item.Biographie,
                    Nom = item.Nom
                });
            }
            context.SaveChanges();
        }

        private static void AjoutTitre(WebzineDbContext context)
        {
            var titres = LocalTitreFactory.CreerTitres();
            foreach (var item in titres)
            {
                context.Titres.Add(new Entity.Titre
                {
                    Album = item.Album,
                    Chronique = item.Chronique,
                    DateCreation = item.DateCreation,
                    DateSortie = item.DateSortie,
                    Duree = item.Duree,
                    IdArtiste = item.IdArtiste,
                    Libelle = item.Libelle,
                    NbLectures = item.NbLectures,
                    NbLikes = item.NbLikes,
                    UrlEcoute = item.UrlEcoute,
                    UrlJaquette = item.UrlJaquette,
                });
            }
            context.SaveChanges();
        }

        private static void AjoutCommentaire(WebzineDbContext context)
        {
            var commentaires = LocalCommentaireFactory.CreerCommentaires();
            foreach (var item in commentaires)
            {
                context.Commentaires.Add(new Entity.Commentaire
                {
                    Auteur = item.Auteur,
                    Contenu = item.Contenu,
                    DateCreation = item.DateCreation,
                    IdTitre = item.IdTitre
                });
            }
            context.SaveChanges();
        }

        private static void AjoutStyle(WebzineDbContext context)
        {
            var styles = LocalStyleFactory.CreerStyles();
            foreach (var item in styles)
            {
                context.Styles.Add(new Entity.Style
                {
                    Libelle = item.Libelle,
                });
            }
            context.SaveChanges();
        }

        private static void AjoutTitreStyle(WebzineDbContext context)
        {
            var random = new Random();
            var titres = context.Titres;
            var styles = context.Styles.ToListAsync().Result;
            foreach (var item in titres)
            {
                context.TitresStyles.Add(new Entity.TitreStyle
                {
                    IdTitre = item.IdTitre,
                    IdStyle = styles[random.Next(styles.Count)].IdStyle
                });
            }
            context.SaveChanges();
        }
    }
}
