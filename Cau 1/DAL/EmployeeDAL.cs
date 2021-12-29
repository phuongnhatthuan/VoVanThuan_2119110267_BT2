using Cau_1.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cau_1.DAL
{
    class EmployeeDAL : DBConnection
    {
        public List<EmployeeDTO> ReadDepartment()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from  Employee", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            List<EmployeeDTO> lstDepartment = new List<EmployeeDTO>();
            DepartmentDAL Dep = new DepartmentDAL();
            while (reader.Read())
            {
                EmployeeDTO objDepartmentDTO = new EmployeeDTO();
                objDepartmentDTO.IdEmployee = (int.Parse(reader["IdEmployee"].ToString()));
                objDepartmentDTO.Name = reader["Name"].ToString();
                objDepartmentDTO.DateBirth = (DateTime.Parse(reader["DateBirth"].ToString()));
                objDepartmentDTO.Gender = reader["Gender"].ToString();
                objDepartmentDTO.PlaceBirth = reader["PlaceBirth"].ToString();
                objDepartmentDTO.Department= Dep.ReadArea(int.Parse(reader["IdDepartment"].ToString())) ;
                lstDepartment.Add(objDepartmentDTO);
            }
            conn.Close();
            return lstDepartment;
        }

        public void XoaDepartment(EmployeeDTO cn)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from  Employee where IdEmployee=@IdEmployee", conn);
            cmd.Parameters.Add(new SqlParameter("@IdEmployee", cn.IdEmployee));
            cmd.ExecuteNonQuery();
            conn.Close();


        }
        public void ThemDepartment(EmployeeDTO cn)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(
                "insert into  Employee values(@IdEmployee,@Name,@DateBirth,@Gender,@PlaceBirth,@Department)", conn);
            cmd.Parameters.Add(new SqlParameter("@IdEmployee", cn.IdEmployee));
            cmd.Parameters.Add(new SqlParameter("@Name", cn.Name));
            cmd.Parameters.Add(new SqlParameter("@DateBirth", cn.DateBirth));
            cmd.Parameters.Add(new SqlParameter("@Gender", cn.Gender));
            cmd.Parameters.Add(new SqlParameter("@PlaceBirth", cn.PlaceBirth));
            cmd.Parameters.Add(new SqlParameter("@Department", cn.Department.IdDepartment));
            cmd.ExecuteNonQuery();
            conn.Close();



        }
        public void SuaDepartment(EmployeeDTO cn)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(
                "update  Employee set  Name = @Name, DateBirth = @DateBirth,Gender = @Gender,PlaceBirth = @PlaceBirth,IdDepartment = @IdDepartment where @IdEmployee = IdEmployee", conn);
            cmd.Parameters.Add(new SqlParameter("@IdEmployee", cn.IdEmployee));
            cmd.Parameters.Add(new SqlParameter("@Name", cn.Name));
            cmd.Parameters.Add(new SqlParameter("@DateBirth", cn.DateBirth));
            cmd.Parameters.Add(new SqlParameter("@Gender", cn.Gender));
            cmd.Parameters.Add(new SqlParameter("@PlaceBirth", cn.PlaceBirth));
            cmd.Parameters.Add(new SqlParameter("@IdDepartment", cn.Department.IdDepartment));
            cmd.ExecuteNonQuery();
            conn.Close();

        }
    }
}
