using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Refresh_TopCoding;

public class SlidingWIndowTask
{
    public bool IsSubsequence(string s, string t) {
        if(s == null || t == null) return false;
        int sCount = 0;
        int tCount =0;

        while(sCount < s.Length && tCount < t.Length){
            if(s[sCount] == t[tCount]){
                sCount++;
            }
            tCount++;
        }

        return s.Length == sCount;
    }
    
    public int FindContentChildren(int[] g, int[] s) {
        Array.Sort(g);
        Array.Sort(s);


        int count =0;
        int gIndex =0;
        int sIndex =0;

        while(gIndex <g.Length && sIndex < s.Length){
            if(g[gIndex] <= s[sIndex]){
                gIndex++;
            }
            sIndex++;
        }

        return gIndex;
        
        
    }
    
    
    public int[] Decrypt(int[] code, int k) 
    {
        int[] res = new int[code.Length];


        var index = 0;
        for(int i =0; i <code.Length;i++){
            int sum = 0;
            int steps = Math.Abs(k);
            for (int j = 1; j < steps; j++)
            {
                if (k > 0)
                {
                    index = (i+j)%code.Length;
                }
                else
                {
                    index = (i-j +code.Length)%code.Length;
                }
                sum += code[index];
            }
            res[i] = sum;
        }

        return res;
    }
    
    public List<int> InorderTraversal(TreeNode root)
    {
        var res = new List<int>();
        if(root == null) return res;

        var s = new Stack<TreeNode>();
        s.Push(root);

        while(s.Count >0){
            var node = s.Pop();
            res.Add(node.val);
            if(node.left != null){
                s.Push(node.left);
            }
            if(node.right != null){
                s.Push(node.right);
            }
        }

        return res;

    }
}
