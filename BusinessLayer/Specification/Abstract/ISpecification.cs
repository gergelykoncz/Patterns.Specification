
namespace BusinessLayer.Specification.Abstract
{
    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T item);
    }
}
