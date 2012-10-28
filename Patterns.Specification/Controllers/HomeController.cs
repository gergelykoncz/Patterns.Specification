using System.Web.Mvc;
using BusinessLayer.Facade;

namespace Patterns.Specification.Controllers
{
    public class HomeController : Controller
    {

        private readonly PersonFacade _personFacade;

        public HomeController(PersonFacade personFacade)
        {
            this._personFacade = personFacade;
        }

        public ActionResult Index()
        {
            return View(_personFacade.GetPersons());
        }

    }
}
