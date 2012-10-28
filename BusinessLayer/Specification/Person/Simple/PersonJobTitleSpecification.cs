using BusinessLayer.Specification.Abstract;

namespace BusinessLayer.Specification.Person.Simple
{
    using Person = BusinessLayer.Entity.Person;

    public class PersonJobTitleSpecification : ISpecification<Person>
    {
        private readonly string _jobTitleFragment;

        public PersonJobTitleSpecification(string jobTitleFragment)
        {
            this._jobTitleFragment = jobTitleFragment;
        }

        public bool IsSatisfiedBy(Person item)
        {
            if (string.IsNullOrEmpty(_jobTitleFragment))
            {
                return true;
            }
            else
            {
                return item.JobTitle.ToUpper().Contains(_jobTitleFragment.ToUpper());
            }
        }
    }
}
