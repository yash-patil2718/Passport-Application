using ContessoUniversity.Repository;
using Microsoft.AspNetCore.Mvc;
using PassportWebApplication.Data;
using PassportWebApplication.Models;
using PassportWebApplication.Repository.IRepository;

namespace PassportWebApplication.Repository
{
    public class FamilyRepository : Repository<FamilyDetails>, IFamilyRepository
    {
        private readonly PassportContext _context;
        public FamilyRepository(PassportContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ActionResult<FamilyDetails>> CreateFamilyDetailsAsync(FamilyDetails model)
        {
            await _context.FamilyDetails.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }
    }
}
