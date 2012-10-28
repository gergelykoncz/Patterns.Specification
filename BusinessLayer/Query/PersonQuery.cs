
namespace BusinessLayer.Query
{
    public class PersonQuery
    {
        public string NameFragment { get; set; }
        public string JobFragment { get; set; }
        public int? MinAge { get; set; }
        public int? MaxAge { get; set; }
        public SpecificationLogic NameLogic { get; set; }
        public SpecificationLogic JobLogic { get; set; }
        public SpecificationLogic MinAgeLogic { get; set; }
    }
}
