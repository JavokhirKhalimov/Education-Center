using Microsoft.AspNetCore.Mvc;

namespace EducationalCenterAPI.Controllers
{
    [ApiController,
        Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            var res = StatusCode(StatusCodes.Status200OK, new
            {
                message = "Ishlamoqda"
            });
            return res;
        }

        [HttpGet("{id:int}")]
        public object getbyid(int id)
        {
            return id;
        }
    }
}
