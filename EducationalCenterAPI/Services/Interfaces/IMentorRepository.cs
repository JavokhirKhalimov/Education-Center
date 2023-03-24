using EducationalCenterAPI.Models;
using EducationalCenterAPI.Models.PostModels;

namespace EducationalCenterAPI.Services.Interfaces
{
    public interface IMentorRepository
    {
        Task<IEnumerable<Mentor>> GetAllMentorsAsync();
        Task<Mentor> GetMentorByIdAsync(int id);
        Task<Mentor> DeleteMentorByIdAsync(int id);
        Task<Mentor> UpdateMentorByIdAsync(PostMentor mentor);
        Task<Mentor> AddMentorAsync(PostMentor mentor);
    }
}
