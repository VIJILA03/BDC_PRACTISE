public class Student
{
    public int StudentId { get; set; }
    public string StudentName { get; set; }

}
public class test
{
    public static void Main(String[] args)
    {
        Student std= new Student();
        std.StudentId = 123;
        std.StudentName = "ABC";
        Console.WriteLine("id: "+std.StudentId);
        Console.WriteLine("Name: "+std.StudentName);

    }
}
