using BusinessLayer.Entity;
using BusinessLayer.Specification.Person.Simple;
using NUnit.Framework;

namespace Tests.BusinessLayer.Specification.Persons
{
    [TestFixture]
    public class PersonUntilAgeSpecificationTests
    {
        [Test]
        public void ReturnsTrueIfNoValueIsSpecified()
        {
            var specification = new PersonUntilAgeSpecification(null);
            var person = new Person();

            Assert.True(specification.IsSatisfiedBy(person));
        }

        [Test]
        public void ReturnsFalseIfPersonAgeBiggerThanNumberSpeicifed()
        {
            var specification = new PersonUntilAgeSpecification(14);
            var person = new Person() { Age = 15 };

            Assert.False(specification.IsSatisfiedBy(person));
        }

        [Test]
        public void ReturnsTrueIfPersonAgeEqualsNumberSpeicifed()
        {
            var specification = new PersonUntilAgeSpecification(15);
            var person = new Person() { Age = 15 };

            Assert.True(specification.IsSatisfiedBy(person));
        }

        [Test]
        public void ReturnsTrueIfPersonAgeLesserThanNumberSpeicifed()
        {
            var specification = new PersonUntilAgeSpecification(16);
            var person = new Person() { Age = 15 };

            Assert.True(specification.IsSatisfiedBy(person));
        }
    }
}
