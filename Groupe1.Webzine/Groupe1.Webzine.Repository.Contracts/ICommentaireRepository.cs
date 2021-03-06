using Groupe1.Webzine.Entity;
using System.Collections.Generic;

namespace Groupe1.Webzine.Repository.Contracts
{
    public interface ICommentaireRepository
    {
        /// <summary>
        /// Ajout d'un commentaire
        /// </summary>
        /// <param name="commentaire"></param>
        void Add(Commentaire commentaire);

        /// <summary>
        /// Supprime un commentaire
        /// </summary>
        /// <param name="commentaire"></param>
        void Delete(Commentaire commentaire);

        /// <summary>
        /// Retourne un commentaire demandé
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Commentaire Find(int id);

        /// <summary>
        /// Retourne tous les commentaires
        /// </summary>
        /// <returns></returns>
        IEnumerable<Commentaire> FindAll();
    }
}
