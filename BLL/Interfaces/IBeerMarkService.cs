using DAL.Entities;

namespace BLL.Interfaces;

public interface IBeerMarkService
{
    Task<List<BeerMarkViewModel>> GetBeerMarks();
}