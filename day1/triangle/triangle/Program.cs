public class Triangle
{
    public static void Main()
    {
        int side1, side2, side3;
        Console.WriteLine("Enter side 1:");
        side1=Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter side 2:");
        side2 =Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter side 3: ");
        side3 = Convert.ToInt32(Console.ReadLine());
        if(side1==side2 && side2==side3)
        {
            Console.WriteLine("EQUILATERAL TRIANGLE");
        }
        else if(side1==side2 || side2==side3 || side1==side3)
        {
            Console.WriteLine("ISOSCELES TRIANGLE");
        }
        else
        {
            Console.WriteLine("scalene triangle");
        }
    }
}