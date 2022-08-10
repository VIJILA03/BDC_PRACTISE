public class Arraycopy
{
    public static void Main()
    {
        //Initialize first array   
        int[] array1 = new int[] { 2,4,6,8,10 };

        //Create another array array with size of 1st array  
        int[] array2 = new int[array1.Length];

        //Copying all elements of one array into another  

        /*for (int i = 0; i < array1.Length; i++)
        {
            array2[i] = array1[i];
        }
        */

        //in-built function
        Array.Copy(array1,array2,5);

        //Displaying elements of  1st array
        //
        Console.WriteLine("Elements of 1st array: ");
        for (int i = 0; i < array1.Length; i++)
        {
            Console.Write(array1[i] + " ");
        }

        Console.WriteLine();

        //Displaying elements of 2nd array  

        Console.WriteLine("Elements of second array: ");
        for (int i = 0; i < array2.Length; i++)
        {
            Console.Write(array2[i] + " ");
        }
    }
}
