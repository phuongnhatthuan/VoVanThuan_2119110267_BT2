using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cau_1.DAL
{
    class DBConnection
    {
        public DBConnection()
        {
        }
        public SqlConnection CreateConnection()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=DESKTOP-R0IAVP4\SQLEXPRESS2012; Initial Catalog=HR; User Id=sa;Password=sa1105";
            return conn;
        }
    }
}
