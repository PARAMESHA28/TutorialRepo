using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutorial.Domain.IRepositories;
using Tutorial.Domain.IServices;
using Tutorial.Domain.Models;
using Tutorial.Domain.Models.Dtos;

namespace Tutorial.Service.ServiceImpl
{
    public class TopicService : ITopicService
    {
        private readonly ITopicRepository _repository;
        public TopicService(ITopicRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Topic>> GetAll()
        {
            return await _repository.GetAllTopics();
        }
        public async Task<Topic> GetById(int id)
        {
            return (Topic)await _repository.GetTopicById(id);
        }
        public async Task<TopicDto> Create(TopicDto topicDto)
        {
            return await _repository.CreateTopic(topicDto);
        }
        public async Task<Topic> Update(Topic topic)
        {
            return await _repository.UpdateTopic(topic);
        }
        public async Task<Topic> DeleteById(int id)
        {
            return await _repository.DeleteTopicById(id);
        }
    }
}
