public class reverse
{
    public static void Main()
    {
        string str="hello";
        int l = 0;
        Console.Write("The characters of the string in reverse are : \n");
        l = str.Length - 1;

        for (int i = l; i >= 0; i--)
        {

           
            Console.WriteLine(str[i]);


        }
       

        Console.Write("\n\n");
       
    }
}
