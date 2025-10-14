namespace ConsoleApp3;

public class LongestAlternatingSubarrayTask
{
    public int LongestAlternatingSubarray(int[] nums, int threshold)
    {
        int maxLen = 0;
        int n = nums.Length;
        int i = 0;

        while (i < n)
        {
            if (nums[i] > threshold || nums[i] % 2 != 0)
            {
                i++;
                continue;
            }

            int j = i;
            while (j < n && nums[j] <= threshold && nums[j] % 2 == (j - i) % 2)
            {
                j++;
            }

            maxLen = Math.Max(maxLen, j - i);
            i = i + 1;
        }

        return maxLen;
    }
}

