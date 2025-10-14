namespace Refresh_TopCoding;

public class TwoPointers
{
    public string MergeAlternately(string word1, string word2)
    {
        int maxLength = Math.Max(word1.Length, word2.Length);
        string res = string.Empty;
        for (int i = 0; i < maxLength; i++)
        {
            if (i < word1.Length)
            {
                res += word1[i];
            }

            if (i < word2.Length)
            {
                res += word2[i];
            }
        }

        return res;
    }

    public bool ContainsNearbyDuplicate(int[] nums, int k)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i+1; j < nums.Length; j++)
            {
                int diff = Math.Abs(i - j);
                int n1 = nums[i];
                int n2 = nums[j];
                if (diff <= k && (n1 == n2))
                {
                    return true;
                }
            }
        }

        return false;
    }
    
    public int FindLHS(int[] nums) {
        var map = new Dictionary<int,int>();
        var best = 0;
        foreach(var n in nums){
            if(!map.ContainsKey(n)){
                map[n] = 0;
            }
            map[n]++;
        }

        foreach(var kvp in map){
            var k = kvp.Key;

            if(map.ContainsKey(k+1)){
                best = Math.Max(best, (map[k] + map[k+1]));
            }
        }

        return best;
    }
    
    public double FindMaxAverage(int[] nums, int k) {
        if(nums.Length < k) return 0;
        double best = double.MaxValue;
        double res = 0.0;
        double sum = 0.0;
        int left =0;
        int right = left + k;

        while(right <= nums.Length){
            for(int i = 0; i < k;i++){
                sum += nums[i+left];
            }
            best = Math.Max(best,(sum/k));
            left++;
            right++;
        }

        return best;
    }
    
    public string LongestNiceSubstring(string s) {
        if(s.Length < 2) return string.Empty;
        var res = string.Empty;
        for(int i = 0; i < s.Length; i++)
        {
            for(int j = i + 1; j <= s.Length; j++)
            {
                string sub = s.Substring(i, j - i);
                if(IsNice(sub) && sub.Length > res.Length)
                {
                    res = sub;
                }
            }
        }

        return res;
    }

    private bool IsNice(string str){
        var hSet = new HashSet<char>();
        foreach(var c in str){
            hSet.Add(c);
        }

        foreach(var c in hSet){
            if(!hSet.Contains(char.ToUpper(c)) || !hSet.Contains(char.ToLower(c))) return false;
        }

        return true;
    }
    
    public int CountGoodSubstrings(string s) {
        if(s.Length < 3) return 0;
        int count =0;
        int left =0;
        int right =3;
        while(right <= s.Length){
            var hset =new HashSet<char>();
            for(int i = 0; i<3; i++){
                hset.Add(s[i+left]);
            }
            if(hset.Count == 3) count++;
            hset.Clear();
            left++;
            right++;
        }

        return count;
    }
    
    public int MinimumDifference(int[] nums, int k) {
        if(nums.Length ==1 && k ==1) return 0;
        int min = int.MaxValue;

        Array.Sort(nums);

        int start =0;
        while(start < nums.Length - (k-1)){
            int j = start +k-1;
            int diff = Math.Abs(nums[j] - nums[start]);
            if(diff == 0) return 0;

            if(diff < min){
                min =diff;
            }
            start++;
        }
        return min;
    }
    
    public int MinimumRecolors(string blocks, int k) {
        if(blocks.Length < k) return 0;
        int min = int.MaxValue;
        for(int i =0; i <blocks.Length-k;i++){
            var sub = blocks.Substring(i, k);
            min = Math.Min(min,GetW(sub));

        }

        return min;
    }

    private int GetW(string sub)
    {
        int count = 0;
        foreach (var c in sub)
        {
            if (c =='W') count++;
        }
        return count;
    }
}