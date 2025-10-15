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
    public class ContentRepository: IContentRepository
    {
        public readonly CourseDbContext _context;
        public ContentRepository(CourseDbContext context)
        {
            _context = context;
        }
        public async Task<ContentDto> CreatedAsync(ContentDto contentDto)
        {
            var content = new Content
            {
                Title = contentDto.Title,
                Body = contentDto.Body,
                SubTopicId = contentDto.SubTopicId
            };
            _context.Contents.Add(content);
            await _context.SaveChangesAsync();

            // Optionally update the DTO with the generated ContentId
            contentDto.Id = content.ContentId;
            return contentDto;
        }
        public async Task<Content> DeleteByAsync(int id)
        {
            var content = await _context.Contents.FindAsync(id);
            if (content == null)
            {
                return null;
            }
            _context.Contents.Remove(content);
            await _context.SaveChangesAsync();
            return content;
        }
        public async Task<IEnumerable<Content>> GetAllAsync()
        {
            return await Task.FromResult(_context.Contents.ToList());
        }
        public async Task<Content> GetByIdAsync(int id)
        {
            var content = await _context.Contents.FindAsync(id);
            return content;
        }
        public async Task<ContentDto> UpdateByAsync(ContentDto content)
        {
            var existingContent = await _context.Contents.FindAsync(content.Id);
            if (existingContent == null)
            {
                return null;
            }
            existingContent.Title = content.Title;
            existingContent.Body = content.Body;
            existingContent.SubTopicId = content.SubTopicId;
            await _context.SaveChangesAsync();

            // Map Content to ContentDto before returning
            return new ContentDto
            {
                Id = existingContent.ContentId,
                Title = existingContent.Title,
                Body = existingContent.Body,
                SubTopicId = existingContent.SubTopicId
            };
        }

        public async Task<IEnumerable<Content>> GetContentBySubtopic(int subtopicId)
        {
            return await _context.Contents.
                Where(c => c.SubTopicId == subtopicId).
                ToListAsync();
        }


    }
}
