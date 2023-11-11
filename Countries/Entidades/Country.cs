namespace Countries.Entidades
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Tid { get; set; }
        public string Capitals { get; set; }
        public string SubRegion { get; set; }
        public double Area { get; set; }
        public int Population { get; set; }
        public string Continents { get; set; }
        public string Flags { get; set; }
        public List<CountryActivity> CountryActivities { get; set; }
    }
}
