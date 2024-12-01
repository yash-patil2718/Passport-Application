namespace PassportWebApplication.Repository.IRepository
{
    public interface IUnitofWork : IDisposable
    {
        public IUserRepository UserRepository { get; }
        public IFeedbackRepository FeedbackRepository { get; }
        public IServiceRepository ServiceRepository { get; }
        public IApplicantRepository ApplicantRepository { get; }
        public IFamilyRepository FamilyRepository { get; }
        public IResidentialRepository ResidentialRepository { get; }
        public IEmergencyRepository EmergencyRepository { get; }
        public IOtherRepository OtherRepository { get; }
        public IDocumentsRepository DocumentsRepository { get; }
        public IAdminRepository AdminRepository { get; }
        public IMasterDetailsRepository MasterDetailsRepository { get; }
        Task<int> SaveAsync();
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}
