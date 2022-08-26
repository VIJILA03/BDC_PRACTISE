using System.Configuration;
using System.Data.SqlClient;

namespace Assign;
public class aassign
{
    public static void Main(String[] args)
    {

        string connect = ConfigurationManager.ConnectionStrings["MyKey"].ConnectionString;
        //string connect = "data source=LAPTOP-PH4JPVTP;initial catalog=demo;trusted_connection=true";

        SqlConnection sqlconn = new SqlConnection(connect);
        Console.WriteLine("connecting to the server");
        sqlconn.Open();
        Console.WriteLine("connected to the server");


        SqlCommand cmd = new SqlCommand("SELECT * FROM GetHigherBalance()", sqlconn);

        Console.WriteLine("found successfully");




        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            Console.WriteLine(dr[0].ToString() + " " + dr[1].ToString() + " " + dr[2].ToString() + " " + dr[3].ToString() + " " + dr[4].ToString() + " " + dr[5].ToString() + " " + dr[6].ToString() + " " + dr[7].ToString() + " " + dr[8].ToString() + " " + dr[9].ToString());
            //Console.WriteLine(dr[1].ToString());
            //Console.WriteLine(dr[2].ToString());
            //Console.WriteLine(dr[3].ToString());

        }
        dr.Close();

        sqlconn.Close();
    }
}

