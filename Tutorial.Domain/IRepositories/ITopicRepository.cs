using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutorial.Domain.Models;
using Tutorial.Domain.Models.Dtos;

namespace Tutorial.Domain.IRepositories
{
    public interface ITopicRepository
    {
        Task<IEnumerable<Topic>> GetAllTopics();
        Task<Topic> GetTopicById(int id);
        Task<TopicDto> CreateTopic(TopicDto topic);
        Task<TopicDto> UpdateTopic(TopicDto topic);
        Task<Topic> DeleteTopicById(int id);
    }
}
