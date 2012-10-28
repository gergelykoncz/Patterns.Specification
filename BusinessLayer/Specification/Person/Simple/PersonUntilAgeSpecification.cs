using BusinessLayer.Specification.Abstract;

namespace BusinessLayer.Specification.Person.Simple
{
    using Person = BusinessLayer.Entity.Person;

    public class PersonUntilAgeSpecification : CompositeSpecification<Person>
    {
        private readonly int? _untilAge;

        public PersonUntilAgeSpecification(int? untilAge)
        {
            this._untilAge = untilAge;
        }

        public override bool IsSatisfiedBy(Person item)
        {
            if (!_untilAge.HasValue)
            {
                return true;
            }
            else
            {
                return item.Age <= _untilAge.Value;
            }
        }
    }
}
