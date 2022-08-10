class Withoutrep
{

    // This function returns true if all characters in
    // str[i..j] are distinct, otherwise returns false
    public static bool Withoutrepeat(string str,
                                   int i, int j)
    {

        
        bool[] check = new bool[26];

        for (int k = i; k <= j; k++)
        {
            if (check[str[k] - 'a'] == true)
                return false;

            check[str[k] - 'a'] = true;
        }
        return true;
    }

    // Returns length of the longest substring
    // with all distinct characters.
    public static int LongestUniqueSubsttr(string str)
    {
        int n = str.Length;

        // Result
        int res = 0;

        for (int i = 0; i < n; i++)
            for (int j = i; j < n; j++)
                if (Withoutrepeat(str, i, j))
                    res = Math.Max(res, j - i + 1);//maximum count

        return res;
    }

   
    public static void Main()
    {
        string str = "helloworld";
        Console.WriteLine("The input string is " + str);

        int len = LongestUniqueSubsttr(str);

        Console.WriteLine("The length of the longest " +
                          "non-repeating character " +
                          "substring is " + len);
    }
}

