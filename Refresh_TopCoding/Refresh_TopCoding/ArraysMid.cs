namespace Refresh_TopCoding;

public class ArraysMid
{
    public bool CheckPossibility(int[] nums) {
        int[] soretd = new int[nums.Length];
        
        nums.CopyTo(soretd,0);
        Array.Sort(soretd);
        var count = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (soretd[i] != nums[i])
            {
                count++;
            }
        }
        return count <=1;
    }
    
    public int EraseOverlapIntervals(int[][] intervals) {
        Array.Sort(intervals, (a,b) => a[0].CompareTo(b[0]));

        var count =0;

        for(int i =0; i < intervals.Length-1;i++){
            if(intervals[i][1] > intervals[i+1][0]){
                count++;
                intervals[i+1][1] = Math.Min(intervals[i][1],intervals[i+1][1]);
            }
        }

        return count;
    }
    public int SubarraySum(int[] nums, int k) 
    {
        int sum = 0;
        int count = 0;

        for(int i =0; i <nums.Length;i++){
            for(int j =i; j<nums.Length;j++){
                int num = nums[j];
                if(sum +num <= k){
                    sum+= num;
                }
                if(sum == k){
                    sum= 0;
                    count++;
                }
            }
        }

        return count;

    }
}