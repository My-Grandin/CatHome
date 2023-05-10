using CatHome.Domain.DTOs.WriteDTOs;
using CatHome.Domain.Entities;
using CatHome.Domain.Repositories;
using CatHome.Domain.Services.Interfaces;

namespace CatHome.Domain.Services
{
    public class AdoptionApplicationService : IAdoptionApplicationService
    {
        private readonly IAdoptionApplicationRepository _repo;
        private readonly IMemberRepository _memberRepository;
        private readonly ICatRepository _catRepository;

        public AdoptionApplicationService(IAdoptionApplicationRepository repo, IMemberRepository memberRepository, ICatRepository catRepository)
        {
            _repo = repo;
            _memberRepository = memberRepository;
            _catRepository = catRepository;
        }

        public async Task<List<AdoptionApplication>> GetAdoptionApplicationsAsync()
        {
            return await _repo.GetAdoptionApplicationsAsync();
        }
        public async Task<AdoptionApplication> PostAdoptionApplication(AdoptionApplicationWriteDTO applicationDTO)
        {
            var memberExists = await _memberRepository.MemberExists(applicationDTO.MemberId);
            if (!memberExists) throw new ArgumentException("Member does not exist");

            var catExists = await _catRepository.CatExists(applicationDTO.CatId);
            if (!catExists) throw new ArgumentException("Cat does not exist");

            var application = SetAdoptionApplicationData(applicationDTO);
            ValidateAdoptionApplication(application);
            
            return await _repo.PostAdoptionApplicationAsync(application);
        }

        private static void ValidateAdoptionApplication(AdoptionApplication application)
        {
            if (application == null) { throw new ArgumentNullException("Application can't be null"); }
        }

        private static AdoptionApplication SetAdoptionApplicationData(AdoptionApplicationWriteDTO applicationDTO)
        {
            var application = new AdoptionApplication
            {
                CreatedAt = DateTime.Now,
                CatId = applicationDTO.CatId,
                MemberId = applicationDTO.MemberId
            };

            UpdateAdoptionApprovalStatus(application);
            UpdateAdoptionApplicationStatus(application);
            return application;
        }

        private static void UpdateAdoptionApprovalStatus(AdoptionApplication adoptionApplication)
        {
            // Here is where the approval rules will be checked (i.e. if cat is in same town as member, etc.).
            adoptionApplication.MustBeApprovedByAnotherMember = true;
        }

        private static void UpdateAdoptionApplicationStatus(AdoptionApplication adoptionApplication)
        {
            // Here rules will be checked (i.e. if member has record of animal abuse, not old enough, etc. - if so application status gets rejected)
            adoptionApplication.Status = AdoptionApplicationStatus.PENDING;
        }

    }
}
