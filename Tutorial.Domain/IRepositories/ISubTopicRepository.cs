using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutorial.Domain.Models;
using Tutorial.Domain.Models.Dtos;

namespace Tutorial.Domain.IRepositories
{
    public interface ISubTopicRepository
    {
        Task<IEnumerable<SubTopic>> GetAll();
        Task<SubTopic> GetById(int id);
        Task<IEnumerable<SubTopic>> GetByTopicId(int topicId);
        Task<SubTopicsDto> Create(SubTopicsDto subTopicDto);
        Task<SubTopicsDto> Update(SubTopicsDto subTopic);
        Task<SubTopic> DeleteById(int id);
    }
}
