using Groupe1.Webzine.Entity;
using Groupe1.Webzine.Repository.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Groupe1.Webzine.WebApplication.Areas.Administration.Controller
{
    /// <summary>
    /// Controlleur pour la page Commentaire de l'Area Admimnistration @ip:port/Administration/
    /// </summary>
    [Area("Administration")]
    public class CommentaireController : Microsoft.AspNetCore.Mvc.Controller
    {
        private ICommentaireRepository _repository;

        public CommentaireController(ICommentaireRepository iCommentaire)
        {
            _repository = iCommentaire;
        }

        /// <summary>
        /// Methode retournant la vue Index {action = /}
        /// </summary>
        /// <returns>La vue pour voir et agir avec les Commentaires</returns>
        [Route("administration/commentaires")]
        public IActionResult Index()
        {
            var commentaires = _repository.FindAll();
            return View(nameof(Index), commentaires);
        }

        // <summary>
        /// Methode retournant la vue Delete {action = /Delete}
        /// </summary>
        /// /// <param name="id">id du commentaire</param>
        /// <returns>La vue pour supprimer un commmentaire</returns>
        public IActionResult Delete(int id)
        {
            var commentaire = _repository.Find(id);
            return View(nameof(Delete), commentaire);
        }

        [HttpPost]
        public IActionResult DeleteAction(Commentaire commentaire)
        {
            commentaire = _repository.Find(commentaire.IdCommentaire);

            if (commentaire != null)
            {
                _repository.Delete(commentaire);
                return this.RedirectToAction(
                    nameof(CommentaireController.Index)
                    );
            }
            this.ModelState.AddModelError(string.Empty, "Commentaire introuvable");
            return this.View(nameof(Delete));
        }
    }
}
