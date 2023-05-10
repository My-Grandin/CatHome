using CatHome.Domain.Entities;

namespace CatHome.Domain.Repositories
{
    public interface IAdoptionApplicationRepository
    {
        Task<List<AdoptionApplication>> GetAdoptionApplicationsAsync();
        Task<AdoptionApplication> PostAdoptionApplicationAsync(AdoptionApplication adoptionApplication);
    }
}
