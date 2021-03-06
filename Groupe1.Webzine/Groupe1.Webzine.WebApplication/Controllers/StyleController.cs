using Groupe1.Webzine.Repository.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Groupe1.Webzine.WebApplication.Controllers
{
    /// <summary>
    /// Controller de la page Style
    /// </summary>
    /// <returns></returns>
    public class StyleController : Controller
    {
        private ITitreRepository _repositoryT { get; set; }
        private IStyleRepository _repositoryS { get; set; }

        public StyleController(ITitreRepository iTItre, IStyleRepository iStyle)
        {
            _repositoryT = iTItre;
            _repositoryS = iStyle;
        }

        /// <summary>
        /// Appel de la vue dans le dossier views/style
        /// </summary>
        /// <returns>Les musiques associées au style</returns>
        public IActionResult Index(int id)
        {
            var style = _repositoryS.Find(id);
            var titres = _repositoryT.SearchByStyle(style.Libelle);
            var model = new ViewModels.StyleIndexVM
            {
                LibelleStyle = style.Libelle,
                Titres = titres.ToList()
            };
            return View(model);
        }

        public IActionResult Index(string name)
        {
            var style = _repositoryS.Find(name);
            var titres = _repositoryT.SearchByStyle(style.Libelle);
            var model = new ViewModels.StyleIndexVM
            {
                LibelleStyle = style.Libelle,
                Titres = titres.ToList()
            };
            return View(model);
        }
    }
}
