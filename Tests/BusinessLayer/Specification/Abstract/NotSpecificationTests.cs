using System;
using BusinessLayer.Specification.Abstract;
using Moq;
using NUnit.Framework;

namespace Tests.BusinessLayer.Specification.Abstract
{
    [TestFixture]
    public class NotSpecificationTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorFailsIfNoOtherSpecificationIsSupplied()
        {
            new NotSpecification<object>(null);
        }

        [Test]
        public void IsSatisfiedByReturnsNegateOfPassedSpecification()
        {
            var otherSpecification = new Mock<ISpecification<object>>();
            otherSpecification.Setup<bool>(x => x.IsSatisfiedBy(It.IsAny<object>())).Returns(false);

            var specification = new NotSpecification<object>(otherSpecification.Object);
            Assert.True(specification.IsSatisfiedBy(string.Empty));
        }
    }
}
