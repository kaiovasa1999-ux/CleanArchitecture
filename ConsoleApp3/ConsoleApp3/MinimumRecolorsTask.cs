using System.Globalization;

namespace ConsoleApp3;

public class MinimumRecolorsTask
{
    public int MinimumRecolors(string blocks, int k)
    {
        
        int minOperations = int.MaxValue;
        int whiteCount = 0;

 
        for (int i = 0; i < k; i++) {
            if (blocks[i] == 'W') whiteCount++;
        }
        minOperations = whiteCount;

        for (int i = k; i < blocks.Length; i++) {
            if (blocks[i - k] == 'W') whiteCount--; 
            if (blocks[i] == 'W') whiteCount++;   

            minOperations = Math.Min(minOperations, whiteCount);
        }

        return minOperations;
    }
}