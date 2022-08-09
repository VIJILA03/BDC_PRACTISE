
public class bothevenorodd
{
    public static void Main(string[] args)
    {


        int num1, num2;
        bool BothEvenorOdd;
        Console.Write("Enter First number: ");
        num1 = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter Second number: ");
        num2 = Convert.ToInt32(Console.ReadLine());


        
        BothEvenorOdd = ((num1 % 2 == 0)
            && (num2 % 2 == 0)) ? true : false;

        if(BothEvenorOdd)
        {
            Console.WriteLine("TRUE");
        }
        else
        {
            Console.WriteLine("FALSE");
        }
    }
}