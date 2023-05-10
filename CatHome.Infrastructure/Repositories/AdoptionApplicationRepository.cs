using CatHome.Domain.Entities;
using CatHome.Domain.Repositories;
using CatHome.Infrastructure.Context;
using Newtonsoft.Json;

namespace CatHome.Infrastructure.Repositories
{
    public class AdoptionApplicationRepository : IAdoptionApplicationRepository
    {
        private readonly string _filePathForAdoptionApplications = @"../CatHome.Infrastructure/adoptionApplications.json";
        private readonly JsonContext _context;

        public AdoptionApplicationRepository(JsonContext context)
        {
            if (!File.Exists(_filePathForAdoptionApplications))
            {
                File.WriteAllText(_filePathForAdoptionApplications, "[]");
            }
            _context = context;
        }
        public async Task<AdoptionApplication> PostAdoptionApplicationAsync(AdoptionApplication adoptionApplication)
        {
            var applications = await GetAdoptionApplicationsAsync();
            adoptionApplication.Id = _context.GetNextId(applications);

            applications.Add(adoptionApplication);

            await _context.AddDataToJsonFile(_filePathForAdoptionApplications, applications);
            
            return adoptionApplication;
        }

        public async Task<List<AdoptionApplication>> GetAdoptionApplicationsAsync()
        {
            return await _context.DeserializeJsonFile<AdoptionApplication>(_filePathForAdoptionApplications);
        }
    }
}
