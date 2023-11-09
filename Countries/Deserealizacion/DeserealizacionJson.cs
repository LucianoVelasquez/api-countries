namespace Countries.Deserealizacion
{
    public class Name
    {
        public string Common { get; set; }
    }

    public class Country
    {
        public Name Name { get; set; }
        public List<string> Tld { get; set; }
        public List<string> Capital { get; set; }
        public string Subregion { get; set; }
        public double Area { get; set; }
        public int Population { get; set; }
        public List<string> Continents { get; set; }
        public Flags Flags { get; set; }
    }

    public class Flags
    {
        public string Png { get; set; }
    }

    public class RootObject
    {
        public List<Country> Countries { get; set; }
    }
}
