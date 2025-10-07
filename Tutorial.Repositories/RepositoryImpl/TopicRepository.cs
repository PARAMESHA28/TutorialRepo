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
            return await _courseDbContext.Topic.ToListAsync();
        }
        public async Task<Topic> GetTopicById(int id)
        {
            return await _courseDbContext.Topic.FindAsync(id);
        }
        public async Task<TopicDto> CreateTopic(TopicDto topic)
        {
            var topics = new Topic
            {
                TopicName = topic.TopicName,
                CourseId = topic.CourseId
            };
            _courseDbContext.Topic.Add(topics);
            await _courseDbContext.SaveChangesAsync();
            return topic;
        }
        public async Task<Topic> UpdateTopic(Topic topic)
        {
            var existingTopic = await _courseDbContext.Topic.FindAsync(topic.TopicId);
            if (existingTopic == null)
            {
                return null;
            }
            existingTopic.TopicName = topic.TopicName;
            existingTopic.CourseId = topic.CourseId;
            return existingTopic;
        }
        public async Task<Topic> DeleteTopicById(int id)
        {
            var topic = _courseDbContext.Topic.Find(id);
            if(topic == null)
            {
                return null;
            }
            _courseDbContext.Topic.Remove(topic);
            await _courseDbContext.SaveChangesAsync();
            return topic;
        }
    }
}
