using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Facade;

namespace Patterns.Specification.Controllers
{
    public class HomeController : Controller
    {

        private readonly ICarFacade _carFacade;

        public HomeController(ICarFacade carFacade)
        {
            this._carFacade = carFacade;
        }

        public ActionResult Index()
        {
            return View();
        }

    }
}
