using CatHome.Domain.Entities;

namespace CatHome.Domain.Services.Interfaces
{
    public interface ICatService
    {
        Task<List<Cat>> GetCatsAsync();
    }
}
