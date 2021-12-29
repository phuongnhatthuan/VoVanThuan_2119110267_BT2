using Cau_1.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cau_1.DAL
{
    class DepartmentDAL :DBConnection
    {
        public List<DepartmentDTO> ReadAreaList()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Department", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            List<DepartmentDTO> lstArea = new List<DepartmentDTO>();
            while (reader.Read())
            {
                DepartmentDTO area = new DepartmentDTO();
                area.IdDepartment = int.Parse(reader["IdDepartment"].ToString());
                area.Name = reader["Name"].ToString();
                lstArea.Add(area);
            }
            conn.Close();
            return lstArea;
        }
        public DepartmentDTO ReadArea(int IdDepartment)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(
                "select * from Department where IdDepartment = " + IdDepartment.ToString(), conn);
            SqlDataReader reader = cmd.ExecuteReader();
            DepartmentDTO area = new DepartmentDTO();
            if (reader.HasRows && reader.Read())
            {
                area.IdDepartment = int.Parse(reader["IdDepartment"].ToString());
                area.Name = reader["Name"].ToString();
            }
            conn.Close();
            return area;
        }
    }
}
