using Microsoft.AspNetCore.Mvc;
using PassportWebApplication.Models;

namespace PassportWebApplication.Repository.IRepository
{
    public interface IFamilyRepository :IRepository<FamilyDetails>
    {
        Task<ActionResult<FamilyDetails>> CreateFamilyDetailsAsync(FamilyDetails model);
    }
}
