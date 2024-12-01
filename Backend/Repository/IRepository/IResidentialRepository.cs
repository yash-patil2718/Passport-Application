using Microsoft.AspNetCore.Mvc;
using PassportWebApplication.Models;

namespace PassportWebApplication.Repository.IRepository
{
    public interface IResidentialRepository : IRepository<ResidentialDetails>
    {
        Task<ActionResult<ResidentialDetails>> CreateResidentialDetailsAsync(ResidentialDetails model);
    }
}
