using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tutorial.Domain.Constant;
using Tutorial.Domain.IServices;
using Tutorial.Domain.Models;
using Tutorial.Domain.Models.Dtos;
using Tutorial.Service.ServiceImpl;

namespace Tutorial.Server.Controllers
{
    [Route(RootMapConstants.BaseControllerRoute)]
    public class ContentController : ControllerBase

    {
        public readonly IContentService _contentService;
        public ContentController(IContentService contentService)
        {
            _contentService = contentService;
        }
       
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var contents = await _contentService.GetAllAsync();
            return Ok(contents);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var contents = await _contentService.GetByIdAsync(id);
            return Ok(contents);
        }

        [HttpPost]
        public async Task<IActionResult> Created(ContentDto contentdto)
        {
            var created =await _contentService.CreatedAsync(contentdto);
            return Ok(created);
        }

        [HttpPut]
        public async Task<IActionResult> Updated(int id, ContentDto content)
        {
            if (id != content.Id)
            {
                return BadRequest();
            }
            var existingcontent = await _contentService.GetByIdAsync(content.Id);
            if (existingcontent == null)
            {
                return NotFound();
            }
            // Pass ContentDto to UpdateByAsync, not Content
            var updatedContent = await _contentService.UpdateByAsync(content);
            return Ok(updatedContent);
        }

        [HttpDelete]
        public async Task<IActionResult> Deleted(int id)
        {
            var existingCourse = await _contentService.GetByIdAsync(id);
            if (existingCourse == null)
            {
                return NotFound();
            }
            await _contentService.DeleteByAsync(id);
            return NoContent();
        }




    }
}
