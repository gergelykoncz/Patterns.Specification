using System;

namespace BusinessLayer.Specification.Abstract
{
    public class AndSpecification<T> : CompositeSpecification<T>
    {
        private readonly ISpecification<T> _left;
        private readonly ISpecification<T> _right;

        public AndSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            if (left == null)
            {
                throw new ArgumentNullException("left");
            }
            if (right == null)
            {
                throw new ArgumentNullException("right");
            }

            this._left = left;
            this._right = right;
        }

        public override bool IsSatisfiedBy(T item)
        {
            return _left.IsSatisfiedBy(item) && _right.IsSatisfiedBy(item);
        }
    }
}
