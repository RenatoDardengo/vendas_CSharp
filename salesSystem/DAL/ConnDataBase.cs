using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SalesSystem.DAL
{
    internal class ConnDataBase
    {
        public SqlConnection con = new SqlConnection();

        private string DataBasePath()
        {
            return ConfigurationManager.AppSettings[@"Local"];
        }

        public ConnDataBase()
        {
            con.ConnectionString = DataBasePath();
        }

       public SqlConnection OpenDataBase() // Method to Open connection whit DB
        {
            if(con.State != ConnectionState.Open)
            {
                con.Open();
            }
            return con;
        }

        public void CloseDataBase()  //Method to close connection whit DB
        {
            if (con.State != ConnectionState.Closed)
            {
                con.Close();
                con.Dispose();
            }
        }


        public DataTable DataReturn (string query) // Method to return DataTable
        {
            using (var dt = new DataTable())
            {
                if (dt != null)
                {
                    dt.Clear();
                }

                using (var cmd = new SqlCommand(query, con))
                {
                    using (var da = new SqlDataAdapter())
                    {
                        da.SelectCommand = cmd;
                        da.Fill(dt);
                        return dt;
                    }
                }
            }

        }




    }
}
