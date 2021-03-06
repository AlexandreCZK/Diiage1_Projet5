using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Groupe1.Webzine.Repository.Contracts;

namespace Groupe1.Webzine.WebApplication.Controllers.Components
{
    public class SideBar : ViewComponent
    {
        private IStyleRepository _repository { get; set; }

        public SideBar(IStyleRepository iStyle)
        {
            _repository = iStyle;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // du code ici, on peut faire comme dans un controller
            // à savoir, récupérer un model et le passer à la vue
            var vm = _repository.FindAll();
            // attention : si cela peut ressembler à un contrôleur, cela n'en
            // est pas un. Le view component ne répond pas à une requête HTTP
            return this.View(vm);
            // ou par exemple nomDeMaVue (au lieu de Default.cshtml)
            // return this.View('nomDeMaVue', vm);
        }
    }
}
