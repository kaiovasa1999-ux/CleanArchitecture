namespace BackTracking;

public class PalindromePartitioning
{
    public List<List<string>> Partition(string s)
    {
        var res = new List<List<string>>();

        GetPalindromes(0, s, new List<string>(), res);

        return res;
    }

    private void GetPalindromes(int start, string word, List<string> parts, List<List<string>> result){
        if(start >= word.Length){
            result.Add(new List<string>(parts));
            return;
        }

        for(int end = start; end < word.Length; end++){
            if(IsPalindrome(start, end, word)){

                parts.Add(word.Substring(start, end-start+1));

                GetPalindromes(end +1, word, parts, result);

                parts.RemoveAt(parts.Count -1);
            }
        }

    }

    private bool IsPalindrome(int i, int j, string s)
    {
        while (i < j)
        {
            if(s[i] != s[j]) return false;

            i++;
            j--;
        }

        return true;
    }
}