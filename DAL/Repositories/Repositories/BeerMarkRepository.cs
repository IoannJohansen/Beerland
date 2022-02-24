using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Repositories;

public class BeerMarkRepository : IBeerMarkRepository
{
    private readonly ApplicationDbContext _applicationDbContext;

    public BeerMarkRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<List<BeerMark>> GetAllBeerMarks()
    {
        return await _applicationDbContext.BeerMarks.ToListAsync();
    }
}