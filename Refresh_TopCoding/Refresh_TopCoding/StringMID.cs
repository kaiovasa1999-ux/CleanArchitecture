using System.Collections;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;

namespace Refresh_TopCoding;

public class StringMID
{
    public int LengthOfLongestSubstring(string s)
    {
        if (s.Length == 0 || s == null) return 0;
        int max = int.MinValue;
        int current = 0;
        var hSet = new HashSet<char>();

        for (int i = 0; i < s.Length; i++)
        {
            var c = s[i];
            if (hSet.Contains(c))
            {
                hSet.Clear();
                current = 0;
            }

            hSet.Add(c);
            current++;
            if (max < current)
            {
                max = current;
            }
        }

        return max;
    }

    public string IntToRoman(int num)
    {
        int[] values = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
        string[] symbols = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
        var res = new StringBuilder();

        //this is all possible symbols as a roman nums PS (found them on internet).

        //the idea is to append each symbols while num is >= from the current symbols of [i];


        for (int i = 0; i < symbols.Length && num > 0; i++)
        {
            while (num >= values[i])
            {
                num -= values[i];
                res.Append(symbols[i]);
            }
        }

        return res.ToString();
    }

    public string Multiply(string num1, string num2)
    {
        int f1 = 1;
        int f2 = 1;
        long n1 = 0;
        long n2 = 0;
        for (int i = num1.Length - 1; i >= 0; i--)
        {
            int x = Math.Abs(48 - num1[i]) * f1;
            n1 += x;
            f1 *= 10;
        }

        for (int i = num2.Length - 1; i >= 0; i--)
        {
            int y = Math.Abs(48 - num2[i]) * f2;
            n2 += y;
            f2 *= 10;
        }

        return (n1 * n2).ToString();
    }

    public string LargestNumber(int[] nums)
    {
        var res = string.Empty;

        var numbers = new List<int>();

        for (int i = 0; i < nums.Length; i++)
        {
            string num = nums[i].ToString();

            foreach (var n in num)
            {
                numbers.Add(int.Parse(n.ToString()));
            }
        }

        foreach (var x in numbers.OrderByDescending(x => x))
        {
            res += x.ToString();
        }

        // if(res[0] == '0') return 0;

        return res;
    }

    public int LongestPalindromeSubseq(string s)
    {
        int left = 0;
        int right = s.Length - 1;
        int differances = 0;

        while (left <= right)
        {
            if (s[left] != s[right])
            {
                differances++;
            }
            else if (s[left + 1] == s[right])
            {
                left++;
            }
            else if (s[left] == s[right - 1])
            {
                right--;
            }

            left++;
            right--;
        }

        return s.Length - differances;
    }

    // public int CharacterReplacement(string s, int k)
    // {
    //     int max = 0;
    //
    //     for (int i = 0; i < s.Length; i++)
    //     {
    //         char c = s[i];
    //         int count = 1;
    //         int diffs = 0;
    //         int j = i;
    //         while (true)
    //         {
    //             if (j + 1 < s.Length)
    //             {
    //                 var nextChar = s[j + 1];
    //                 if (nextChar == c) count++;
    //                 if (c != nextChar)
    //                 {
    //                     diffs++;
    //                     count++;
    //                 }
    //
    //                 if (diffs > k)
    //                 {
    //                     if (max < count - 1) max = count - 1;
    //                     break;
    //                 }
    //             }
    //             else
    //             {
    //                 break;
    //             }
    //
    //             if (max < count) max = count;
    //
    //             j++;
    //         }
    //     }
    //
    //     return max;
    // }


    public int Calculate(string s)
    {
        var stack = new Stack<int>();
        var prev = '+';
        var num = 0;

        for (int i = 0; i < s.Length; i++)
        {
            if (char.IsDigit(s[i]))
            {
                num = num * 10 + (s[i] - '0');
            }

            if ((!char.IsDigit(s[i]) && s[i] != ' ') || i == s.Length - 1)
            {
                if (prev == '*')
                {
                    stack.Push(stack.Pop() * num);
                }
                else if (prev == '/')
                {
                    stack.Push(stack.Pop() / num);
                }
                else if (prev == '+')
                {
                    stack.Push(num);
                }
                else if (prev == '-')
                {
                    stack.Push(-num);
                }

                prev = s[i];
                num = 0;
            }
        }

        return stack.Sum();
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

        if (k > 0) res.Length = Math.Max(0, res.Length - k);

        return res.Length == 0 ? "0" : res.ToString();
    }

    public List<int> FindAnagrams(string s, string p)
    {
        var res = new List<int>();
        int left = 0;
        int right = p.Length - 1;
        var pMap = new Dictionary<char, int>();
        foreach (var c in p)
        {
            if (!pMap.ContainsKey(c))
            {
                pMap[c] = 0;
            }

            pMap[c]++;
        }

        while (right <= s.Length && left + p.Length <= s.Length)
        {
            var idx = 0;
            var monitorData = new Dictionary<char, int>();
            for (int i = 0; i < p.Length; i++)
            {
                var c = s[i + left];
                if (!monitorData.ContainsKey(c))
                {
                    monitorData[c] = 0;
                }

                monitorData[c]++;
            }

            foreach (var kvp in monitorData)
            {
                var c = kvp.Key;
                if (!pMap.ContainsKey(c) || pMap[c] != kvp.Value)
                {
                    break;
                }

                if (pMap[c] == kvp.Value)
                {
                    idx += kvp.Value;
                }

                if (idx == p.Length)
                {
                    res.Add(left);
                }
            }

            monitorData.Clear();
            left++;
            right++;
        }

        return res;
    }

    public int Compress(char[] chars)
    {
        int currentC = 1;
        int counter = 1;
        for (int i = 1; i < chars.Length; i++)
        {
            if (chars[i] == chars[i - 1])
            {
                currentC++;
            }
            else
            {
                counter++;
                if (currentC > 1)
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

    public string ValidIPAddress2(string queryIP)
    {
        string[] ip4Data = queryIP.Split('.');
        string[] iP6Data = queryIP.Split(':');
        if (ip4Data.Length == 4)
        {
            foreach (var token in ip4Data)
            {
                if (token.Length == 0 || token.Length > 3 ||
                    (token.Length > 1 && token[0] == '0' ||
                     !int.TryParse(token, out int num) ||
                     num <= 0 || num >= 255))
                {
                    return "Neither";
                }

                return "IPv4";
            }
        }

        if (iP6Data.Length == 6)
        {
            foreach (var token in iP6Data)
            {
                if (token.Length == 0 || token.Length > 4)
                {
                    return "Neither";
                }

                foreach (var c in token)
                {
                    if (!(char.IsDigit(c) || char.IsLetter(c) && char.ToLower(c) - 'a' < 6))
                    {
                        return "Neither";
                    }
                }
            }

            return "IPv6";
        }

        return "Neither";
    }

    public string FindLongestWord(string s, IList<string> dictionary)
    {
        var best = "";

        foreach (var word in dictionary)
        {
            if (word.Length > best.Length || (word.Length == best.Length && string.Compare(word, best) < 0))
            {
                int i = 0, j = 0;
                while (i < s.Length && j < word.Length)
                {
                    if (s[i] == word[j])
                    {
                        j++;
                    }

                    i++;
                }

                if (j == word.Length)
                {
                    best = word;
                }
            }
        }

        return best;
    }

    public bool CheckInclusion(string s1, string s2)
    {
        var freq = new Dictionary<char, int>();

        foreach (var c in s1)
        {
            freq[c] = freq.GetValueOrDefault(c) + 1;
        }

        var map = new Dictionary<char, int>();
        int left = 0;
        for (int right = 0; right < s2.Length; right++)
        {
            var c = s2[right];
            map[c] = map.GetValueOrDefault(c) + 1;
            if (right - left + 1 > s1.Length)
            {
                map[s2[left]]--;
                if (map[s2[left]] <= 0) map.Remove(s2[left]);
                left++;
            }


            if (map.Count == freq.Count)
            {
                bool isValid = true;
                foreach (var kvp in map)
                {
                    if (freq.GetValueOrDefault(kvp.Key) != kvp.Value)
                    {
                        isValid = false;
                        break;
                    }
                }

                if (isValid)
                {
                    return true;
                }
            }
        }


        return false;
    }

    public int CountSubstrings(string s)
    {
        if (string.IsNullOrEmpty(s)) return 0;

        int n = s.Length;
        int count = 0;

        for (int midPoint = 0; midPoint < 2 * n - 1; midPoint++)
        {
            int left = midPoint / 2;
            int right = left + (midPoint % 2);

            while (left >= 0 && right < n && s[left] == s[right])
            {
                count++;
                left--;
                right++;
            }
        }

        return count;
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
                h--;
            }
        }

        if (h < 0) return false;

        return count == 0;
    }

    public int UnlockLock(string target, List<string> deadEnds)
    {
        if (deadEnds.Contains("0000")) return -1;

        var q = new Queue<(string, int)>();
        var visited = new HashSet<string>();
        q.Enqueue(("0000", 0));

        while (q.Count > 0)
        {
            var (lok, turn) = q.Dequeue();
            if (lok == target) return turn;

            foreach (var child in Children(lok))
            {
                if (!visited.Contains(child))
                {
                    visited.Add(child);
                    q.Enqueue((child, turn + 1));
                }
            }
        }

        return -1;
    }

    private List<string> Children(string lok)
    {
        var res = new List<string>();

        for (int i = 0; i < 4; i++)
        {
            var digit = ((lok[i] - '0') + 10) % 10;
            res[i] = digit.ToString();
            var next = lok.Substring(0, i) + digit + lok.Substring(i + 1);
        }

        return res;
    }

    public List<List<string>> AccountsMerge(List<List<string>> accounts)
    {
        var emailToName = new Dictionary<string, string>();
        var graph = new Dictionary<string, HashSet<string>>(StringComparer.Ordinal);

        foreach (var acc in accounts)
        {
            var name = acc[0];

            for (int i = 1; i < acc.Count; i++)
            {
                string email = acc[i];
                if (!graph.ContainsKey(email))
                {
                    graph[email] = new HashSet<string>(StringComparer.Ordinal);
                }

                emailToName[email] = name;
            }

            for (int i = 2; i < acc.Count; i++)
            {
                string a = acc[1];
                string b = acc[i];
                graph[a].Add(b);
                graph[b].Add(a);
            }
        }

        var res = new List<List<string>>();
        var visited = new HashSet<string>(StringComparer.Ordinal);

        foreach (var start in graph.Keys)
        {
            if (visited.Contains(start)) continue;

            var q = new Queue<string>();
            var compoent = new List<string>();

            q.Enqueue(start);
            visited.Add(start);

            while (q.Count > 0)
            {
                var current = q.Dequeue();
                compoent.Add(current);

                foreach (var child in Children(current))
                {
                    if (!visited.Contains(child))
                    {
                        visited.Add(child);
                        q.Enqueue(child);
                    }
                }
            }

            compoent.Sort(StringComparer.Ordinal);
            compoent.Insert(0, emailToName[start]);
            res.Add(compoent);
        }

        return res;
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

    public int MinimumLengthEncoding(string[] words)
    {
        var good = new HashSet<string>(words);

        foreach (var word in words)
        {
            for (int i = 0; i < word.Length; i++)
            {
                good.Remove(word.Substring(i));
            }
        }

        return good.Sum(w => w.Length + 1);
    }

    public string FindReplaceString(string s, int[] indices, string[] sources, string[] targets)
    {
        int k = indices.Length;
        int total = 0;
        for (int i = 0; i < k; i++)
        {
            var src = sources[i];
            var index = indices[i] - total;
            var target = targets[i];

            if (s.Substring(index, src.Length) == src)
            {
                s = s.Substring(0, index) + target + s.Substring(index + src.Length);

                total += src.Length - target.Length;
            }
        }

        return s;
    }

    public int EqualSubstring(string s, string t, int maxCost)
    {
        int currCost = 0;
        int maxL = 0;
        int j = 0;
        for (int i = 0; i < s.Length; i++)
        {
            currCost += Math.Abs(s[i] - t[i]);

            while (currCost > maxCost)
            {
                currCost -= Math.Abs(s[j] - t[j]);
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

    public int MinAddToMakeValid(string s)
    {
        if (s == string.Empty) return 0;

        var open = 0;
        var close = 0;

        foreach (var c in s)
        {
            if (c == '(') open++;
            else
            {
                if (close > 0) close--;
                else close++;
            }
        }

        return open + close;
    }

    // public List<List<string>> SuggestedProducts(string[] products, string searchWord)
    // {
    //     Array.Sort(products);
    //     var res = new List<List<string>>();
    //     var searchKes = new List<string>();
    //
    //     var k = string.Empty;
    //     foreach (var c in searchWord)
    //     {
    //         k += c.ToString();
    //         searchKes.Add(k);
    //     }
    //
    //     int index = 0;
    //     int count = 1;
    //     foreach (var p in products)
    //     {
    //         var list = new List<string>();
    //         var key = searchKes[index];
    //         if (p.Contains(key) && count <= 3)
    //         {
    //             list.Add(p);
    //             count++;
    //         }
    //
    //         if (count > 3)
    //         {
    //             res.Add(list);
    //             count = 1;
    //             break;
    //         }
    //     }
    //
    //     return res;
    // }

    public int CountHomogenous(string s)
    {
        var ans = 0;
        var currentStreak = 0;

        int MOD = 10 ^ 9 + 7;

        for (int i = 0; i < s.Length; i++)
        {
            if (i == 0 || s[i] == s[i - 1])
            {
                currentStreak++;
            }
            else
            {
                currentStreak = 1;
            }

            ans = (ans + currentStreak) % MOD;
        }

        return ans;
    }

    public List<string> RestoreIpAddresses(string s)
    {
        var list = new List<string>();
        var n = s.Length;

        for (int i = 1; i <= 3; i++)
        {
            var n1 = s.Substring(0, 1);
            if (!IsValid(n1))
            {
                continue;
            }

            for (int j = i + 1; j <= i + 3 && j < n; j++)
            {
                var n2 = s.Substring(i, j - i);

                if (!IsValid(n2))
                {
                    continue;
                }

                for (int k = j + 1; k <= j + 3 && k < n; k++)
                {
                    var n3 = s.Substring(j, k - j);
                    var n4 = s.Substring(k);

                    if (IsValid(n3) && IsValid(n4))
                    {
                        list.Add($"{n1}.{n2}.{n3}.{n4}");
                    }
                }
            }
        }

        return list;
    }

    public bool IsInterleave(string s1, string s2, string s3)
    {
        if ((s1.Length + s2.Length) != s3.Length) return false;
        int m = s1.Length;
        int n = s2.Length;
        var dp = new bool[m + 1, n + 1];
        dp[m, n] = true;

        for (int i = m; i >= 0; i--)
        {
            for (int j = n; j >= 0; j--)
            {
                if (i < s1.Length && s3[i + j] == s1[i])
                {
                    dp[i, j] = dp[i + 1, j];
                }

                if (!dp[i, j] && j < s2.Length && s3[i + j] == s2[j])
                {
                    dp[i, j] = dp[i, j + 1];
                }
            }
        }

        return dp[0, 0];
    }

    public int FibTabulationDP(int n)
    {
        if (n <= 1) return n;
        int[] dp = new int[n + 1];
        dp[0] = 0;
        dp[1] = 1;

        for (int i = 2; i <= n; i++)
        {
            dp[i] = dp[i - 1] + dp[i - 2];
        }

        return dp[n];
    }

    public int UniquePaths(int m, int n)
    {
        int[,] dp = new int[m, n];
        for (int i = 0; i < m; i++) dp[i, 0] = 1;
        for (int i = 1; i < n; i++) dp[0, i] = 1;

        for (int i = 1; i < m; i++)
        {
            for (int j = 1; j < n; j++)
            {
                dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
            }
        }

        return dp[m - 1, n - 1];
    }

    public int LongestCommonSubsequence(string text1, string text2)
    {
        int m = text1.Length;
        int n = text2.Length;
        int[,] dp = new int[m + 1, n + 1]; // Create a DP table with extra row and column for the base case

        // Fill the DP table
        for (int i = 1; i <= m; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                if (text1[i - 1] == text2[j - 1]) // If characters match, add 1 to the previous diagonal value
                {
                    dp[i, j] = dp[i - 1, j - 1] + 1;
                }
                else // If not, take the maximum value from either the previous row or column
                {
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                }
            }
        }

        // The final answer is stored in dp[m, n], representing the longest common subsequence
        return dp[m, n];
    }

    public int CountChange(int[] coins, int amount)
    {
        int[] dp = new int[amount + 1];
        Array.Fill(dp, amount + 1);
        dp[0] = 0;

        for (int i = 1; i <= amount; i++)
        {
            foreach (var c in coins)
            {
                if (c <= i)
                {
                    dp[i] = Math.Min(dp[i], dp[i - c] + 1);
                }
            }
        }

        return dp[amount] > amount ? -1 : dp[amount];
    }

    // public int FibMemo(int n,int[] memo)
    // {
    //     int res = 0;
    //     if(memo[n] != null) return memo[n];
    //
    //     if (n == 1 || n == 2) return n;
    //     else
    //     {
    //         res = FibMemo(n-1,memo);
    //     }
    // }

    // public string Multiply2(string num1, string num2)
    // {
    //     if (num1 == "0" || num2 == "0") return "0";
    //
    //     int[] res = new int[num1.Length + num2.Length];
    //
    //     for (int i = num1.Length; i >= 0; i--)
    //     {
    //         int d1 = num1[i] - '0';
    //         for (int j = num2.Length; j >= 0; j--)
    //         {
    //             int d2 = num2[j] - '0';
    //             int prod = d1 * d2;
    //             var sum = res[i + j + 1] + prod;
    //             res[i + j + 1] = sum % 10;
    //             res[i + j] += sum / 10;
    //         }
    //     }
    //
    //     var sb = new StringBuilder();
    //     int idx = 0;
    //
    //     while (idx < res.Length && res[idx] == 0)
    //     {
    //         idx++;
    //     }
    //
    //     for (; idx < res.Length; idx++)
    //     {
    //         sb.Append((char)('0' + res[idx]));
    //     }
    //
    //     return sb.ToString();
    // }

    // public string PushDominoes(string dominoes) 
    // {
    //     var result = new char[dominoes.Length];
    //
    //     var positions = new List<int> {-1};
    //     var forces = new List<char> {'L'};
    //
    //
    //     for(int i = 0; i< dominoes.Length; i++){
    //         result[i] = dominoes[i];
    //         
    //         if (dominoes[i] == 'L' || dominoes[i] == 'R')
    //         {
    //             positions.Add(i);
    //             forces.Add(dominoes[i]);
    //         }
    //     }
    //     positions.Add(dominoes.Length);
    //     forces.Add('R');
    //
    //     for(int i = 1; i< positions.Count; i++){
    //         var leftForce = forces[i-1];
    //         var rightForce = forces[i];
    //         var leftIndex = positions[i-1];
    //         var rightIndex = positions[i];
    //         if(forces[i] == forces[i-1]){
    //             for(int j = leftIndex+1; j < rightIndex; j++ ){
    //                 result[j] =forces[i];
    //             }
    //         } else if(leftForce == 'R' && rightForce == 'L'){
    //             while(leftIndex < rightIndex){
    //                 result[leftIndex++] = leftForce;
    //                 result[rightIndex--] = rightForce;
    //             }
    //         }
    //     }
    //
    //     return new string(result);
    // }

    public string PushDominoes(string dominoes)
    {
        var res = new char[dominoes.Length];
        var positions = new List<int> { -1 };
        var pushes = new List<char> { 'L' };

        for (int i = 0; i < dominoes.Length; i++)
        {
            if (dominoes[i] == 'L' || dominoes[i] == 'R')
            {
                positions.Add(i);
                pushes.Add(dominoes[i]);
            }
        }

        positions.Add(dominoes.Length);
        pushes.Add('R');

        for (int i = 1; i < positions.Count; i++)
        {
            var leftPush = pushes[i - 1];
            var rightPush = pushes[i];
            var leftI = positions[i - 1];
            var rightI = positions[i];

            if (leftPush == rightPush)
            {
                for (int j = leftI + 1; j < rightI; j++)
                {
                    res[j] = pushes[i];
                }
            }
            else if (leftPush == 'R' && rightPush == 'L')
            {
                while (leftI < rightI)
                {
                    res[leftI++] = leftPush;
                    res[rightI++] = rightPush;
                }
            }
        }

        return new string(res);
    }

    public List<string> RestoreIpAddresses2(string s)
    {
        var res = new List<string>();
        var n = s.Length;

        for (int i = 1; i <= 3; i++)
        {
            var n1 = s.Substring(0, i);
            if (!IsValid(n1)) continue;

            for (int j = i + 1; j <= i + 3; j++)
            {
                var n2 = s.Substring(i, j - i);
                if (!IsValid(n2)) continue;

                for (int k = j + 1; k <= j + 3 && k < n; k++)
                {
                    var n3 = s.Substring(j, k - j);
                    var n4 = s.Substring(k);
                    if (IsValid(n3) && IsValid(n4))
                    {
                        res.Add($"{n1}.{n2}.{n3}.{n4}");
                    }
                }
            }
        }

        return res;
    }

    private bool IsValid(string num)
    {
        if (num.Length == 0 || num.Length > 3) return false;

        if (num.Length > 1 && num[0] == '0') return false;
        int val = int.Parse(num);

        return val >= 0 && val <= 255;
    }


    // public int MinDistance(string word1, string word2)
    // {
    //     var m = word1.Length;
    //     var n = word2.Length;
    //     var memo = new int?[m + 1, n + 1];
    //
    //     return Recursion(word1, word2, memo, m, n, 0, 0);
    // }
    //
    // public int Recursion(string word1, string word2, int?[,] memo, int m, int n, int i, int j)
    // {
    //     if (i == m) return n - j;
    //     if (j == n) return m - i;
    //
    //     if (!memo[i, j].HasValue)
    //     {
    //         if (word1[i] == word2[j])
    //         {
    //             memo[i, j] = Recursion(word1, word2, memo, m, n, i + 1, j + 1);
    //         }
    //         else
    //         {
    //             memo[i, j] = 1 + Math.Min(Math.Min(Recursion(word1, word2, memo, m, n, i + 1, j),
    //                     Recursion(word1, word2, memo, m, n, i, j + 1)),
    //                 Recursion(word1, word2, memo, m, n, i + 1, j + 1));
    //         }
    //     }
    //
    //     return memo[i, j].Value;
    // }

    public int LongestSubstring(string s, int k)
    {
        if (s.Length < k) return 0;

        int l = 0;
        int r = k;
        var text = "";
        var map = new Dictionary<char, int>();
        int max = -1;

        while (r <= s.Length)
        {
            var currentMax = 0;
            text = s.Substring(l, k);
            foreach (var c in text)
            {
                if (!map.ContainsKey(c))
                {
                    map[c] = 0;
                }

                map[c]++;
            }

            foreach (var kvp in map)
            {
                var v = kvp.Value;
                if (v >= k)
                {
                    currentMax += v;
                }
            }

            map.Clear();
            if (currentMax > max)
            {
                max = currentMax;
            }

            l++;
            r++;
        }

        return max;
    }

    // public int LongestSubstring(string s, int k)
    // {
    //     if (string.IsNullOrEmpty(s) || k <= 0) return 0;
    //     return Helper(s, 0, s.Length, k);
    // }

    private int Helper(string s, int start, int end, int k)
    {
        if (end - start < k) return 0;

        var map = new Dictionary<char, int>();
        for (int i = start; i < end; i++)
        {
            char c = s[i];
            map[c] = map.ContainsKey(c) ? map[c] + 1 : 1;
        }

        for (int i = start; i < end; i++)
        {
            if (map[s[i]] < k)
            {
                int left = Helper(s, start, i, k);
                int right = Helper(s, i + 1, end, k);
                return Math.Max(left, right);
            }
        }

        return end - start;
    }

    public string ComplexNumberMultiply(string num1, string num2)
    {
        var num1Parts = num1.Split('+');
        int a = int.Parse(num1Parts[0]);
        int b = int.Parse(num1Parts[1].Substring(0, num1Parts[1].Length - 1));
        var num2Parts = num2.Split('+');
        int c = int.Parse(num2Parts[0]);
        int d = int.Parse(num2Parts[1].Substring(0, num2Parts[1].Length - 1));

        var real = a * c - b * d;
        var imag = a * d + b * c;

        return $"{real}+{imag}i";
    }

    public int NumDecodings(string s)
    {
        if (string.IsNullOrEmpty(s) || s[0] == '0') return 0;

        int prev2 = 1; // empty prefix has 1 way
        int prev1 = 1; // first char is non-zero, so 1 way

        for (int i = 1; i < s.Length; i++)
        {
            int curr = 0;

            // One-digit decode (s[i] as a single letter)
            if (s[i] != '0')
                curr += prev1;

            // Two-digit decode (s[i-1]s[i] as a pair)
            int two = (s[i - 1] - '0') * 10 + (s[i] - '0');
            if (two >= 10 && two <= 26)
                curr += prev2;

            // If curr stays 0, no valid decoding continues from here
            if (curr == 0) return 0;

            prev2 = prev1;
            prev1 = curr;
        }

        return prev1;
    }

    public int CharacterReplacement(string s, int k)
    {
        var count = new int[26];
        var maxCount = 0;
        var maxLen = 0;
        var l = 0;

        for (int r = 0; r < s.Length; r++)
        {
            int idxR = s[r] - 'A';
            count[idxR]++;
            maxCount = Math.Max(maxCount, count[idxR]);

            while ((r - l + 1) - maxCount > k)
            {
                int idxL = s[l] - 'A';
                count[idxL]--;
                l++;
            }

            maxLen = Math.Max(maxLen, r - l + 1);
        }

        return maxLen;
    }

    // public int CharacterReplacement(string s, int k) {
    //     var count = new int[26];
    //     var maxCount =0;
    //     var maxL = 0;
    //     int l =0;
    //
    //     for(int r =0; r < s.Length;r++){
    //         int idxR = s[r] -'A';
    //         count[idxR]++;
    //         maxCount = Math.Max(maxCount,count[idxR]);
    //
    //         while((r-l+1) - maxCount > k){
    //             int idxL = s[l] -'A';
    //             count[idxL]--;
    //             l--;
    //         }
    //         maxL = Math.Max(maxL,r-l+1);
    //     }
    //
    //     return maxL;
    // }

    public string ValidIPAddress(string queryIP)
    {
        var ip4 = queryIP.Split('.');
        var ip6 = queryIP.Split(':');
        if (ip4.Length == 4)
        {
            foreach (var tok in ip4)
            {
                if (tok.Length == 0 || tok.Length > 3
                                    || (tok.Length > 1 && tok[0] == '0')
                                    || !int.TryParse(tok, out int num) || num < 0 || num > 255)
                {
                    return "Neither";
                }
            }

            return "IPv4";
        }

        if (ip6.Length == 8)
        {
            foreach (var tok in ip6)
            {
                if (tok.Length == 0 || tok.Length > 4)
                {
                    return "Neither";
                }

                foreach (var ch in tok)
                {
                    if (!(char.IsDigit(ch) || char.IsLetter(ch) && char.ToLower(ch) - 'a' < 6))
                    {
                        return "Neither";
                    }
                }
            }

            return "IPv6";
        }

        return "Neither";
    }

    public string SortVowels(string s)
    {
        var vols = new HashSet<char>("aeiouAEIOU");

        var arr = s.ToCharArray();

        var pq = new PriorityQueue<char, int>();

        for (int i = 0; i < arr.Length; i++)
        {
            if (vols.Contains(arr[i]))
            {
                pq.Enqueue(arr[i], (arr[i] - 'a'));
                arr[i] = '*';
            }
        }

        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == '*')
            {
                arr[i] = pq.Dequeue();
            }
        }

        return new string(arr);
    }

    public string[] ReorderLogFiles(string[] logs)
    {
        var letters = new Dictionary<string, string>();
        var digits = new List<string>();

        foreach (var log in logs)
        {
            var idx = 0;
            while (log[idx] != ' ')
            {
                idx++;
            }

            var id = log.Substring(0, idx);
            var str = log.Substring(idx + 1);

            if (char.IsLetter(str[0]))
            {
                letters.Add(id, str);
            }
            else
            {
                digits.Add(log);
            }
        }

        var lettersData =
            letters.OrderBy(x => x.Value)
                .ThenBy(x => x.Key)
                .Select(x => $"{x.Key} {x.Value}").ToArray();

        var res = new string[digits.Count + lettersData.Length];

        for (int i = 0; i < lettersData.Length; i++)
        {
            res[i] = lettersData[i];
        }

        for (int i = 0; i < digits.Count; i++)
        {
            res[lettersData.Length + 1] = digits[i];
        }

        return res;
    }

    public List<List<string>> SuggestedProducts(string[] products, string searchWord)
    {
        Array.Sort(products);

        int n = products.Length;
        var start = 0;
        var end = n - 1;

        var res = new List<List<string>>();

        for (int i = 0; i < searchWord.Length; i++)
        {
            var c = searchWord[i];

            while (start <= end && (products[start].Length <= i || products[start][i] < c))
            {
                start++;
            }

            while (start <= end && products[end].Length <= i || products[end][i] > c)
            {
                end--;
            }

            var finds = new List<string>();

            for (int k = 0; k < 3 && start + k <= end; k++)
            {
                finds.Add(products[start + k]);
            }

            res.Add(finds);
        }

        return res;
    }

    public int LongestPalindromeSubseq2(string s)
    {
        var dp = new int[s.Length, s.Length];

        for (int i = 0; i < s.Length; i++)
        {
            dp[i, i] = 1;
        }

        for (int i = s.Length - 1; i >= 0; i--)
        {
            for (int j = i + 1; j < s.Length; j++)
            {
                if (s[i] == s[j])
                {
                    dp[i, j] = dp[i + 1, j - 1];
                }
                else
                {
                    dp[i, j] = Math.Max(dp[i + 1, j], dp[i, j - 1]);
                }
            }
        }

        return dp[0, s.Length - 1];
    }

    public string ReplaceWords(IList<string> dictionary, string sentence)
    {
        var res = new StringBuilder();
        var map = new HashSet<string>(dictionary);
        var replace = false;
        string current = "*";

        foreach (var c in sentence)
        {
            if (c == ' ')
            {
                replace = false;
                res.Append(current + " ");
                current = "";
            }
            else
            {
                if (replace) continue;

                current += c;

                if (map.Contains(current))
                {
                    replace = true;
                }
            }
        }

        res.Append(current);

        return res.ToString();
    }

    public int RepeatedStringMatch(string a, string b)
    {
        var min = (a.Length - 1 + b.Length) / a.Length;

        var sb = new StringBuilder();

        for (int i = 0; i < min * 2; i++)
        {
            sb.Append(a);
            if (sb.ToString().IndexOf(b) > -1) return i + 1;
        }

        return -1;
    }

    public string Multiply2(string num1, string num2)
    {  if(num1 == "0" || num2 == "0"){
            return "0";
        }

        int[] res = new int[num1.Length + num2.Length];

        for(int i = num1.Length-1; i >=0; i--){
            int d1 = num1[i] -'0';
            for(int j = num2.Length-1; j>=0; j--){
                int d2 = num2[j]-'0';

                int prod = d1*d2;
                var sum = res[i+j+1] + prod;

                res[i+j+1] = sum % 10;
                
                res[i+j] += sum / 10;
            }
        }

        return "";
    }
    
    public int AmountOfTime(TreeNode root, int start) {
        if(root == null) return 0;
        if(root.left == null && root.right == null) return 0;
        var q =new Queue<TreeNode>();
        q.Enqueue(root);

        var graph = new Dictionary<int,List<int>>(); 

        while(q.Count >0)
        {
            var node = q.Dequeue();
            if(node.left != null){
                q.Enqueue(node.left);
                graph[node.left.val] = new List<int>();
                graph[node.left.val].Add(node.val);
                graph[node.val].Add(node.left.val);
            }
            if(node.right != null){
                q.Enqueue(node.right);
                graph[node.right.val] = new List<int>();
                graph[node.right.val].Add(node.val);
                graph[node.val].Add(node.left.val);
            }
        }

        int min = 0;
        var infected = new Queue<int>();
        var visited = new HashSet<int>();
        infected.Enqueue(start);
        visited.Add(start);

        while(infected.Count >0){
            var size = infected.Count;

            for(int i =0; i <size;i++){
                var infectedNode = infected.Dequeue();
                foreach(var nei in graph[infectedNode]){
                    if(visited.Add(nei)){
                        infected.Enqueue(nei);
                    }
                }
            }
            if(infected.Count >0) min++;
        }
        return min;
    }
}