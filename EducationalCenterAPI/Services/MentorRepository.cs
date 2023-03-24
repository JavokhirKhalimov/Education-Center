using EducationalCenterAPI.Data;
using EducationalCenterAPI.Entitys;
using EducationalCenterAPI.Models;
using EducationalCenterAPI.Models.PostModels;
using EducationalCenterAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EducationalCenterAPI.Services
{
    public class MentorRepository : IMentorRepository
    {
        private readonly DataContext _dataContext;
        private readonly IWebHostEnvironment _webHost;

        public MentorRepository(
            DataContext dataContext,
            IWebHostEnvironment webHost)
        {
            _dataContext = dataContext;
            _webHost = webHost;
        }

        public async Task<Mentor> AddMentorAsync(PostMentor mentor)
        {
            string fileExt = Path.GetExtension(mentor.Image.FileName);
            string fileName = Guid.NewGuid().ToString() + fileExt;
            string filePath = Path.Combine("images", "mentors", fileName);
            string fullPath = Path.Combine(_webHost.WebRootPath, filePath);

            Mentor men = new Mentor();

            using(var stream = File.Open(fullPath, FileMode.OpenOrCreate))
            {
                await mentor.Image.CopyToAsync(stream);
                men.ImageUrl = filePath;
            }
            men.CvUrl = mentor.CvUrl;
            men.FullName = mentor.FullName;
            men.Discription = mentor.Discription;
            
            await _dataContext.Mentors.AddAsync(men);
            await _dataContext.SaveChangesAsync();

            return men;
        }

        public async Task<Mentor> DeleteMentorByIdAsync(int id)
        {
            var mentor = await this.GetMentorByIdAsync(id);
            string fullPath = Path.Combine(_webHost.WebRootPath, mentor.ImageUrl);
            System.IO.File.Delete(fullPath);
            _dataContext.Mentors.Remove(mentor);
            await _dataContext.SaveChangesAsync();
            return mentor;
        }

        public async Task<IEnumerable<Mentor>> GetAllMentorsAsync()
        {
            var mentors = await _dataContext.Mentors.ToListAsync();
            return mentors;
        }

        public async Task<Mentor> GetMentorByIdAsync(int id)
        {
            var mentor = await _dataContext.Mentors
                .FirstOrDefaultAsync(mentor => mentor.Id == id);
            if (mentor is null)
                throw new KeyNotFoundException("Bunday mentor mavjud emas!");
            return mentor;
        }

        public Task<Mentor> UpdateMentorByIdAsync(PostMentor mentor)
        {
            throw new NotImplementedException();
        }
    }
}
