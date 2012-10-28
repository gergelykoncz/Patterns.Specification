using BusinessLayer.Specification.Abstract;
using Moq;

namespace Tests.BusinessLayer.Specification.Abstract.TestHelper
{
    public class SpecificationGenerator
    {
        public static ISpecification<object> GetSpecification(bool satisfiedBy)
        {
            var mock = new Mock<ISpecification<object>>();
            mock.Setup<bool>(x => x.IsSatisfiedBy(It.IsAny<object>())).Returns(satisfiedBy);
            return mock.Object;
        }

    }
}
