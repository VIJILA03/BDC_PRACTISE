namespace heightrange
{
    public class Heightrange
    {
        public static void Main(string[] args)
        {
            float Heightincm;
            Console.Write("Enter the height of the person (in centimetres): ");
            Heightincm = Convert.ToInt32(Console.ReadLine());

            if (Heightincm < 135.0)
                Console.Write(" SHORT");
            else if (Heightincm >= 135.0 && Heightincm <= 180.0)
                Console.Write(" AVERAGE ");

            else
                Console.Write("TALL");
        }
    }
}