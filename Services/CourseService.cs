using Contracts.Dtos;
using Contracts.IServices;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CourseService : ICourseService
    {
        private readonly DataContext _dataContext;

        public CourseService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Guid> AddToCourseNewStudentAsync(Guid courseId, StudentDto studentDto)
        {
            Course course = await _dataContext.Courses
                .FirstOrDefaultAsync(x => x.Id == courseId)
                ?? throw new Exception($"Курс с таким id: {courseId} не найден.");

            Student student = new Student
            {
                FullName = studentDto.FullName,
                CourseId = courseId
            };

            _dataContext.Students.Add(student);
            await _dataContext.SaveChangesAsync();

            return student.Id;
        }

        public async Task<Guid> CreateCourseAsync(CourseDto courseDto)
        {
            Course course = new Course
            {
                Name = courseDto.Name, 
            };
            _dataContext.Courses.Add(course);
            await _dataContext.SaveChangesAsync();
            return course.Id;
        }

        public async Task DeleteCourseAsync(Guid courseId)
        {
            Course course = await _dataContext.Courses
                .FirstOrDefaultAsync(x => x.Id == courseId)
                ?? throw new Exception($"Курс с таким id: {courseId} не найден.");

            _dataContext.Courses.Remove(course);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<List<CourseDto>> GetAllCoursesAsync()
        {
            List<CourseDto> courses = await _dataContext.Courses
                .Include(x => x.Students)
                .Select(x => new CourseDto(x.Name, x.Students.Select(s => new StudentDto(s.FullName)).ToList()))
                .ToListAsync();

            return courses;
        }
    }
}
