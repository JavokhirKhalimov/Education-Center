using EducationalCenterAPI.Entitys;
using EducationalCenterAPI.Models.PostModels;
using EducationalCenterAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EducationalCenterAPI.Controllers
{
    [ApiController,
        Route("api/[controller]")]
    public class MentorController : ControllerBase
    {
        private readonly IMentorRepository _mentorRepository;
        public MentorController(IMentorRepository mentorRepository)
        {
            _mentorRepository = mentorRepository;
        }

        [HttpGet, Authorize]
        public async Task<IActionResult> GetAll()
        {
            var mentors = await _mentorRepository.GetAllMentorsAsync();
            return Ok(mentors);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var mentor = await _mentorRepository.GetMentorByIdAsync(id);
            return Ok(mentor);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm] PostMentor postMentor)
        {
            return Ok(await _mentorRepository.AddMentorAsync(postMentor));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var mentor = await _mentorRepository.DeleteMentorByIdAsync(id);
            return Ok(mentor);
        }
    }
}
