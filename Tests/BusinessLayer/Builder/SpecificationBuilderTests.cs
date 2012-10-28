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
        public void ReturnsAndSpecificationIfSpecifiedInQuery()
        {
            var builder = new SpecificationBuilder();
            PersonQuery query = new PersonQuery() { Logic = SpecificationLogic.And };
            var specification = builder.BuildSpecificationFromQuery(query);

            Assert.IsInstanceOf<AndSpecification<Person>>(specification);
        }

        [Test]
        public void ReturnsOrSpecificationIfSpecifiedInQuery()
        {
            var builder = new SpecificationBuilder();
            PersonQuery query = new PersonQuery() { Logic = SpecificationLogic.Or };
            var specification = builder.BuildSpecificationFromQuery(query);

            Assert.IsInstanceOf<OrSpecification<Person>>(specification);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void FailsIfNoLogicIsSpecifiedInQuery()
        {
            var builder = new SpecificationBuilder();
            PersonQuery query = new PersonQuery();
            builder.BuildSpecificationFromQuery(query);
        }
    }
}
