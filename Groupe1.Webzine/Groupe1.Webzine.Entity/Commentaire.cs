using System;
using System.ComponentModel.DataAnnotations;

namespace Groupe1.Webzine.Entity
{
    /// <summary>
    /// Entité commentaire
    /// </summary>
    public class Commentaire
    {
        /// <summary>
        /// Id du commentaire
        /// </summary>
        public int IdCommentaire { get; set; }

        /// <summary>
        /// Contenu du commentaire
        /// </summary>
        [Display(Name= "Commentaire")]
        [Required]
        [MinLength(10)]
        [MaxLength(1000)]
        public string Contenu { get; set; }

        /// <summary>
        /// Nom de la personne ayant poster le commentaire
        /// </summary>
        [Display(Name="Nom")]
        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string Auteur { get; set; }

        /// <summary>
        /// Date a laquelle le commentaire à été poster
        /// </summary>
        [Required]
        [Display(Name = "Date de création")]
        public DateTime DateCreation { get; set; }

        /// <summary>
        /// Id du titre sur lequelle le commentaire a été psoter
        /// </summary>
        public int IdTitre { get; set; }

        /// <summary>
        /// L'objet titre sur lequelle le commentaire a été psoter
        /// </summary>
        public Titre Titre { get; set; }

    }
}
