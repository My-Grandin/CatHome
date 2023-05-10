using CatHome.Domain.Entities;

namespace CatHome.Domain.Repositories
{
    public interface ICatRepository
    {
        Task<List<Cat>> GetCatsAsync();
        Task<bool> CatExists(int id);
    }
}
