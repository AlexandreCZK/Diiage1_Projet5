using System.Collections.Generic;

namespace Groupe1.Webzine.Entity.Factory
{
    /// <summary>
    /// Factory permettant de créer des faux artistes (en dur).
    /// </summary>
    public class LocalArtisteFactory
    {
        /// <summary>
        /// Crée une liste d'artistes en dur.
        /// </summary>
        /// <returns>Liste contenant des artistes en dur</returns>
        public static List<Artiste> CreerArtistes()
        {
            var artistes = new List<Artiste>();

            artistes.Add(new Artiste
            {
                IdArtiste = 1,
                Biographie = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam consequat vitae urna vel commodo. Mauris consectetur risus in mattis euismod. Nam condimentum mauris mi, at pulvinar ligula laoreet id. Vestibulum nec quam id mauris aliquam posuere.",
                Nom = "Ninho",
                Titres = new List<Titre> { LocalTitreFactory.CreerTitres()[0] }
            });
            artistes.Add(new Artiste
            {
                IdArtiste = 2,
                Biographie = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam consequat vitae urna vel commodo. Mauris consectetur risus in mattis euismod. Nam condimentum mauris mi, at pulvinar ligula laoreet id. Vestibulum nec quam id mauris aliquam posuere.",
                Nom = "Pnl",
                Titres = new List<Titre> { LocalTitreFactory.CreerTitres()[1] }
            });
            artistes.Add(new Artiste
            {
                IdArtiste = 3,
                Biographie = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam consequat vitae urna vel commodo. Mauris consectetur risus in mattis euismod. Nam condimentum mauris mi, at pulvinar ligula laoreet id. Vestibulum nec quam id mauris aliquam posuere.",
                Nom = "ACDC",
                Titres = new List<Titre> { LocalTitreFactory.CreerTitres()[2] }
            });
            artistes.Add(new Artiste
            {
                IdArtiste = 4,
                Biographie = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam consequat vitae urna vel commodo. Mauris consectetur risus in mattis euismod. Nam condimentum mauris mi, at pulvinar ligula laoreet id. Vestibulum nec quam id mauris aliquam posuere.",
                Nom = "Queen",
                Titres = new List<Titre> { LocalTitreFactory.CreerTitres()[3] }
            });
            artistes.Add(new Artiste
            {
                IdArtiste = 5,
                Biographie = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam consequat vitae urna vel commodo. Mauris consectetur risus in mattis euismod. Nam condimentum mauris mi, at pulvinar ligula laoreet id. Vestibulum nec quam id mauris aliquam posuere.",
                Nom = "Jonhy",
                Titres = new List<Titre>()
            });

            return artistes;
        }
    }
}