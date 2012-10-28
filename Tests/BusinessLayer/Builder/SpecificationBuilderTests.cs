using System;
using BusinessLayer.Builder;
using BusinessLayer.Entity;
using BusinessLayer.Query;
using BusinessLayer.Specification.Abstract;
using NUnit.Framework;

namespace Tests.BusinessLayer.Builder
{
    [TestFixture]
    public class SpecificationBuilderTests
    {
        [Test]
        public void GetNameAndJobSpecificationReturnsAndSpecificationIfQueryIsAnd()
        {
            var builder = new SpecificationBuilder();
            ISpecification<Person> specification = builder.GetNameAndJobSpecification(SpecificationLogic.And, string.Empty, string.Empty);

            Assert.IsInstanceOf<AndSpecification<Person>>(specification);
        }

        [Test]
        public void GetNameAndJobSpecificationReturnsOrSpecificationIfQueryIsOr()
        {
            var builder = new SpecificationBuilder();
            ISpecification<Person> specification = builder.GetNameAndJobSpecification(SpecificationLogic.Or, string.Empty, string.Empty);

            Assert.IsInstanceOf<OrSpecification<Person>>(specification);
        }

        [Test]
        public void GetAgeSpecificationsReturnsAndSpecificationIfQueryIsAnd()
        {
            var builder = new SpecificationBuilder();
            ISpecification<Person> specification = builder.GetAgeSpecifications(SpecificationLogic.And, 0, 0);

            Assert.IsInstanceOf<AndSpecification<Person>>(specification);
        }

        [Test]
        public void GetAgeSpecificationsReturnsOrSpecificationIfQueryIsOr()
        {
            var builder = new SpecificationBuilder();
            ISpecification<Person> specification = builder.GetAgeSpecifications(SpecificationLogic.Or, 0, 0);

            Assert.IsInstanceOf<OrSpecification<Person>>(specification);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GetSpecificationThrowsWhenQueryIsInvalid()
        {
            var builder = new SpecificationBuilder();
            builder.BuildSpecificationFromQuery(new PersonQuery() { JobLogic = SpecificationLogic.Invalid });
        }
    }
}
