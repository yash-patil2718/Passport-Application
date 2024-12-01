using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using PassportWebApplication.Data;
using PassportWebApplication.Repository.IRepository;

namespace PassportWebApplication.Repository
{
    public class UnitOfWork : IUnitofWork
    {
        private bool disposedValue;
        private readonly PassportContext _passportContext;
        private IDbContextTransaction _transaction;
        public IUserRepository UserRepository { get; }
        public IFeedbackRepository FeedbackRepository { get; }

        public IServiceRepository ServiceRepository { get; }

        public IApplicantRepository ApplicantRepository { get; }

        public IFamilyRepository FamilyRepository { get; }

        public IResidentialRepository ResidentialRepository { get; }

        public IEmergencyRepository EmergencyRepository { get; }

        public IOtherRepository OtherRepository { get; }

        public IDocumentsRepository DocumentsRepository { get; }

        public IMasterDetailsRepository MasterDetailsRepository { get; }

        public IAdminRepository AdminRepository { get; }

        public UnitOfWork( PassportContext passportContext)
        {
            this.UserRepository = new UserRepository(passportContext);
            this.FeedbackRepository = new FeedbackRepository(passportContext);
            this.ServiceRepository = new ServiceRepository(passportContext);
            this.ApplicantRepository = new ApplicantRepository(passportContext);
            this.FamilyRepository = new FamilyRepository(passportContext);
            this.ResidentialRepository = new ResidentialRepository(passportContext);
            this.EmergencyRepository = new EmergencyRepository(passportContext);
            this.OtherRepository = new OtherRepository(passportContext);
            this.DocumentsRepository = new DocumentRepository(passportContext);
            this.MasterDetailsRepository = new MasterDetailsRepository(passportContext);
            this.AdminRepository = new AdminRepository(passportContext);
            _passportContext = passportContext;
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _passportContext.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            await _transaction.CommitAsync();
        }

        public async Task RollbackTransactionAsync()
        {
            await _transaction.RollbackAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await _passportContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _passportContext.Dispose();
        }
    }
}
