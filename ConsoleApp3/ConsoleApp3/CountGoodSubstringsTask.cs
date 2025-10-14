namespace ConsoleApp3;

public class CountGoodSubstringsTask
{
    public int CountGoodSubstrings(string s)
    {
        var x = 0;
        int windowSize = 3;
        int j = 0;
        Dictionary<int, HashSet<string>> dict = new Dictionary<int, HashSet<string>>();
        for (int i = 0; i < s.Length; i++)
        {
            dict.Add(i, new HashSet<string>());


            for (j = i; j < windowSize + i; j++)
            {
                if (j >= s.Length)
                {
                    break;
                }

                dict[i].Add(s[j].ToString());
            }
        }

        foreach (var item in dict)
        {
            if (item.Value.Count == 3)
            {
                x++;
            }
        }

        return x;
    }
}