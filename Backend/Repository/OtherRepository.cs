using ContessoUniversity.Repository;
using Microsoft.AspNetCore.Mvc;
using PassportWebApplication.Data;
using PassportWebApplication.Models;
using PassportWebApplication.Repository.IRepository;

namespace PassportWebApplication.Repository
{
    public class OtherRepository : Repository<OtherDetails>, IOtherRepository
    {
        private readonly PassportContext _context;

        public OtherRepository(PassportContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ActionResult<OtherDetails>> CreateOtherDetailsAsync(OtherDetails model)
        {
            await _context.OtherDetails.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }
    }
}
