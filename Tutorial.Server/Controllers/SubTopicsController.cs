using Microsoft.AspNetCore.Mvc;
using Tutorial.Domain.IServices;
using Tutorial.Domain.Models;
using Tutorial.Domain.Models.Dtos;
using Tutorial.Service.ServiceImpl;

namespace Tutorial.Server.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class SubTopicsController : ControllerBase
    {
        private readonly ISubTopicsService _subTopicsService;
        public SubTopicsController(ISubTopicsService subTopicsService)
        {
            _subTopicsService = subTopicsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var subTopics = await _subTopicsService.GetSubTopicsAsync();
            return Ok(subTopics);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var topic = await _subTopicsService.GetSubTopicByIdAsync(id);
            if (topic == null)
            {
                return NotFound();
            }
            return Ok(topic);
        }

        [HttpGet("ByTopic/{topicId}")]
        public async Task<IActionResult> GetSubTopicsByTopic(int topicId)
        {
            var subTopics = await _subTopicsService.GetSubTopicsByTopicId(topicId);

            if (subTopics == null)
            {
                return NotFound();
            }

            return Ok(subTopics);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SubTopicsDto topicDto)
        {
            var createdTopic = await _subTopicsService.CreateSubTopic(topicDto);

            return CreatedAtAction(nameof(GetById), new { id = createdTopic.SubTopicId }, createdTopic);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, SubTopicsDto topic)
        {
            if (id != topic.SubTopicId)
            {
                return BadRequest();
            }
            var existingTopic = await _subTopicsService.GetSubTopicByIdAsync(id);
            if (existingTopic == null)
            {
                return NotFound();
            }
            await _subTopicsService.UpdateSubTopic(topic);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingTopic = await _subTopicsService.GetSubTopicByIdAsync(id);
            if (existingTopic == null)
            {
                return NotFound();
            }
            await _subTopicsService.DeleteSubTopicByIdAsync(id);
            return NoContent();
        }
    }
}
