public class ex1
{
    public static void Main()
    {
        string filename = "C:\\Users\\Vijila\\source\\repos\\day3\\sample.txt";
        FileStream fs = new FileStream(filename, FileMode.Append);//it is an existing file

        StreamWriter sw = new StreamWriter(fs);
        sw.WriteLine("welcome");
        sw.WriteLine("to");
        sw.WriteLine("magic");
        sw.WriteLine("world");
       
        sw.Close();

        Console.WriteLine("file is apended");
        using (StreamReader sr = File.OpenText(filename))
        {
            string str = "";
            while ((str = sr.ReadLine()) != null)
            {
                Console.WriteLine(str);
            }
            sr.Close();

            fs.Close();
        }
    }
}
