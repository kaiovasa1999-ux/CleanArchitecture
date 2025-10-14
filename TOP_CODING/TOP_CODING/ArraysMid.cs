namespace TOP_CODING;

public class ArraysMid
{
    public int MaxArea(int[] height)
    {
        int left = 0;
        int right = height.Length - 1;
        int maxVolume = int.MinValue;

        while (left <= right)
        {
            var currentHeight = Math.Min(height[left], height[right]);
            var currentVolume = currentHeight * (right - left);
            if (currentVolume > maxVolume) maxVolume = currentVolume;

            if (height[left] < height[right])
            {
                left++;
            }
            else
            {
                right--;
            }
        }

        return maxVolume;
    }

    public int Search(int[] nums, int target)
    {
        int left = 0;
        int right = nums.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (nums[mid] == target) return mid;

            if (nums[left] <= nums[mid])
            {
                if (target > nums[left] && target <= nums[mid])
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            else
            {
                if (target > nums[left] && target <= nums[mid])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
        }

        return -1;
    }

    public bool CanJump(int[] nums)
    {
        int maxReach = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (i > maxReach) return false;
            maxReach = Math.Max(maxReach, i + nums[i]);
            if (maxReach >= nums.Length - 1) return true;
        }

        return true;
    }

    public int LongestConsecutive(int[] nums)
    {
        var hSet = new HashSet<int>(nums);
        var max = 0;
        foreach (var n in nums)
        {
            if (!hSet.Contains(n - 1))
            {
                var current = 1;
                while (hSet.Contains(n + current))
                {
                    current++;
                }

                max = Math.Max(current, max);
            }
        }

        return max;
    }

    public int CanCompleteCircuit(int[] gas, int[] cost)
    {
        if (gas.Sum() < cost.Sum()) return -1;

        var tank = 0;
        int res = 0;

        for (int i = 0; i < gas.Length; i++)
        {
            tank += gas[i] - cost[i];

            if (tank < 0)
            {
                tank = 0;
                res = i + 1;
            }
        }

        return res;
    }

    public int MinSubArrayLen(int target, int[] nums)
    {
        int start = 0;
        int minL = int.MaxValue;
        int sum = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
            while (sum >= target)
            {
                minL = Math.Min(minL, i - start + 1);
                sum -= nums[start];
                start++;
            }
        }

        return minL;
    }
    
    public int LengthOfLIS(int[] nums) {
        if(nums.Length ==0) return 0;

        var dp = new int[nums.Length];
        Array.Fill(dp,1);
        int maxL =0;
        for(int i =0; i < nums.Length;i++){
            for(int j = 0; j < i; j++){
                if(nums[j] < nums[i]){
                    dp[i] = Math.Max(dp[i],dp[j]+1);
                }
            }

            maxL = Math.Max(dp[i],maxL);
        }

        return maxL;
    }
    
    public int MaxProduct(int[] nums) {
        int max =1;
        int min =1;
        int maxRes =0;

        for(int i =0; i <nums.Length;i++){
            var currentMax =nums[i] * max;
            var currentMin = nums[i] * min;

            max = Math.Max(currentMax, Math.Max(nums[i],currentMin));
            min = Math.Min(currentMax, Math.Min(nums[i],currentMin));

            maxRes = Math.Max(maxRes,max);

        }
        return maxRes;


    }
    
    public int LongestOnes(int[] nums, int k) {
        int left =0;

        for(int i =0; i < nums.Length;i++){
            k -= 1 + nums[i];
            if(k <0){
                k += 1 - nums[i];
                left++;
            }
        }

        return nums.Length - left;
    }
    
    public int EliminateMaximum(int[] dist, int[] speed) {
        for(int i =0; i <dist.Length;i++){
            dist[i] = (dist[i] + speed[i]) / speed[i];
        }

        Array.Sort(dist);

        int kils =0;
        for(int i =0; i < dist.Length;i++){
            if(dist[i] < i) break;
            kils++;
        }

        return kils;
    }
    
    public int LengthOfLongestSubstring(string s) {
        int max =0;
        var hSet = new HashSet<char>();
        int left =0;

        for(int i =0; i < s.Length;i++){
            while(hSet.Contains(s[i])){
                hSet.Remove(s[left]);
                left++;
            }

            hSet.Add(s[i]);
            max = Math.Max(max, hSet.Count);
        }

        return max;
    }
    
    public List<string> RestoreIpAddresses(string s) {
        var res = new List<string>();

        for(int i =1; i <= i+3;i++){
            var n1 = s.Substring(0,0);
            if(IsValid(n1)) continue;
            for(int j =i; j <= j+3;j++){
                var n2 = s.Substring(i,j-i);
                if(IsValid(n2)) continue;
                for(int k = j; k <= k+3;j++){
                    var n3 = s.Substring(j,k-j);
                    var n4 = s.Substring(k);
                    if(IsValid(n3) && IsValid(n4)){
                        res.Add($"{n1}.{n2}.{n3}.{n4}");
                    }
                }
            }
        }

        return res;
    }

    private bool IsValid(string num){
        if(num.Length == 0 || num.Length >3) return false;
        if(num.Length >1 && num[0] =='0') return false;
        var val= int.Parse(num);

        return val >0 && val<= 255;
    }
}