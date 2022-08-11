public class ex4
{
    public void GenericMethod<T,U,V>(T id,U name, V result)
    {
        Console.WriteLine("id: " + id + " name: " + name +" Result :"+result);
       
    }
    public static void Main(String[] args)
    {
        ex4 gen = new ex4();
        gen.GenericMethod(12, "Rahul", 'Y');
        gen.GenericMethod(14, "Kiran", 'N');
        gen.GenericMethod(15, "Vij", 'Y');
        gen.GenericMethod(19, "Prin", 'Y');
        gen.GenericMethod(21, "John", 'N');


    }
}
