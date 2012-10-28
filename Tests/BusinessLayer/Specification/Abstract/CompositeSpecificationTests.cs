using BusinessLayer.Specification.Abstract;
using Moq;
using NUnit.Framework;

namespace Tests.BusinessLayer.Specification.Abstract
{
    [TestFixture]
    public class CompositeSpecificationTests
    {
        [Test]
        public void AndReturnsAndSpecification()
        {
            var compositeSpecification = new Mock<CompositeSpecification<object>>().Object;
            var otherSpeicfication = new Mock<ISpecification<object>>().Object;
            ISpecification<object> andSpecification = compositeSpecification.And(otherSpeicfication);

            Assert.IsInstanceOf<AndSpecification<object>>(andSpecification);
        }

        [Test]
        public void OrReturnsOrSpecification()
        {
            var compositeSpecification = new Mock<CompositeSpecification<object>>().Object;
            var otherSpeicfication = new Mock<ISpecification<object>>().Object;
            ISpecification<object> orSpecification = compositeSpecification.Or(otherSpeicfication);

            Assert.IsInstanceOf<OrSpecification<object>>(orSpecification);
        }

        [Test]
        public void NotReturnsNotSpecification()
        {
            var compositeSpecification = new Mock<CompositeSpecification<object>>().Object;
            var otherSpeicfication = new Mock<ISpecification<object>>().Object;
            ISpecification<object> notSpecification = compositeSpecification.Not(otherSpeicfication);

            Assert.IsInstanceOf<NotSpecification<object>>(notSpecification);
        }
    }
}
