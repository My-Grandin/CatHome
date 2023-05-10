using CatHome.Domain.Entities;
using CatHome.Domain.Repositories;
using CatHome.Infrastructure.Context;

namespace CatHome.Infrastructure.Repositories
{
    public class CatRepository : ICatRepository
    {
        public CatRepository(JsonContext context)
        {
            _context = context;
        }
        private readonly string _filePathForCats = @"../CatHome.Infrastructure/cats.json";
        private readonly string _filePathForTowns = @"../CatHome.Infrastructure/towns.json";
        private readonly JsonContext _context;

        public async Task<List<Cat>> GetCatsAsync()
        {
            var cats = await _context.DeserializeJsonFile<Cat>(_filePathForCats);
            cats = await SetTownToCats(cats);

            return cats;
        }

        public async Task<bool> CatExists(int id)
        {
            var cats = await _context.DeserializeJsonFile<Cat>(_filePathForCats);
            return cats.Any(c => c.Id == id);
        }

        private async Task<List<Cat>> SetTownToCats(List<Cat> cats)
        {
            var towns = await _context.DeserializeJsonFile<Town>(_filePathForTowns);
            foreach (Cat cat in cats)
            {
                cat.City = towns.Single(t => t.Id == cat.Town);
            }
            return cats;
        }
    }
}
