using System.Collections.Generic;

namespace Groupe1.Webzine.WebApplication.Areas.Administration.ViewModels
{
    public class TitreEditVM
    {
        public string Titre { get; set; }
        public int Id { get; set; }
        public List<string> Styles { get; set; }
        public string NomArtiste { get; set; }
        public string NomAlbum { get; set; }
        public string Chronique { get; set; }
        public string DateSortie { get; set; }
        public double Duree { get; set; }
        public string Jaquette { get; set; }
        public string Url { get; set; }
        public int NbLectures { get; set; }
        public int NbLikes { get; set; }
    }
}
