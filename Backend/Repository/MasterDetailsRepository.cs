using ContessoUniversity.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PassportWebApplication.Data;
using PassportWebApplication.DTO.ApplicationStatusDto;
using PassportWebApplication.Models;
using PassportWebApplication.Repository.IRepository;

namespace PassportWebApplication.Repository
{
    public class MasterDetailsRepository : Repository<MasterDetails>, IMasterDetailsRepository
    {
        private readonly PassportContext _passportContext;
        public MasterDetailsRepository(PassportContext context) : base(context)
        {
            _passportContext = context;
        }

        public async Task<ActionResult<MasterDetails>> CreateMasterDetailsAsync(MasterDetails model)
        {
            await _passportContext.MasterDetails.AddAsync(model);
            await _passportContext.SaveChangesAsync();
            return model;
        }

        public async Task<TrackApplicationDetailsDto> GetApplicationStatusDetails([FromBody]TrackApplicationDto model)
        {
            try
            {
                var application = await (from p in _passportContext.MasterDetails
                                         join a in _passportContext.ApplicantDetails
                                         on p.ApplicntDetailsId equals a.ApplicntDetailsId
                                         where p.ApplicationNo == model.ApplicationNo // Assuming ApplicationNo is in MasterDetails table
                                         select new
                                         {
                                             PaymentStatus = p.PaymentStatus,
                                             ApplicantFirstName = a.ApplicantFirstName,
                                             ApplicantLastName = a.ApplicantLastName,
                                             ApplicationStatus = p.ApplicationStatus,
                                         }).FirstOrDefaultAsync();

                var applicationDetails = new TrackApplicationDetailsDto
                {
                    ApplicationNo = model.ApplicationNo,
                    ApplicantName = application.ApplicantFirstName + " " + application.ApplicantLastName,
                    ApplicationType = model.ApplicationType,
                    DateOfBirth = model.DOB,
                    PaymentStatus = application.PaymentStatus,
                    ApplicationStatus = application.ApplicationStatus,
                };
                return applicationDetails;
            }
            catch (Exception ex) 
            {
                return null;
            }
        }


        
    }
}
