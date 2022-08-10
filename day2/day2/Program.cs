/*public class student
{
    /*public student(int id,String name)
    {
        Console.WriteLine("Constructor is called");
        Console.WriteLine(id);
        Console.WriteLine(name);
    }
    
    public int id,age;
    public String name;
    public static String clgname="SJCE";

    public student(int id, int age, string name)
    {
        this.id = id;
        this.age = age;
        this.name = name;
        
    }
    public void showdet()
        {
        Console.WriteLine(id + " " + age + " " + " " + name+" "+clgname);
        }
}
public class Example
{
    
    static void Main(string[] args)
    {
        /*int[] ints = { 1, 2, 3 };
        int[] ints2 = new int[3];
        ints2[0] =4;
        ints2[1] =5;
        ints2[2] = 6;
        /*for(int i = 0; i < ints.Length; i++)
        {
            Console.WriteLine(ints[i]);
        }*/
/*int[,] ARR1 = new int[3,3];
ARR1[0,0] = 1;
ARR1[1,0] = 2;
ARR1[2,0] = 3;
ARR1[0,1] = 4;
ARR1[1,1] = 5;
ARR1[2,1] = 6;
ARR1[0,2] = 7;
ARR1[1,2] = 8;
ARR1[2,2] = 9;

for(int i=0; i <ARR1.GetLength(0); i++)
{
    for(int j=0;j<ARR1.GetLength(1); j++)
    {
        Console.WriteLine(ARR1[i,j] + " ");


    }
    Console.WriteLine();
    Console.WriteLine(ARR1.Length);
}
/*int[][] arr = new int[3][];
arr[0] = ints2;
arr[1] = ints;
arr[2] = ints2;
for (int i = 0; i <arr.Length ; i++)
{
    for (int j = 0; j < arr.Length; j++)
    {
        Console.WriteLine(arr[i][j] + " ");


    }
    Console.WriteLine();
    Console.WriteLine(arr.Length);
}
student std = new student(1,14,"vj");

student std2 = new student(2,14,"vij");
std.showdet();
std2.showdet();




}
}
 public enum days
    {
        sun,mon,tue,wed,thur,fri,sat
    }
    public static void Main(String[] args)
    {
        Console.WriteLine(days.tue);
    }*/
/*public class Student
{
   public struct about
    {
        public string name;
        public int age;
        public int id;
    }
    static void Main(string[] args)
    {
        about a;
        a.id = 102;
        a.name = "VIJ";
        a.age = 22;
        Console.WriteLine("Name: "+a.name+"\nAge: "+a.age+"\nId: "+a.id);
    }
}*/

/*public class one
{
   public static void Main(string[] args)
    {
        string name = "hdcv ";
        string name1 = "gmorn";
        char[] chars = name.ToCharArray();
        Console.WriteLine(chars);
        //name=name.TrimEnd('0');

        //Console.WriteLine(name);
        //Console.WriteLine(name.Substring(0,7));
        //Console.WriteLine(string.Concat(name," ",name1));
        //name1=name1.Replace('o', 'b');
       // Console.WriteLine(name1);
       //name.CompareTo(name1);
        Console.WriteLine(name.CompareTo(name1));
           
    }

}*/
public class Exceptionhand
{

    public static void Main(string[] args)
    {
        try {

            unchecked { 
            


                int num = int.MaxValue;
                Console.WriteLine(num + 2);
            }
            
        }
        catch(Exception e)
        {
            Console.WriteLine(e.ToString());
        }
        }

}

