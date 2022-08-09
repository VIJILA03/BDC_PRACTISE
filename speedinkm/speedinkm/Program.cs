public class speedinkm
{
    public static void Main(string[] args)
    {
        float distance;
        float hour, min, sec;
        float timeinsec;
        float kmperhr, milesperhr;

        Console.Write("Input distance(metres): ");
        distance = Convert.ToInt32(Console.ReadLine());
        
        Console.Write("Input time:\n");

        Console.Write("Input hour value: ");
        hour = Convert.ToInt32(Console.ReadLine());

        Console.Write("Input minutes value: ");
        min = Convert.ToInt32(Console.ReadLine());

        Console.Write("Input seconds value: ");
        sec = Convert.ToInt32(Console.ReadLine());

        timeinsec = (hour * 3600) + (min * 60) + sec;

        kmperhr = (distance / 1000.0f) / (timeinsec / 3600.0f);

        milesperhr = kmperhr / 1.609f;

        Console.WriteLine("Your speed in km/h is: "+kmperhr);
        Console.WriteLine("Your speed in miles/h is: "+milesperhr);
    }
}
