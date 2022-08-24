using System.Data.SqlClient;
namespace assignment1;

    public class Day5
    {
        public static void Main(string[] args)
        {
            string connect = "data source=LAPTOP-PH4JPVTP;initial catalog=demo;trusted_connection=true";
            Console.WriteLine("Before connection");
            SqlConnection sqlconn = new SqlConnection(connect);
            Console.WriteLine("Before connection");
            
            Console.WriteLine("after connection");
        SqlCommand cmd = new SqlCommand("Passportinfo", sqlconn);
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        sqlconn.Open();

        for (int i = 0; i <10; i++)
        {
            cmd.Parameters.Clear();

            Console.WriteLine("enter passport number");
            string Passno = Console.ReadLine();
            cmd.Parameters.Add("@PassportNumber", System.Data.SqlDbType.VarChar).Value = Passno;

            Console.WriteLine("enter candidate name");
            string CandidateName = Console.ReadLine();
            cmd.Parameters.Add("@CandidateName", System.Data.SqlDbType.VarChar).Value = CandidateName;

            Console.WriteLine("enter issue date");
            DateTime IssueDate   = DateTime.Parse(Console.ReadLine());
            cmd.Parameters.Add("@IssueDate", System.Data.SqlDbType.DateTime).Value = IssueDate;

            Console.WriteLine("enter exp date");
            DateTime ExpDate = DateTime.Parse(Console.ReadLine());
            cmd.Parameters.Add("@ExpDate", System.Data.SqlDbType.Date).Value = ExpDate;

            //Console.WriteLine("enter years of validity");
           // int Validity = ((TimeSpan)(ExpDate - IssueDate)).years;
                int Validity = new DateTime((ExpDate - IssueDate).Ticks).Year;
            //int Validity = Convert.ToInt32(Console.ReadLine());
            cmd.Parameters.Add("@Validity", System.Data.SqlDbType.Int).Value = Validity;

            Console.WriteLine("enter the channel applied through");
            string AppliedChannel = Console.ReadLine();
            cmd.Parameters.Add("@AppliedChannel", System.Data.SqlDbType.VarChar).Value = AppliedChannel;

            cmd.ExecuteNonQuery();
        }

        Console.WriteLine("executed successfully");
        cmd.Parameters.Clear();
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.CommandText = "fetchPassportInformation";


        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
        Console.WriteLine(dr[0].ToString()+" " + dr[1].ToString()+" "+ dr[2].ToString()+" "+ dr[3].ToString() + " " + dr[4].ToString() + " " + dr[5].ToString());
    //Console.WriteLine(dr[1].ToString());
    //Console.WriteLine(dr[2].ToString());
    //Console.WriteLine(dr[3].ToString());

        }
        dr.Close();

         sqlconn.Close();

}
}

