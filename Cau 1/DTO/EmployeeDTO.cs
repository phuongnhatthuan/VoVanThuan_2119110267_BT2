using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cau_1.DTO
{
    public class EmployeeDTO
    {
        public int IdEmployee { get; set; }
        public string Name { get; set; }
        public DateTime DateBirth { get; set; }
        public string Gender { get; set; }
        public string PlaceBirth { get; set; }
        public DepartmentDTO Department { get; set; }
        public string NameDepartment
        {
            get { return Department.Name; }
        }
    }
}
