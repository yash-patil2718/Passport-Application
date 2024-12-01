using Microsoft.AspNetCore.Mvc;
using PassportWebApplication.Models;

namespace PassportWebApplication.Repository.IRepository
{
    public interface IOtherRepository : IRepository<OtherDetails>
    {

        Task<ActionResult<OtherDetails>> CreateOtherDetailsAsync(OtherDetails model);
    }
}
