using AutoMapper;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace BLL.Services;

public class BeerMarkService : IBeerMarkService
{
    private readonly IBeerMarkRepository _beerMarkRepository;
    private readonly IMapper _mapper;

    public BeerMarkService(IBeerMarkRepository beerMarkRepository, IMapper mapper)
    {
        _beerMarkRepository = beerMarkRepository;
        _mapper = mapper;
    }

    public async Task<List<BeerMarkViewModel>> GetBeerMarks()
    {
        var beerMarks = await _beerMarkRepository.GetAllBeerMarks();
        return _mapper.Map<List<BeerMark>, List<BeerMarkViewModel>>(beerMarks);
    }
}