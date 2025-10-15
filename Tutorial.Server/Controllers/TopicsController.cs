using Microsoft.AspNetCore.Mvc;
using Tutorial.Domain.IServices;
using Tutorial.Domain.Constant;
using Tutorial.Domain.Models;
using Tutorial.Domain.Models.Dtos;
using Tutorial.Service.ServiceImpl;

namespace Tutorial.Server.Controllers
{
    [Route(RouteMapConstants.BaseControllerRoute)]
    public class TopicsController : ControllerBase
    {
       
        private readonly ITopicService _topicService;

        public TopicsController(ITopicService topicService)
        {
            _topicService = topicService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var topics = await _topicService.GetAll();
            return Ok(topics);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var topic = await _topicService.GetById(id);
            if (topic == null)
            {
                return NotFound();
            }
            return Ok(topic);
        }

        [HttpGet("ByCourse/{courseId}")]
        public async Task<IActionResult> GetTopicsByCourse(int courseId)
        {
            var topics = await _topicService.GetTopicsByCourseId(courseId);

            if ( topics == null)
            {
                return NotFound();
            }

            return Ok(topics);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TopicDto topicDto)
        {
            var createdTopic = await _topicService.Create(topicDto);

            return CreatedAtAction(nameof(GetById), new { id = createdTopic.TopicId }, createdTopic);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TopicDto topicDto)
        {
            if (id != topicDto.TopicId)
            {
                return BadRequest();
            }
            var existingTopic = await _topicService.GetById(id);
            if (existingTopic == null)
            {
                return NotFound();
            }
            await _topicService.Update(topicDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingTopic = await _topicService.GetById(id);
            if (existingTopic == null)
            {
                return NotFound();
            }
            await _topicService.DeleteById(id);
            return NoContent();
        }
    }
}
