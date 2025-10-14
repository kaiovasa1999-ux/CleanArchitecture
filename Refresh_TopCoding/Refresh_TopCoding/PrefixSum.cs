using System.Runtime.ExceptionServices;

namespace Refresh_TopCoding;

public class PrefixSum
{
    public int MinStartValue(int[] nums)
    {
        
        if (nums.Length ==0) return 0;

        var prefix = new int[nums.Length];
        prefix[0] = nums[0];

        int min = int.MaxValue;
        for(int i = 1; i < nums.Length;i++){
            prefix[i] = prefix[i-1] + nums[i];

            min = Math.Min(min, prefix[i]);
        }

        if(min <0){
            return Math.Abs(min) +1;
        }

        return 1;
    }
    int LargestAltitude2(int[] gain) {
        var prefix = new int[gain.Length+1];
        prefix[0] =0;
        if(gain == null) return 0;

        int top = int.MinValue;

        for(int i =1; i <= gain.Length;i++){
            prefix[i] = prefix[i-1] + gain[i];

            top = Math.Max(top,prefix[i]);
        }

        return top;
    }
    public int MaxScore(string s)
    {
        int leftZeros =0;
        int rightOnes = 0;
        int max = 0;
        foreach(var c in s){
            if(c == '1') rightOnes++;
        }

        for (int i = 1; i < s.Length;i++)
        {
            if(s[i] == '0') leftZeros++;
            else rightOnes--;
            max = Math.Max(max,(leftZeros + rightOnes));
        }

        return max;

    }
    
    public int SumOddLengthSubarrays(int[] arr)
    {
        int n = arr.Length;
        if (n == 0) return 0;

        int[] prefixSum = new int[n];

        prefixSum[0] = arr[0];

        int totalSum = 0;

        for (int i = 1; i < n; ++i)
            prefixSum[i] = prefixSum[i - 1] + arr[i];
        
        totalSum = prefixSum[n - 1];

        for (int i = 3; i <= n; i += 2)
        {
            for (int j = i - 1; j < n; j++)
            {
                totalSum += prefixSum[j];
                if (j - i >= 0)
                    totalSum -= prefixSum[j - i];
            }
        }

        return totalSum;
    }
    
    public int LargestAltitude(int[] gain)
    {
        var prefix = new int[gain.Length +1];
        prefix[0] = 0;
        var top = int.MinValue;

        for(int i =0; i < gain.Length;i++){
            prefix[i + 1] = prefix[i] + gain[i];
        }
        for(int i =0; i < prefix.Length;i++){
            if(prefix[i] > top){
                top = prefix[i];
            }
        }

        return top;
    }
}

