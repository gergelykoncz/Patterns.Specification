using System.Collections.Generic;
using System.Linq;
using BusinessLayer.Entity;
using BusinessLayer.Facade;
using Moq;
using NUnit.Framework;
using Patterns.Specification.Controllers;
using Patterns.Specification.ViewModels;

namespace Tests.WebUI.Controllers
{
    [TestFixture]
    public class HomeControllerTests
    {
        [Test]
        public void PersonModelGetsDataFromFacadeOnGet()
        {
            var facade = new Mock<IPersonFacade>();
            var persons = new List<Person>();
            persons.Add(new Person("Test", 1, "Test"));
            facade.Setup<IEnumerable<Person>>(x => x.GetPersons()).Returns(persons.AsEnumerable());
            var xy = facade.Object;
            HomeController controller = new HomeController(facade.Object);

            var result = controller.Index();
            var viewModel = result.Model as PersonViewModel;

            Assert.AreEqual(persons, viewModel.Result);
        }
    }
}
