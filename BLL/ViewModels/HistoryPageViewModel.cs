using DAL.Entities;

namespace BLL.ViewModels;

public class HistoryPageViewModel
{
    public List<ProductionHistory> History { get; set; }

    public double ActualValue { get; set; }
}