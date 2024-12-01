using ContessoUniversity.Repository;
using Microsoft.AspNetCore.Mvc;
using PassportWebApplication.Data;
using PassportWebApplication.Models;
using PassportWebApplication.Repository.IRepository;

namespace PassportWebApplication.Repository
{
    public class ResidentialRepository : Repository<ResidentialDetails>, IResidentialRepository
    {
        private readonly PassportContext _context;
        public ResidentialRepository(PassportContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ActionResult<ResidentialDetails>> CreateResidentialDetailsAsync(ResidentialDetails model)
        {
            await _context.ResidentialDetails.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }
    }
}
