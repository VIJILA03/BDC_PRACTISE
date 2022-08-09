
public class bothevenorodd
{
    public static void Main(string[] args)
    {


        int n1, n2;
        bool BothEvenorOdd;
        Console.Write("Enter First number: ");
        n1 = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter Second number: ");
        n2 = Convert.ToInt32(Console.ReadLine());


        //bothEven = ((n1%2!=0) || (n1%2!=0))? false:true;
        BothEvenorOdd = ((n1 % 2 == 0)
            && (n2 % 2 == 0)) ? true : false;

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