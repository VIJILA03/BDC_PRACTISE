public class Exercise10
{
    public static void Main()
    {
        int[] arr1 = new int[10];
        int[] arr2 = new int[10];
        int[] arr3 = new int[10];
        int i, j = 0, k = 0, n;


       
        Console.Write("Enter the no.of.elements :");
        n = Convert.ToInt32(Console.ReadLine());

        
        for (i = 0; i < n; i++)
        {
            
            arr1[i] = Convert.ToInt32(Console.ReadLine());
        }

        for (i = 0; i < n; i++)
        {
            if (arr1[i] % 2 == 0)
            {
                arr2[j] = arr1[i];
                j++;
            }
            else
            {
                arr3[k] = arr1[i];
                k++;
            }
        }

        Console.Write("\nThe Even element array : \n");
        for (i = 0; i < j; i++)
        {
            Console.Write(arr2[i]+" ");
        }

        Console.Write("\nThe Odd element array :\n");
        for (i = 0; i < k; i++)
        {
            Console.Write(arr3[i]+" ");
        }
        Console.Write("\n\n");
    }
