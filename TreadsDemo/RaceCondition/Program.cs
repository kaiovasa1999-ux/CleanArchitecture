class Program
{
    static void Main(string[] args)
    {
        for (int i = 100 - 1; i >= 0; i--)
        {
            new Thread(() =>
            {
                if (i < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(i));
                }
                i--;
            });
            Console.WriteLine("asdfasf");
        }
    }
}