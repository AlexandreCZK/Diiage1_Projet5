using System;
using System.Collections.Generic;

namespace Groupe1.Webzine.Entity.Factory
{
    /// <summary>
    /// Factory permettant de créer des faux titre de musique (en dur).
    /// </summary>
    public class LocalTitreFactory
    {
        /// <summary>
        /// Crée une liste de titre de musique en dur.
        /// </summary>
        /// <returns>Liste contenant des titres de musique en dur</returns>
        public static List<Titre> CreerTitres()
        {
            var titres = new List<Titre>();

            titres.Add(new Titre
            {
                IdTitre = 1,
                IdArtiste = 1,
                Artiste = new Artiste { Nom = "Ninho", IdArtiste = 1 },
                Album = "MILS",
                Commentaires = new List<Commentaire>
                {
                    new Commentaire { Auteur="Jean", Contenu="Bon son", DateCreation = DateTime.Now, IdCommentaire= 1, IdTitre = 1},
                    new Commentaire { Auteur="Benois", Contenu="Nul", DateCreation = DateTime.Now, IdCommentaire= 2, IdTitre = 1}
                },
                Chronique = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam consequat vitae urna vel commodo.",
                DateCreation = DateTime.Now,
                Duree = 300,
                DateSortie = DateTime.Now,
                Libelle = "Soleil",
                NbLectures = 500,
                NbLikes = 100,
                TitresStyles = new List<TitreStyle> { new TitreStyle { IdStyle = LocalStyleFactory.RecupererStyle().IdStyle, IdTitre = 1 } },
                UrlEcoute = "https://www.youtube.com/embed/9qmUr4BMO5Y",
                UrlJaquette = "https://static.booska-p.com/images/news/ninho-lache-la-tracklist-et-la-cover-de-sa-mixtape-m-i-l-s-649.jpg"
            });
            titres.Add(new Titre
            {
                IdTitre = 2,
                IdArtiste = 2,
                Artiste = new Artiste { Nom = "PNL", IdArtiste = 2 },
                Album = "Que la famille",
                Commentaires = new List<Commentaire>
                {
                    new Commentaire { Auteur="Alexandre", Contenu="Bon son a l'ancienne", DateCreation = DateTime.Now, IdCommentaire= 3, IdTitre = 2},
                    new Commentaire { Auteur="Jeans", Contenu="Naze", DateCreation = DateTime.Now, IdCommentaire= 4, IdTitre = 2}
                },
                Chronique = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam consequat vitae urna vel commodo.",
                DateCreation = DateTime.Now,
                Duree = 300,
                DateSortie = DateTime.Now,
                Libelle = "Lala",
                NbLectures = 25000,
                NbLikes = 1000,
                TitresStyles = new List<TitreStyle> { new TitreStyle { IdStyle = LocalStyleFactory.RecupererStyle().IdStyle, IdTitre = 2 } },
                UrlEcoute = "https://www.youtube.com/embed/j9FV40_1Z9M",
                UrlJaquette = "https://images.genius.com/4316ac9f801371fbb66c85031ee83be5.1000x1000x1.jpg"
            });
            titres.Add(new Titre
            {
                IdTitre = 3,
                IdArtiste = 3,
                Artiste = new Artiste { Nom = "ACDC", IdArtiste = 3 },
                Album = "Power Up",
                Commentaires = new List<Commentaire>(),
                Chronique = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam consequat vitae urna vel commodo.",
                DateCreation = DateTime.Now,
                Duree = 300,
                DateSortie = DateTime.Now,
                Libelle = "Realize",
                NbLectures = 1000000,
                NbLikes = 500000,
                TitresStyles = new List<TitreStyle> { new TitreStyle { IdStyle = LocalStyleFactory.RecupererStyle().IdStyle, IdTitre = 3 } },
                UrlEcoute = "https://www.youtube.com/embed/gLA70huskTk",
                UrlJaquette = "https://www.monsieurvintage.com/photos/2020/09/acdc-power-up-instagram.jpg"
            });
            titres.Add(new Titre
            {
                IdTitre = 4,
                IdArtiste = 4,
                Artiste = new Artiste { Nom = "Queen", IdArtiste = 4 },
                Album = "Queen",
                Commentaires = new List<Commentaire>(),
                Chronique = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam consequat vitae urna vel commodo.",
                DateCreation = DateTime.Now,
                Duree = 300,
                DateSortie = DateTime.Now,
                Libelle = "Keep yourself alive",
                NbLectures = 1000000,
                NbLikes = 500000,
                TitresStyles = new List<TitreStyle> { new TitreStyle { IdStyle = LocalStyleFactory.RecupererStyle().IdStyle, IdTitre = 3 } },
                UrlEcoute = "https://www.youtube.com/embed/d4lrjZ1SeOs",
                UrlJaquette = "https://upload.wikimedia.org/wikipedia/commons/4/4c/LP_Label_Queen.jpg"
            });

            return titres;
        }
    }
}