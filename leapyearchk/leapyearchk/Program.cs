namespace Leapyearchk;
public class Leapyearchk
{
    public static void Main(string[] args)
    {
        int year;
        Console.Write("Input an year : ");
        year = Convert.ToInt32(Console.ReadLine());

        if ((year % 400) == 0)
        {
            Console.WriteLine(year+" is a leap year.\n" );
        }
        else if ((year % 100) == 0)
        {

            Console.WriteLine(year + " is not a leap year.\n");
        }
        else if ((year % 4) == 0)
        {
            Console.WriteLine(year + "{is a leap year.\n");
        }
        else
            Console.WriteLine(year + " is not a leap year.\n");
    }
}
