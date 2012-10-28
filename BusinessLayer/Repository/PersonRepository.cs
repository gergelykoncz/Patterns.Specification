﻿using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLayer.Entity;
using BusinessLayer.Specification.Abstract;

namespace BusinessLayer.Repository
{
    public class PersonRepository
    {
        private IList<Person> _persons;
        private IList<Person> Persons
        {
            get
            {
                if (_persons == null)
                {
                    _persons = buildFakeList();
                }
                return _persons;
            }
        }

        private string[] _names = { "John", "Mary", "Tim", "Ed" };
        private string[] _titles = { "CEO", "IT Professional", "Developer", "Consultant" };


        public IEnumerable<Person> GetAll()
        {
            return Persons;
        }

        public IEnumerable<Person> GetBySpecification(ISpecification<Person> specification)
        {
            return Persons.Where(x => specification.IsSatisfiedBy(x));
        }

        private IList<Person> buildFakeList()
        {
            var result = new List<Person>();
            Random rnd = new Random();
            for (int i = 0; i < 5; i++)
            {
                result.Add(generatePerson(rnd));
            }

            return result;
        }

        private Person generatePerson(Random rnd)
        {
            
            int nameIndex = rnd.Next(0, 3);
            int jobIndex = rnd.Next(0, 3);
            int age = rnd.Next(18, 99);

            return new Person(_names[nameIndex], age, _titles[jobIndex]);
        }
    }
}