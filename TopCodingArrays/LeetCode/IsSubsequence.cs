namespace LeetCode;

public class IsSubsequenceClass
{
    public static bool IsSubsequence(string s, string t)
    {
        int x = 0;
        int y = 0;
        while (x < s.Length && y < t.Length)
        {
            if (s[x] == t[y])
            {
                x++;
            }

            y++;
        }

        return x == s.Length;
    }
}