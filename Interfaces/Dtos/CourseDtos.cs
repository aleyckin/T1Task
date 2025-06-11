using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Dtos
{
    public record CourseDto(Guid Id, string Name, List<StudentDto> Students) { }
    public record CourseDtoForCreate(string Name) { }
}
