using System;
using BusinessLayer.Specification.Abstract;
using Moq;
using NUnit.Framework;
using Tests.BusinessLayer.Specification.Abstract.TestHelper;

namespace Tests.BusinessLayer.Specification.Abstract
{
    class OrSpecificationTests
    {
        private ISpecification<object> _left;
        private ISpecification<object> _right;

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorThrowsIfLeftIsNull()
        {
            _left = null;
            _right = new Mock<ISpecification<Object>>().Object;
            new OrSpecification<object>(_left, _right);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorThrowsIfRightIsNull()
        {
            _left = new Mock<ISpecification<Object>>().Object;
            _right = null;
            new OrSpecification<object>(_left, _right);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorThrowsIfBothAreNull()
        {
            _left = null;
            _right = null;
            new OrSpecification<object>(_left, _right);
        }

        [Test]
        public void IsSatisfiedByReturnsTrueIfBothAreSatisfiedBy()
        {
            _left = SpecificationGenerator.GetSpecification(true);
            _right = SpecificationGenerator.GetSpecification(true);
            var orSpecification = new OrSpecification<object>(_left, _right);

            Assert.True(orSpecification.IsSatisfiedBy(string.Empty));
        }

        [Test]
        public void IsSatisfiedByReturnsTrueIfLeftIsntSatisfied()
        {
            _left = SpecificationGenerator.GetSpecification(false);
            _right = SpecificationGenerator.GetSpecification(true);
            var orSpecification = new OrSpecification<object>(_left, _right);

            Assert.True(orSpecification.IsSatisfiedBy(string.Empty));
        }

        [Test]
        public void IsSatisfiedByReturnsTrueIfRightIsntSatisfied()
        {
            _left = SpecificationGenerator.GetSpecification(true);
            _right = SpecificationGenerator.GetSpecification(false);
            var orSpecification = new OrSpecification<object>(_left, _right);

            Assert.True(orSpecification.IsSatisfiedBy(string.Empty));
        }

        [Test]
        public void IsSatisfiedByReturnsFalsefBothArentSatisfied()
        {
            _left = SpecificationGenerator.GetSpecification(false);
            _right = SpecificationGenerator.GetSpecification(false);
            var orSpecification = new OrSpecification<object>(_left, _right);

            Assert.False(orSpecification.IsSatisfiedBy(string.Empty));
        }

    }
}
