using BusinessLayer.Entity;
using BusinessLayer.Specification.Person.Simple;
using NUnit.Framework;

namespace Tests.BusinessLayer.Specification.Persons
{
    [TestFixture]
    public class PersonFromAgeSpecificationTests
    {
        [Test]
        public void ReturnsTrueIfNoValueIsSpecified()
        {
            var specification = new PersonFromAgeSpecification(null);
            var person = new Person();

            Assert.True(specification.IsSatisfiedBy(person));
        }

        [Test]
        public void ReturnsTrueIfPersonAgeBiggerThanNumberSpeicifed()
        {
            var specification = new PersonFromAgeSpecification(14);
            var person = new Person() { Age = 15 };

            Assert.True(specification.IsSatisfiedBy(person));
        }

        [Test]
        public void ReturnsTrueIfPersonAgeEqualsNumberSpeicifed()
        {
            var specification = new PersonFromAgeSpecification(15);
            var person = new Person() { Age = 15 };

            Assert.True(specification.IsSatisfiedBy(person));
        }

        [Test]
        public void ReturnsFalsefPersonAgeLesserThanNumberSpeicifed()
        {
            var specification = new PersonFromAgeSpecification(16);
            var person = new Person() { Age = 15 };

            Assert.False(specification.IsSatisfiedBy(person));
        }
    }
}
