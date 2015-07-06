using Bow.Administracion;
using Bow.Administracion.DTOs.InputModels;
using System.Web.Mvc;

namespace Bow.Web.Controllers
{
    public class HomeController : BowControllerBase
    {
        private IAdministracionService _zonificacionService;

        public HomeController(IAdministracionService zonificacionService)
        {
            _zonificacionService = zonificacionService;
        }

        public ActionResult Index()
        {
            //_zonificacionService.SavePais(new SavePaisInput { Nombre = "Chileeeaaa", Indicativo = "34" });
            return View("~/App/Main/views/layout/layout.cshtml"); //Layout of the angular application.
        }
	}
}