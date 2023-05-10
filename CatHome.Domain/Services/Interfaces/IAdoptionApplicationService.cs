using CatHome.Domain.DTOs.WriteDTOs;
using CatHome.Domain.Entities;

namespace CatHome.Domain.Services.Interfaces
{
    public interface IAdoptionApplicationService
    {
        Task<List<AdoptionApplication>> GetAdoptionApplicationsAsync();
        Task<AdoptionApplication> PostAdoptionApplication(AdoptionApplicationWriteDTO adoptionApplication);
    }
}
