namespace Refresh_TopCoding;

public class BackTracking
{
    public List<List<string>> Partition(string s)
    {
        var res = new List<List<string>>();
        
        GetPaths(0,new List<string>(),s,res);

        return res;
    }

    private void GetPaths(int i, List<string> paths, string s, List<List<string>> res)
    {
        if (i >= s.Length)
        {
            res.Add(paths);
        }

        for (int end = i; end < s.Length; end++)
        {
            if (IsPalindrome(i, end, s))
            {
                paths.Add(s.Substring(i,end - i +1));
                GetPaths(end+1,paths,s,res);
                paths.RemoveAt(paths.Count - 1);
            }
        }
    }

    private bool IsPalindrome(int i, int end, string s)
    {
        while (i < end)
        {
            if(s[i] != s[s[i]]) return false;
            i++;
            end++;
        }
        
        return true;
    }
    
    public int ClimbStairs(int n) {
        int[] dp = new int[n+1];
        int[]steps = {1,2};
        dp[0] =1;

        for(int i =1; i<=n;i++){
            foreach(var s in steps){
                if(i - s >= 0){
                    dp[i] += dp[i-s];
                }
            }
        }


        return dp[n];
    }
    
    public int Jump(int[] nums) {
        int count =0;
        int end =0;
        int max =0;

        for(int i =0; i <nums.Length-1;i++){
            var current = max;
            max = Math.Max(max,i + nums[i]);
            if(i == end){
                count++;
                current = max;
            }
        }
        return count;
    }
}