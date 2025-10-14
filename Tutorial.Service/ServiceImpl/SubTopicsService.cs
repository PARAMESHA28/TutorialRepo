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
    public class SubTopicsService : ISubTopicsService
    {
        private readonly ISubTopicRepository _subTopicRepository;
        public SubTopicsService(ISubTopicRepository subTopicRepository)
        {
            _subTopicRepository = subTopicRepository;
        }
        public async Task<IEnumerable<SubTopic>> GetSubTopicsAsync()
        {
            return await _subTopicRepository.GetAll();
        }
        public async Task<SubTopic> GetSubTopicByIdAsync(int id)
        {
            return await _subTopicRepository.GetById(id);
        }
        public async Task<IEnumerable<SubTopic>> GetSubTopicsByTopicId(int topicId)
        {
            return await _subTopicRepository.GetByTopicId(topicId);
        }

        public async Task<SubTopicsDto> CreateSubTopic(SubTopicsDto subTopicsDto)
        {
            return await _subTopicRepository.Create(subTopicsDto);
        }
        public async Task<SubTopicsDto> UpdateSubTopic(SubTopicsDto subTopic)
        {
            return await _subTopicRepository.Update(subTopic);
        }
        public async Task<SubTopic> DeleteSubTopicByIdAsync(int id)
        {
            return await (_subTopicRepository.DeleteById(id));
        }
    }
}

