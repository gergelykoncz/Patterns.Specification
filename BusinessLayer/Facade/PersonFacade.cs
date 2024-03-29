﻿using System.Collections.Generic;
using BusinessLayer.Builder;
using BusinessLayer.Entity;
using BusinessLayer.Query;
using BusinessLayer.Repository;
using BusinessLayer.Specification.Abstract;

namespace BusinessLayer.Facade
{
    public class PersonFacade : IPersonFacade
    {
        private readonly PersonRepository _repository;
        private readonly SpecificationBuilder _specificationBuilder;

        public PersonFacade(PersonRepository repository,
            SpecificationBuilder specificationBuilder)
        {
            this._repository = repository;
            this._specificationBuilder = specificationBuilder;
        }

        public virtual IEnumerable<Person> GetPersons()
        {
            return _repository.GetAll();
        }

        public virtual IEnumerable<Person> Search(PersonQuery query)
        {
            ISpecification<Person> personSpecification = _specificationBuilder.BuildSpecificationFromQuery(query);
            return _repository.GetBySpecification(personSpecification);
        }
    }
}
