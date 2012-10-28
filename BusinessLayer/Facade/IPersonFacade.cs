using System.Collections.Generic;
using BusinessLayer.Entity;
using BusinessLayer.Query;

namespace BusinessLayer.Facade
{
    public interface IPersonFacade
    {
        IEnumerable<Person> GetPersons();
        IEnumerable<Person> Search(PersonQuery query);
    }
}
