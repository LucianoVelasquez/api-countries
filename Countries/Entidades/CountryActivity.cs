namespace Countries.Entidades
{
    public class CountryActivity
    {
        public int CountryId { get; set; }
        public int ActivityId { get; set; }
        public string CountryTid { get; set; }

        public Country Country { get; set; }
        public Activity Activity { get; set; }
    }
}