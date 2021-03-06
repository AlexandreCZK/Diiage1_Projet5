using Groupe1.Webzine.Entity;
using System.Collections.Generic;

namespace Groupe1.Webzine.WebApplication.ViewModels
{
    public class TitreHomeVM
    {
        public string Artiste { get; set; }
        public string Nom { get; set; }
        public string Date { get; set; }
        public string Chronique { get; set; }
        public string Jaquette { get; set; }
        public int Id { get; set; }
        public int IdArtiste { get; set; }
        public List<Style> Styles { get; set; }
    }
}
