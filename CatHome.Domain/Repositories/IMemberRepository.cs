namespace CatHome.Domain.Repositories
{
    public interface IMemberRepository
    {
        Task<bool> MemberExists(int id);
    }
}
