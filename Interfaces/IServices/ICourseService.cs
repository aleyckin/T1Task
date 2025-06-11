using Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.IServices
{
    public interface ICourseService
    {
        public Task<List<CourseDto>> GetAllCoursesAsync();
        public Task<Guid> CreateCourseAsync(CourseDto courseDto);
        public Task<Guid> AddToCourseNewStudentAsync(Guid CourseId, StudentDto studentDto);
        public Task DeleteCourseAsync(Guid courseId);
    }
}
