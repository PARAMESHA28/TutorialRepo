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
    public class CourseService: ICourseService
    {
        public readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courserepository)

        {
            _courseRepository = courserepository;
        }

        public Task<CourseDto> CreateAsync(CourseDto course)
        {
            return _courseRepository.CreateAsync(course);

        }
        public Task<Course> DeleteAsync(int id)
        {
            return _courseRepository.DeleteAsync(id);
        }
        public Task<IEnumerable<Course>> GetAllAsync()
        {
            return _courseRepository.GetAllAsync();
        }

        public Task<Course> UpdateAsync(Course course)
        {
                       return _courseRepository.UpdateAsync(course);
        }
        public Task<Course> GetByIdAsync(int id)
        {
            return _courseRepository.GetByIdAsync(id);
        }

    }
}
