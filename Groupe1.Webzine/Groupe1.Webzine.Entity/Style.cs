using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Groupe1.Webzine.Entity
{
    /// <summary>
    /// Entité style
    /// </summary>
    public class Style
    {
        /// <summary>
        /// Id du style
        /// </summary>
        public int IdStyle { get; set; }

        /// <summary>
        /// Nom du style (Pop, Rock, Jazz, ...)
        /// </summary>
        [Display(Name = "Libellé")]
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Libelle { get; set; }

        /// <summary>
        /// Liste contanant l'id de tout les titres ayant pour style lui même
        /// </summary>
        public List<TitreStyle> TitresStyles { get; set; }
    }
}
