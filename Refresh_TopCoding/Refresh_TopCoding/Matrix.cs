namespace Refresh_TopCoding;

public class Matrix
{
    private int rows = 0;
    private int cols = 0;

    int IslandPerimeter(int[][] grid)
    {
        var rows = grid.Length;
        var cols = grid[0].Length;
        var visited = new bool[rows, cols];
        int all = 0;
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (grid[r][c] == 1)
                {
                    return GetBorders(r, c, grid);
                }
            }
        }

        int GetBorders(int r, int c, int[][] grid)
        {
            if (r < 0 || r >= grid.Length || c < 0 || c >= grid[0].Length || grid[r][c] == 0) return 1;

            if (!visited[r, c])
            {
                visited[r, c] = true;
            }

            int res = GetBorders(r + 1, c, grid);
            res += GetBorders(r - 1, c, grid);
            res += GetBorders(r, c + 1, grid);
            res += GetBorders(r, c - 1, grid);
            return res;
        }

        return all;
    }

    int[][] FloodFill(int[][] image, int sr, int sc, int color)
    {
        if (image[sr][sc] == color) return image;
        int[][] nextImage = new int[image.Length][];
        int initialColor = image[sr][sc];

        DFS(sr, sc, image, color, initialColor);

        return image;
    }

    void DFS(int sr, int sc, int[][] image, int nextColor, int startColor)
    {
        if (sr < 0 || sr >= image.Length || sc < 0 || sc >= image[0].Length || image[sr][sc] != startColor) return;

        image[sr][sc] = nextColor;
        DFS(sr + 1, sc, image, nextColor, startColor);
        DFS(sr, sc + 1, image, nextColor, startColor);
        DFS(sr - 1, sc, image, nextColor, startColor);
        DFS(sr, sc - 1, image, nextColor, startColor);
    }

    bool IsToeplitzMatrix(int[][] matrix)
    {
        // for (int r = 0; r < matrix.Length - 1; r++)
        // {
        //     for (int c = 0; c < matrix[0].Length - 1) {
        //         if (matrix[r][c] != matrix[r + 1][c + 1])
        //             return false;
        //     }
        // }

        return true;
    }

    int[][] Transpose(int[][] matrix)
    {
        int rows = matrix.Length;
        int cols = matrix[0].Length;
        var res = new int[cols][];

        for (int c = 0; c < cols; c++)
        {
            res[c] = new int[rows];
            for (int r = 0; r < rows; r++)
            {
                res[c][r] = matrix[r][c];
            }
        }

        return res;
    }

    public int ProjectionArea(int[][] grid)
    {
        int n = grid.Length;
        int top = 0, front = 0, side = 0;

        for (int i = 0; i < n; i++)
        {
            int rowMax = 0;
            for (int j = 0; j < n; j++)
            {
                int h = grid[i][j];
                if (h > 0) top++;
                if (h > rowMax) rowMax = h;
            }

            side += rowMax;
        }

        for (int j = 0; j < n; j++)
        {
            int colMax = 0;
            for (int i = 0; i < n; i++)
            {
                int h = grid[i][j];
                if (h > colMax) colMax = h;
            }

            front += colMax;
        }

        return top + front + side;
    }

    public List<int> LuckyNumbers(int[][] matrix)
    {
        HashSet<int> minNums = new HashSet<int>();
        int[] maxPerColumn = new int[matrix[0].Length];
        for (int row = 0; row < matrix.Length; row++)
        {
            int minRow = 100001;
            for (int col = 0; col < matrix[row].Length; col++)
            {
                minRow = minRow < matrix[row][col] ? minRow : matrix[row][col];

                maxPerColumn[col] = maxPerColumn[col] < matrix[row][col] ? matrix[row][col] : maxPerColumn[col];
            }

            minNums.Add(minRow);
        }

        List<int> luckyNumbers = new List<int>();
        foreach (var i in maxPerColumn)
        {
            if (minNums.Contains(i)) luckyNumbers.Add(i);
        }

        return luckyNumbers;
    }

    public int NumSpecial(int[][] mat)
    {
        rows = mat.Length;
        cols = mat[0].Length;
        int count = 0;

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (mat[r][c] == 1)
                {
                    var rRes = IsOtherOnesAtRow(c, mat);
                    var cRes = IsOtherOnesAtCol(r, mat);

                    if (rRes == true && cRes == true)
                    {
                        count++;
                    }
                }
            }
        }

        return count;
    }

    private bool IsOtherOnesAtRow(int c, int[][] mat)
    {
        int count = 0;
        for (int r = 0; r < rows; r++)
        {
            if (mat[r][c] == 1)
            {
                count++;
            }
        }

        return count == 1;
    }

    private bool IsOtherOnesAtCol(int r, int[][] mat)
    {
        int count = 0;
        for (int c = 0; c < cols; c++)
        {
            if (mat[r][c] == 1)
            {
                count++;
            }
        }

        return count == 1;
    }
    
    public int IslandPerimeter2(int[][] grid) {
        int rows = grid.Length;
        int cols = grid[0].Length;

        var res = 0;

        for(int r = 0; r< rows;r++){
            for(int c =0; c< cols;c++){
                if(grid[r][c] ==1){
                    BackTrack(r,c,grid);
                }
            }
        }
        return res;
    }

    private  int BackTrack(int r, int c, int[][] grid){
        if(r < 0 || r>= grid.Length || c <0 || c>= grid[0].Length || grid[r][c] == 0) return 1;

        grid[r][c] =2;

        int perimeter = BackTrack(r+1,c,grid);
        perimeter +=  BackTrack(r-1,c,grid);
        perimeter +=  BackTrack(r,c+1,grid);
        perimeter +=  BackTrack(r,c-1,grid);

        return perimeter;
    }
    
    public int MinDiffInBST(TreeNode root) {
        if(root == null) return 0;

        var s = new Stack<TreeNode>();
        s.Push(root);
        int min = int.MaxValue;
        int diff = 0;

        while(s.Count >0 ){
            var node = s.Pop();
            if(node.left != null){
                s.Push(node.left);
                diff = Math.Abs(node.left.val - node.val);
                if(min > diff) min = diff;
            }
            if(node.right != null){
                s.Push(node.right);
                diff = Math.Abs(node.right.val - node.val);
                if(min > diff) min = diff;
            }
        }

        return min;
    }
    
    public int SumRootToLeaf(TreeNode root) {
        var paths = new List<string>();
        DFS(root ,paths, string.Empty);

        var sum = 0;

        foreach(var p in paths){
            sum += Convert.ToInt32(p,2);//specficaly for this line I use thise resoruces =>https://stackoverflow.com/questions/1961599/how-to-convert-binary-to-decimal
        }
        return sum;
    }

    private void DFS(TreeNode root,List<string>paths,string path){
        if(root == null) return;

        path += root.val.ToString();
        if(root.left == null && root.right == null){
            paths.Add(path);
        }

        DFS(root.left,paths,path);
        DFS(root.right,paths,path);
    }
    
    public int[][] FloodFill2(int[][] image, int sr, int sc, int color) {
        int rows = image.Length;
        int cols = image[0].Length;
        var visited = new bool[rows, cols];
        
        var initialColor = image[sr][sc];
        DFS(sr,sc,initialColor,color, image);

        return image;
    }

    private void DFS(int r,int c, int initialColor, int color, int[][] image){
        if(r <0 || r>= image.Length || c <0 || c>= image[0].Length || image[r][c] != initialColor) return;
        image[r][c] = color;

        DFS(r +1, c,initialColor,color,image);
        DFS(r -1, c,initialColor,color,image);
        DFS(r, c+1,initialColor,color,image);
        DFS(r, c-1,initialColor,color,image);
    }
    
    public List<int> InorderTraversal(TreeNode root) {
        var res =new List<int>();
        DFS(root,res);
        return res;
    }
    private void DFS(TreeNode node, List<int> result)
    {
        if (node == null) return;

        DFS(node.left, result);
        result.Add(node.val);
        DFS(node.right, result);
    }
    
    public bool IsSameTree(TreeNode p, TreeNode q) {
        var qData = new List<int>();
        var pData = new List<int>();

        DFS(p,pData);
        DFS(q,qData);

        if (qData.Count != pData.Count) return false;

        for(int i =0; i <qData.Count;i++){
            var x = qData[i];
            var y = pData[i];
            if(x!= y)return false;
        }

        return true;
    }


    private void DFS2(TreeNode root, List<int> data){
        if(root == null) return;

        DFS(root.left,data);
        data.Add(root.val);
        DFS(root.right,data);
    }
    
    public bool IsUnivalTree(TreeNode root) {
        if(root == null) return false;

        var seen = new HashSet<int>();
        var s = new Stack<TreeNode>();
        s.Push(root);

        while(s.Count > 0){
            var node = s.Pop();
            seen.Add(node.val);
            if(node.left != null) s.Push(node.left);
            if(node.right != null) s.Push(node.right);
        }

        return seen.Count ==1;
    }
    
    public int MaxDepth(TreeNode root) {
        if(root == null) return 0;

        var maxD =1;

        var s = new Stack<TreeNode>();
        s.Push(root);

        while(s.Count >0){
            for(int i = 0; i < s.Count;i++){
                var node = s.Pop();
                if(node.left != null) s.Push(node.left);
                if(node.right != null) s.Push(node.right);
            }
            maxD++;
        }

        return maxD;
    }
    
    public bool IsSymmetric(TreeNode root) {
        if(root == null) return false;

        var s = new Stack<(TreeNode a, TreeNode b)>();

        s.Push((root.left,root.right));

        while(s.Count >0){
            var (nodeA, nodeB) = s.Pop();
            if(nodeA == null && nodeB == null) continue;
            if(nodeA == null || nodeB == null) return false;
            if(nodeA.val != nodeB.val) return false;

            s.Push((nodeA.left,nodeB.right));
            s.Push((nodeA.right,nodeB.left));
        }

        return true;
    }
    
    public int MinDepth(TreeNode root) {
        if(root == null) return 0;

        var s = new Stack<TreeNode>();
        s.Push(root);
        var depth = 1;

        while(s.Count >0){
            for(int i =0; i <s.Count; i++){
                var node = s.Pop();
                if(node.left == null && node.right == null){
                    return depth;
                }
                if(node.left != null) s.Push(node.left);
                if(node.right != null) s.Push(node.right);
            }
            depth++;
        }

        return depth;

    }
    
    public bool HasPathSum(TreeNode root, int targetSum) {
        if(root == null) return false;

        return DFS(root, 0, targetSum);

    }
    private bool DFS(TreeNode root, int sum, int targetSum){
        if(root == null) return false;

        if(root.left == null && root.right == null){
            if(sum == targetSum) return true;
        }
        return DFS(root.left,sum + root.left.val,targetSum)||DFS(root.right,sum + root.right.val,targetSum);
    }
    
    public bool Exist(char[][] board, string word) {
        int rows = board.Length;
        int cols = board[0].Length;

        int index = 0;
        var res = true;
        
        for(int r = 0; r < rows;r++){
            for(int c = 0;c < cols;c++){
                if(board[r][c] == word[0]){
                   res = CheckForWord(r,r,0,word,board);
                }   
            }
        }

        return res;
    }

    private bool CheckForWord(int r, int c,int i ,string w, char[][]board){
        if(r < 0 || r >= board.Length || c < 0 || c>= board[0].Length || board[r][c] != w[i]) return false;

        var temp = board[r][c];
        board[r][c] = '#';

        var res = 
            CheckForWord(r+1,c, i+1,w, board)||
            CheckForWord(r-1,c, i+1,w,board)||
            CheckForWord(r,c+1, i+1,w,board)||
            CheckForWord(r,c-1, i+1,w, board);

        board[r][c] =temp;
        return res;

    }
}