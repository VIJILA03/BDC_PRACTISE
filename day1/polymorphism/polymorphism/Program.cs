/*public class polymorphism
{
    public static int add(int a,int b)
    {
        return a + b;
    }
    public static int add(int a,int b,int c)
    {
        return a + b + c;
    }
    public static void Main(String[] args)
    {
        Console.WriteLine(add(1,2));
        Console.WriteLine(add(1,2,3));
    }
}
*/
public abstract class Shape
{
    public abstract void draw();
   /* {
       // Console.WriteLine("this is parent class);
    }*/
}
public class circle : Shape
{
    public override void draw()
    {
        Console.WriteLine("this is circle");
    }
}
public class rect : Shape
{
    public override void draw()
    {
        Console.WriteLine("this is rect");
    }
}
public class main
{
    public static void Main(string[] args)
    {
        Shape S1=new circle();
        Shape S2=new rect();
        S1.draw();
        S2.draw();
    }
}
