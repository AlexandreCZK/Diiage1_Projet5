using Groupe1.Webzine.Entity;
using System;
using System.Collections.Generic;

namespace Groupe1.Webzine.WebApplication.ViewModels
{
    public class TitreVM
    {
        public int IdTitre { get; set; }
        public int IdArtiste { get; set; }
        public Artiste Artiste { get; set; }
        public string Libelle { get; set; }
        public string Chronique { get; set; }
        public DateTime DateCreation { get; set; }
        public int Duree { get; set; }
        public DateTime DateSortie { get; set; }
        public string UrlJaquette { get; set; }
        public string UrlEcoute { get; set; }
        public int NbLectures { get; set; }
        public int NbLikes { get; set; }
        public string Album { get; set; }
        public List<TitreStyle> TitresStyles { get; set; }
        public List<Commentaire> Commentaires { get; set; }
        public string Time { get; set; }
    }
}
