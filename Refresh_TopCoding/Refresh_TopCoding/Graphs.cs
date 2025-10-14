namespace Refresh_TopCoding;

public class Graphs
{
    public int IslandPerimeter(int[][] grid)
    {
        int rows = grid.Length;
        int cols = grid[0].Length;
        var res = 0;
        bool[,] visited = new bool[rows, cols];
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (grid[r][c] == 1)
                {
                    res += DFS(r, c, grid, visited);
                }
            }
        }

        return res;
    }

    private int DFS(int r, int c, int[][] grid, bool[,] visited)
    {
        if (r < 0 || r >= grid.Length || c < 0 || c >= grid[0].Length || grid[r][c] == 0) return 1;
        if (visited[r, c])
        {
            return 0;
        }

        visited[r, c] = true;

        int res = DFS(r + 1, c, grid, visited);
        res += DFS(r - 1, c, grid, visited);
        res += DFS(r, c + 1, grid, visited);
        res += DFS(r, c - 1, grid, visited);

        return res;
    }

    public int[][] FloodFill(int[][] image, int sr, int sc, int color)
    {
        if (image[sr][sc] == color) return image;

        var initialColor = image[sc][sr];

        DFS(sr, sc, initialColor, color, image);

        return image;
    }

    private void DFS(int r, int c, int initialColor, int color, int[][] image)
    {
        if (r < 0 || r >= image.Length || c < 0 || c >= image[0].Length || image[r][c] != initialColor) return;
        image[r][c] = color;
        DFS(r + 1, c, initialColor, color, image);
        DFS(r - 1, c, initialColor, color, image);
        DFS(r, c - 1, initialColor, color, image);
        DFS(r, c + 1, initialColor, color, image);
    }

    public int FindJudge(int n, int[][] trust) {
        if(trust.Length ==1) return n;

        var q = new Queue<(int a,int b)>();

        foreach(var t in trust){
            q.Enqueue((t[0],t[1]));
        }

        var trustBy =0;

        while (q.Count >0){
            var (a,b) =q.Dequeue();
            if(a == b) return -1;
            else if (b == n){
                trustBy++;
            }

        }

        if(trustBy == n-1) return n;


        return -1;
    }
    
    public int FindCenter(int[][] edges) {
        if(edges.Length == 0) return 0;

        var map = new Dictionary<int,int>();

        foreach(var edge in edges){
            foreach(var e in edge){
                if(!map.ContainsKey(e)){
                    map[e] =0;
                }
                map[e]++;
            }
        }

        return map.OrderByDescending(x => x.Value).Select(x => x.Key).FirstOrDefault();
    }
    
    public bool ValidPath(int n, int[][] edges, int source, int destination) {
        if(source == destination) return true;

        var map = new Dictionary<int, HashSet<int>>();
        var visited = new bool[n];

        foreach(var e in edges){
            var start = e[0];
            var end = e[1];

            if(!map.ContainsKey(start)){
                map.Add(start,new HashSet<int>());
            }
            map[start].Add(end);

            if (!map.ContainsKey(end))
            {
                map.Add(end, new HashSet<int>());
            }
            map[end].Add(start);
        }

        var s = new Stack<int>();
        
        s.Push(source);

        while (s.Count >0)
        {
            var v = s.Pop();
            var neightbors = map[v];

            foreach (var ne in neightbors)
            {
                if (!visited[ne])
                {
                    if(ne == destination) return true;
                    
                    s.Push(ne);
                }
            }
            
            visited[v] = true;
        }
        
        
        
        return false;
    }
}