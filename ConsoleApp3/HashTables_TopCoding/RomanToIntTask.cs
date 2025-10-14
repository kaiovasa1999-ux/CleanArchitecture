namespace HashTables_TopCoding;

public class RomanToIntTask
{
    public int RomanToInt(string s)
    {
        var res = 0;
        
        int result = 0;
        int n = s.Length;
        Dictionary<char, int> map = new Dictionary<char, int>();
        
        map.Add('I',1);
        map.Add('V',5);
        map.Add('X',10);
        map.Add('L',50);
        map.Add('C',100);
        map.Add('D',500);
        map.Add('M',1000);

        for (int i = 0; i < n; i++)
        {
            var ch = s[i];
            var currentNum = map[ch];
            if (i + 1 < n)
            {
                var next = s[i + 1];
                var nextNum = map[next];
                if (currentNum < nextNum)
                {
                    nextNum -= currentNum;
                    res += nextNum;
                    i++;
                    continue;
                }
            }
            res += currentNum;
        }

        return res;

    }
}