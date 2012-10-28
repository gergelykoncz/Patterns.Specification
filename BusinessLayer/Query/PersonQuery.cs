
namespace BusinessLayer.Query
{
    public class PersonQuery
    {
        public string NameFragment { get; set; }
        public string JobFragment { get; set; }
        public int? MinAge { get; set; }
        public int? MaxAge { get; set; }
        public SpecificationLogic Logic { get; set; }
    }
}
