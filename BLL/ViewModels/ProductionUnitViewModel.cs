namespace BLL.ViewModels;

public class ProductionUnitViewModel
{
    public long Id { get; set; }

    public DateTime Date { get; set; }

    public int Produced { get; set; }

    public string BeerMark { get; set; }
}