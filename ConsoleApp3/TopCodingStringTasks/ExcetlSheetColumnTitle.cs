using System.Text;

namespace TopCodingStringTasks;

public class ExcetlSheetColumnTitle
{
    public string ConvertToTitle(int columnNumber)
    {
        Dictionary<char, char> map = new Dictionary<char, char>();
        string res = string.Empty;
        while (columnNumber >0)
        {
            columnNumber--;
            var left = columnNumber % 26;
            char letter = (char)('A' + left);
            res += letter;
            columnNumber /= 26;
        }
        char[] arr = res.ToCharArray();
        Array.Reverse(arr);

        return new string(arr);;
    }
}