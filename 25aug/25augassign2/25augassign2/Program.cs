using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace assign2
{
    public class assign2
    {
        public static void Main(string[] args)
        {
            string connect = ConfigurationManager.ConnectionStrings["MyKey"].ConnectionString;
            //string connect = "data source=LAPTOP-PH4JPVTP;initial catalog=demo;trusted_connection=true";

            SqlConnection sqlconn = new SqlConnection(connect);
            Console.WriteLine("connecting to the server");
            sqlconn.Open();
            Console.WriteLine("connected to the server");

            Console.WriteLine("ENTER THE MOVIE GENRE");
            string genre = Console.ReadLine();
            SqlCommand cmd = new SqlCommand("SELECT  *  from GetMovies(@genre)", sqlconn);

            cmd.Parameters.Add("@genre", System.Data.SqlDbType.VarChar).Value = genre;
            // cmd.ExecuteNonQuery();



            SqlDataReader dr = cmd.ExecuteReader();
            
            while (dr.Read())
            {
                Console.WriteLine(dr[0].ToString() + " " + dr[1].ToString());
                //Console.WriteLine(dr[1].ToString());
                //Console.WriteLine(dr[2].ToString());
                //Console.WriteLine(dr[3].ToString());
            }
            dr.Close();
            /*SqlCommand cmd1 = new SqlCommand(@"SELECT  *  from GetMovies'" + genre + "'", sqlconn);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd1);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine(dr[0].ToString());
            }
            
            
            SqlDataAdapter adp = new SqlDataAdapter();
            //Create the command object
           
            //Inline query or stored procedure
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connect;
            adp.SelectCommand = cmd;
            //Open the connedction to sql server
            connect.Open();

            //Fill to datatable
            DataTable dt = new DataTable();
            adp.Fill(dt);
            connect.Close();

            GridView1.DataSource = dt;
            GridView1.DataBind(); */
            sqlconn.Close();
        }
    }
}