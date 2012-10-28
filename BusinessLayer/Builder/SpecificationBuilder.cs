using System;
using BusinessLayer.Entity;
using BusinessLayer.Query;
using BusinessLayer.Specification.Abstract;
using BusinessLayer.Specification.Person.Simple;

namespace BusinessLayer.Builder
{
    public class SpecificationBuilder
    {
        public ISpecification<Person> BuildSpecificationFromQuery(PersonQuery query)
        {
            var leftSpec = GetNameAndJobSpecification(query.NameLogic, query.NameFragment, query.JobFragment);
            var rightSpec = GetAgeSpecifications(query.MinAgeLogic, query.MinAge, query.MaxAge);
            return getSpecificationByLogic(query.JobLogic, leftSpec, rightSpec);
        }

        public ISpecification<Person> GetNameAndJobSpecification(SpecificationLogic logic, string nameFragment, string jobFragment)
        {
            var nameSpecification = new PersonNameSpecification(nameFragment);
            var jobSpecification = new PersonJobTitleSpecification(jobFragment);

            return getSpecificationByLogic(logic, nameSpecification, jobSpecification);

        }

        public ISpecification<Person> GetAgeSpecifications(SpecificationLogic logic, int? minAge, int? maxAge)
        {
            var minAgeSpecification = new PersonFromAgeSpecification(minAge);
            var maxAgeSpecification = new PersonUntilAgeSpecification(maxAge);

            return getSpecificationByLogic(logic, minAgeSpecification, maxAgeSpecification);
        }

        private ISpecification<Person> getSpecificationByLogic(SpecificationLogic logic, ISpecification<Person> left, ISpecification<Person> right)
        {
            if (logic == SpecificationLogic.And)
            {
                return new AndSpecification<Person>(left, right);
            }
            else if (logic == SpecificationLogic.Or)
            {
                return new OrSpecification<Person>(left, right);
            }
            else
            {
                throw new InvalidOperationException("Query.Logic is in invalid state.");
            }
        }
    }
}
