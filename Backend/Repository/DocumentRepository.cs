using ContessoUniversity.Repository;
using Microsoft.AspNetCore.Mvc;
using PassportWebApplication.Data;
using PassportWebApplication.Models;
using PassportWebApplication.Repository.IRepository;

namespace PassportWebApplication.Repository
{
    public class DocumentRepository : Repository<Documents>, IDocumentsRepository
    {
        private readonly PassportContext _context;
        public DocumentRepository(PassportContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ActionResult<Documents>> CreateDocumentAsync(Documents model)
        {
            await _context.Documents.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }
    }
}
