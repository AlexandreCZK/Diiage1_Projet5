using Groupe1.Webzine.Entity;
using System.Collections.Generic;

namespace Groupe1.Webzine.Repository.Contracts
{
    public interface IStyleRepository
    {
        /// <summary>
        /// Ajoute un style
        /// </summary>
        /// <param name="style"></param>
        void Add(Style style);

        /// <summary>
        /// Supprime un style
        /// </summary>
        /// <param name="style"></param>
        void Delete(Style style);

        /// <summary>
        /// Retourne le style demandé
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Style Find(int id);

        /// <summary>
        /// Retourne le style demandé avec son nom
        /// </summary>
        /// <param name="name">Son nom</param>
        /// <returns>Retourne le style demandé avec son nom</returns>
        Style Find(string name);

        /// <summary>
        /// Retourne tous les styles
        /// </summary>
        /// <returns></returns>
        IEnumerable<Style> FindAll();

        /// <summary>
        /// Met à jour un style
        /// </summary>
        /// <param name="style"></param>
        void Update(Style style);

    }
}
