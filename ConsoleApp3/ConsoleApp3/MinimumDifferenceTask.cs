namespace ConsoleApp3;

public class MinimumDifferenceTask
{
    public int MinimumDifference(int[] nums, int k)
    {
        if (nums.Length == 0 ||  k ==1)
        {
            return 0;
        }
        nums = nums.OrderBy(n => n).ToArray();
        
        int minResult = int.MaxValue;
        int start = 0;
        while (start < nums.Length - (k - 1))
        {
            int j = start+ k - 1;
            int currentDifference = Math.Abs(nums[j] - nums[start]);
            if (currentDifference == 0)
            {
                return 0;
            }
            
            minResult = Math.Min(minResult, currentDifference);
            start++;
        }

        return minResult;
    }
}