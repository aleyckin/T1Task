﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Student : IId
    {
        public string FullName { get; set; } = string.Empty;
        public Guid CourseId { get; set; }
    }
}
