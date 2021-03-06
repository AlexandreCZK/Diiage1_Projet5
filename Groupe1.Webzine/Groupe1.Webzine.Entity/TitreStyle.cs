using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Groupe1.Webzine.Entity
{
    /// <summary>
    /// Entité represantant un style d'un titres
    /// </summary>
    [Table("titre_style")]
    public class TitreStyle
    {
        /// <summary>
        /// Id du titre
        /// </summary>
        [Key]
        [Column("id_titre")]
        public int IdTitre { get; set; }

        /// <summary>
        /// Id du style
        /// </summary>
        [Key]
        [Column("id_style")]
        public int IdStyle { get; set; }

    }
}
