using System;
using BusinessLayer.Specification.Abstract;
using Moq;
using NUnit.Framework;
using Tests.BusinessLayer.Specification.Abstract.TestHelper;

namespace Tests.BusinessLayer.Specification.Abstract
{
    [TestFixture]
    public class AndSpecificationTests
    {
        private ISpecification<object> _left;
        private ISpecification<object> _right;

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorThrowsIfLeftIsNull()
        {
            _left = null;
            _right = new Mock<ISpecification<Object>>().Object;
            new AndSpecification<object>(_left, _right);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorThrowsIfRightIsNull()
        {
            _left = new Mock<ISpecification<Object>>().Object;
            _right = null;
            new AndSpecification<object>(_left, _right);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorThrowsIfBothAreNull()
        {
            _left = null;
            _right = null;
            new AndSpecification<object>(_left, _right);
        }

        [Test]
        public void IsSatisfiedByReturnsTrueIfBothAreSatisfiedBy()
        {
            _left = SpecificationGenerator.GetSpecification(true);
            _right = SpecificationGenerator.GetSpecification(true);
            var andSpecification = new AndSpecification<object>(_left, _right);

            Assert.True(andSpecification.IsSatisfiedBy(string.Empty));
        }

        [Test]
        public void IsSatisfiedByReturnsFalseIfLeftIsntSatisfied()
        {
            _left = SpecificationGenerator.GetSpecification(false);
            _right = SpecificationGenerator.GetSpecification(true);
            var andSpecification = new AndSpecification<object>(_left, _right);

            Assert.False(andSpecification.IsSatisfiedBy(string.Empty));
        }

        [Test]
        public void IsSatisfiedByReturnsFalseIfRightIsntSatisfied()
        {
            _left = SpecificationGenerator.GetSpecification(true);
            _right = SpecificationGenerator.GetSpecification(false);
            var andSpecification = new AndSpecification<object>(_left, _right);

            Assert.False(andSpecification.IsSatisfiedBy(string.Empty));
        }

        [Test]
        public void IsSatisfiedByReturnsFalseIBothArentSatisfied()
        {
            _left = SpecificationGenerator.GetSpecification(false);
            _right = SpecificationGenerator.GetSpecification(false);
            var andSpecification = new AndSpecification<object>(_left, _right);

            Assert.False(andSpecification.IsSatisfiedBy(string.Empty));
        }
    }
}
