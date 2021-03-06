using Groupe1.Webzine.Entity;
using System.Collections.Generic;

namespace Groupe1.Webzine.WebApplication.ViewModels
{
    public class RechercheVM
    {
        public List<Artiste> Artistes { get; set; }
        public List<TitreVM> Titres { get; set; }
    }
}
