public class areaandperimeter
{
    static void main(string[] args)
    {
    double radius, area, perimeter;
    double pi = 3.14;
    Console.WriteLine("Enter the radius of the circle");
        radius=Convert.ToDouble(Console.ReadLine());
        area = pi* radius * radius;
        perimeter = 2 * pi* radius;
    Console.WriteLine("AREA OF THE CIRCLE"+area);
        Console.WriteLine("PERIMETER OF THE CIRCLE"+perimeter);

    }
}