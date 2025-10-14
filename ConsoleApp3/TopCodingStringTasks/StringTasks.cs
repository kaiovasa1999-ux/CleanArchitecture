namespace TopCodingStringTasks;

public class StringTasks
{
   
    List<List<int>> LargeGroupPositions(string s)
    {
        int counter = 1;
        List<List<int>> coordinates = new();
        for (int i = 0; i < s.Length; i++)
        {
            if (i + 1 < s.Length && s[i] == s[i + 1])
            {
                counter++;
            }
            else
            {
                if (counter >= 3)
                {
                    coordinates.Add(new List<int> { i - counter + 1, i });
                }

                counter = 1;
            }
        }

        return coordinates;
    }

    bool JudgeCircle(string moves)
    {
        int distnaceFromOriginalPoint = 0;

        foreach (char move in moves)
        {
            if (move == 'U')
            {
                distnaceFromOriginalPoint++;
            }
            else if (move == 'D')
            {
                distnaceFromOriginalPoint--;
            }
            else if (move == 'R')
            {
                distnaceFromOriginalPoint++;
            }
            else if (move == 'L')
            {
                distnaceFromOriginalPoint--;
            }
        }

        return distnaceFromOriginalPoint == 0;
    }

    string LargestOddNumber(string num)
    {
        string res = "";

        for (int i = num.Length - 1; i >= 0; i--)
        {
            if (int.Parse(num[i].ToString()) % 2 == 0)
            {
                continue;
            }
            else
            {
                for (int j = 0; j < i + 1; j++)
                {
                    res += num[j];
                }
            }

            break;
        }


        return res;
    }

    string[] FindRestaurant(string[] list1, string[] list2)
    {
        Dictionary<string, int> lib = new();
        foreach (string s in list1)
        {
            if (lib.ContainsKey(s))
            {
                lib[s]++;
                continue;
            }

            lib.Add(s, 1);
        }

        foreach (string s in list2)
        {
            if (lib.ContainsKey(s))
            {
                lib[s]++;
                continue;
            }

            lib.Add(s, 1);
        }

        var res = lib.Where(x => x.Value == 2).Select(x => x.Key).Take(1).ToArray();
        return res;
    }

    string LicenseKeyFormatting(string s, int k)
    {
        string clieanString = string.Empty;
        string result = string.Empty;
        foreach (var c in s)
        {
            if (c != '-')
            {
                clieanString += c;
            }
        }

        int kCounter = k;
        bool isOdd = false;
        if (clieanString.Length % k == 1)
        {
            result += clieanString[0].ToString().ToUpper() + "-";
            isOdd = true;
        }

        int i = 0;
        if (isOdd)
        {
            i = 1;
        }

        while (i < clieanString.Length)
        {
            if (kCounter == 0)
            {
                kCounter = k;
                result += "-";
            }

            result += clieanString[i].ToString().ToUpper();
            kCounter--;
            i++;
        }


        return result;
    }

    int FindLUSlength(string a, string b)
    {
        if (a == b)
        {
            return -1;
        }

        int counter = 0;
        int maxCount = 0;
        int aIndex = 0;
        int bIndex = 0;
        var max = 0;
        while (aIndex < a.Length && bIndex < b.Length)
        {
            if (a[aIndex] != b[bIndex])
            {
                counter++;
                aIndex++;
                bIndex++;
                continue;
            }

            aIndex++;
            bIndex++;
        }

        max = Math.Max(maxCount, counter);
        return max;
    }

    bool ValidPalindrome(string s)
    {
        if (s.Length == 1)
        {
            return true;
        }

        int startIndex = 0;
        int endInedx = s.Length - 1;
        bool alreadyDeletedChars = false;
        while (startIndex < endInedx)
        {
            if (s[startIndex] != s[endInedx])
            {
                if (alreadyDeletedChars)
                    return false;

                alreadyDeletedChars = true;
                if (s[startIndex + 1] == s[endInedx])
                {
                    startIndex++;
                }
                else if (s[startIndex] == s[endInedx - 1])
                {
                    endInedx--;
                }
                else
                {
                    return false;
                }
            }

            startIndex++;
            endInedx--;
        }

        return true;
    }

    string MostCommonWord(string paragraph, string[] banned)
    {
        char[] delimiters = { ' ', '!', '?', '\'', ',', ';', '.' };
        var pargpraList = paragraph.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        var words = new List<string>();
        foreach (var p in pargpraList)
        {
            var word = string.Empty;
            foreach (char c in p)
            {
                if (char.IsLetter(c))
                {
                    c.ToString().ToLower();
                    word += c;
                }
            }

            word.ToLower();
            words.Add(word);
        }

        foreach (var word in banned)
        {
            word.ToLower();
        }

        Dictionary<string, int> wordsCount = new();
        foreach (var word in words)
        {
            var key = word.ToLower();
            if (wordsCount.ContainsKey(key))
            {
                wordsCount[key]++;
                continue;
            }

            wordsCount.Add(key.ToLower(), 1);
        }

        var mostCommonWords = wordsCount.OrderByDescending(x => x.Value).Select(x => x.Key).ToList();

        foreach (var kvp in mostCommonWords)
        {
            if (!banned.Contains(kvp))
            {
                return kvp;
            }
        }

        return "";
    }

    bool RotateString(string s, string goal)
    {
        if (s == goal)
        {
            return true;
        }

        int iterations = 0;
        while (iterations < s.Length)
        {
            if (s != goal)
            {
                s = s.Substring(1) + s[0];
                iterations++;
                if (s == goal)
                    return true;
            }

            if (iterations == s.Length)
                return false;
        }

        return true;
    }

    string ReverseWords(string s)
    {
        List<string> words = new List<string>();
        var res = string.Empty;
        words = s.Split(' ').ToList();

        foreach (var word in words)
        {
            for (int i = word.Length - 1; i >= 0; i--)
            {
                res += word[i];
            }

            res += " ";
        }

        return res;
    }

    int FirstUniqChar(string s)
    {
        Dictionary<char, int> chars = new Dictionary<char, int>();
        int index = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (!chars.ContainsKey(s[i]))
            {
                chars.Add(s[i], 1);
                continue;
            }

            chars[s[i]]++;
        }

        var unique = chars.OrderBy(x => x.Value).Where(x => x.Value == 1).Select(x => x.Key).FirstOrDefault();
        if (unique == 0)
        {
            return -1;
        }

        for (int i = 0; i < s.Length; i++)
        {
            if (unique == s[i])
            {
                return i;
            }
        }

        return -1;
    }

    int CountSeniors(string[] details)
    {
        details.ToList();
        int count = 0;
        var temp = string.Empty;
        var age = 0;
        foreach (var data in details)
        {
            for (int i = 11; i < 13; i++)
            {
                temp += data[i];
            }

            age = int.Parse(temp);
            temp = string.Empty;
            if (age > 60)
            {
                count++;
            }
        }

        return count;
    }

    bool IsAnagram(string s, string t)
    {
        Dictionary<char, int> charsS = new Dictionary<char, int>();
        Dictionary<char, int> charsT = new Dictionary<char, int>();

        foreach (char c in s)
        {
            if (charsS.ContainsKey(c))
            {
                charsS[c]++;
                continue;
            }
            else
            {
                charsS.Add(c, 1);
            }
        }

        foreach (char c in t)
        {
            if (charsT.ContainsKey(c))
            {
                charsT[c]++;
                continue;
            }
            else
            {
                charsT.Add(c, 1);
            }
        }

        for (int k = 0; k < charsS.Count; k++)
        {
            var key = charsS.Keys.ElementAt(k);
            if (charsT.ContainsKey(key))
            {
                if (charsT[key] != charsS[key])
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        return true;
    }

    bool IsSubsequence(string s, string t)
    {
        int sCount = 0;
        int tCount = 0;
        while (sCount < s.Length && tCount < t.Length)
        {
            if (s[sCount] == t[tCount])
            {
                sCount++;
            }

            tCount++;
        }

        return sCount == s.Length;
    }

    bool WordPattern(string pattern, string s)
    {
        var words = s.Split(' ').ToList();
        Dictionary<char, string> map = new();
        if (pattern.Length != words.Count)
        {
            return false;
        }

        for (int i = 0; i < pattern.Length; i++)
        {
            var word = words[i];
            if (map.ContainsKey(pattern[i]))
            {
                var val = map[pattern[i]];

                if (val != word)
                {
                    return false;
                }
            }
            else
            {
                if (map.ContainsValue(word))
                {
                    return false;
                }

                map.Add(pattern[i], word);
            }
        }

        return true;
    }

    int LongestPalindrome(string s)
    {
        if (s.Length == 1)
        {
            return 1;
        }

        if (s is null || s.Length == 0)
        {
            return 0;
        }

        Dictionary<char, int> chars = new Dictionary<char, int>();

        for (int i = 0; i < s.Length; i++)
        {
            if (chars.ContainsKey(s[i]))
            {
                chars[s[i]]++;
            }
            else
            {
                chars.Add(s[i], 1);
            }
        }

        var res = 0;
        var haveOdd = false;
        foreach (var kvp in chars)
        {
            int count = kvp.Value;
            if (count % 2 == 0)
            {
                res += count;
            }
            else
            {
                res += count - 1;
                haveOdd = true;
            }
        }

        if (haveOdd) res += 1;

        return res;
    }

    bool CanConstruct(string ransomNote, string magazine)
    {
        if (ransomNote.Length == 0 && magazine.Length == 0)
        {
            return true;
        }

        Dictionary<char, int> chars = new Dictionary<char, int>();
        Dictionary<char, int> magazineChars = new Dictionary<char, int>();
        var rebuild = string.Empty;
        foreach (var item in ransomNote)
        {
            if (chars.ContainsKey(item))
            {
                chars[item]++;
                continue;
            }

            chars.Add(item, 1);
        }

        foreach (var item in magazine)
        {
            if (magazineChars.ContainsKey(item))
            {
                magazineChars[item]++;
                continue;
            }

            magazineChars.Add(item, 1);
        }

        foreach (var item in chars)
        {
            if (magazineChars.ContainsKey(item.Key))
            {
                // if (magazineChars[item.Key] != item.Value)
                // {
                //     return false;
                // }

                for (int i = 0; i < item.Value; i++)
                {
                    rebuild += item.Key;
                }

                if (rebuild == ransomNote)
                {
                    return true;
                }
            }
        }

        return false;
    }

    int DayOfYear(string date)
    {
        Dictionary<int, int> daysInMonth = new Dictionary<int, int>()
        {
            { 1, 31 },
            { 2, 28 },
            { 3, 31 },
            { 4, 30 },
            { 5, 31 },
            { 6, 30 },
            { 7, 31 },
            { 8, 31 },
            { 9, 30 },
            { 10, 31 },
            { 11, 30 },
            { 12, 31 }
        };
    
        List<string> data = date.Split('-').ToList();
        int year = int.Parse(data[0]);
        int dateMonth = int.Parse(data[1]);
        int days = int.Parse(data[2]);

        if (year % 4 == 0)
        {
            daysInMonth[2] += 1;
        }


        int month = 1;
        int totalDays = 0;
        while (month < dateMonth)
        {
            totalDays += daysInMonth[month];
            month++;
        }

        if (days > 1)
        {
            totalDays += days;
        }

        return totalDays;
    }

    string[] UncommonFromSentences(string s1, string s2)
    {
        var words = s1.Split(' ').ToList();
        List<string> result = new List<string>();
        Dictionary<string, int> allwords = new();

        foreach (string word in words)
        {
            if (allwords.ContainsKey(word))
            {
                allwords[word]++;
                continue;
            }

            allwords[word] = 1;
        }

        var words2 = s2.Split(' ').ToList();
        foreach (string word in words2)
        {
            if (allwords.ContainsKey(word))
            {
                allwords[word]++;
                continue;
            }

            allwords[word] = 1;
        }
        foreach (var kvp in allwords)
        {
            if (kvp.Value == 1)
            {
                result.Add(kvp.Key);
            }
        }

        return result.ToArray();
    }


    string MaximumOddBinaryNumber(string s)
    {
        int zerCount = 0;
        foreach (var c in s)
        {
            if (c == '0')
            {
                zerCount++;
            }
        }
        int onesCount = s.Length - zerCount;



        return new string('1', onesCount - 1) + new string('0', zerCount) + '1';

    }
}