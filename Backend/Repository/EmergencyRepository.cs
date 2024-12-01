using ContessoUniversity.Repository;
using Microsoft.AspNetCore.Mvc;
using PassportWebApplication.Data;
using PassportWebApplication.Models;
using PassportWebApplication.Repository.IRepository;

namespace PassportWebApplication.Repository
{
    public class EmergencyRepository : Repository<EmergencyDetails>, IEmergencyRepository
    {
        private readonly PassportContext _context;
        public EmergencyRepository(PassportContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ActionResult<EmergencyDetails>> CreateEmergencyDetailsAsync(EmergencyDetails model)
        {
            await _context.EmergencyDetails.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }
    }
}
