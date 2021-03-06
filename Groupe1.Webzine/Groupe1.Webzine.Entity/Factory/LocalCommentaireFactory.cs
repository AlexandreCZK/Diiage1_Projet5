using System;
using System.Collections.Generic;

namespace Groupe1.Webzine.Entity.Factory
{
    /// <summary>
    /// Factory permettant de créer des faux commentaire (en dur).
    /// </summary>
    public class LocalCommentaireFactory
    {
        /// <summary>
        /// Crée une liste de commentaires en dur.
        /// </summary>
        /// <returns>Liste contenant des commentaires en dur</returns>
        public static List<Commentaire> CreerCommentaires()
        {
            var commentaires = new List<Commentaire>();

            commentaires.Add(new Commentaire
            {
                IdCommentaire = 1,
                IdTitre = 1,
                Auteur = "Jean",
                Contenu = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam erat mauris, tempor sit amet orci ac, posuere hendrerit risus. Sed et congue purus.",
                DateCreation = DateTime.Now,
                Titre = LocalTitreFactory.CreerTitres()[0]
            });
            commentaires.Add(new Commentaire
            {
                IdCommentaire = 1,
                IdTitre = 2,
                Auteur = "Alexandre",
                Contenu = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam erat mauris, tempor sit amet orci ac, posuere hendrerit risus. Sed et congue purus.",
                DateCreation = DateTime.Now,
                Titre = LocalTitreFactory.CreerTitres()[1]
            });
            commentaires.Add(new Commentaire
            {
                IdCommentaire = 1,
                IdTitre = 3,
                Auteur = "Benoît",
                Contenu = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam erat mauris, tempor sit amet orci ac, posuere hendrerit risus. Sed et congue purus.",
                DateCreation = DateTime.Now,
                Titre = LocalTitreFactory.CreerTitres()[2],
            });

            return commentaires;
        }
    }
}