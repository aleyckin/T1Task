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
        public Task<Guid> CreateCourseAsync(CourseDtoForCreate courseDto);
        public Task<Guid> AddToCourseNewStudentAsync(Guid CourseId, StudentDtoForCreate studentDto);
        public Task DeleteCourseAsync(Guid courseId);
    }
}
