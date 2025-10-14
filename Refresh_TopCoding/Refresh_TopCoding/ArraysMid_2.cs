namespace Refresh_TopCoding;

public class ArraysMid_2
{
    public int MaxSubArray(int[] nums)
    {
        int maxSum = int.MinValue;
        int sum = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            int num = nums[i];
            sum += num;
            if (maxSum < sum) maxSum = sum;
        }

        return maxSum;
    }

    public int LongestUnivaluePath(TreeNode root)
    {
        int max = -1;
        DFS(root, 0);


        void DFS(TreeNode root, int count)
        {
            if (max < count) max = count;
            if (root == null) return;

            if (root.left != null)
            {
                if (root.left.val == root.val) DFS(root.left, count + 1);
                else DFS(root.right, count);
            }
            else if (root.right != null)
            {
                if (root.right.val == root.val) DFS(root.right, count + 1);
                else DFS(root.left, count);
            }
        }

        return max;
    }

    public int MaxSubArra2y(int[] nums)
    {
        int maxSum = int.MinValue;
        int current = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            current += nums[i];
            maxSum = Math.Max(current, maxSum);
            if (current < 0) current = 0;
        }

        return maxSum;
    }

    public bool CanJump(int[] nums)
    {
        if (nums.Length < 2) return true;

        var farthest = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (i > farthest)
            {
                return false;
            }

            farthest = Math.Max(farthest, nums[i] + i);
            if (farthest >= nums.Length - 1)
            {
                return true;
            }
        }

        return farthest >= nums.Length - 1;
    }

    public int Jump(int[] nums)
    {
        int l = 0;
        int r = 0;
        int res = 0;

        while (r < nums.Length - 1)
        {
            int max = 0;
            for (int i = l; i <= r; i++)
            {
                max = Math.Max(max, i + nums[i]);
            }

            l++;
            r = max;
            res++;
        }

        return res;
    }

    public int[][] Merge(int[][] intervals)
    {
        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

        var res = new List<int[]>();

        foreach (var i in intervals)
        {
            var start = i[0];
            var end = i[1];

            int n = res.Count;

            if (n == 0 || res[n - 1][1] < start)
            {
                res.Add(i);
            }
            else
            {
                res[n - 1][1] = Math.Max(end, res[n - 1][1]);
            }
        }

        return res.ToArray();
    }

    public int MinPathSum(int[][] grid)
    {
        if (grid == null || grid.Length == 0 || grid[0].Length == 0) return 0;

        var rows = grid.Length;
        var cols = grid[0].Length;

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (r == 0 && c == 0) continue;

                int fromTop = r > 0 ? grid[r - 1][c] : int.MaxValue;
                int fromLeft = c > 0 ? grid[r][c - 1] : int.MaxValue;

                grid[r][c] += Math.Min(fromTop, fromLeft);
            }
        }

        var res = grid[rows - 1][cols - 1];
        return res;
    }

    public bool SearchMatrix(int[][] matrix, int target)
    {
        var rows = matrix.Length;
        var cols = matrix[0].Length;
        var left = 0;
        var right = cols - 1;

        for (int r = 0; r < rows; r++)
        {
            while (left <= right)
            {
                int mid = (left + right) / 2;
                int num = matrix[r][mid];

                if (num == target) return true;

                if (num < target)
                {
                    left = mid + 1;
                }

                else
                {
                    right = mid - 1;
                }
            }

            left = 0;
            right = matrix[0].Length - 1;
        }

        return false;
    }

    public int MinimumTotal(List<List<int>> triangle)
    {
        int m = triangle.Count;

        for (int i = m - 2; i >= 0; i--)
        {
            for (int j = 0; j < triangle[i].Count; j++)
            {
                triangle[i][j] += Math.Min(triangle[i + 1][j], triangle[i][j + 1]);
            }
        }

        return triangle[0][0]; //top
    }

    public int MinPathSum2(int[][] grid)
    {
        int rows = grid.Length;
        int cols = grid[0].Length;
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (r == 0 && c == 0) continue;

                int moveDown = r > 0 ? grid[r - 1][c] : int.MaxValue;
                int moveRight = c > 0 ? grid[r][c - 1] : int.MaxValue;

                grid[r][c] += Math.Min(moveDown, moveRight);
            }
        }

        return grid[rows - 1][cols - 1];
    }

    public int CanCompleteCircuit(int[] gas, int[] cost)
    {
        int total = 0;
        int tank = 0;
        int startIndex = 0;

        for (int i = 0; i < gas.Length; i++)
        {
            int diff = gas[i] - cost[i];
            total += diff;
            tank += diff;

            if (tank < 0)
            {
                startIndex = i + 1;
            }
        }

        return 0;
    }

    public int LongestConsecutive(int[] nums)
    {
        var hSet = new HashSet<int>();
        int longest = 0;
        int curr = 0;
        foreach (var n in nums)
        {
            if (hSet.Contains(n - 1))
            {
                while (hSet.Contains(n + curr))
                {
                    curr++;
                }

                longest = Math.Max(longest, curr);
            }
        }

        return longest;
    }

    public int MaxProduct(int[] nums)
    {
        int maxRes = nums[0];
        int minSum = 1;
        int maxSum = 1;


        for (int i = 0; i < nums.Length; i++)
        {
            var currMax = nums[i] * maxSum;
            var currMin = nums[i] * minSum;

            maxSum = Math.Max(currMax, Math.Max(nums[i], currMin));
            minSum = Math.Max(currMax, Math.Min(nums[i], currMin));

            maxRes = Math.Max(maxRes, maxSum);
        }

        return maxRes;
    }

    public int MaximalSquare(char[][] matrix)
    {
        int maxSide = 0;
        int rows = matrix.Length;
        int cols = matrix[0].Length;
        var dp = new int[rows + 1, cols + 1];

        for (int r = 1; r < rows; r++)
        {
            for (int c = 1; c < cols; c++)
            {
                if (matrix[r - 1][c - 1] == '1')
                {
                    dp[r, c] = 1 + Math.Min(dp[r - 1, c - 1], Math.Min(dp[r - 1, c], dp[r, c - 1]));

                    maxSide = Math.Max(maxSide, dp[r, c]);
                }
            }
        }

        return maxSide * maxSide;
    }

    public int FindDuplicate(int[] nums)
    {
        var hSet = new HashSet<int>();

        foreach (var n in nums)
        {
            if (!hSet.Contains(n)) hSet.Add(n);
            else
            {
                return n;
            }
        }

        return -1;
    }

    public int LengthOfLIS(int[] nums)
    {
        if (nums.Length == 0) return 0;

        var dp = new int[nums.Length];
        Array.Fill(dp, 1);

        int max = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (nums[j] < nums[i])
                {
                    dp[i] = Math.Max(dp[i], dp[j] + 1);
                }
            }

            max = Math.Max(max, dp[i]);
        }

        return max;
    }

    public bool IncreasingTriplet(int[] nums)
    {
        int firstN = int.MaxValue;
        int secondN = int.MaxValue;

        foreach (var n in nums)
        {
            if (n <= firstN) firstN = n;
            else if (n <= secondN) secondN = n;
            else return true;
        }

        return false;
    }

    public int MinimumTota2l(List<List<int>> triangle)
    {
        int n = triangle.Count;

        for (int i = n - 2; i >= 0; i--)
        {
            for (int j = 0; j < triangle[i].Count; j++)
            {
                triangle[i][j] += Math.Min(triangle[i + 1][j], triangle[i][j + 1]);
            }
        }

        return triangle[0][0];
    }

    public int EraseOverlapIntervals(int[][] intervals)
    {
        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

        int count = 0;

        for (int i = 0; i < intervals.Length; i++)
        {
            if (intervals[i][1] > intervals[i + 1][0])
            {
                count++;
                intervals[i + 1][1] = Math.Min(intervals[i][1], intervals[i + 1][1]);
            }
        }

        return count;
    }

    public int SubarraySum2(int[] nums, int k)
    {
        var dict = new Dictionary<int, int>();
        var sum = 0;
        var ways = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
            if (sum == k)
            {
                ways++;
            }

            ways += dict.GetValueOrDefault(sum - k);

            dict[sum] = dict.GetValueOrDefault(sum) + 1;
        }


        return ways;
    }

    public int LeastBricks(List<List<int>> wall)
    {
        var map = new Dictionary<int, int>();

        for (int i = 0; i < wall.Count; i++)
        {
            var cross = 0;

            for (int j = 0; j < wall[i].Count - 1; j++)
            {
                cross = wall[i][j];

                var x = map.GetValueOrDefault(cross) + 1;
                map[cross] = x;
            }
        }

        var maxCorss = map.Count > 0 ? map.Values.Max() : 0;

        return wall.Count - maxCorss;
    }

    public int SubarraySum(int[] nums, int k)
    {
        var map = new Dictionary<int, int>();
        int sum = 0;
        int count = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            sum += nums[i];

            if (sum == k) count++;

            count += map.GetValueOrDefault(sum - k);
            map[sum] = map.GetValueOrDefault(sum) + 1;
        }

        return count;
    }

    public bool CheckPossibility(int[] nums)
    {
        if (nums.Length <= 2) return true;

        var mod = false;

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i - 1] > nums[i])
            {
                if (mod) return false;

                mod = true;
                if (i < 2 || nums[i - 2] <= nums[i])
                {
                    nums[i - 1] = nums[i];
                }
                else
                {
                    nums[i] = nums[i - 1];
                }
            }
        }

        return true;
    }

    public int NumSubarrayProductLessThanK(int[] nums, int k)
    {
        if (k <= 1) return 0;
        var products = 1;
        int count = 0;
        int left = 0;

        for (int r = 0; r < nums.Length; r++)
        {
            products *= nums[r];
            while (products >= k)
            {
                products /= nums[left];
                left++;
            }

            count += r - left + 1;
        }

        return count;
    }

    public int MinimumTotal2(List<List<int>> triangle)
    {
        int m = triangle.Count;

        for (int i = m - 2; i >= 0; i--)
        {
            for (int j = 0; j < triangle[i].Count; j++)
            {
                triangle[i][j] += Math.Min(triangle[i + 1][j], triangle[i + 1][j + 1]);
            }
        }

        return triangle[0][0];
    }

    public long CountSubarrays(int[] nums, int k)
    {
        if (nums.Length == 0 || k == 0) return 0;

        int max = nums.Max();
        int res = 0;
        var maxNumPositions = new List<int>();

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == max)
            {
                maxNumPositions.Add(i);
            }

            int freq = maxNumPositions.Count;

            if (freq >= k)
            {
                res += maxNumPositions[freq - k] + 1;
            }
        }

        return res;
    }

    public int EliminateMaximum(int[] dist, int[] speed)
    {
        var timeToArrive = new int[dist.Length];

        var kils = 0;
        for (int i = 0; i < timeToArrive.Length; i++)
        {
            var time = (dist[i] / speed[i]) + 1;
            timeToArrive[i] = time;
        }

        for (int i = 0; i < timeToArrive.Length; i++)
        {
            if (i >= timeToArrive[i]) break;
            kils++;
        }

        return kils;
    }
    
    public int MinIncrementForUnique(int[] nums) {
        Array.Sort(nums);

        int changesCount =0;

        for(int i= 1; i < nums.Length;i++){
            if(nums[i] <= nums[i-1]){
                int updateBy = nums[i-1] - nums[i] +1;
                nums[i] +=updateBy;
                changesCount+=updateBy;
            }
        }
        return changesCount;
    }
}