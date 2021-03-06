using Groupe1.Webzine.Business.Contracts;
using Groupe1.Webzine.Repository.Contracts;
using Groupe1.Webzine.WebApplication.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Groupe1.Webzine.WebApplication.Controllers
{
    /// <summary>
    /// Controller pour les recherches
    /// </summary>
    public class RechercheController : Controller
    {
        private ITitreRepository _repositoryT { get; set; }
        private IArtisteRepository _repositoryA { get; set; }
        private ITime _time { get; set; }

        public RechercheController(ITitreRepository iTitre, IArtisteRepository iArtiste, ITime iTime)
        {
            _repositoryT = iTitre;
            _repositoryA = iArtiste;
            _time = iTime;
        }

        /// <summary>
        /// Appel de la vue Index
        /// </summary>
        /// <param name="query">Ce que l'utilisateur a recherché</param>
        /// <returns></returns>
        [Route("Recherche/{query?}")]
        public IActionResult Index(string query)
        {
            // Artistes trouvés avec la recherche
            var artistes = _repositoryA.FindAll().Where(a => a.Nom.ToLower().Contains(query.ToLower())).ToList();
            // Titres trouvés avec la recherche 
            var titres = _repositoryT.Search(query).ToList();

            // Titres appartenant aux artistes trouvés de la recherche
            //var titresArtistesTrouves = _repositoryT.FindAll().Where(t => t.Artiste.Nom.ToLower().Contains(query.ToLower())).ToList();
            // Liste finale des titres
            //titres.AddRange(titresArtistesTrouves);

            List<TitreVM> titresVM = new List<TitreVM>();
            
            foreach (var titre in titres)
            {
                var titreVM = new TitreVM();
                titreVM.Album = titre.Album;
                titreVM.Artiste = titre.Artiste;
                titreVM.Chronique = titre.Chronique;
                titreVM.Commentaires = titre.Commentaires;
                titreVM.DateCreation = titre.DateCreation;
                titreVM.DateSortie = titre.DateSortie;
                titreVM.Duree = titre.Duree;
                titreVM.IdArtiste = titre.IdArtiste;
                titreVM.IdTitre = titre.IdTitre;
                titreVM.Libelle = titre.Libelle;
                titreVM.NbLectures = titre.NbLectures;
                titreVM.NbLikes = titre.NbLikes;
                titreVM.Time = _time.SecondsConverter(titre.Duree);
                titreVM.TitresStyles = titre.TitresStyles;
                titreVM.UrlEcoute = titre.UrlEcoute;
                titreVM.UrlJaquette = titre.UrlJaquette;
                titresVM.Add(titreVM);
            }
            var model = new RechercheVM
            {
                Artistes = artistes,
                Titres = titresVM
            };
            ViewBag.Query = query;
            return View(model);
        }
    }
}
