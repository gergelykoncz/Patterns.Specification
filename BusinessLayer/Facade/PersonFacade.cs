using System.Collections.Generic;
using BusinessLayer.Entity;
using BusinessLayer.Repository;
using BusinessLayer.Query;

namespace BusinessLayer.Facade
{
    public class PersonFacade
    {
        private readonly PersonRepository _repository;

        public PersonFacade(PersonRepository repository)
        {
            this._repository = repository;
        }

        public IEnumerable<Person> GetPersons()
        {
            return _repository.GetAll();
        }

        public IEnumerable<Person> Search(PersonQuery query)
        {
            return _repository.GetAll();
        }
    }
}
