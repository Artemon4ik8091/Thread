namespace ConsoleApp6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyObject myObject = new MyObject();
            myObject.Start = Int32.Parse(Console.ReadLine());
            myObject.End = Int32.Parse(Console.ReadLine());
            Threads threads = new Threads();
            threads.count = Int32.Parse(Console.ReadLine());
            //Console.WriteLine("Hello, World!");
            ParameterizedThreadStart parameterizedThreadStart = new ParameterizedThreadStart(ConsoleWrite);
            //ThreadStart threadStart = new ThreadStart(ConsoleWrite);
            Thread thread = new Thread(parameterizedThreadStart);
            thread.IsBackground = true;
            thread.Priority = ThreadPriority.Lowest;
            thread.Start(myObject);
            thread.Join();
        }
        static void ConsoleWrite(object my)
        {
            int Start = ((MyObject)my).Start;
            int End = ((MyObject)my).End;
            string Message = ((MyObject)my).Message;
            int count = ((Threads)my).count;
            for (int i = Start; i <= End; i++)
            {
                Console.WriteLine("Из потока: " + i);
            }
        }
    }

    class MyObject
    {
        public int Start { get; set; }
        public int End { get; set; }
        public string Message { get; set; } = "THIS IS CHEATS!";
    }
    class Threads
    {
        public int count { get; set; }
    }
}