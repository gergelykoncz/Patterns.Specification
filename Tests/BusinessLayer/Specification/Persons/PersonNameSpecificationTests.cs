using BusinessLayer.Entity;
using BusinessLayer.Specification.Person.Simple;
using NUnit.Framework;

namespace Tests.BusinessLayer.Specification.Persons
{
    [TestFixture]
    public class PersonNameSpecificationTests
    {
        [Test]
        public void ReturnsTrueIfNoNameIsSupplied()
        {
            var specification = new PersonNameSpecification(string.Empty);
            var person = new Person();
            Assert.True(specification.IsSatisfiedBy(person));
        }

        [Test]
        public void ReturnsTrueWhenMatchesPartially()
        {
            var specification = new PersonNameSpecification("din");
            var person = new Person() { Name = "Edina" };
            Assert.True(specification.IsSatisfiedBy(person));
        }

        [Test]
        public void MatchingIsCaseInsensitive()
        {
            var specification = new PersonNameSpecification("JOHN");
            var person = new Person() { Name = "John" };
            Assert.True(specification.IsSatisfiedBy(person));
        }
    }
}
