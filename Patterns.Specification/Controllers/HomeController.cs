using System.Web.Mvc;
using BusinessLayer.Facade;
using BusinessLayer.Query;
using Patterns.Specification.ViewModels;

namespace Patterns.Specification.Controllers
{
    public class HomeController : Controller
    {

        private readonly IPersonFacade _personFacade;

        public HomeController(IPersonFacade personFacade)
        {
            this._personFacade = personFacade;
        }

        [HttpGet]
        public ViewResult Index()
        {
            var viewModel = new PersonViewModel();
            viewModel.Result = _personFacade.GetPersons();
            viewModel.Query = new PersonQuery();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(PersonViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.Result = _personFacade.Search(model.Query);
            }
            return View(model);
        }
    }
}
