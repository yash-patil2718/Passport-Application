using ContessoUniversity.Repository;
using Microsoft.AspNetCore.Mvc;
using PassportWebApplication.Data;
using PassportWebApplication.Models;
using PassportWebApplication.Repository.IRepository;

namespace PassportWebApplication.Repository
{
    public class ApplicantRepository : Repository<ApplicantDetails>, IApplicantRepository
    {
        private readonly PassportContext _context;
        public ApplicantRepository(PassportContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ActionResult<ApplicantDetails>> CreateApplicantDetailsAsync(ApplicantDetails model)
        {
            await _context.ApplicantDetails.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }
    }
}
