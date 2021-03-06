using Groupe1.Webzine.Entity;
using System;
using System.Collections.Generic;

namespace Groupe1.Webzine.WebApplication.ViewModels
{
    /// <summary>
    /// ViemModel de la vue ChroniqueTitre
    /// </summary>
    public class TitreIndexVM
    {
        public string NomArtiste { get; set; }
        public string LibelleTitre { get; set; }
        public string ChroniqueTitre { get; set; }
        public List<Commentaire> Commentaires { get; set; }
        public int IdTitre { get; set; }
        public DateTime DateCreation { get; set; }
        public string UrlEcoute { get; set; }
        public Commentaire commentaire { get; set; }
        public int NbLikes { get; set; }
        public string Time { get; set; }
    }
}
