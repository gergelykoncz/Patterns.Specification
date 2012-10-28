using BusinessLayer.Entity;
using BusinessLayer.Specification.Person.Simple;
using NUnit.Framework;

namespace Tests.BusinessLayer.Specification.Persons
{
    [TestFixture]
    public class PersonJobTitleSpecificationTests
    {
        [Test]
        public void ReturnsTrueIfNoJobTitleIsSupplied()
        {
            var specification = new PersonJobTitleSpecification(string.Empty);
            var person = new Person();
            Assert.True(specification.IsSatisfiedBy(person));
        }

        [Test]
        public void ReturnsTrueWhenMatchesPartially()
        {
            var specification = new PersonJobTitleSpecification("CEO");
            var person = new Person() { JobTitle = "The CEO" };
            Assert.True(specification.IsSatisfiedBy(person));
        }

        [Test]
        public void MatchingIsCaseInsensitive()
        {
            var specification = new PersonJobTitleSpecification("Manager");
            var person = new Person() { JobTitle = "MaNaGeR" };
            Assert.True(specification.IsSatisfiedBy(person));
        }
    }
}
