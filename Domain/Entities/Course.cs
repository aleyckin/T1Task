using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Course : IId
    {
        public string Name { get; set; } = string.Empty;
        List<Student> Students { get; set; } = new List<Student>();
    }
}
