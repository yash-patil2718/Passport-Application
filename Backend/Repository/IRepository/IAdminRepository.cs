using PassportWebApplication.DTO.AdminDto;
using PassportWebApplication.DTO.Feedback;
using PassportWebApplication.Models;

namespace PassportWebApplication.Repository.IRepository
{
    public interface IAdminRepository : IRepository<User>
    {
        Task<IEnumerable<Feedback>> GetAllFeedbacks();
        Task<IEnumerable<Feedback>> GetAllComplaints();
        Task UpdateCustomerComplaint(AdminFeedbackDto model);
        Task<IEnumerable<UpdateApplicationDto>> GetAllNewApplications();

        Task<IEnumerable<UpdateApplicationDto>> GetAllRenewApplications();
        Task UpdateApplicationStatus(UpdateApplicationDto model);
        Task<IEnumerable<UserListDto>> GetAllUsersAsync();
    }
}
