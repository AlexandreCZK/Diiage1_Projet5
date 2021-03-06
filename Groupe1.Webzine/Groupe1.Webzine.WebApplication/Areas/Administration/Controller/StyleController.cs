using Groupe1.Webzine.Entity;
using Groupe1.Webzine.Repository;
using Groupe1.Webzine.Repository.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Groupe1.Webzine.WebApplication.Areas.Administration.Controller
{
    /// <summary>
    /// Controlleur pour la page Style de l'Area Admimnistration @ip:port/Administration/Style/{action}
    /// </summary>
    [Area("Administration")]
    public class StyleController : Microsoft.AspNetCore.Mvc.Controller
    {
        private IStyleRepository _repository;

        public StyleController(IStyleRepository iStyle)
        {
            _repository = iStyle;
        }

        /// <summary>
        /// Methode retournant la vue Index {action = /}
        /// </summary>
        /// <returns>La vue pour voir et agir avec les Styles</returns>
        [Route("administration/styles")]
        public IActionResult Index()
        {
            var styles = _repository.FindAll();

            return View(nameof(Index), styles);
        }

        /// <summary>
        /// Methode retournant la vue Create {action = /Create}
        /// </summary>
        /// <returns>La vue pour creer un Style</returns>
        public IActionResult Create()
        {
            return View("Create_Edit");
        }

        // <summary>
        /// Methode retournant la vue Edit {action = /Edit}
        /// </summary>
        /// <returns>La vue pour modifier un Style</returns>
        public IActionResult Edit(int id)
        {
            var style = _repository.Find(id);

            return View("Create_Edit", style);
        }

        // <summary>
        /// Methode retournant la vue Delete {action = /Delete}
        /// </summary>
        /// /// <param name="id">id du style</param>
        /// <returns>La vue pour supprimer un Style</returns>
        public IActionResult Delete(int id)
        {
            var style = _repository.Find(id);

            return View(nameof(Delete), style);
        }

        [HttpPost]
        public IActionResult DeleteAction(Style style)
        {
            style = _repository.Find(style.IdStyle);

            if (style != null)
            {
                _repository.Delete(style);
                return this.RedirectToAction(
                    nameof(StyleController.Index)
                    );
            }
            this.ModelState.AddModelError(string.Empty, "Style introuvable");
            return this.View(nameof(Delete));
        }

        [HttpPost]
        public IActionResult Create_UpdateAction(Style style)
        {
            ModelState.Remove("IdStyle");
            if (this.ModelState.IsValid)
            {
                if (style.IdStyle == 0)
                {
                    _repository.Add(style);
                }
                else
                {
                    _repository.Update(style);
                }
                
                return this.RedirectToAction(
                    nameof(StyleController.Index)
                    );
            }
            return View("Create_Edit");
        }
    }
}
