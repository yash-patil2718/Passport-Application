using ContessoUniversity.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PassportWebApplication.Data;
using PassportWebApplication.Models;
using PassportWebApplication.Repository.IRepository;

namespace PassportWebApplication.Repository
{
    public class FeedbackRepository : Repository<Feedback>, IFeedbackRepository
    {
        private readonly PassportContext _context;
        public FeedbackRepository(PassportContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ActionResult<Feedback>> CreateAsync(Feedback feedback)
        {
             _context.Feedbacks.Add(feedback);
              await _context.SaveChangesAsync();
            return feedback;
        }

        public async Task<bool> ExistsAsync(int feedbackId)
        {
            return await _context.Feedbacks.AnyAsync(f => f.FeedbackId == feedbackId);
        }

        public Task<Feedback> GetAllFeedbacksAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Feedback> GetFeedbackById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
