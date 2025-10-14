namespace HashTables_TopCoding;

public class IsometricStringTask
{
    public bool IsIsomorphic(string s, string t)
    {
        var mapS = new Dictionary<char, int>();
        var mapT = new Dictionary<char, int>();

        for (int i = 0; i < s.Length; i++)
        {
            if (!mapS.ContainsKey(s[i]))
            {
                mapS.Add(s[i], 1);
            }
            else
            {
                mapS[s[i]]++;
            }

            if (!mapT.ContainsKey(t[i]))
            {
                mapT.Add(t[i], 1);
            }
            else
            {
                mapT[t[i]]++;
            }
        }
        
        mapT.OrderBy(x => x.Value);
        mapS.OrderBy(x => x.Value);

        for (var i = 0; i < mapS.Count; i++)
        {
            var sVal = mapS[mapS.Keys.ElementAt(i)];
            var tVal = mapT[mapT.Keys.ElementAt(i)];
            if (sVal != tVal)
            {
                return false;
            }
        }

        return true;
    }
}