using System.Collections.Generic;
using BusinessLayer.Entity;
using BusinessLayer.Query;

namespace Patterns.Specification.ViewModels
{
    public class PersonViewModel
    {
        public IEnumerable<Person> Result { get; set; }
        public PersonQuery Query { get; set; }
    }
}