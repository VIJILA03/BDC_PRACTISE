/* generics

public class GenericEg
{
    public void show<T>(T msg)
    {
        Console.WriteLine(msg);
    }
   // public GenericEg(T msg)
   //{
    //    Console.WriteLine(msg);
   // }
    
   
}
public class driverclass
{
    public static void Main(string[] args)
    {
        //GenericEg<string> g = new GenericEg<string>("this is a string msg");
        //GenericEg<int> g1 = new GenericEg<int>(2);
        //GenericEg<char> g2 = new GenericEg<char>('t');
        GenericEg gen = new GenericEg();
        gen.show("HI WELCOME");
        gen.show(123);
        gen.show('F');
        gen.show(true);

    }
}
*/
/*using System.Text;
public class listarr
{
    public static void Main(string[] args)
    {
        var newlist=new List<string>();
        newlist.Add("one");
        newlist.Add("two");
        newlist.Add("three");
        newlist.Add("four");
        newlist.Add("five");
        newlist.Add("six");
        newlist.Add("seven");
        newlist.Add("seven"); //list can have duplicate item
        foreach (var item in newlist)
        {
            Console.WriteLine(item);
        }*/
/*var newhashset=new HashSet<int>();
newhashset.Add(1);
newhashset.Add(2);
newhashset.Add(3);

newhashset.Add(5);
newhashset.Add(6);
newhashset.Add(4);//doesnot arrange or sort
newhashset.Add(7);
newhashset.Add(7);//hashset wont allow duplicate
newhashset.Add(8);
foreach (var item in newhashset)
{
   Console.WriteLine(item);
}*/
/*var newsortedset = new SortedSet<string>();
newsortedset.Add("hello");
newsortedset.Add("hi");
newsortedset.Add("apple");
newsortedset.Add("act");
newsortedset.Add("hi");
newsortedset.Add("buzz");
foreach (var item in newsortedset)
{
    Console.WriteLine(item);
}
var stackset = new Stack<string>();
stackset.Push("a");
stackset.Push("b");
stackset.Push("c");
stackset.Push("d");
stackset.Push("e");
foreach (var item in stackset)
{
    Console.WriteLine(item);
}
Console.WriteLine("top element");
Console.WriteLine(stackset.Peek());
Console.WriteLine("elemet poped");
Console.WriteLine(stackset.Pop());
Console.WriteLine("top elemet ");
Console.WriteLine(stackset.Peek());
Console.WriteLine("after");
foreach (var item in stackset)
{
    Console.WriteLine(item);
}*/
/*var queueset = new Queue<int>();
queueset.Enqueue(1);
queueset.Enqueue(2);
queueset.Enqueue(3);
queueset.Enqueue(4);
queueset.Enqueue(5);
foreach (var item in queueset)
{
      Console.WriteLine(item);
}
Console.WriteLine("top element");
Console.WriteLine(queueset.Peek());
Console.WriteLine("top element deleted");
Console.WriteLine(queueset.Dequeue());
Console.WriteLine("top element");
Console.WriteLine(queueset.Peek());
Console.WriteLine("After dequeue");
foreach (var item in queueset)
{
    Console.WriteLine(item);
}
var linked = new LinkedList<string>();
linked.AddLast("a");
linked.AddLast("b");
linked.AddLast("c");
linked.AddLast("d");
linked.AddLast("e");
linked.AddLast("f");
linked.AddFirst("g");
foreach (var item in linked)
{
    Console.WriteLine(item);
}
Console.WriteLine("next");
LinkedListNode<string> linknode = linked.Find("d");
linked.AddAfter(linknode, "r");
Console.WriteLine("next");
linked.AddBefore(linknode, "t");
Console.WriteLine("next");

foreach (var item in linked)
{
    Console.WriteLine(item);
}
SortedDictionary<string, string> dic = new SortedDictionary<string, string>();
dic.Add("one", "h");
dic.Add("two", "i");
dic.Add("three", "j");
    dic.Add("four", "i"); 


foreach (KeyValuePair<string,string> keyvaluepair in dic)
{
    Console.WriteLine(keyvaluepair);
}
SortedList<int,string> keyValuePairs = new SortedList<int,string>();
keyValuePairs.Add(1, "f");
keyValuePairs.Add(4, "g");
keyValuePairs.Add(3, "h");
keyValuePairs.Add(2, "i");

//keyValuePairs.Add(4, "z");//doesnt allow for duplicate
foreach(var item in keyValuePairs)
{
    Console.WriteLine(item);
}*/
//FileStream fs = new FileStream("C:\\Users\\Vijila\\Desktop\\hello\\test.txt",FileMode.OpenOrCreate);
/*StreamWriter sw = new StreamWriter(fs);
//fs.WriteByte(66);
sw.WriteLine("hello");
sw.Close();
fs.Close();
Console.WriteLine("hello is written");
StreamReader sr = new StreamReader(fs);
string str=sr.ReadToEnd();
Console.WriteLine(str);
sr.Close();
fs.Close();
using(TextWriter tw = File.CreateText("C:\\Users\\Vijila\\Desktop\\hello\\test.txt"))
{
    tw.WriteLine("hi this is vijila");
}
using (TextReader reader = File.OpenText("C:\\Users\\Vijila\\Desktop\\hello\\test.txt"))
{
    //Console.WriteLine(reader.Read());
    //Console.WriteLine(reader.ReadLine());
    Console.WriteLine(reader.ReadToEnd());
}
String filename = "C:\\Users\\Vijila\\Desktop\\hello\\test.txt";
using (BinaryWriter bw = new BinaryWriter(File.Open(filename, FileMode.Create)))
{
    bw.Write('A');
    bw.Write("Hello");
}
using(BinaryReader br=new BinaryReader(File.Open(filename, FileMode.Open)))
{

    Console.WriteLine(br.ReadChar());
    Console.WriteLine(br.ReadString());
}

string longtext = "today is thursday,\"HAVE A NICE DAY\"";
StringBuilder sb = new StringBuilder();
StringWriter sw = new StringWriter(sb);
sw.WriteLine(longtext);
sw.Close();
StringReader sr = new StringReader(sb.ToString());
while (sr.Peek() != -1)
{
    Console.WriteLine(sr.ReadLine());
}

FileInfo fi = new FileInfo("C:\\Users\\Vijila\\Desktop\\hello\\test1.txt");
fi.Create();
//DirectoryInfo di=new DirectoryInfo("C:\\Users\\Vijila\\Desktop\\hello\\test");
//di.Create();

*/
class Mutlithread { 

    public static void thread1()
    {
      
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(i);
            //Thread.Sleep(500);
            
            
        }
    }
    /*public static void thread2()
    {
        for (int i = 11; i < 21; i++)
        {
            Console.WriteLine(i);
            Thread.Sleep(1000);
        }
    }*/
    static void Main()
    {
        /*Thread thr = Thread.CurrentThread;
        thr.Name="main thread";
        Console.WriteLine(thr.Name);*/
        Thread t1 = new Thread(new ThreadStart(thread1));
        t1.Start();
        
        //Thread t2 = new Thread(new ThreadStart(thread2));
        // t2.Start();
        Thread t3 = new Thread(new ThreadStart(thread1));
        t3.Start();
        
    }
}