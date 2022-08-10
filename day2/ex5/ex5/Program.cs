public class ex5
{
    public static void Main()
    {
        string str1;
        char[] arr1;
        int l=0, i;
        
        char ch;
  
        str1 = "Welcome";
        l = str1.Length;
        arr1 = str1.ToCharArray(0, l); // Converts string into char array.

        Console.Write("\nAfter conversion : ");
        for (i = 0; i < l; i++)
        {
            ch = arr1[i];
            if (Char.IsLower(ch)) // check whether the character is lowercase
                Console.Write(Char.ToUpper(ch)); // Converts lowercase character to uppercase.
            else
                Console.Write(Char.ToLower(ch)); // Converts uppercase character to lowercase.
        }
        Console.Write("\n\n");
    }
}
