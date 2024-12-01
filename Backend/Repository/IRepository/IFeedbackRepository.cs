using Microsoft.AspNetCore.Mvc;
using PassportWebApplication.Models;

namespace PassportWebApplication.Repository.IRepository
{
    public interface IFeedbackRepository : IRepository<Feedback>
    {
        Task<ActionResult<Feedback>> CreateAsync(Feedback feedback);
        Task<Feedback> GetAllFeedbacksAsync();
        Task<Feedback> GetFeedbackById(int id);
        Task<bool> ExistsAsync(int feedbackId);
    }
}
