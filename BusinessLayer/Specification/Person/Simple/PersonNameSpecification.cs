using BusinessLayer.Specification.Abstract;

namespace BusinessLayer.Specification.Person.Simple
{
    using Person = BusinessLayer.Entity.Person;

    public class PersonNameSpecification : CompositeSpecification<Person>
    {
        private readonly string _nameFragment;

        public PersonNameSpecification(string nameFragment)
        {
            this._nameFragment = nameFragment;
        }

        public override bool IsSatisfiedBy(Person item)
        {
            if (string.IsNullOrEmpty(_nameFragment))
            {
                return true;
            }
            else
            {
                return item.Name.ToUpper().Contains(_nameFragment.ToUpper());
            }
        }
    }
}
