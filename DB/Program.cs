using System;
using System.Data.Common;
using System.Data;
using System.Diagnostics;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;

namespace DB
{
    internal class DbInfo
    {
        private static String strConn = "Server=localhost;Database=myrank;Uid=root;Pwd=rlghlek153;";
        private static MySqlConnection conn = new MySqlConnection(strConn);

        public static MySqlConnection Getconn
        {
            get {return conn;}
        }
        
    }
    public class Select
    {

        public String SelectWorld(int skip, int show)
        {

            MySqlConnection conn = DbInfo.Getconn;
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            MySqlCommand cmd = new MySqlCommand($"SELECT * from worldrank order by surviveTime desc limit {skip}, {show}", conn);
            cmd.ExecuteNonQuery(); //
            MySqlDataReader rdr = cmd.ExecuteReader();

            String strName = null;
            String strTime = null;
            while (rdr.Read())
            {
                String temp = (String)rdr["userName"];
                if (temp.Length < 10)
                {
                    strName += temp.PadRight(10, ' ');
                }
                strTime += (String)rdr["surviveTime"];
            }
            conn.Close();
            return strName + strTime.Substring(0, 8);
            //객체 만들어서 리턴하기
        }
    }
    public class Insert
    {
        public void InsertRank(String userName, String surviveTime)
        {
            MySqlConnection conn = DbInfo.Getconn;
            conn.Open();
            String sql = String.Format("insert into worldrank(userName, surviveTime) values('{0}', '{1}')", userName, surviveTime);
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}