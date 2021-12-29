using Cau_1.DAL;
using Cau_1.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cau_1.BAL
{
    class EmployeeBAL
    {
        EmployeeDAL dal = new EmployeeDAL();
        public List<EmployeeDTO> ReadDepartment()
        {
            List<EmployeeDTO> lstCus = dal.ReadDepartment();
            return lstCus;
        }
        public void ThemDepartment(EmployeeDTO cn)
        {
            dal.ThemDepartment(cn);
        }
        public void XoaDepartment(EmployeeDTO cn)
        {
            dal.XoaDepartment(cn);
        }
        public void SuaDepartment(EmployeeDTO cn)
        {
            dal.SuaDepartment(cn);
        }
    }
}
