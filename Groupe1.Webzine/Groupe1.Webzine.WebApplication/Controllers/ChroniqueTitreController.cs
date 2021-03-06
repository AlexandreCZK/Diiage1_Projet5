using Groupe1.Webzine.Business.Contracts;
using Groupe1.Webzine.Entity;
using Groupe1.Webzine.Repository.Contracts;
using Groupe1.Webzine.WebApplication.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Groupe1.Webzine.WebApplication.Controllers
{
    /// <summary>
    /// Controller de la vue ChroniqueTitre
    /// </summary>
    public class Titre : Controller
    {
        private ITitreRepository _titreRepository { get; set; }
        private IStyleRepository _styleRepository { get; set; }
        public ITime _time { get; set; }

        public Titre(ITitreRepository iTitre, IStyleRepository iStyle, ITime iTime)
        {
            _titreRepository = iTitre;
            _styleRepository = iStyle;
            _time = iTime;
        }

        /// <summary>
        /// Appel de la vue ChroniqueTitre dans le dossier Views/ChroniqueTitre
        /// Appel du ViewModel ChroniqueTitreVM
        /// </summary>
        /// <returns></returns>
        public IActionResult Index(int id)
        {
            var titre = _titreRepository.Find(id);

            List<Style> styles = new List<Style>(); 
            titre.TitresStyles.ForEach(tS => styles.Add(_styleRepository.Find(tS.IdStyle)));
            ViewBag.Styles = styles;

            var model = new TitreIndexVM
            {
                LibelleTitre = titre.Libelle,
                ChroniqueTitre = titre.Chronique,
                Commentaires = titre.Commentaires,
                NomArtiste = titre.Artiste.Nom,
                UrlEcoute = titre.UrlEcoute,
                Time = _time.SecondsConverter(titre.Duree)
            };
            return View(model);
        }
    }
}
