public class mergearray
{
    public static void Main()
    {
        int[] arr1 = new int[100];
        int[] arr2 = new int[100];
        int[] arr3 = new int[200];
        int len1, len2, len3;
        int i = 0, j = 0; ;

        //input for first array

        Console.Write("Input the number of elements to be stored in the first array :");
        len1 = Convert.ToInt32(Console.ReadLine());

       
        for ( i = 0; i < len1; i++)
        {
            
            arr1[i] = Convert.ToInt32(Console.ReadLine());
        }

       
        //input for second array

        Console.Write("Input the number of elements to be stored in the second array :");
        len2 = Convert.ToInt32(Console.ReadLine());

        for ( i = 0; i < len2; i++)
        {
           
            arr2[i] = Convert.ToInt32(Console.ReadLine());
        }
        

        len3 = len1 + len2;

        //add and store both arrays in a single array

        for (i = 0; i < len1; i++)
        {
            arr3[i] = arr1[i];
        }
        for(j=0;j<len2;j++)
        {
            arr3[i] = arr2[j];
            i++;
        }
        //SORT
        for (i = 0; i < len3; i++)
        {
            for (j = 0; j< len3 - 1; j++)
            {

                if (arr3[j] >= arr3[j + 1])
                {
                    int temp = arr3[j + 1];
                    arr3[j + 1] = arr3[j];
                    arr3[j] = temp;
                }
            }
        }



        Console.Write("\nThe merged array : \n");
        for ( i = 0; i < len3; i++)
        {
            Console.Write(arr3[i]);
        }
        Console.Write("\n\n");
    }
}

