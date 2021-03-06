using Groupe1.Webzine.Entity;
using System.Collections.Generic;

namespace Groupe1.Webzine.Repository.Contracts
{
    public interface IArtisteRepository
    {
        /// <summary>
        /// Ajoute un nouvel artiste
        /// </summary>
        /// <param name="artiste"></param>
        void Add(Artiste artiste);

        /// <summary>
        /// Supprime un artiste
        /// </summary>
        /// <param name="artiste"></param>
        void Delete(Artiste artiste);

        /// <summary>
        /// Retourne l'artiste demandé
        /// </summary>
        /// <param name="id">Id d'un artiste</param>
        /// <returns></returns>
        Artiste Find(int id);

        /// <summary>
        /// Retourne l'artiste demandé avec son nom
        /// </summary>
        /// <param name="nom">Nom de l'artiste</param>
        /// <returns>Retourne l'artiste demandé</returns>
        Artiste Find(string nom);
        
        /// <summary>
        /// Retourne tous les artistes
        /// </summary>
        /// <returns></returns>
        IEnumerable<Artiste> FindAll();

        /// <summary>
        /// Met à jour un artiste
        /// </summary>
        /// <param name="artiste"></param>
        void Update(Artiste artiste);
        
    }
}
