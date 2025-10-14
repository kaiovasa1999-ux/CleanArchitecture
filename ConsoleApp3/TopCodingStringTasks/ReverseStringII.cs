namespace TopCodingStringTasks;

public class ReverseStringII
{
    public string ReverseStr(string s, int k)
    {
        if(s.Length == 1) return s;
        if(k > s.Length)
        {
            k = s.Length;
        }
        char[] chars = new char[s.Length];
        int endIndex = k;
        for(int i = 0; i < s.Length; i++)
        {
            if(i % (2 * k) < k)
            {
                chars[endIndex - 1] = s[i];
                endIndex--;
            }
            else
            {
                endIndex = k + i + 1 > s.Length ? s.Length : k + i + 1;
                chars[i] = s[i];
            }
        }

        return new string(chars);
    }
}