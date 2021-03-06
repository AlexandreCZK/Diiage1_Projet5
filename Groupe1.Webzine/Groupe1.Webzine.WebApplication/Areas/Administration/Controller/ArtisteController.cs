using Groupe1.Webzine.Entity;
using Groupe1.Webzine.Repository.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Groupe1.Webzine.WebApplication.Areas.Administration.Controller
{
    /// <summary>
    /// Controlleur pour la page Artistes de l'Area Admimnistration @ip:port/Administration/Artist/{action}
    /// </summary>
    [Area("Administration")]
    public class ArtisteController : Microsoft.AspNetCore.Mvc.Controller
    {
        private IArtisteRepository _repository;
        public ArtisteController(IArtisteRepository iArtiste)
        {
            _repository = iArtiste;
        }

        /// <summary>
        /// Methode retournant la vue Index {action = /}
        /// </summary>
        /// <returns>La vue pour voir et agir avec les Artistes</returns>
        [Route("administration/artistes")]
        public IActionResult Index()
        {
            var artistes = _repository.FindAll();
            return View(artistes);
        }

        /// <summary>
        /// Methode retournant la vue Create {action = /Create}
        /// </summary>
        /// <returns>La vue pour creer un Artiste</returns>
        public IActionResult Create()
        {
            return View("Create_Edit");
        }

        // <summary>
        /// Methode retournant la vue Edit {action = /Edit}
        /// </summary>
        /// <returns>La vue pour modifier un Artiste</returns>
        public IActionResult Edit(int id)
        {
            var artiste = _repository.Find(id);

            return View("Create_Edit", artiste);
        }

        // <summary>
        /// Methode retournant la vue Delete {action = /Delete}
        /// </summary>
        /// <returns>La vue pour supprimer un Artiste</returns>
        public IActionResult Delete(int id)
        {
            var artiste = _repository.Find(id);

            return View(artiste);
        }

        [HttpPost]
        public IActionResult DeleteAction(Artiste artiste)
        {
            artiste = _repository.Find(artiste.IdArtiste);

            if (artiste != null)
            {
                _repository.Delete(artiste);
                return this.RedirectToAction(
                    nameof(ArtisteController.Index)
                    );
            }

            return this.View(nameof(Delete));
        }

        [HttpPost]
        public IActionResult Create_UpdateAction(Artiste artiste)
        {
            ModelState.Remove("IdArtiste");
            if (this.ModelState.IsValid)
            {
                if (artiste.IdArtiste == 0)
                {
                    _repository.Add(artiste);
                }
                else
                {
                    _repository.Update(artiste);
                }
                return this.RedirectToAction(
                    nameof(ArtisteController.Index)
                    );
            }

            return View("Create_Edit");
        }
    }
}
