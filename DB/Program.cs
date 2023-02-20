using System;
using MySql.Data.MySqlClient;

namespace DB
{
    public class Select
    {
        private static String strConn = "Server=localhost;Database=myrank;Uid=root;Pwd=rlghlek153;";
        private static MySqlConnection conn = new MySqlConnection(strConn);

        public String SelectWorld()
        {

            conn.Open();
            MySqlCommand cmd = new MySqlCommand($"SELECT * from worldrank", conn);
            cmd.ExecuteNonQuery();
            MySqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
                return (String)rdr["userName"];
            
            //객체 만들어서 리턴하기
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}