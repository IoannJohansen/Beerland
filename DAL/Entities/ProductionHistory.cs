using System.ComponentModel.DataAnnotations;

namespace DAL.Entities;

public class ProductionHistory
{
    [Key] public long Id { get; set; }

    public DateTime Date { get; set; }

    public long BeerMarkId { get; set; }

    public double ActualVolume { get; set; }

    public virtual BeerMark Beermark { get; set; }
}