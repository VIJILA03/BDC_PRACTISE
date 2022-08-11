namespace ex3;
using System;
using System.Collections.Generic;
class ex3
{
    static void Main()
    {
         Dictionary<int,int> StudentList =new Dictionary<int,int>();

        
        StudentList.Add(1, 75);
        StudentList.Add(2, 86);
        StudentList.Add(3, 78);

   
        foreach(KeyValuePair<int, int> val in StudentList)
        {
            Console.WriteLine("studentid: "+val.Key+" studentmarks: "+val.Value);
        }
    }
}
