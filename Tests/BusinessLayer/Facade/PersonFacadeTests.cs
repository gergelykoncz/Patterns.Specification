using System.Collections.Generic;
using System.Linq;
using BusinessLayer.Entity;
using BusinessLayer.Facade;
using BusinessLayer.Repository;
using Moq;
using NUnit.Framework;

namespace Tests.BusinessLayer.Facade
{
    [TestFixture]
    public class PersonFacadeTests
    {
        [Test]
        public void GetPersonsReturnsAllFromRepository()
        {
            List<Person> persons = new List<Person>();
            persons.Add(new Person("a", 1, "a"));
            persons.Add(new Person("b", 2, "b"));

            var repositoryMock = new Mock<PersonRepository>();
            repositoryMock.Setup<IEnumerable<Person>>(x => x.GetAll()).Returns(persons.AsEnumerable());

            var facade = new PersonFacade(repositoryMock.Object);

            Assert.AreEqual(persons.AsEnumerable(), facade.GetPersons());
        }
    }
}
