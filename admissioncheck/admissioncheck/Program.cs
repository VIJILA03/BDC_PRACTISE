public class Admissioncheck
{
    public static void Main(string[] args)
    {
        float physics, maths, chemistry;
        Console.WriteLine("ELIGIBILTY CHECK");
        Console.WriteLine("Enter Maths mark: ");
        maths=Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter Chemsitry mark: ");
        chemistry =Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter Physics mark: ");
        physics =Convert.ToInt32(Console.ReadLine());
        float total = maths + physics + chemistry;
        float mathphy = maths + physics;
        float matchem = maths + chemistry;
        if(maths>=65 && physics>=55 && chemistry>=50 && (total >= 180 || mathphy >= 140 || matchem >= 140))
        {
            Console.WriteLine("YOU ARE ELIGIBLE");

        }
        else
        {
            Console.WriteLine("YOU ARE NOT ELIGIBLE");
        }

    }
}
