﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cau_1.DTO
{
    public class DepartmentDTO
    {
        public int  IdDepartment { get; set; }
        public string Name { get; set; }
        public List<EmployeeDTO> Employees { get; set; }
    }
}
