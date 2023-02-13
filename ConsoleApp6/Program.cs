namespace ConsoleApp6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            ThreadStart threadStart = new ThreadStart(ConsoleWrite);
            Thread thread = new Thread(threadStart);
            thread.IsBackground = true;
            thread.Priority = ThreadPriority.Lowest;
            thread.Start();
            thread.Join();
            for (int i=0;i <=50;i++)
            {
                Console.WriteLine("Из основной программы: " + i);
            }
        }
        static void ConsoleWrite()
        {
            for (int i = 0; i <= 50; i++)
            {
                if(i == 25)
                {
                    Console.ReadLine();
                }
                Console.WriteLine("Из потока: " + i);
            }
        }
    }
}