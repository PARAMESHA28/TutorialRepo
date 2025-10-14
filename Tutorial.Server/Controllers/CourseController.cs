using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tutorial.Domain.Constant;
using Tutorial.Domain.IServices;
using Tutorial.Domain.Models;
using Tutorial.Domain.Models.Dtos;

namespace Tutorial.Server.Controllers
{
    [Route(RootMapConstants.BaseControllerRoute)]
    public class CourseController : ControllerBase
    {
        public readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var courses = await _courseService.GetAllAsync();
            return Ok(courses);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var course = await _courseService.GetByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CourseDto coursedto)
        {
            var createdCourse = await _courseService.CreateAsync(coursedto);

            return CreatedAtAction(nameof(GetById), new { id = createdCourse.CourseId }, createdCourse);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CourseDto course)
        {
            if (id != course.CourseId)
            {
                return BadRequest();
            }
            var existingCourse = await _courseService.GetByIdAsync(id);
            if (existingCourse == null)
            {
                return NotFound();
            }
            await _courseService.UpdateAsync(course);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingCourse = await _courseService.GetByIdAsync(id);
            if (existingCourse == null)
            {
                return NotFound();
            }
            await _courseService.DeleteAsync(id);
            return NoContent();
        }
        
    }
}
