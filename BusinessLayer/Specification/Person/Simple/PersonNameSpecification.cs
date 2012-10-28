using BusinessLayer.Specification.Abstract;

namespace BusinessLayer.Specification.Person.Simple
{
    using Person = BusinessLayer.Entity.Person;

    public class PersonNameSpecification:ISpecification<Person>
    {
        private readonly string _nameFragment;

        public PersonNameSpecification(string nameFragment)
        {
            this._nameFragment = nameFragment;
        }

        public bool IsSatisfiedBy(Person item)
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
