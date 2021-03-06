using Groupe1.Webzine.Entity;
using System.Collections.Generic;

namespace Groupe1.Webzine.Repository.Contracts
{
    public interface ITitreRepository
    {
        /// <summary>
        /// Ajoute un titre
        /// </summary>
        /// <param name="titre"></param>
        void Add(Titre titre);

        /// <summary>
        /// Compte le nombre de titres
        /// </summary>
        /// <returns></returns>
        int Count();

        /// <summary>
        /// Supprime un titre
        /// </summary>
        /// <param name="titre"></param>
        void Delete(Titre titre);

        /// <summary>
        /// Retourne le titre demandé
        /// </summary>
        /// <param name="idTitre"></param>
        /// <returns></returns>
        Titre Find(int idTitre);

        /// <summary>
        /// Retourne les titres demandés (pour la pagination) triés selon la date de création(du plus récent à ancien)
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        IEnumerable<Titre> FindTitres(int offset, int limit);

        /// <summary>
        /// Retourne tous les titres
        /// </summary>
        /// <returns></returns>
        IEnumerable<Titre> FindAll();

        /// <summary>
        /// Incremente le nombre de lecture d'un titre
        /// </summary>
        /// <param name="titre"></param>
        void IncrementNbLectures(Titre titre);

        /// <summary>
        /// Increment le nombre de like d'un titre
        /// </summary>
        /// <param name="titre"></param>
        void IncrementNbLikes(Titre titre);

        /// <summary>
        /// Recherche, de manière insensible à la casse, les titres contenant le mot cherché.
        /// </summary>
        /// <param name="mot"></param>
        /// <returns></returns>
        IEnumerable<Titre> Search(string mot);

        /// <summary>
        /// Recherche, de manière insensible à la casse, les titres contenant le style de musique cherché.
        /// </summary>
        /// <param name="libelle"></param>
        /// <returns></returns>
        IEnumerable<Titre> SearchByStyle(string libelle);

        /// <summary>
        /// Met à jour un titre
        /// </summary>
        /// <param name="titre"></param>
        void Update(Titre titre);
    }
}
