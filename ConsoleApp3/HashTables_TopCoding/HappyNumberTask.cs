namespace HashTables_TopCoding;

public class HappyNumberTask
{
    private int res = 0;
    public bool IsHappy(int n) {
        var strNum = n.ToString();
       var x = Calculate(strNum);
        
        if(x == 1) return true;

        return false;
    }

    private int Calculate(string num)
    {

        res = 0;
        foreach(var c in num){
            int n = int.Parse(c.ToString());
            int sumPowerOfN = n*n;
            res += sumPowerOfN;
        }

        var sum = 0;
        foreach (var c in res.ToString())
        {
            var n = int.Parse(c.ToString());
            sum += n;
        }
        if(sum == 1){
            return 1;
        }
        else{
            return Calculate(res.ToString());
        }
    }
}