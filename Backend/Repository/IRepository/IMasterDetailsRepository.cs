using Microsoft.AspNetCore.Mvc;
using PassportWebApplication.DTO.ApplicationStatusDto;
using PassportWebApplication.Models;

namespace PassportWebApplication.Repository.IRepository
{
    public interface IMasterDetailsRepository : IRepository<MasterDetails>
    {
        Task<ActionResult<MasterDetails>> CreateMasterDetailsAsync(MasterDetails model);

        Task<TrackApplicationDetailsDto> GetApplicationStatusDetails(TrackApplicationDto model);

    }
}
