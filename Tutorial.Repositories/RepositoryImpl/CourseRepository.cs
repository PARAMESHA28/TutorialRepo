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
   public class CourseRepository: ICourseRepository
    {
     public readonly CourseDbContext _context;
        public CourseRepository(CourseDbContext context)
        {
            _context = context;
        }
        public async Task<CourseDto> CreateAsync(CourseDto courseDto)
        {
            var course = new Course
            {
                CourseName = courseDto.CourseName,
                Description = courseDto.Description
                // Map other properties if needed
            };
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            // Optionally, update courseDto with generated CourseId
            courseDto.CourseId = course.CourseId;
            return courseDto;
        }
        public async Task<Course> DeleteAsync(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return null;
            }
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return course;
        }
        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            return await _context.Courses.ToListAsync();
        }
        public async Task<Course> GetByIdAsync(int id)
        {
            return await _context.Courses.FindAsync(id);
        }
        public async Task<Course> UpdateAsync(Course course)
        {
            var existingCourse = await _context.Courses.FindAsync(course.CourseId);
            if (existingCourse == null)
            {
                return null;
            }
            existingCourse.CourseName = course.CourseName;
            existingCourse.Description = course.Description;
            await _context.SaveChangesAsync();
            return existingCourse;
        }
    }
}
