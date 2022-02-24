using DAL.Entities;

namespace DAL.Repositories.Interfaces;

public interface IBeerMarkRepository
{
    Task<List<BeerMark>> GetAllBeerMarks();
}