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

            /*// Console.WriteLine("enter a empid");
             Console.WriteLine("enter a salary");
             //int id = (int)Convert.ToInt64(Console.ReadLine());
             float sal = (float)Convert.ToDouble(Console.ReadLine());
             SqlCommand cmd = new SqlCommand("select dbo.Fn_EmpSalary(@Salary) as SalaryInfo", sqlconn);
             //cmd.CommandType = System.Data.CommandType.Text;
            // cmd.Parameters.Add("@empid", System.Data.SqlDbType.Int).Value = id;
             cmd.Parameters.Add("@salary", System.Data.SqlDbType.Float).Value = sal;
            // cmd.ExecuteNonQuery();
             Console.WriteLine("found successfully");

             string result = cmd.ExecuteScalar().ToString();
             Console.WriteLine("the salary range is "+result);*/
            Console.WriteLine("enter a subject");
            string sub = Console.ReadLine();
            SqlCommand cmd = new SqlCommand("select * from fnAlter(@subject)", sqlconn);
            //SqlCommand cmd = new SqlCommand("select  fn_maxmarks(@subject)", sqlconn);
            cmd.Parameters.Add("@subject",System.Data.SqlDbType.VarChar).Value = sub;
            // cmd.ExecuteNonQuery();
            Console.WriteLine("The built string is :"+cmd.CommandText.ToString());
            

            /*string result = cmd.ExecuteScalar().ToString();
            if (result == null || result ==string.Empty)
                Console.WriteLine("the subject "+sub+" is not found enter a valid subject");

            else
            {
                Console.WriteLine(sub+" found successfully");
                Console.WriteLine("The highest mark is " + result);
                    }
            */
            /*(SqlDataReader dr = cmd.ExecuteReader();
              while (dr.Read())
              {
                  Console.WriteLine(dr[0].ToString()+" "+ dr[1].ToString() +" " + dr[2].ToString());
                  //Console.WriteLine(dr[1].ToString());
                  //Console.WriteLine(dr[2].ToString());
                  //Console.WriteLine(dr[3].ToString());

              }
              dr.Close();
            */
            SqlDataAdapter da=new SqlDataAdapter(cmd.CommandText.ToString(),sqlconn);
            DataTable dt = new DataTable();
            da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine(dr[0].ToString());
                //Console.WriteLine(dr[1].ToString());
                //Console.WriteLine(dr[2].ToString());
                //Console.WriteLine(dr[3].ToString());

            }
          
          sqlconn.Close();

        }
    }
}