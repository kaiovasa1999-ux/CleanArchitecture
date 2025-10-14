// See https://aka.ms/new-console-template for more information

using System.Security.Cryptography;

int[] arr1 = new int[] { 1, 2, 3 };
int[] arr2 = new int[] { 1, 1 };
Console.WriteLine(FindContentChildren(arr1, arr2));

static int FindContentChildren(int[] g, int[] s)
{
    int cookiesCount = 0;
    int gIndex = 0;
    int sIndex = 0;
    g.OrderBy(x => x);
    s.OrderBy(x => x);

    while (gIndex < g.Length || sIndex < s.Length)
    {
        int childGreed = g[gIndex];
        int cookieSize = s[sIndex];
        if (childGreed > cookieSize)
        {
            sIndex++;
            continue;
        }
        else if (childGreed == cookieSize)
        {
            cookiesCount++;
            sIndex++;
            gIndex++;
        }
    }
    return cookiesCount;
}


// string MostCommonWord(string paragraph, string[] banned)
// {
//     var dict = new Dictionary<string, int>();
//     var commonWord = string.Empty;
//     var pureWords = paragraph
//         .Split(' ')
//         .Select(x =>
//             new string(x.ToLower()
//                 .Where(char.IsLetter)
//                 .ToArray()
//             )
//         )
//         .Where(clean => !string.IsNullOrEmpty(clean))
//         .ToList();
//     foreach (var word in pureWords)
//     {
//         if (dict.ContainsKey(word))
//         {
//             dict[word]++;
//             continue;
//         }
//
//         dict.Add(word, 1);
//     }
//
//     var sortedDict = dict.OrderByDescending(kvp => kvp.Value).ToDictionary();
//     foreach (var word in banned)
//     {
//         if (sortedDict.ContainsKey(word))
//         {
//             sortedDict.Remove(word);
//             continue;
//         }
//     }
//
//     commonWord = sortedDict.FirstOrDefault().Key;
//
//     return commonWord;
// }