using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutorial.Domain.IRepositories;
using Tutorial.Domain.Models;
using Tutorial.Domain.Models.Dtos;
using Tutorial.Repositories.Data;

namespace Tutorial.Repositories.RepositoryImpl
{
    public class TopicRepository : ITopicRepository
    {
        private readonly CourseDbContext _courseDbContext;
        public TopicRepository(CourseDbContext courseDbContext)
        {
            _courseDbContext = courseDbContext;
        }
        public async Task<IEnumerable<Topic>> GetAllTopics()
        {
            return await _courseDbContext.Topics.ToListAsync();
        }
        public async Task<Topic> GetTopicById(int id)
        {
            return await _courseDbContext.Topics.FindAsync(id);
        }
        public async Task<TopicDto> CreateTopic(TopicDto topic)
        {
            var topics = new Topic
            {
                TopicName = topic.TopicName,
                CourseId = topic.CourseId,
                TopicsOrder=topic.TopicsOrder

            };
            _courseDbContext.Topics.Add(topics);
            await _courseDbContext.SaveChangesAsync();

            var createdtopic = new TopicDto
            {
                TopicId = topics.TopicId,
                TopicName = topics.TopicName,
                CourseId = topics.CourseId,
                TopicsOrder=topics.TopicsOrder

            };
            return createdtopic;
        }
        public async Task<Topic> UpdateTopic(Topic topic)
        {
            var existingTopic = await _courseDbContext.Topics.FindAsync(topic.TopicId);
            if (existingTopic == null)
            {
                return null;
            }
            existingTopic.TopicName = topic.TopicName;
            existingTopic.CourseId = topic.CourseId;
            existingTopic.TopicsOrder = topic.TopicsOrder; 
            return existingTopic;
        }
        public async Task<Topic> DeleteTopicById(int id)
        {
            var topic = _courseDbContext.Topics.Find(id);
            if(topic == null)
            {
                return null;
            }
            _courseDbContext.Topics.Remove(topic);
            await _courseDbContext.SaveChangesAsync();
            return topic;
        }
    }
}
