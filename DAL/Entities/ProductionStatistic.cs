namespace DAL.Entities
{
    public class ProductionStatistic
    {
        public long Id { get; set; }

        public DateTime Date { get; set; }

        public double Target { get; set; }

        public double Produced { get; set; }

        public long BeerMarkId { get; set; }

        public BeerMark BeerMark { get; set; }
    }
}
