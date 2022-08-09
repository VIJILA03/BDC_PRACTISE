public class reverse3letters
{
    public static void Main(string[] args)
    {
        char firstletter,secondletter, thirdletter;
        Console.WriteLine("ENTER THREE LETTERS");
        firstletter = Convert.ToChar(Console.ReadLine());
        secondletter = Convert.ToChar(Console.ReadLine());
        thirdletter = Convert.ToChar(Console.ReadLine());
        Console.WriteLine("REVERSED LETTERS: "+thirdletter+" "+secondletter+" "+firstletter);
    }
}
