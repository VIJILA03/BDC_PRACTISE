using System.Configuration;
using System.Data.SqlClient;

namespace assign2
{ 
    public class assign2
    {
        public static void Main(string[] args) { 
         string connect = ConfigurationManager.ConnectionStrings["MyKey"].ConnectionString;
          //string connect = "data source=LAPTOP-PH4JPVTP;initial catalog=demo;trusted_connection=true";
         Console.WriteLine("Before connection");
         SqlConnection sqlconn = new SqlConnection(connect);
Console.WriteLine("Before connection");
sqlconn.Open();
Console.WriteLine("after connection");
SqlCommand cmd = new SqlCommand("STUDENTYR", sqlconn);

    Console.WriteLine("enter year : ");
            int year = (int)Convert.ToInt64(Console.ReadLine());
    cmd.CommandType = System.Data.CommandType.StoredProcedure;
    cmd.Parameters.Add("@year", System.Data.SqlDbType.VarChar).Value = year;
    cmd.ExecuteNonQuery();
    Console.WriteLine("added successfully");




SqlDataReader dr = cmd.ExecuteReader();
while (dr.Read())
{
    Console.WriteLine(dr[0].ToString() + " " + dr[1].ToString() + " " + dr[2].ToString() + " " + dr[3].ToString());
    //Console.WriteLine(dr[1].ToString());
    //Console.WriteLine(dr[2].ToString());
    //Console.WriteLine(dr[3].ToString());

}
dr.Close();
sqlconn.Close();

        }
    }
}
