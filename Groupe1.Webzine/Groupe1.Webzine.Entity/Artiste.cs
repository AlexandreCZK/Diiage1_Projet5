using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Groupe1.Webzine.Entity
{
    /// <summary>
    /// Entité Artiste
    /// </summary>
    public class Artiste
    {
        /// <summary>
        /// Id de l'Artsite
        /// </summary>
        public int IdArtiste { get; set; }

        /// <summary>
        /// Id de l'artiste pour l'api spotify
        /// </summary>
        public string IdSpotify { get; set; }

        /// <summary>
        /// Nom de l'artiste
        /// </summary>
        [MinLength(1)]
        [MaxLength(50)]
        [Display(Name = "Nom de l'artiste")]
        public string Nom { get; set; }

        /// <summary>
        /// Biographie de l'artiste
        /// </summary>
        public string Biographie { get; set; }

        /// <summary>
        /// Listes des titres de l'artiste
        /// </summary>
        public List<Titre> Titres { get; set; }

    }
}
