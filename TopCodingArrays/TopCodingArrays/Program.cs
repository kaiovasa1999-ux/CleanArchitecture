// See https://aka.ms/new-console-template for more information

using System.Security.Cryptography;

string text = "Bob hit a ball, the hit BALL flew far after it was hit.";
string[] arr = new String[] { "hit" };
Console.WriteLine("asdf");
var res = MostCommonWord(text, arr);
Console.WriteLine(res);


string MostCommonWord(string paragraph, string[] banned)
{
    var dict = new Dictionary<string, int>();
    var commonWord = string.Empty;
    var pureWords = paragraph
        .Split(' ')
        .Select(x =>
            new string(x.ToLower()
                .Where(char.IsLetter)
                .ToArray()
            )
        )
        .Where(clean => !string.IsNullOrEmpty(clean))
        .ToList();
    foreach (var word in pureWords)
    {
        if (dict.ContainsKey(word))
        {
            dict[word]++;
            continue;
        }

        dict.Add(word, 1);
    }

    var sortedDict = dict.OrderByDescending(kvp => kvp.Value).ToDictionary();
    foreach (var word in banned)
    {
        if (sortedDict.ContainsKey(word))
        {
            sortedDict.Remove(word);
            continue;
        }
    }

    commonWord = sortedDict.FirstOrDefault().Key;

    return commonWord;
}