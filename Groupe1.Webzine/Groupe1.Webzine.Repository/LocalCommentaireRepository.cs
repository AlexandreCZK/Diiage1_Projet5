using Groupe1.Webzine.Entity;
using Groupe1.Webzine.Entity.Factory;
using Groupe1.Webzine.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Groupe1.Webzine.Repository
{
    public class LocalCommentaireRepository : ICommentaireRepository
    {
        private static List<Commentaire> _commentaires = LocalCommentaireFactory.CreerCommentaires();

        public void Add(Commentaire commentaire)
        {
            if (commentaire != null)
            {
                commentaire.IdCommentaire = _commentaires.Count + 1;
                _commentaires.Add(commentaire);
            }
            else
            {
                throw new NullReferenceException("Le commentaire est nulle");
            }
        }

        public void Delete(Commentaire commentaire)
        {
            if (commentaire != null)
            {
                var commentaireFactory = _commentaires.FirstOrDefault(c => c.IdCommentaire == commentaire.IdCommentaire);
                if (commentaireFactory != null)
                {
                        _commentaires.Remove(commentaireFactory);
                    }
                else
                {
                    throw new Exception($"Le commentaire ({commentaire.IdCommentaire}) {commentaire.Contenu} n'existe pas");
                }
            }
            else
            {
                throw new NullReferenceException("Artiste est nulle");
            }
        }

        public Commentaire Find(int id)
        {
            var commentaire = _commentaires.FirstOrDefault(c => c.IdCommentaire == id);
            if (commentaire == null)
            {
                throw new NullReferenceException("Le commentaire avec l'id :" + id + " n'existe pas");
            }
            return commentaire;
        }

        public IEnumerable<Commentaire> FindAll()
        {
            return _commentaires;
        }
    }
}
