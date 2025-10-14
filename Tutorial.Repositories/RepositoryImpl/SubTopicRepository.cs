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
    public class SubTopicRepository : ISubTopicRepository
    {
        private readonly CourseDbContext _courseDbContext;
        public SubTopicRepository(CourseDbContext courseDbContext)
        {
            _courseDbContext = courseDbContext;
        }
        public async Task<IEnumerable<SubTopic>> GetAll()
        {
            return await _courseDbContext.SubTopics.ToListAsync();

        }
        public async Task<SubTopic> GetById(int id)
        {
            return await _courseDbContext.SubTopics.FindAsync(id);

        }
        public async Task<IEnumerable<SubTopic>> GetByTopicId(int topicId)
        {
            return await _courseDbContext.SubTopics.
                Where(t => t.TopicId == topicId)
                .ToListAsync();
        }

        public async Task<SubTopicsDto> Create(SubTopicsDto subTopicDto)
        {
            var subtopics = new SubTopic
            {
                SubTopicName = subTopicDto.SubTopicName,
                TopicId = subTopicDto.TopicId,
                SubTopicsOrder = subTopicDto.SubTopicsOrder,
            };
            _courseDbContext.SubTopics.Add(subtopics);
            await _courseDbContext.SaveChangesAsync();

            var createdSubTopic = new SubTopicsDto
            {
                SubTopicId = subtopics.SubTopicId,
                SubTopicName = subtopics.SubTopicName,
                TopicId = subtopics.TopicId,
                SubTopicsOrder = subtopics.SubTopicsOrder,
            };
            return createdSubTopic;
        }
        public async Task<SubTopicsDto> Update(SubTopicsDto subTopic)
        {
            var existingSubTopic = await _courseDbContext.SubTopics.FindAsync(subTopic.TopicId);
            if (existingSubTopic == null)
            {
                return null;
            }
            existingSubTopic.SubTopicName = subTopic.SubTopicName;
            existingSubTopic.TopicId = subTopic.TopicId;
            existingSubTopic.SubTopicsOrder = subTopic.SubTopicsOrder;
            await _courseDbContext.SaveChangesAsync();

            return new SubTopicsDto
            {
                SubTopicId  = existingSubTopic.SubTopicId,
                SubTopicName= existingSubTopic.SubTopicName,
                TopicId = existingSubTopic.TopicId,
                SubTopicsOrder= existingSubTopic.SubTopicsOrder,
            };
        }
        public async Task<SubTopic> DeleteById(int id)
        {
            var subTopic = _courseDbContext.SubTopics.Find(id);
            if (subTopic == null)
            {
                return null;
            }
            _courseDbContext.SubTopics.Remove(subTopic);
            await _courseDbContext.SaveChangesAsync();
            return subTopic;
        }
    }
}
