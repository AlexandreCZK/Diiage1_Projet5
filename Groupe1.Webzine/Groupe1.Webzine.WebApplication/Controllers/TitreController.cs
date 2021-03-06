using Groupe1.Webzine.Business.Contracts;
using Groupe1.Webzine.Entity;
using Groupe1.Webzine.Repository.Contracts;
using Groupe1.Webzine.WebApplication.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Groupe1.Webzine.WebApplication.Controllers
{
    /// <summary>
    /// Controller de la vue ChroniqueTitre
    /// </summary>
    public class TitreController : Controller
    {
        private ITitreRepository _repository;
        private IStyleRepository _styleRepository;
        private ICommentaireRepository _commentaireRepository;
        public ITime _time { get; set; }

        public TitreController(ITitreRepository iTitre, IStyleRepository iStyle, ICommentaireRepository iCommentaire, ITime iTime)
        {
            _repository = iTitre;
            _styleRepository = iStyle;
            _commentaireRepository = iCommentaire;
            _time = iTime;
        }

        /// <summary>
        /// Appel de la vue ChroniqueTitre dans le dossier Views/ChroniqueTitre
        /// Appel du ViewModel ChroniqueTitreVM
        /// </summary>
        /// <returns></returns>
        [Route("Titre/{id}")]
        public IActionResult Index(int id)
        {
            var titre = _repository.Find(id);

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
                Time = _time.SecondsConverter(titre.Duree),
                IdTitre = titre.IdTitre,
                NbLikes = titre.NbLikes,
                DateCreation = titre.DateCreation
            };
            return View(model);
        }

        [Route("Titres/Style/{name}")]
        public IActionResult Style(string name)
        {
            var style = _styleRepository.Find(name);
            var titres = _repository.SearchByStyle(style.Libelle);
            List<TitreVM> titresVM = new List<TitreVM>();
            var titreVM = new TitreVM();
            foreach (var titre in titres)
            {
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
            var model = new StyleIndexForTitreVM
            {
                LibelleStyle = style.Libelle,
                Titres = titresVM.ToList()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Liker(Entity.Titre titreLiker)
        {
            titreLiker = _repository.Find(titreLiker.IdTitre);
            _repository.IncrementNbLikes(titreLiker);
            return this.RedirectToAction(nameof(TitreController.Index), new { Id = titreLiker.IdTitre });
        }

        [HttpPost]
        public IActionResult Commenter(TitreIndexVM model)
        {
            var commentaire = new Commentaire { Auteur = model.commentaire.Auteur, Contenu = model.commentaire.Contenu, DateCreation = model.commentaire.DateCreation, IdTitre = model.IdTitre, IdCommentaire = model.commentaire.IdCommentaire};
            _commentaireRepository.Add(commentaire);
            return RedirectToAction("Index", "Titre", new { id = model.IdTitre });
        }

    }
}
