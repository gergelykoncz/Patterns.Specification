
namespace BusinessLayer.Entity
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string JobTitle { get; set; }

        public Person() { }
        public Person(string name, int age, string jobTitle)
        {
            this.Name = name;
            this.Age = age;
            this.JobTitle = jobTitle;
        }
    }
}
