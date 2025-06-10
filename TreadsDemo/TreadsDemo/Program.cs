class Program
{
    static void Main(string[] args)
    {

        List<int> range = Enumerable.Range(0, 1000000).ToList();

        for (int i = 0; i < 10; i++)
        {
            new Thread(() =>
            {
                while (range.Count > 0)
                {
                    range.RemoveAt(range.Count - 1);
                    Console.WriteLine($"range[{i}] = {range.Count}");
                }
            }).Start();
        }
    }
}
   