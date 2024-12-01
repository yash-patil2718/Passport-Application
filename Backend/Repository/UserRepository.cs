using ContessoUniversity.Repository;
using Microsoft.EntityFrameworkCore;
using PassportWebApplication.Data;
using PassportWebApplication.DTO.ApplicationStatusDto;
using PassportWebApplication.Models;
using PassportWebApplication.Repository.IRepository;

namespace PassportWebApplication.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly PassportContext _context;

        public UserRepository(PassportContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(user => user.Email == email);
        }

        public async Task<User> GetUserByUsername(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(user => string.Compare(user.UserName,username,true)==0);
        }

        public async Task<PaymentUpdateDto> MakePaymentForApplication(PaymentUpdateDto model)
        {
            var applicationToUpdate = await _context.MasterDetails
                                                .Where(a => a.ApplicationNo == model.ApplicationNo)
                                                .FirstOrDefaultAsync();
            if (applicationToUpdate == null)
            {
                return model;
            }
            else
            {
                applicationToUpdate.PaymentStatus = Enums.PaymentStatus.Paid;
                applicationToUpdate.UpdatedOn = DateTime.Now;
                _context.MasterDetails.Update(applicationToUpdate);
                await _context.SaveChangesAsync();
                return model;
            }
        }
    }
}
