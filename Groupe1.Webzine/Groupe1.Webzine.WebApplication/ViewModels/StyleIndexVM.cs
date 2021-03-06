using Groupe1.Webzine.Entity;
using System.Collections.Generic;

namespace Groupe1.Webzine.WebApplication.ViewModels
{
    public class StyleIndexVM
    {
        public string LibelleStyle { get; set; } //Propriété du nom style
        public List<Titre> Titres { get; set; } // Liste des titres pour les afficher
    }
}
