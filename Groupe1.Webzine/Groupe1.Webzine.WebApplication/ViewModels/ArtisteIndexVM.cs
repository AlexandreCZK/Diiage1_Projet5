using Groupe1.Webzine.Entity;
using System.Collections.Generic;

namespace Groupe1.Webzine.WebApplication.ViewModels
{
    public class ArtisteIndexVM
    {
        public string NomArtiste { get; set; } //Propriété du nom artiste
        public string BioArtiste { get; set; } //Propriété de la bio artiste
        public List<Titre> Titres  { get; set; } // Liste des titres pour les afficher dans les albums
    }
}
