using System.Collections.Generic;

namespace Groupe1.Webzine.WebApplication.ViewModels
{
    public class StyleIndexForTitreVM
    {
        public string LibelleStyle { get; set; } //Propriété du nom style
        public List<TitreVM> Titres { get; set; } // Liste des titres pour les afficher
    }
}
