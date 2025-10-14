namespace TopCodingStringTasks;

public class RomanToInteger
{
    public int RomanToInt(string s) {
        int result = 0;
        int n = s.Length;
        Dictionary<char, int> map = new Dictionary<char, int>();
        s = "MCMXVIII";
        
        var remeNumber =s.ToCharArray();
        map.Add('I',1);
        map.Add('V',5);
        map.Add('X',10);
        map.Add('L',50);
        map.Add('C',100);
        map.Add('D',500);
        map.Add('M',1000);
        char next ;
        for (int i = 0; i < s.Length; i++)
        {
           
            char c = s[i];
            int current = map[c];
            if (i + 1 < s.Length)
            {
                next = s[i + 1];
                int nextNum = map[next];
                if (current < nextNum)
                {
                    nextNum -= current;
                    result+=nextNum;
                    i++;
                    continue;
                }
            }
           
            result+=current;
        }
        
        return result;
    }
}