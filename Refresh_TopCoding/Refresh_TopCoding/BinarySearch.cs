namespace Refresh_TopCoding;

public class BinarySearch
{
    public bool CheckIfExist(int[] arr)
    {
        var hSet = new HashSet<int>(arr);
        // foreach(var n in hSet)
        // {
        //     var res = (double)n / 2;
        //     if(hSet.Contains(n*n) || hSet.Contains(res)) return true;
        // }
        return false;
        
    }
    
    public int CountNegatives(int[][] grid) {
        
        int count =0;

        foreach(var row in grid){
            count += GetNegative(row);
        }

        return count;
    }

    private int GetNegative(int[] rowData){
        int left =0;
        int right = rowData.Length -1;

        while(left <= right){
            int mid = (left + right) /2;
            bool isNegative = rowData[mid] < 0 ? true : false;

            if(isNegative)
            {
                right = mid - 1;
            }
            else{
                left = mid +1;
            }
        }

        return rowData.Length -1 - right;
    }
    
    public int GetCommon(int[] nums1, int[] nums2) {
        foreach(var n in nums1){
            int left =0;
            int right = nums2.Length;
            while(left <= right){
                int mid = (left + right) /2;
                if(n == nums2[mid]){
                    return n;
                }
                else if (nums2[mid] > n){
                    right = mid-1;
                }
                else{
                    left =mid+1;
                }
            }
        }

        return -1;

    }
    
    // public int GetCommon(int[] nums1, int[] nums2) {
    //     foreach(var n in nums1){
    //         int left =0;
    //         int right = nums2.Length-1;
    //         while(left <= right){
    //             int mid  =(left + right) /2;
    //             if(n == nums2[mid]) return n;
    //             else if (nums2[mid] > n){
    //                 left = mid +1;
    //             }
    //             else{
    //                 right = mid-1;
    //             }
    //         }
    //     }
    //     return -1;
    // }
    
    public List<int> TargetIndices(int[] nums, int target)
    {
        var res = new List<int>();
        Array.Sort(nums);

        int left =0;
        int right = nums.Length -1;
        
        while(left <= right){
            int mid = (left + right) /2;

            if(nums[mid] < target){
                left = mid+1;
            }
            else{
                right = mid-1;
            }
        }

        while (right +1 < nums.Length && nums[right + 1] == target)
        {
            res.Add(right + 1);
        }

        return res;
    }

}