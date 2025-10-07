using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutorial.Domain.Models;
using Tutorial.Domain.Models.Dtos;

namespace Tutorial.Domain.IServices
{
    public interface ITopicService
    {
        Task<IEnumerable<Topic>> GetAll();
        Task<Topic> GetById(int id);
        Task<TopicDto> Create(TopicDto topicDto);
        Task<Topic> Update(Topic topic);
        Task<Topic> DeleteById(int id);
    }
}
