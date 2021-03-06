using Groupe1.Webzine.Entity;
using Groupe1.Webzine.Repository.Contracts;
using Groupe1.Webzine.WebApplication.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Groupe1.Webzine.WebApplication.Controllers
{
    /// <summary>
    /// Controller de la page d'accueil
    /// </summary>
    public class HomeController : Controller
    {
        private ITitreRepository _repositoryT { get; set; }
        private IStyleRepository _repositoryS { get; set; }

        public HomeController(ITitreRepository iTitre, IStyleRepository iStyle)
        {
            _repositoryS = iStyle;
            _repositoryT = iTitre;
        }

        /// <summary>
        /// Appel de la vue index dans le dossier Views/Home
        /// </summary>
        /// <returns></returns>
        [Route("")]
        [Route("/page/{id}")]
        public IActionResult Index()
        {
            var titres = _repositoryT.FindAll().ToList();
            var lastTitresVM = new List<TitreHomeVM>();
            
            foreach (var t in titres)
            {
                List<Style> styles = new List<Style>();
                t.TitresStyles.ForEach(tS => styles.Add(_repositoryS.Find(tS.IdStyle)));
                lastTitresVM.Add(new TitreHomeVM
                {
                    Id = t.IdTitre,
                    Artiste = t.Artiste.Nom,
                    Nom = t.Libelle,
                    Date = t.DateSortie.ToString(),
                    Chronique = t.Chronique,
                    Jaquette = t.UrlJaquette,
                    Styles = styles
                });
            }

            var betterTitresVM = new List<TitreHomeVM>();
            titres.ForEach(t =>
                betterTitresVM.Add(new TitreHomeVM
                {
                    Artiste = t.Artiste.Nom,
                    Nom = t.Libelle,
                    Jaquette = t.UrlJaquette,
                    IdArtiste = t.IdArtiste
                }));
            this.ViewBag.betterTitresVM = betterTitresVM;
            return View(lastTitresVM);
        }
    }
}
