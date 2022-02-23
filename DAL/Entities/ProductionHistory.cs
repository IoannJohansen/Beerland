namespace DAL.Entities;

public class ProductionHistory
{
    public long Id { get; set; }

    public DateTime Date { get; set; }

    public string BeerMark { get; set; }

    public long ActualVolume { get; set; }
}