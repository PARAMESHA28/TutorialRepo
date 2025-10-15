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
    public class ContentService: IContentService
    {
        public readonly IContentRepository _contentRepository;
        public ContentService(IContentRepository contentRepository)
        {
            _contentRepository = contentRepository;
        }
        public async Task<Content> GetByIdAsync(int id)
        {
            return await _contentRepository.GetByIdAsync(id);
        }
        public async Task<ContentDto> UpdateByAsync(ContentDto content)
        {
            return await _contentRepository.UpdateByAsync(content);
        }
        public async Task<Content> DeleteByAsync(int id)
        {
            return await _contentRepository.DeleteByAsync(id);
        }
        public async Task<ContentDto> CreatedAsync(ContentDto content)
        {
            return await _contentRepository.CreatedAsync(content);
        }
        public async Task<IEnumerable<Content>> GetAllAsync()
        {
            return await _contentRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Content>> GetContentBySubTopicid(int subtopicId)
        {
            return await _contentRepository.GetContentBySubtopic(subtopicId);
        }

    }
}
