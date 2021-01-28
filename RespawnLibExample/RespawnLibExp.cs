using Respawn;
using System;
using System.Data.SqlClient;

namespace RespawnLibExample
{
    public class RespawnLibExp
    {

        static String DB_FilePath = "D:\\workspace\\VSProjects\\RespawnLibExample\\RespawnLibExample\\Database1.mdf";

        static String con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + DB_FilePath + ";Integrated Security=True;Connect Timeout=500";

        private static Checkpoint checkpoint = new Checkpoint();

        static SqlConnectionStringBuilder cn = new SqlConnectionStringBuilder(con);


        public void AddUser(string user)
        {
            using (SqlConnection conn = new SqlConnection(con))
            {
                string sql = "insert into tbl_user(name)values(@name);";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {

                    cmd.Parameters.AddWithValue("@name", user);

                    conn.Open();

                    cmd.ExecuteNonQuery();


                    conn.Close();
                }
            }
        }

        public void Reset()
        {
            checkpoint.Reset(cn.ToString());
        }
        public bool IsUserTableEmpty()
        {

            using (SqlConnection conn = new SqlConnection(con))
            {
                string sql = "SELECT CASE WHEN EXISTS(SELECT 1 FROM dbo.tbl_user) THEN 0 ELSE 1 END AS IsEmpty";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {

                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    reader.Read();

                    int res = reader.GetInt32(reader.GetOrdinal("IsEmpty"));

                    if (res == 1) 
                    {
                        return true;
                    }

                    conn.Close();
                }
            }

            return false;
        }

    }
}