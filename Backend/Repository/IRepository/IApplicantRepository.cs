using Microsoft.AspNetCore.Mvc;
using PassportWebApplication.Models;

namespace PassportWebApplication.Repository.IRepository
{
    public interface IApplicantRepository : IRepository<ApplicantDetails>
    {
        Task<ActionResult<ApplicantDetails>> CreateApplicantDetailsAsync(ApplicantDetails model);
    }
}
