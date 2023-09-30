using System.Xml.Serialization;

namespace TNBase.Domain
{
    public class Collector
    {
        [XmlIgnore]
        public int Id { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string Number { get; set; }
        public string Postcodes { get; set; }
    }
}
