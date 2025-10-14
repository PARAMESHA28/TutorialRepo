using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutorial.Domain.Models;
using Tutorial.Domain.Models.Dtos;

namespace Tutorial.Domain.IServices
{
    public interface ISubTopicsService
    {
        Task<IEnumerable<SubTopic>> GetSubTopicsAsync();
        Task<SubTopic> GetSubTopicByIdAsync(int id);
        Task<IEnumerable<SubTopic>> GetSubTopicsByTopicId(int topicId);
        Task<SubTopicsDto> CreateSubTopic(SubTopicsDto subTopicsDto);
        Task<SubTopicsDto> UpdateSubTopic(SubTopicsDto subTopicDto);
        Task<SubTopic> DeleteSubTopicByIdAsync(int id);
    }
}
