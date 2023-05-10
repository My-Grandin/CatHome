using CatHome.Domain.Entities;
using CatHome.Domain.Repositories;
using CatHome.Domain.Services.Interfaces;

namespace CatHome.Domain.Services
{
    public class CatService : ICatService
    {
        private readonly ICatRepository _catRepository;

        public CatService(ICatRepository catRepository)
        {
            _catRepository = catRepository;
        }

        public async Task<List<Cat>> GetCatsAsync()
        {
            return await _catRepository.GetCatsAsync();
        }

    }
}
