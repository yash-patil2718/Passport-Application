using Microsoft.AspNetCore.Mvc;
using PassportWebApplication.Models;

namespace PassportWebApplication.Repository.IRepository
{
    public interface IEmergencyRepository : IRepository<EmergencyDetails>
    {
        Task<ActionResult<EmergencyDetails>> CreateEmergencyDetailsAsync(EmergencyDetails model);
    }
}
