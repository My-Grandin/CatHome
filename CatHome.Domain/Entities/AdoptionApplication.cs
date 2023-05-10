namespace CatHome.Domain.Entities
{
    public class AdoptionApplication
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public int CatId { get; set; }
        public bool MustBeApprovedByAnotherMember { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ApprovedBy { get; set; }
        public AdoptionApplicationStatus Status { get; set; } = AdoptionApplicationStatus.PENDING;
    }
}
