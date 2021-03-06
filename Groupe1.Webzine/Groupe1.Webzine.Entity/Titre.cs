using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Groupe1.Webzine.Entity
{
    /// <summary>
    /// Entité titre
    /// </summary>
    public class Titre
    {
        /// <summary>
        /// Id du titre
        /// </summary>
        public int IdTitre { get; set; }

        /// <summary>
        /// Id de l'artiste
        /// </summary>
        public int IdArtiste { get; set; }

        /// <summary>
        /// Object contenat l'artiste
        /// </summary>
        public Artiste Artiste { get; set; }

        /// <summary>
        /// Nom du titre
        /// </summary>
        [Display(Name = "Titre")]
        [Required]
        [MinLength(1)]
        [MaxLength(200)]
        public string Libelle { get; set; }

        /// <summary>
        /// Chronique du titre (petite histoire)
        /// </summary>
        [Required]
        [MinLength(10)]
        [MaxLength(4000)]
        public string Chronique { get; set; }

        /// <summary>
        /// Date de création sur le site du titre
        /// </summary>
        [Required]
        [Display(Name = "Date de création")]
        public DateTime DateCreation { get; set; }

        /// <summary>
        /// Durée du titre
        /// </summary>
        [Display(Name = "Durée en secondes")]
        public int Duree { get; set; }

        /// <summary>
        /// Date de sortie
        /// </summary>
        [Required]
        [Display(Name = "Date de sortie")]
        public DateTime DateSortie { get; set; }

        /// <summary>
        /// Image de la jaquette (lien)
        /// </summary>
        [Required]
        [Display(Name = "Jaquette de l'album")]
        [MaxLength(250)]
        public string UrlJaquette { get; set; }

        /// <summary>
        /// URL pour ecouter le titre
        /// </summary>
        [Display(Name = "URL d'écoute")]
        [MinLength(13)]
        [MaxLength(250)]
        public string UrlEcoute { get; set; }

        /// <summary>
        /// Nombre de fois ou le titre a été écouté 
        /// </summary>
        [Display(Name = "Nombre de lectures")]
        [Required]
        public int NbLectures { get; set; }

        /// <summary>
        /// Nombre de fois ou le titre à été aimer
        /// </summary>
        [Display(Name = "Nombre de likes")]
        [Required]
        public int NbLikes { get; set; }

        /// <summary>
        /// Nom de l'album
        /// </summary>
        [Required]
        public string Album { get; set; }

        /// <summary>
        /// Liste contanant l'id de tout les style du titre
        /// </summary>
        public List<TitreStyle> TitresStyles { get; set; }

        /// <summary>
        /// Liste de tout les commentaire concernant ce titre
        /// </summary>
        public List<Commentaire> Commentaires { get; set; }
    }
}
