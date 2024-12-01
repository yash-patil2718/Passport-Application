using PassportWebApplication.DTO.ApplicationStatusDto;
using PassportWebApplication.Models;

namespace PassportWebApplication.Repository.IRepository
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserByUsername(string username);
        Task<User> GetUserByEmail(string email);
        Task<PaymentUpdateDto> MakePaymentForApplication(PaymentUpdateDto model);
    }
}
