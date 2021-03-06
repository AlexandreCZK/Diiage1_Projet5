using Groupe1.Webzine.Business.Contracts;
using Groupe1.Webzine.Entity;
using Groupe1.Webzine.Repository.Contracts;
using Groupe1.Webzine.WebApplication.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Groupe1.Webzine.WebApplication.Areas.Administration.Controller
{
    /// <summary>
    /// Controlleur pour la page Titre de l'Area Admimnistration @ip:port/Administration/Titre/{action}
    /// </summary>
    [Area("Administration")]
    public class TitreController : Microsoft.AspNetCore.Mvc.Controller
    {
        private IArtisteRepository _repositoryArtiste;
        private ITitreRepository _repositoryTitre;
        private IStyleRepository _repositoryStyle;
        private ITime _time;
        public TitreController(IArtisteRepository iArtiste, ITitreRepository iTitre, IStyleRepository iStyle, ITime iTime)
        {
            _repositoryArtiste = iArtiste;
            _repositoryTitre = iTitre;
            _repositoryStyle = iStyle;
            _time = iTime;
        }

        /// <summary>
        /// Methode retournant la vue Index {action = /}
        /// </summary>
        /// <returns>La vue pour voir et agir avec les Titres</returns>
        [Route("administration/titres")]
        public IActionResult Index()
        {
            var titres = _repositoryTitre.FindAll();
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
            return View(nameof(Index), titresVM);
        }

        /// <summary>
        /// Methode retournant la vue Create {action = /Create}
        /// </summary>
        /// <returns>La vue pour creer un Titre</returns>
        public IActionResult Create()
        {
            this.ViewBag.Artistes = _repositoryArtiste.FindAll();
            this.ViewBag.Styles = _repositoryStyle.FindAll();
            return View("Create_Edit");
        }

        // <summary>
        /// Methode retournant la vue Edit {action = /Edit}
        /// </summary>
        /// <returns>La vue pour modifier un Titre</returns>
        public IActionResult Edit(int id)
        {
            var titre = _repositoryTitre.Find(id);

            this.ViewBag.Artistes = _repositoryArtiste.FindAll();
            this.ViewBag.Styles = _repositoryStyle.FindAll();
            return View("Create_Edit", titre);
        }

        // <summary>
        /// Methode retournant la vue Delete {action = /Delete}
        /// </summary>
        /// <returns>La vue pour supprimer un Titre</returns>
        public IActionResult Delete(int id)
        {
            var titre = _repositoryTitre.Find(id);

            return View(nameof(Delete), titre);
        }

        [HttpPost]
        public IActionResult DeleteAction(Titre titre)
        {
            titre = _repositoryTitre.Find(titre.IdTitre);

            if (titre != null)
            {
                _repositoryTitre.Delete(titre);
                return this.RedirectToAction(
                    nameof(TitreController.Index)
                    );
            }
            this.ModelState.AddModelError(string.Empty, "Titre introuvable");
            return this.View(nameof(Delete));
        }

        [HttpPost]
        public IActionResult Create_UpdateAction(Titre titre)
        {
            ModelState.Remove("IdTitre");
            titre.DateCreation = DateTime.Now;
            if (this.ModelState.IsValid)
            {
                if (titre.IdTitre == 0)
                {
                    _repositoryTitre.Add(titre);
                }
                else
                {
                    _repositoryTitre.Update(titre);
                }
                return this.RedirectToAction(
                    nameof(ArtisteController.Index)
                    );
            }
            this.ViewBag.Artistes = _repositoryArtiste.FindAll();
            this.ViewBag.Styles = _repositoryStyle.FindAll();
            return View("Create_Edit");
        }
    }
}
