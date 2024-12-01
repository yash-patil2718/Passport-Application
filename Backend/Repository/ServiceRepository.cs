using AutoMapper;
using ContessoUniversity.Repository;
using Microsoft.AspNetCore.Mvc;
using PassportWebApplication.Data;
using PassportWebApplication.DTO.NewApplication;
using PassportWebApplication.Models;
using PassportWebApplication.Repository.IRepository;

namespace PassportWebApplication.Repository
{
    public class ServiceRepository : Repository<ServiceRquired>, IServiceRepository
    {
        private readonly PassportContext _context;



        public ServiceRepository(PassportContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ActionResult<ServiceRquired>> CreateServiceRequiredAsync(ServiceRquired model)
        {
            await _context.ServiceRquireds.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }
    }
}
