namespace Groupe1.Webzine.WebApplication.Areas.Administration.ViewModels
{
    public class TitreIndexVM
    {
        public int Id { get; set; }
        public string NomArtiste { get; set; }
        public string Libelle { get; set; }
        public double Duree { get; set; }
        public string DateSortie { get; set; }
        public int NbLectures { get; set; }
        public int NbLikes { get; set; }
        public int NbCommentaires { get; set; }
    }
}
