using Cau_1.DTO;
using System;
using System.Collections.Generic;
using System.Data;
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
            //SqlCommand cmd = new SqlCommand("select * from  Employee", conn);
            SqlCommand cmd = new SqlCommand("selectEmployee", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();
            List<EmployeeDTO> lstDepartment = new List<EmployeeDTO>();
            DepartmentDAL Dep = new DepartmentDAL();
            while (reader.Read())
            {
                EmployeeDTO objDepartmentDTO = new EmployeeDTO();
                objDepartmentDTO.IdEmployee = (int.Parse(reader["IdEmployee"].ToString()));
                objDepartmentDTO.Name = reader["Name"].ToString();
                objDepartmentDTO.DateBirth = (DateTime.Parse(reader["DateBirth"].ToString()));
                objDepartmentDTO.Gender = reader["Gender"].ToString()   ;
                objDepartmentDTO.PlaceBirth = reader["PlaceBirth"].ToString();
                objDepartmentDTO.Department= Dep.ReadArea(int.Parse(reader["IdDepartment"].ToString())) ;
                lstDepartment.Add(objDepartmentDTO);
            }
            conn.Close();
            return lstDepartment;
        }

        public void XoaDepartment(EmployeeDTO cn)
        {
            /*SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from  Employee where IdEmployee=@IdEmployee", conn);
            cmd.Parameters.Add(new SqlParameter("@IdEmployee", cn.IdEmployee));
            cmd.ExecuteNonQuery();
            conn.Close();*/
            //
            SqlConnection con = new SqlConnection();

            //Chỗ này tạm thời có thể gán cứng chuỗi kết nối
            try
            {
                //khỏi tạo instance của class SqlCommand
                SqlCommand cmd = new SqlCommand();
                //sử dụng thuộc tính CommandText để chỉ định tên Proc
                cmd.CommandText = "XoaDepartment";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                //khai báo các thông tin của tham số truyền vào
                cmd.Parameters.Add("@IdEmployee", SqlDbType.Int).Value = 1;
                //mở chuỗi kết nối
                con.Open();
                //sử dụng ExecuteNonQuery để thực thi
                cmd.ExecuteNonQuery();
                //đóng chuỗi kết nối.
                con.Close();

                Console.WriteLine("Xoa thanh cong !!!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Co loi xay ra !!!" + e);
            }
            // dóng chuỗi kết nối
            finally
            {
                con.Close();
            }


        }
        public void ThemDepartment(EmployeeDTO cn)
        {
            /*SqlConnection conn = CreateConnection();
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
            conn.Close();*/
            //
            SqlConnection conn = CreateConnection();
            conn.Open();


            //Chỗ này tạm thời có thể gán cứng chuỗi kết nối
            try
            {
                //khỏi tạo instance của class SqlCommand
                SqlCommand cmd = new SqlCommand();
                //sử dụng thuộc tính CommandText để chỉ định tên Proc
                cmd.CommandText = "ThemDepartment";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
                //khai báo các thông tin của tham số truyền vào
                cmd.Parameters.Add("@IdEmployee", SqlDbType.Int).Value = cn.IdEmployee;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = cn.Name;
                cmd.Parameters.Add("@DateBirth", SqlDbType.Date).Value = cn.DateBirth;
                cmd.Parameters.Add("@Gender", SqlDbType.NVarChar).Value = cn.Gender;
                cmd.Parameters.Add("@PlaceBirth", SqlDbType.NVarChar).Value = cn.PlaceBirth;
                cmd.Parameters.Add("@Department", SqlDbType.Int).Value = cn.Department.IdDepartment;
                //mở chuỗi kết nối
                conn.Open();
                //sử dụng ExecuteNonQuery để thực thi
                cmd.ExecuteNonQuery();
                //đóng chuỗi kết nối.
                conn.Close();

                Console.WriteLine("Them thanh cong !!!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Co loi xay ra !!!" + e);
            }
            // dóng chuỗi kết nối
            finally
            {
                conn.Close();
            }



        }
        public void SuaDepartment(EmployeeDTO cn)
        {
            /*SqlConnection conn = CreateConnection();
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
            conn.Close();*/
            //
            SqlConnection con = new SqlConnection();


            //Chỗ này tạm thời có thể gán cứng chuỗi kết nối
            try
            {
                //khỏi tạo instance của class SqlCommand
                SqlCommand cmd = new SqlCommand();
                //sử dụng thuộc tính CommandText để chỉ định tên Proc
                cmd.CommandText = "SuaDepartment";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                //khai báo các thông tin của tham số truyền vào
                cmd.Parameters.Add("@IdEmployee", SqlDbType.Int).Value = cn.IdEmployee;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = cn.Name;
                cmd.Parameters.Add("@DateBirth", SqlDbType.Date).Value = cn.DateBirth;
                cmd.Parameters.Add("@Gender", SqlDbType.NVarChar).Value = cn.Gender;
                cmd.Parameters.Add("@PlaceBirth", SqlDbType.NVarChar).Value = cn.PlaceBirth;
                cmd.Parameters.Add("@IdDepartment", SqlDbType.Int).Value = cn.Department.IdDepartment;
                //mở chuỗi kết nối
                con.Open();
                //sử dụng ExecuteNonQuery để thực thi
                cmd.ExecuteNonQuery();
                //đóng chuỗi kết nối.
                con.Close();

                Console.WriteLine("Sua thanh cong !!!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Co loi xay ra !!!" + e);
            }
            // dóng chuỗi kết nối
            finally
            {
                con.Close();
            }

        }
    }
}
