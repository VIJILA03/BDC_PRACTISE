public class reverse3letters
{
    public static void Main(String[] args)
    {
        char firstletter,secondletter, thirdletter;
        Console.WriteLine("ENTER THREE LETTERS");
        firstletter = Convert.ToChar(Console.ReadLine());
        secondletter = Convert.ToChar(Console.ReadLine());
        thirdletter = Convert.ToChar(Console.ReadLine());
        Console.WriteLine("REVERSED LETTERS:{0} {1} {2} "+thirdletter+" "+secondletter+" "+firstletter);
    }
}
