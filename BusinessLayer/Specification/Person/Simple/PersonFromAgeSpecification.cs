using BusinessLayer.Specification.Abstract;

namespace BusinessLayer.Specification.Person.Simple
{
    using Person = BusinessLayer.Entity.Person;

    public class PersonFromAgeSpecification : ISpecification<Person>
    {
        private readonly int? _fromAge;

        public PersonFromAgeSpecification(int? fromAge)
        {
            this._fromAge = fromAge;
        }

        public bool IsSatisfiedBy(Person item)
        {
            if (!_fromAge.HasValue)
            {
                return true;
            }
            else
            {
                return item.Age >= _fromAge.Value;
            }
        }
    }
}
