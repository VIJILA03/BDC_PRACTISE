using System.Configuration;
using System.Data.SqlClient;
namespace Day5
{
    public class Day5
    {
        public static void Main(string[] args)
        {
            string connect = ConfigurationManager.ConnectionStrings["MyKey"].ConnectionString;
            //string connect = "data source=LAPTOP-PH4JPVTP;initial catalog=demo;trusted_connection=true";
            Console.WriteLine("Before connection");
            SqlConnection sqlconn = new SqlConnection(connect);
            Console.WriteLine("Before connection");
            sqlconn.Open();
            Console.WriteLine("after connection");
            SqlCommand cmd = new SqlCommand("Example", sqlconn);
            for (int i = 1; i <=2; i++)
            {
                cmd.Parameters.Clear();
                Console.WriteLine("enter emp name");
                string name = Console.ReadLine();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@name", System.Data.SqlDbType.VarChar).Value = name;
                cmd.ExecuteNonQuery();
                Console.WriteLine("added successfully");

            }

            cmd.Parameters.Clear();
            Console.WriteLine("line 29 completes");
            cmd.Parameters.Add("@name", System.Data.SqlDbType.VarChar).Value = "";
            Console.WriteLine("line 30 completes");
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine(dr[0].ToString()+" "+ dr[1].ToString());
                //Console.WriteLine(dr[1].ToString());
                //Console.WriteLine(dr[2].ToString());
                //Console.WriteLine(dr[3].ToString());

            }
           dr.Close();
            sqlconn.Close();

        }
    }
}