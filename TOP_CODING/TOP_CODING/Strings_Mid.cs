using System.Runtime.InteropServices;
using System.Text;

namespace TOP_CODING;

public class Strings_Mid
{
    public string Multiply(string num1, string num2)
    {
        if (num1 == "0" || num2 == "0") return "0";

        var arr = new int[num1.Length + num2.Length];
        for (int i = 0; i < num1.Length; i++)
        {
            var d1 = num1[i] - '0';

            for (int j = 0; j < num2.Length; j++)
            {
                var d2 = num2[j] - '0';

                var product = d1 * d2;

                var sum = arr[i + j + 1] + product;
                arr[i + j + 1] = sum % 10;
                arr[i + j] += sum / 10;
            }
        }


        var res = new StringBuilder();
        int ix = 0;

        for (; ix < arr.Length; ix++)
        {
            res.Append((char)('0' + arr[ix]));
        }

        return res.ToString();
    }

    public int LengthOfLongestSubstring(string s)
    {
        var start = 0;
        int longest = 0;
        var set = new HashSet<char>();

        for (int i = 0; i < s.Length; i++)
        {
            while (!s.Contains(s[i]))
            {
                s.Remove(s[i]);
                start++;
            }

            set.Add(s[i]);

            longest = Math.Max(s.Length, longest);
        }

        return longest;
    }

    public int NumDecodings(string s)
    {
        var memo = Enumerable.Repeat(-1, s.Length + 1).ToArray();

        return DFS(memo, s, 0);

        int DFS(int[] arr, string s, int start)
        {
            if (start == s.Length) return 1;

            if (s[start] == '0') return 0;

            if (arr[start] == -1)
            {
                arr[start] = DFS(arr, s, start + 1);
                if (start + 1 < s.Length)
                {
                    var c1 = s[start];
                    var c2 = s[start + 1];
                    if (c1 == '1' || c1 == '2' && c2 >= '0' && c2 <= '6')
                    {
                        arr[start] = DFS(arr, s, start + 2);
                    }
                }
            }

            return arr[start];
        }
    }

    public bool WordBreak(string s, IList<string> wordDict)
    {
        var hSet = new HashSet<string>(wordDict);
        var dp = new bool[s.Length + 1];
        dp[0] = true;

        for (int i = 1; i < dp.Length; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (dp[j] && hSet.Contains(s.Substring(j, i - j)))
                {
                    dp[i] = true;
                    break;
                }
            }
        }

        return dp[s.Length];
    }

    public string RemoveKdigits(string num, int k)
    {
        if (k >= num.Length) return "0";
        var res = new StringBuilder();

        foreach (var c in num)
        {
            while (k > 0 && res.Length > 0 && res[res.Length - 1] > c)
            {
                res.Length--;
                k--;
            }

            if (res.Length > 0 || c != '0')
            {
                res.Append(c);
            }
        }

        if (k > 0)
        {
            res.Length = Math.Max(0, res.Length - k);
        }

        return res.Length == 0 ? "0" : res.ToString();
    }

    // public List<int> FindAnagrams(string s, string p)
    // {
    //     var res = new List<int>();
    //
    //     if (s.Length < p.Length) return res;
    //
    //     var pCount = new Dictionary<char, int>();
    //     var pCount2 = new Dictionary<char, int>();
    //     var sCount = new Dictionary<char, int>();
    //
    //
    //     foreach (var c in p)
    //     {
    //         if (!pCount.ContainsKey(c))
    //         {
    //             pCount[c] = 0;
    //         }
    //
    //         pCount[c]++;
    //     }
    //
    //     foreach (var c in s)
    //     {
    //         if (!sCount.ContainsKey(c))
    //         {
    //             sCount[c] = 0;
    //         }
    //
    //         sCount[c]++;
    //     }
    //
    //     int left = 0;
    //     int right = p.Length - 1;
    //
    //     while (right < s.Length)
    //     {
    //         for (int i = 0; i < right; i++)
    //         {
    //             var sC = s[i];
    //         }
    //     }
    //
    //
    //     return res;
    // }

    public int Compress(char[] chars)
    {
        int currC = 1;
        int counter = 1;

        for (int i = 1; i < chars.Length; i++)
        {
            if (chars[i] == chars[i - 1])
            {
                currC++;
            }
            else
            {
                counter++;
                if (counter > 1)
                {
                    counter += currC.ToString().Length;
                }

                currC = 1;
            }
        }

        if (currC > 1)
        {
            counter += currC.ToString().Length;
        }

        return counter;
    }

    public bool CheckValidString(string s)
    {
        var count = 0;
        var h = 0;

        foreach (var c in s)
        {
            if (c == '(')
            {
                count++;
                h++;
            }
            else if (c == ')')
            {
                if (count > 0) count--;
                h--;
            }
            else
            {
                if (count > 0) count--;

                h++;
            }
        }

        if (h < 0) return false;

        return count == 0;
    }

    public int MinimumLengthEncoding(string[] words)
    {
        var hSet = new HashSet<string>(words);

        foreach (var w in words)
        {
            for (int i = 1; i < w.Length; i++)
            {
                hSet.Remove(w.Substring(i));
            }
        }

        return hSet.Sum(w => w.Length + 1);
    }

    public string SortVowels(string s)
    {
        var vols = new HashSet<char>("aeiouAEIOU");
        var res = s.ToCharArray();

        var pq = new PriorityQueue<char, int>();

        for (int i = 0; i < s.Length; i++)
        {
            if (vols.Contains(s[i]))
            {
                pq.Enqueue(res[i], (res[i] - 'a'));
                res[i] = '*';
            }
        }

        for (int i = 0; i < res.Length; i++)
        {
            if (res[i] == '*')
            {
                res[i] = pq.Dequeue();
            }
        }

        return new string(res);
    }

    public int CountHomogenous(string s)
    {
        long length = 1;
        long res = 0;
        for (int i = 1; i < s.Length; i++)
        {
            if (s[i] == s[i - 1])
            {
                length++;
            }
            else
            {
                res = (res + ((length * (length + 1)) / 2) % 1000000007) % 1000000007;
                length = 1;
            }
        }

        res = (res + ((length * (length + 1)) / 2) % 1000000007) % 1000000007;

        return (int)res;
    }

    public List<List<string>> SuggestedProducts(string[] products, string searchWord)
    {
        var res = new List<List<string>>();
        Array.Sort(products);
        int max3 = 3;
        for (int i = 0; i < searchWord.Length; i++)
        {
            var row = new List<string>(3);
            if (products.Length < 3)
            {
                max3 = products.Length;
            }

            var c = searchWord[i];
            foreach (var p in products)
            {
                if (i < p.Length && p[i] == c && max3 > 0)
                {
                    max3--;
                    row.Add(p);
                }
            }

            res.Add(row);
            if (products.Length < 3)
            {
                max3 = products.Length;
            }

            max3 = 3;
        }

        return res;
    }

    public int EqualSubstring(string s, string t, int maxCost)
    {
        int cost = 0;
        int maxL = 0;
        int j = 0;

        for (int i = 0; i < s.Length; i++)
        {
            cost += Math.Abs(s[i] - t[i]);
            while (cost > maxCost)
            {
                cost -= Math.Abs(s[j] - t[j]);
                j++;
            }

            maxL = Math.Max(maxL, i - j + 1);
        }

        return maxL;
    }

    public string ReverseParentheses(string s)
    {
        var stack = new Stack<int>();
        var pair = new int[s.Length];

        for (int r = 0; r < s.Length; r++)
        {
            if (s[r] == '(')
            {
                stack.Push(r);
            }
            else if (s[r] == ')')
            {
                var l = stack.Pop();
                pair[r] = l;
                pair[l] = r;
            }
        }

        var sb = new StringBuilder();
        int idx = 0;
        int dir = 1;

        while (idx < s.Length && idx >= 0)
        {
            if (s[idx] == '(' || s[idx] == ')')
            {
                idx = pair[idx];
                dir = -dir;
            }
            else
            {
                sb.Append(s[idx]);
            }

            idx += dir;
        }

        return sb.ToString();
    }

    public int NumSpecialEquivGroups(string[] words)
    {
        var groups = new HashSet<string>();

        foreach (var w in words)
        {
            int n = w.Length;
            var even = new char[(n + 1) / 2];
            var odd = new char[n / 2];

            var e = 0;
            var o = 0;

            for (int i = 0; i < w.Length; i++)
            {
                if (i % 2 == 0) even[e++] = w[i];
                else odd[o++] = w[i];
            }

            Array.Sort(even);
            Array.Sort(odd);

            groups.Add(new string(even) + new string(odd));
        }

        return groups.Count;
    }

    public string PushDominoes(string dominoes)
    {
        var res = new char[dominoes.Length];
        var positions = new List<int>() { -1 };
        var forces = new List<char>() { 'L' };

        for (int i = 0; i < dominoes.Length; i++)
        {
            res[i] = dominoes[i];
            if (dominoes[i] == 'L' || dominoes[i] == 'R')
            {
                positions.Add(i);
                forces.Add(dominoes[i]);
            }
        }

        positions.Add(dominoes.Length);
        forces.Add('R');

        for (int i = 1; i < positions.Count; i++)
        {
            var leftF = forces[i - 1];
            var rightF = forces[i];
            var leftI = positions[i - 1];
            var rightI = positions[i];

            if (forces[i] == forces[i - 1])
            {
                for (int j = leftI + 1; j < rightI; j++)
                {
                    res[j] = forces[i];
                }
            }
            else if (leftF == 'R' && rightF == 'L')
            {
                while (leftI < rightI)
                {
                    res[leftI++] = leftF;
                    res[rightI--] = rightF;
                }
            }
        }

        return new string(res);
    }

    public string FindReplaceString(string s, int[] indices, string[] sources, string[] targets)
    {
        int k = indices.Length;
        int total = 0;

        var x = "asdf1234";
        var u = x.Substring(4, 2);
        for (int i = 0; i < k; i++)
        {
            var src = sources[i];
            var idx = indices[i] - total;
            var target = targets[i];
            var res = s.Substring(idx, src.Length);
            if (res == src)
            {
                s = s.Substring(0, idx) + target + s.Substring(idx + src.Length);
                total += src.Length - target.Length;
            }
        }

        return s;
    }

    public int MinimumLengthEncoding2(string[] words)
    {
        var good = new HashSet<string>(words);

        foreach (var word in words)
        {
            for (int i = 1; i < word.Length; i++)
            {
                var w = word.Substring(i); // creates a part of word which part we check
                // if there are any words like this part from
                // Substring(i => w.Length); time contains 'me' soo 'me'
                // as word should be removed
                good.Remove(w);
            }
        }

        return good.Sum(w => w.Length + 1);
    }

    public List<int> PartitionLabels(string s)
    {
        var res = new List<int>();
        if (string.IsNullOrWhiteSpace(s)) return res;

        var map = new Dictionary<char, int>();

        for (int i = 0; i < s.Length; i++)
        {
            map[s[i]] = i;
        }

        int l = 0;
        int r = 0;

        for (int i = 0; i < s.Length; i++)
        {
            r = Math.Max(r, map[s[i]]);
            if (i == r)
            {
                res.Add(r - l + 1);
                l = i + 1;
            }
        }

        return res;
    }

    public List<int> PartitionLabels2(string s)
    {
        var res = new List<int>();
        if (s == null || s == "") return res;

        var map = new Dictionary<char, int>();

        for (int i = 0; i < s.Length; i++)
        {
            map[s[i]] = i;
        }

        int l = 0;
        int r = 0;

        for (int i = 0; i < s.Length; i++)
        {
            r = Math.Max(r, map[s[i]]);
            if (i == r)
            {
                res.Add(r - l + 1);
                l = i + 1;
            }
        }

        return res;
    }

    public string SimplifyPath(string path)
    {
        if (string.IsNullOrEmpty(path)) return "/";

        var paths = path.Split('/', StringSplitOptions.RemoveEmptyEntries);

        var s = new Stack<string>();

        foreach (var p in paths)
        {
            if (p == ".") continue;
            else if (p == "..")
            {
                if (s.Count > 0) s.Pop();
            }
            else s.Push(p);
        }

        if (s.Count == 0) return "/";
        var segments = s.ToArray();
        Array.Reverse(segments);

        return "/" + string.Join("/", segments);
    }

    // public List<string> RestoreIpAddresses(string s)
    // {
    //     var res = new List<string>();
    //     var n = s.Length;
    //
    //     for (int i = 1; i <= 3 && i < n; i++)
    //     {
    //         var n1 = s.Substring(0, i);
    //         if (!IsValid(n1)) continue;
    //
    //         for (int j = i + 1; j <= i + 3 && j < n; j++)
    //         {
    //             var n2 = s.Substring(i, j - i);
    //             if (!IsValid(n2)) continue;
    //
    //             for (int k = j + 1; k <= j + 3 && k < n; k++)
    //             {
    //                 var n3 = s.Substring(j, k - j);
    //                 var n4 = s.Substring(k);
    //                 if (IsValid(n3) && IsValid(n4))
    //                 {
    //                     res.Add($"{n1}.{n2}.{n3}.{n4}");
    //                 }
    //             }
    //         }
    //     }
    //
    //     return res;
    // }


    public int CharacterReplacement(string s, int k)
    {
        var charMap = new int[26];
        int l = 0;
        int maxCount = 0;
        int maxL = 0;

        for (int r = 0; r < s.Length; r++)
        {
            var charAtIdxR = s[r] - 'A';
            charMap[charAtIdxR]++;
            maxCount = Math.Max(maxCount, charMap[charAtIdxR]);

            while ((r - l + 1) - maxCount > k)
            {
                var charAtIdxRL = s[l] - 'A';
                charMap[charAtIdxRL]--;
                l++;
            }

            maxL = Math.Max(maxL, (r - l + 1));
        }

        return maxL;
    }

    public List<int> FindAnagrams(string s, string p)
    {
        var res = new List<int>();
        if (string.IsNullOrEmpty(s) || p.Length > s.Length) return res;

        int[] count = new int[26];

        foreach (char ch in p)
        {
            var
                x = ch - 'a'; // foreach letter in alpaha bet (a-z) -'a' should give the index of this collection!! a -a = 0; a-b =1; c-a =2... z-a =25 this is the idexes;
            count[x]++;
        }

        int l = 0;
        int mach = p.Length;

        for (int r = 0; r < s.Length; r++)
        {
            int iR = s[r] - 'a';
            count[iR]--;
            if (count[iR] >= 0)
            {
                mach--;
            }

            while (r - l + 1 > p.Length)
            {
                int idxL = s[l] - 'a';
                if (++count[idxL] > 0) mach++; // вече "ни липсва" една такава буква
                l++;
            }

            if ((r - l + 1 == p.Length) && mach == 0)
                res.Add(l);
        }

        return res;
    }

    public IList<int> FindAnagrams2(string s, string p)
    {
        var res = new List<int>();
        if (string.IsNullOrEmpty(s) || p.Length > s.Length) return res;

        int[] count = new int[26];
        foreach (char ch in p) count[ch - 'a']++;

        int left = 0;
        int toMatch = p.Length;

        for (int right = 0; right < s.Length; right++)
        {
            int idxR = s[right] - 'a';
            count[idxR]--;
            if (count[idxR] >= 0) toMatch--; // използвахме нужна буква

            // поддържаме прозорец с дължина <= |p|
            while (right - left + 1 > p.Length)
            {
                int idxL = s[left] - 'a';
                if (++count[idxL] > 0) toMatch++; // вече "ни липсва" една такава буква
                left++;
            }

            if (right - left + 1 == p.Length && toMatch == 0)
                res.Add(left);
        }

        return res;
    }

    public int CanCompleteCircuit(int[] gas, int[] cost)
    {
        if (gas.Sum() < cost.Sum()) return -1;
        int tank = 0;
        int total = 0;
        int start = 0;

        for (int i = 0; i < gas.Length; i++)
        {
            int diff = gas[i] - cost[i];
            tank += diff;
            if (tank < 0)
            {
                start = i + 1;
                tank = 0;
            }
        }

        return start;
    }

    // public List<string> RestoreIpAddresses2(string s)
    // {
    //     var res = new List<string>();
    //
    //     for (int i = 1; i <= 3; i++)
    //     {
    //         var n1 = s.Substring(0, i);
    //         if (!IsValid(n1)) continue;
    //         for (int j = i + 1; j <= j + 3; j++)
    //         {
    //             var n2 = s.Substring(i, j - i);
    //             if (!isValid(n2)) continue;
    //
    //             for (int k = j + 1; k <= j + 3; k++)
    //             {
    //                 var n3 = s.Substring(j, k - j);
    //                 var n4 = s.Substring(k);
    //                 if (isValid(n3) && isValid(n4))
    //                 {
    //                     res.Add($"{n1}.{n2}.{n3}.{n4}");
    //                 }
    //             }
    //         }
    //     }
    //
    //     return res;
    // }


    public int LongestPalindromeSubseq(string s)
    {
        var dp = new int[s.Length, s.Length];

        for (int i = s.Length - 1; i >= 0; i--)
        {
            dp[i, i] = 1;
        }

        for (int i = s.Length - 1; i >= 0; i--)
        {
            for (int j = i + 1; j < s.Length; j++)
            {
                if (s[i] == s[j])
                {
                    dp[i, j] = dp[i + 1, j - 1] + 2;
                }
                else
                {
                    dp[i, j] = Math.Max(dp[i + 1, j], dp[i, j - 1]);
                }
            }
        }

        return dp[0, s.Length - 1];
    }

    public int CountSubstrings(string s)
    {
        int res = 0;

        for (int i = 0; i < s.Length; i++)
        {
            res += Get(s, i, i);
            res += Get(s, i, i + 1);
        }

        return res;
    }

    private int Get(string s, int l, int r)
    {
        int count = 0;

        while (l >= 0 && r < s.Length && s[l] == s[r])
        {
            count++;
            l--;
            r++;
        }

        return count;
    }

    public string ValidIPAddress(string queryIP)
    {
        var v4 = queryIP.Split('.');
        var v6 = queryIP.Split('.');
        if (v4.Length == 4)
        {
            foreach (var t in v4)
            {
                if (!IsValid(t)) return "Neither";
            }

            return "IPv4";
        }

        if (v6.Length == 8)
        {
            foreach (var t in v6)
            {
                if (t.Length == 0 && t.Length > 4) return "Neither";

                foreach (var c in t)
                {
                    if (!(char.IsDigit(c) || char.IsLetter(c) && char.ToLower(c) - 'a' < 6)) return "Neither";
                }
            }

            return "IPv6";
        }

        return "Neither";
    }


    private bool IsValid(string num)
    {
        if (num.Length > 1 && num[0] == '0') return false;
        if (num.Length == 00 || num.Length > 3) return false;
        int val = int.Parse(num);
        return val >= 0 && val <= 255;
    }

    public bool IncreasingTriplet(int[] nums)
    {
        if (nums.Length < 2) return false;

        for (int i = 0; i < nums.Length - 2; i++)
        {
            int n1 = nums[i];
            int n2 = nums[i + 1];
            int n3 = nums[i + 2];
            if (n1 < n2 && n2 < n3) return true;
        }

        return false;
    }

    public int EraseOverlapIntervals(int[][] intervals)
    {
        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));
        int count = 0;

        for (int i = 0; i < intervals.Length; i++)
        {
            if (intervals[i][1] < intervals[i + 1][0])
            {
                intervals[i + 1][1] = Math.Min(intervals[i][1], intervals[i + 1][1]);
                count++;
            }
        }

        return count;
    }

    public string MinWindow(string s, string t)
    {
        if (t == "") return "";

        int need = t.Length;

        var tMap = new Dictionary<char, int>();
        int maxL = int.MaxValue;

        foreach (var c in t)
        {
            if (!tMap.ContainsKey(c))
            {
                tMap[c] = 0;
            }

            tMap[c]++;
        }

        var res = new int[] { -1, -1 };


        for (int i = 0; i < s.Length; i++)
        {
            var sMap = new Dictionary<char, int>();

            for (int j = i; j < s.Length; j++)
            {
                if (!sMap.ContainsKey(s[j]))
                {
                    sMap[s[j]] = 0;
                }

                sMap[s[j]]++;

                bool flag = true;

                foreach (var c in tMap.Keys)
                {
                    if (!sMap.ContainsKey(c) || sMap[c] < tMap[c])
                    {
                        flag = false;
                        break;
                    }
                }

                if (flag && (j - i + 1) < maxL)
                {
                    maxL = (j - i + 1);
                    res[0] = i;
                    res[1] = j;
                }
            }
        }

        return maxL == int.MaxValue ? "" : s.Substring(res[0], maxL);
    }

    public string MinWindow2(string s, string t)
    {
        if (t == "") return "";

        Dictionary<char, int> countT = new Dictionary<char, int>();
        foreach (char c in t)
        {
            if (countT.ContainsKey(c))
            {
                countT[c]++;
            }
            else
            {
                countT[c] = 1;
            }
        }

        int[] res = { -1, -1 };
        int resLen = int.MaxValue;

        for (int i = 0; i < s.Length; i++)
        {
            Dictionary<char, int> countS = new Dictionary<char, int>();
            for (int j = i; j < s.Length; j++)
            {
                if (countS.ContainsKey(s[j]))
                {
                    countS[s[j]]++;
                }
                else
                {
                    countS[s[j]] = 1;
                }

                bool flag = true;
                foreach (var c in countT.Keys)
                {
                    if (!countS.ContainsKey(c) || countS[c] < countT[c])
                    {
                        flag = false;
                        break;
                    }
                }

                if (flag && (j - i + 1) < resLen)
                {
                    resLen = j - i + 1;
                    res[0] = i;
                    res[1] = j;
                }
            }
        }

        return resLen == int.MaxValue ? "" : s.Substring(res[0], resLen);
    }

    public int FirstUniqChar(string s)
    {
        var map = new Dictionary<char, int>();

        foreach (var c in s)
        {
            if (!map.ContainsKey(c))
            {
                map[c] = 0;
            }

            map[c]++;
        }


        for (int i = 0; i < s.Length; i++)
        {
            var c = s[i];
            if (map[c] == 1) return i;
        }

        return -1;
    }

    public int CountSubstrings2(string s)
    {
        int count = 0;

        int n = s.Length;

        for (int mid = 0; mid < n * 2 - 1; mid++)
        {
            int l = mid / 2;
            int r = l + (mid % 2);

            while (l >= 0 && r < n && s[l] == s[r])
            {
                count++;
                l--;
                r++;
            }
        }

        return count;
    }

    public string LargestNumber(int[] nums)
    {
        var numStr = new string[nums.Length];
        for (int i = 0; i < nums.Length; i++)
        {
            numStr[i] = nums[i].ToString();
        }

        var pq = new PriorityQueue<char, char>();


        return String.Concat(numStr);
    }

    public List<int> FindAnagrams23(string s, string p)
    {
        var res = new List<int>();

        if (string.IsNullOrEmpty(s) || p.Length > s.Length) return res;

        int[] count = new int[26];

        foreach (var c in p)
        {
            var i = c - 'a';
            count[i]++;
        }

        int l = 0;
        int maches = p.Length;

        for (int r = 0; r < s.Length; r++)
        {
            int iR = s[r] - 'a';
            count[iR]--;
            if (count[iR] >= 0) maches--;

            while (r - l + 1 > p.Length)
            {
                int idxL = s[l] - 'a';
                if (++count[idxL] > 0) maches++;
                l++;
            }

            if ((r - l + 1 == p.Length) && maches == 0)
            {
                res.Add(l);
            }
        }

        return res;
    }

    public int Compress2(char[] chars)
    {
        var currentC = 1;
        var counter = 1;

        for (int i = 1; i < chars.Length; i++)
        {
            if (chars[i] == chars[i - 1])
            {
                currentC++;
            }
            else
            {
                counter++;
                if (counter > 1)
                {
                    counter += currentC.ToString().Length;
                }

                currentC = 1;
            }
        }

        if (currentC > 1)
        {
            counter += currentC.ToString().Length;
        }

        return counter;
    }

    public int LengthOfLongestSubstr2ing(string s)
    {
        int left = 0;
        var charSet = new HashSet<char>();

        int max = -1;

        for (int i = 0; i < s.Length; i++)
        {
            while (charSet.Contains(s[i]))
            {
                charSet.Remove(s[left]);
                left++;
            }

            charSet.Add(s[i]);
            max = Math.Max(max, charSet.Count);
        }

        return max;
    }

    public int MissingNumber(int[] nums)
    {
        int n = nums.Length;
        int xor = n; // include 'n' from the range [0..n]
        for (int i = 0; i < n; i++)
            xor ^= i ^ nums[i]; // cancel matching indices/values
        return xor; // leftover is the missing number
    }


    public List<int> SubarraySum(int[] arr, int target)
    {
        // Code Here
        var res = new List<int>();
        int n = arr.Length;
        int l = 0;

        int sum = 0;

        for (int i = 0; i < n; i++)
        {
            sum += arr[i];

            while (l <= i && sum > target)
            {
                sum -= arr[l];
                l++;
            }

            if (sum == target)
            {
                return new List<int> { l + 1, i + 1 };
            }
        }

        return new List<int> { -1 };
    }

    // public int MinimumDifference(int[] nums, int k)
    // {
    //     int diff = int.MinValue;
    //     Array.Sort(nums);
    //     int l = 0;
    //
    //     while (l < nums.Length - k - 1)
    //     {
    //     }
    // }

    public int FindLHS(int[] nums)
    {
        var freq = new Dictionary<int, int>();

        foreach (var n in nums)
        {
            if (!freq.ContainsKey(n))
            {
                freq[n] = 0;
            }

            freq[n]++;
        }

        int best = 0;
        foreach (var kvp in freq)
        {
            var k = kvp.Key;

            if (freq.ContainsKey(k + 1))
            {
                best = Math.Max(best, (freq[k] + freq[k + 1]));
            }
        }

        return best;
    }

    public double FindMaxAverage(int[] nums, int k)
    {
        double maxAvg = double.MinValue;

        int currSum = 0;

        for (int end = k; end < nums.Length; end++)
        {
            currSum += nums[end] - nums[end - k];
            if (currSum / k > maxAvg) maxAvg = currSum / k;
        }

        return maxAvg;
    }
    public string ValidIPAddress2(string queryIP) {
        var ip4 = queryIP.Split('.').ToList();
        var ip6 = queryIP.Split(':').ToList();

        if (ip4.Count == 4)
        {
            foreach (var t in ip4)
            {
                if (t.Length > 1 && t[0] == '0') return "Neither";
                if(t.Length == 0 || t.Length > 3) return "Neither";
                if(!int.TryParse(t, out int num) || num <0 || num > 255) return "Neither";
            }

            return "IPv4";
        }

        if (ip6.Count == 6)
        {
            foreach (var t in ip6)
            {
                if(t.Length == 0 || t.Length > 3) return "Neither";

                foreach (var c in t)
                {
                    if(!char.IsDigit(c) || char.IsLetter(c) && char.ToLower(c) -'a' < 6) return "Neither";
                }
            }
            
            return "IPv6";
        }

        return "Neither";
    }
    
}