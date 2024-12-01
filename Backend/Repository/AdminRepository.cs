using AutoMapper;
using ContessoUniversity.Repository;
using Microsoft.EntityFrameworkCore;
using PassportWebApplication.Data;
using PassportWebApplication.DTO.AdminDto;
using PassportWebApplication.DTO.Feedback;
using PassportWebApplication.Enums;
using PassportWebApplication.Models;
using PassportWebApplication.Repository.IRepository;

namespace PassportWebApplication.Repository
{
    public class AdminRepository : Repository<User>, IAdminRepository
    {
        private readonly PassportContext _context;
        public AdminRepository(PassportContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Feedback>> GetAllFeedbacks()
        {
            var feedbacks = await _context.Feedbacks.Where(app => app.FeedbackType == FeedbackType.Feedback).ToListAsync();
            return feedbacks;
        }

        public async Task<IEnumerable<Feedback>> GetAllComplaints()
        {
            var feedbacks = await _context.Feedbacks.Where(app => app.FeedbackType == FeedbackType.Complaint).ToListAsync();
            return feedbacks;
        }

        public async Task UpdateCustomerComplaint(AdminFeedbackDto model)
        {
            var dataToUpdate = await _context.Feedbacks.FindAsync(model.FeedbackId);

            if (dataToUpdate != null) 
            {
                dataToUpdate.Status = model.Status;
                 _context.Feedbacks.Update(dataToUpdate);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<UpdateApplicationDto>> GetAllNewApplications()
        {
            IEnumerable<UpdateApplicationDto> data = await (from m in _context.MasterDetails
                                                            join a in _context.ApplicantDetails
                                                            on m.ApplicntDetailsId equals a.ApplicntDetailsId
                                                            join s in _context.ServiceRquireds
                                                            on m.ServiceRequiredId equals s.ServiceRequiredId
                                                            where m.PassportType == PassportType.New
                                                            select new UpdateApplicationDto
                                                            {
                                                                ApplicantName = a.ApplicantFirstName + " " + a.ApplicantLastName,
                                                                ApplicationNo = m.ApplicationNo,
                                                                DateOfBirth = a.DOB,
                                                                ApplicationType = s.ApplicationType,
                                                                PaymentStatus = m.PaymentStatus,
                                                                ApplicationStatus = m.ApplicationStatus,
                                                            }).ToListAsync();
            return data;
        }


        public async Task<IEnumerable<UpdateApplicationDto>> GetAllRenewApplications()
        {
            IEnumerable<UpdateApplicationDto> data = await (from m in _context.MasterDetails
                                                            join a in _context.ApplicantDetails
                                                            on m.ApplicntDetailsId equals a.ApplicntDetailsId
                                                            join s in _context.ServiceRquireds
                                                            on m.ServiceRequiredId equals s.ServiceRequiredId
                                                            where m.PassportType == PassportType.Renewal
                                                            select new UpdateApplicationDto
                                                            {
                                                                ApplicantName = a.ApplicantFirstName + " " + a.ApplicantLastName,
                                                                ApplicationNo = m.ApplicationNo,
                                                                DateOfBirth = a.DOB,
                                                                ApplicationType = s.ApplicationType,
                                                                PaymentStatus = m.PaymentStatus,
                                                                ApplicationStatus = m.ApplicationStatus,
                                                            }).ToListAsync();
            return data;
        }
        
        // update Application Details
        public async Task UpdateApplicationStatus(UpdateApplicationDto model)
        {
            var application = await _context.MasterDetails.Where(a => a.ApplicationNo == model.ApplicationNo).FirstOrDefaultAsync();
            if (application != null) 
            {
                application.ApplicationStatus = model.ApplicationStatus;
                application.UpdatedOn = DateTime.Now;
                _context.MasterDetails.Update(application);
                await _context.SaveChangesAsync();
            }
        
        }

        public async Task<IEnumerable<UserListDto>> GetAllUsersAsync()
        {
            try 
            {
                var users = await (from u in _context.Users
                                  select new UserListDto
                                   {
                                       FirstName        = u.FirstName,
                                       LastName         = u.LastName,
                                       DOB              = u.DOB,
                                       Email            = u.Email,
                                       MobileNo         = u.PhoneNo,
                                       Username         = u.UserName,
                                       AccountCretedOn  =  u.CreatedOn
                                   }).ToListAsync(); 
                return users;
            }catch (Exception ex) 
            {
                return null;
            }
        }
    }
}
