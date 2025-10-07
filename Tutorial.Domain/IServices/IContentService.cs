using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutorial.Domain.Models;
using Tutorial.Domain.Models.Dtos;

namespace Tutorial.Domain.IServices
{
    public interface IContentService
    {
        Task<Content> GetByIdAsync(int id);
        Task<ContentDto> UpdateByAsync(ContentDto content);
        Task<Content> DeleteByAsync(int id);
 Task<ContentDto> CreatedAsync(ContentDto content);
        Task<IEnumerable<Content>> GetAllAsync();
    }
}
