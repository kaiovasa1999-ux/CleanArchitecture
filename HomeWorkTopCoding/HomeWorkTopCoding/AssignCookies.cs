namespace HomeWorkTopCoding;

public class AssignCookies
{
    public static int FindContentChildren(int[] g, int[] s)
    {
        if (s.Length == 0 || g.Length == 0)
        {
            return 0;
        }
        int cookiesCount = 0;
        int gIndex = 0;
        int sIndex = 0;
        var gSorted = g.OrderBy(x => x).ToList();
        var sSorted = s.OrderBy(x => x).ToList();

        while (true)
        {
            int childGreed = gSorted[gIndex];
            int cookieSize = sSorted[sIndex];
            if (childGreed > cookieSize)
            {
                if (sIndex == s.Length -1)
                {
                    break;
                }
                sIndex++;
            }
            else if (childGreed == cookieSize)
            {
                cookiesCount++;
                if (sIndex == s.Length-1 || gIndex == g.Length-1)
                {
                    break;
                }
                sIndex++;
                gIndex++;
            }
            else
            {
                if (sIndex == s.Length - 1 || gIndex == g.Length - 1)
                {
                    if (gSorted.Count() == 1 && sSorted.Count() == 1)
                    {
                        if (gSorted[0] != sSorted[0])
                        {
                            return 0;
                        }
                    }
                    if(sSorted.Count() == 1)
                    {
                        gIndex++;
                    }
                }
            }
        }
        
        return cookiesCount;
    }
}