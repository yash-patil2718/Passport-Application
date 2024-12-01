using Microsoft.AspNetCore.Mvc;
using PassportWebApplication.Models;

namespace PassportWebApplication.Repository.IRepository
{
    public interface IDocumentsRepository : IRepository<Documents> 
    {
        Task<ActionResult<Documents>> CreateDocumentAsync(Documents model);
    }
}
