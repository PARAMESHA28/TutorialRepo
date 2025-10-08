using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutorial.Domain.Models;
using Tutorial.Domain.Models.Dtos;

namespace Tutorial.Domain.IRepositories
{
  public interface ICourseRepository
    {
        Task<Course> GetByIdAsync(int id);
        Task<CourseDto> CreateAsync(CourseDto course);
        Task<CourseDto> UpdateAsync(CourseDto course);
        Task<Course> DeleteAsync(int id);
        Task<IEnumerable<Course>> GetAllAsync();
    }
}
