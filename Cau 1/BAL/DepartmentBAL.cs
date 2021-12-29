using Cau_1.DAL;
using Cau_1.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cau_1.BAL
{
    public class DepartmentBAL
    {
        DepartmentDAL dal = new DepartmentDAL();
        public List<DepartmentDTO> ReadAreaList()
        {
            List<DepartmentDTO> lstArea = dal.ReadAreaList();
            return lstArea;
        }
    }
}
