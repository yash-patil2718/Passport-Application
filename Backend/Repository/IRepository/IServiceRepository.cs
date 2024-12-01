using Microsoft.AspNetCore.Mvc;
using PassportWebApplication.DTO.NewApplication;
using PassportWebApplication.Models;

namespace PassportWebApplication.Repository.IRepository
{
    public interface IServiceRepository : IRepository<ServiceRquired>
    {
        Task<ActionResult<ServiceRquired>> CreateServiceRequiredAsync(ServiceRquired model);
    }
}
