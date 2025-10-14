/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public bool IsSubtree(TreeNode root, TreeNode subRoot) {
        if(root == null || subRoot == null){
            return false;
        }

        Queue<(TreeNode root,TreeNode subRoot)> q = new Queue<(TreeNode,TreeNode)>();
        
        q.Enqueue((root,subRoot));
        while (q.Any())
        {
            var (node,subNode) = q.Dequeue();

            if (node == null || subNode == null)
            {
                return false;
            }

        }
        
        
        return false;
    }
}