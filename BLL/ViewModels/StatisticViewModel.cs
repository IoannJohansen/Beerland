namespace BLL.ViewModels;

public class StatisticViewModel
{
    public DateTime Date { get; set; }

    public double Target { get; set; }

    public double Produced { get; set; }
    
    public string BeerMark { get; set; }
}