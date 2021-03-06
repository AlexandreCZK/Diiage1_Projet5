using Microsoft.AspNetCore.Mvc;

namespace Groupe1.Webzine.WebApplication.Controllers
{
    /// <summary>
    /// Controller de la page contact
    /// </summary>
    public class ContactController : Controller
    {
        /// <summary>
        /// Appel de la vue Index dans le dossier Views/Contact
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }
    }
}
