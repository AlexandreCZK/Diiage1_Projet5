using Microsoft.AspNetCore.Mvc;
using Groupe1.Webzine.WebApplication.ViewModels;
using Groupe1.Webzine.Repository.Contracts;

namespace Groupe1.Webzine.WebApplication.Controllers
{
    /// <summary>
    /// Controller de la page Artiste
    /// </summary>
    /// <returns></returns>
    public class ArtisteController : Controller
    {
        private IArtisteRepository _repository { get; set; }
        public ArtisteController(IArtisteRepository iArtiste)
        {
            _repository = iArtiste;
        }

        /// <summary>
        /// Appel de la vue index dans le dossier views/artiste
        /// </summary>
        /// <returns></returns>
        [Route("Artiste/{nom}")]
        public IActionResult Index(string nom)
        {
            var artiste = _repository.Find(nom);
            var model = new ArtisteIndexVM
            {
                NomArtiste = artiste.Nom,
                BioArtiste = artiste.Biographie,
                Titres = artiste.Titres
            };
            return View(model);
        }

        
}
}
