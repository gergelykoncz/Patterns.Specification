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
            if (query.Logic == SpecificationLogic.And)
            {
                return 
                    new PersonNameSpecification(query.NameFragment)
                    .And(new PersonFromAgeSpecification(query.MinAge))
                    .And(new PersonUntilAgeSpecification(query.MaxAge))
                    .And(new PersonJobTitleSpecification(query.JobFragment));
            }
            else if (query.Logic == SpecificationLogic.Or)
            {
                return
                    new PersonNameSpecification(query.NameFragment)
                    .Or(new PersonFromAgeSpecification(query.MinAge))
                    .Or(new PersonUntilAgeSpecification(query.MaxAge))
                    .Or(new PersonJobTitleSpecification(query.JobFragment));
            }
            else
            {
                throw new InvalidOperationException("Query.Logic is in invalid state.");
            }
        }
    }
}
