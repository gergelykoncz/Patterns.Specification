using System;

namespace BusinessLayer.Specification.Abstract
{
    public class NotSpecification<T> : CompositeSpecification<T>
    {
        private readonly ISpecification<T> _other;

        public NotSpecification(ISpecification<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("other");
            }
            this._other = other;
        }

        public override bool IsSatisfiedBy(T item)
        {
            return !_other.IsSatisfiedBy(item);
        }
    }
}
