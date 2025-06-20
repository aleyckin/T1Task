﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Dtos
{
    public record StudentDto(Guid Id, string FullName) { }

    public record StudentDtoForCreate(string FullName) { }
}
