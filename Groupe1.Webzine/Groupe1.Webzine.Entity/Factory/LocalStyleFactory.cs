using System;
using System.Collections.Generic;

namespace Groupe1.Webzine.Entity.Factory
{
    /// <summary>
    /// Factory permettant de créer des faux styles de musique (en dur).
    /// </summary>
    public class LocalStyleFactory
    {
        /// <summary>
        /// Crée une liste de styles de musique en dur.
        /// </summary>
        /// <returns>Liste contenant des styles de musique en dur</returns>
        public static List<Style> CreerStyles()
        {
            var styles = new List<Style>();

            styles.Add(new Style
            {
                IdStyle = 1,
                Libelle = "disco"
            });
            styles.Add(new Style
            {
                IdStyle = 2,
                Libelle = "rap"
            });
            styles.Add(new Style
            {
                IdStyle = 3,
                Libelle = "hip-hop"
            });
            styles.Add(new Style
            {
                IdStyle = 4,
                Libelle = "jazz"
            });
            styles.Add(new Style
            {
                IdStyle = 5,
                Libelle = "electronique"
            });

            return styles;
        }

        public static Style RecupererStyle()
        {
            var styles = CreerStyles();
            var random = new Random().Next(styles.Count);

            return styles[random];
        }
    }
}