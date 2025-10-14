using System.ComponentModel.Design;

namespace HashTables_TopCoding;

public class MajorityElementTask
{
    public int MajorityElement(int[] nums)
    {
        var map = new Dictionary<int, int>();
        foreach (var num in nums)
        {
            if (!map.ContainsKey(num))
            {
                map.Add(num, 1);
            }
            else
            {
                map[num]++;
            }
        }

        var biggest = map.OrderByDescending(x => x.Value).First();
        if (biggest.Value > nums.Length / 2)
        {
            return biggest.Key;
        }
        var res = 0;
        
      
        return res;
    }
}