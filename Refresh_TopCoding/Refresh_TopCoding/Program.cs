// See https://aka.ms/new-console-template for more information

using System.Globalization;
using Refresh_TopCoding;

var cs = new ArraysMid_2();


var wall = new List<List<int>>
{
    new List<int> { 1, 2, 2, 1 },
    new List<int> { 3, 1, 2 },
    new List<int> { 1, 3, 2 },
    new List<int> { 2, 4 },
    new List<int> { 3, 1, 2 },
    new List<int> { 1, 3, 1, 1 }
};

Console.WriteLine(
    cs.EliminateMaximum(new []{1,1,2,3}, new []{1,1,1,1}));


string ReverseWords(string s)
*/{
    var words = s.Split(' ').ToList();
    var reversed = string.Empty;

    foreach (var word in words)
    {
        for (int i = word.Length - 1; i >= 0; i--)
        {
            reversed += word[i];
        }

        reversed += " ";
    }

    var res = reversed.TrimEnd();

    return res;
}

string MergeAlternately(string word1, string word2)
{
    var res = string.Empty;

    var longest = Math.Max(word1.Length, word2.Length);

    for (int i = 0; i < longest; i++)
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

int FindContentChildren(int[] g, int[] s)
{
    var count = 0;

    Array.Sort(g);
    Array.Sort(s);
    int i = 0, j = 0;

    while (i < g.Length && j < s.Length)
    {
        if (s[i] >= g[j])
        {
            count++;
            i++;
        }

        j++;
    }

    return count;
}

int MinStartValue(int[] nums)
{
    if (nums.Length == 0) return 1;

    int[] prefix = new int[nums.Length];
    prefix[0] = nums[0];
    int min = int.MaxValue;

    for (int i = 1; i < nums.Length; i++)
    {
        int current = prefix[i - 1] + nums[i];

        prefix[i] = current;
        min = Math.Min(min, current);
    }

    if (min < 0)
    {
        return Math.Abs(min) + 1;
    }

    return 1;
}

int MaxScore(string s)
{
    int totalOnes = 0;
    foreach (var c in s)
    {
        if (c == '1') totalOnes++;
    }

    int leftZeroes = 0;
    int maxValue = int.MinValue;

    foreach (var c in s)
    {
        if (c == '0')
        {
            leftZeroes++;
        }
        else
        {
            totalOnes--;
        }

        maxValue = Math.Max(maxValue, leftZeroes + totalOnes);
    }

    return maxValue;
}

// int MinStartValue2(int[] nums)
// {
//     // var prefix = new int[nums.Length];
//     // prefix[0] = nums[0];
//     // int min = int.MaxValue;
//     //
//     // for (int i = 1; i < nums.Length) {
//     //     var current = prefix[i - 1] + nums[i];
//     //     prefix[i] = current;
//     //     min = Math.Min(current, min);
//     // }
//     //
//     // if (min < 0)
//     // {
//     //     return Math.Abs(min) + 1;
//     // }
//     //
//     // return 1;
// }

int LargestAltitude(int[] gain)
{
    var prefix = new int[gain.Length];
    if (gain.Length == 0) return 0;
    prefix[0] = gain[0];

    int max = int.MinValue;

    for (int i = 1; i < gain.Length; i++)
    {
        prefix[i] = prefix[i - 1] + gain[i];
    }

    foreach (var n in prefix)
    {
        if (n > max)
        {
            max = n;
        }
    }

    return max;
}

int BuyChoco(int[] prices, int money)
{
    if (prices.Length == 1) return 0;
    Array.Sort(prices);
    int count = 0;

    for (int i = 0; i < prices.Length; i++)
    {
        int p1 = prices[i];
        int p2 = prices[i + 1];
        if ((p1 + p2) > money)
        {
            return money;
        }
        else
        {
            money -= p1 + p2;
            return money;
        }
    }

    return money;
}

int MinMovesToSeat(int[] seats, int[] students)
{
    Array.Sort(seats);
    Array.Sort(students);
    int steps = 0;
    for (int i = 0; i < seats.Length; i++)
    {
        steps += Math.Abs(seats[i] - students[i]);
    }

    return steps;
}

double Average(int[] salary)
{
    var pq = new PriorityQueue<double, int>();

    foreach (var s in salary)
    {
        pq.Enqueue(s, s);
    }

    if (pq.Count == 3)
    {
        pq.Dequeue();
        return pq.Dequeue();
    }

    pq.Dequeue(); // remove the bigest;
    double secondSmallest = 0;
    double secondBiggest = pq.Dequeue();

    while (pq.Count > 1)
    {
        if (pq.Count == 2)
        {
            secondSmallest = pq.Dequeue();
        }

        pq.Dequeue();
    }

    double avg = (secondSmallest + secondBiggest) / 2;

    return avg;
}

bool ValidPalindrome(string s)
{
    int left = 0;
    int right = s.Length - 1;


    var h = new HashSet<int>();
    h.Clear();
    bool isDiff = false;
    while (left < right)
    {
        if (s[left] != s[right])
        {
            if (isDiff) return false;
            isDiff = true;

            if (s[left + 1] == s[right])
            {
                left++;
            }

            if (s[left] == s[right])
            {
                right--;
            }
        }

        left++;
        right--;
    }

    return true;
}


double FindMaxAverage(int[] nums, int k)
{
    if (nums.Length == 1 && k == 1) return nums[0];
    double res = 0;
    double max = double.MinValue;
    double sum = 0;

    int left = 0;
    int right = k;

    while (right <= nums.Length)
    {
        for (int i = left; i < right; i++)
        {
            sum += nums[i];
        }

        res = sum / (double)k;
        sum = 0;
        if (max < res)
        {
            max = res;
        }

        left++;
        right++;
    }

    return max;
}

int FindLHS(int[] nums)
{
    var map = new Dictionary<int, int>();

    foreach (var n in nums)
    {
        if (!map.ContainsKey(n))
        {
            map[n] = 0;
        }

        map[n]++;
    }

    int maxLength = 0;

    foreach (var kvp in map)
    {
        int number = kvp.Key;
        if (map.ContainsKey(number + 1))
        {
            maxLength = Math.Max(maxLength, map[number] + map[number + 1]);
        }
    }

    return maxLength;
}

bool ContainsNearbyDuplicate(int[] nums, int k)
{
    for (int i = 0; i < nums.Length; i++)
    {
        for (int j = 1; j < nums.Length; j++)
        {
            if (nums[i] == nums[j] && Math.Abs(j - i) <= k - 1)
            {
                return true;
            }
        }
    }

    return false;
}

int MaxProductDifference(int[] nums)
{
    Array.Sort(nums);
    int a = nums[0], b = nums[1], c = nums[^1], d = nums[^2];

    var res = Math.Abs((a * b) - (c * d));
    return res;
}

int HeightChecker(int[] heights)
{
    var pq = new PriorityQueue<int, int>();

    foreach (var h in heights)
    {
        pq.Enqueue(h, h);
    }

    int counter = 0;
    while (pq.Count > 0)
    {
        for (int i = 0; i < heights.Length; i++)
        {
            int qNum = pq.Dequeue();
            if (qNum != heights[i])
            {
                counter++;
            }
        }
    }

    return counter;
}