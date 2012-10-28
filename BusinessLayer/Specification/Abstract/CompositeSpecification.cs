
namespace BusinessLayer.Specification.Abstract
{
    public abstract class CompositeSpecification<T> : ISpecification<T>
    {
        public abstract bool IsSatisfiedBy(T item);

        public AndSpecification<T> And(ISpecification<T> other)
        {
            return new AndSpecification<T>(this, other);
        }

        public OrSpecification<T> Or(ISpecification<T> other)
        {
            return new OrSpecification<T>(this, other);
        }

        public NotSpecification<T> Not(ISpecification<T> other)
        {
            return new NotSpecification<T>(other);
        }
    }
}
