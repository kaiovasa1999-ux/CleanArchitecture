using System.Collections;
using System.Text;

namespace Refresh_TopCoding;

public class Graphs_DFS_MID
{
    private int logestPath = 0;

    public int NumIslands(char[][] grid)
    {
        int rows = grid.Length;
        int cols = grid[0].Length;
        var visited = new bool[rows, cols];
        int islandCounter = 0;

        var directions = new int[4][]
        {
            new int[2] { 0, 1 },
            new int[2] { 0, -1 },
            new int[2] { 1, 0 },
            new int[2] { -1, 0 },
        };

        var q = new Queue<(int, int)>();
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (grid[r][c] == '1' && visited[r, c] == false)
                {
                    visited[r, c] = true;
                    q.Enqueue((r, c));
                    islandCounter++;
                    while (q.Count > 0)
                    {
                        var (x, y) = q.Dequeue();
                        foreach (var dir in directions)
                        {
                            var nr = x + dir[0];
                            var nc = y + dir[1];
                            if (nr >= 0 && nr < rows && nc >= 0 && nc < cols && !visited[nr, nc] && grid[nr][nc] == '1')
                            {
                                q.Enqueue((nr, nc));
                                visited[nr, nc] = true;
                            }
                        }
                    }
                }
            }
        }

        return islandCounter;
    }

    public int FindBottomLeftValue(TreeNode root)
    {
        if (root == null) return 0;
        var q = new Queue<TreeNode>();

        q.Enqueue(root);
        int maxLeft = root.val;

        while (q.Count > 0)
        {
            var levelData = q.Count;
            maxLeft = q.Peek().val;
            for (int i = 0; i < levelData; i++)
            {
                var node = q.Dequeue();
                if (node.left != null)
                {
                    q.Enqueue(node.left);
                }

                if (node.right != null) q.Enqueue(node.right);
            }
        }

        return maxLeft;
    }

    public int FindCircleNum(int[][] isConnected)
    {
        int n = isConnected.Length;
        var visited = new bool[n];
        var citiesConnection = isConnected[0].Length;
        var q = new Queue<int>();
        var count = 0;


        for (int i = 0; i < n; i++)
        {
            if (!visited[i])
            {
                count++;
                visited[i] = true;
                q.Enqueue(i);
            }

            while (q.Count > 0)
            {
                var city = q.Dequeue();
                for (int j = 0; j < citiesConnection; j++)
                {
                    if (isConnected[city][j] == 1 && !visited[j])
                    {
                        visited[j] = true;
                        q.Enqueue(j);
                    }
                }
            }
        }

        return count;
    }

    public int KthSmallest(TreeNode root, int k)
    {
        var stack = new Stack<TreeNode>();
        var current = root;

        while (true)
        {
            while (current != null)
            {
                stack.Push(current);
                current = current.left;
            }

            current = stack.Pop();
            k--;
            if (k == 0)
                return current.val;
            current = current.right;
        }
    }

    public int MaxAreaOfIsland(int[][] grid)
    {
        int rows = grid.Length;
        int cols = grid[0].Length;

        var s = new Stack<(int, int)>();
        var maxArea = 0;

        var dirs = new int[4][]
        {
            new int[2] { 0, 1 },
            new int[2] { 0, -1 },
            new int[2] { 1, 0 },
            new int[2] { -1, 0 },
        };


        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (grid[r][c] == 1)
                {
                    grid[r][c] = 2;
                    var area = 1;
                    s.Push((r, c));

                    while (s.Count > 0)
                    {
                        var (x, y) = s.Pop();

                        foreach (var d in dirs)
                        {
                            var nr = x + d[0];
                            var nc = y + d[1];
                            if (nr >= 0 && nr < rows && nc >= 0 && nc < cols && grid[nr][nc] == 1)
                            {
                                s.Push((nr, nc));
                                area++;
                                grid[nr][nc] = 2;
                            }
                        }
                    }

                    maxArea = Math.Max(maxArea, area);
                }
            }
        }

        return maxArea;
    }

    // public int LongestUnivaluePath(TreeNode root) {
    //
    //     DFS(root);
    //     return logestPath;
    //     
    // }
    //
    // private int DFS(TreeNode root)
    // {
    //     if(root == null) return 0;
    //     
    //     var left = DFS(root.left);
    //     var right = DFS(root.right);
    //
    //     var leftPath = 0;
    //     var rightPath = 0;
    //
    //     if(root.left !=null && root.left.val == root.val){
    //         leftPath = left +1;
    //     }
    //     if(root.right != null && root.right.val == root.val){
    //         rightPath = right +1;
    //     }
    //     
    //     this.logestPath = Math.Max(leftPath, rightPath);
    //     
    //     return Math.Max(leftPath, rightPath);
    // }

    public string Tree2str(TreeNode root)
    {
        var res = new StringBuilder();
        DFS(root, res);
        return res.ToString();
    }

    private void DFS(TreeNode root, StringBuilder res)
    {
        if (root == null) return;
        res.Append(root.val);
        if (root.left == null && root.right == null) return;

        res.Append('(');
        if (root.left != null)
        {
            DFS(root.left, res);
        }

        res.Append(')');
        if (root.right != null)
        {
            res.Append('(');
            DFS(root.right, res);
            res.Append(')');
        }
    }

    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        if (root == null || root == p || root == q) return root;

        var left = LowestCommonAncestor(root.left, p, q);
        var right = LowestCommonAncestor(root.right, p, q);

        if (left != null && right != null) return root;

        return left ?? right;
    }

    // public List<List<string>> AccountsMerge(List<List<string>> accounts)
    // {
    //     var emailToName = new Dictionary<string, string>();
    //     var graph = new Dictionary<string, HashSet<string>>();
    //     
    // }

    // public int NetworkDelayTime(int[][] times, int n, int k)
    // {
    //     var graph = new Dictionary<int, List<(int, int)>>();
    //
    //     for (int i = 1; i <= n; i++)
    //     {
    //         graph[i] = new List<(int, int)>();
    //     }
    //
    //     foreach (var time in times)
    //     {
    //         var src = time[0];
    //         var dst = time[1];
    //         var w = time[2];
    //         graph[src].Add((dst, w));
    //     }
    //
    //     var stack = new Stack<int>();
    //     var inStack = new bool[n + 1];
    //     var dist = Enumerable.Repeat(int.MaxValue, n + 1).ToArray();
    //
    //     dist[k] = 0;
    //     stack.Push(k);
    //     inStack[k] = true;
    //
    //     while (stack.Count > 0)
    //     {
    //         var u = stack.Pop();
    //         inStack[u] = false;
    //
    //         foreach (var (v, w) in graph[u])
    //         {
    //             if (dist[u] + w < dist[v])
    //             {
    //                 dist[v] = dist[u] + w;
    //                 if (!inStack[v])
    //                 {
    //                     stack.Push(v);
    //                     inStack[v] = true;
    //                 }
    //             }
    //         }
    //     }
    //
    //     var maxDist = 0;
    //     for (int i = 1; i <= n; i++)
    //     {
    //         if (dist[i] == int.MaxValue)
    //         {
    //             return -1;
    //         }
    //
    //         maxDist = Math.Max(maxDist, dist[i]);
    //     }
    //
    //     return maxDist;
    // }

    public List<List<int>> AllPathsSourceTarget(int[][] graph)
    {
        var q = new Queue<List<int>>();
        var res = new List<List<int>>();

        q.Enqueue(new List<int> { 0 });
        while (q.Count > 0)
        {
            var path = q.Dequeue();
            var lastNode = path[^1];
            foreach (var p in graph[lastNode])
            {
                var newPath = new List<int>(path) { p };
                if (p == graph.Length - 1)
                {
                    res.Add(newPath);
                }
                else
                {
                    q.Enqueue(newPath);
                }
            }
        }

        return res;
    }

    public int ArrayNesting(int[] nums)
    {
        int n = nums.Length;
        var seen = new bool[n];
        int best = 0;

        for (int i = 0; i < n; i++)
        {
            if (seen[i]) continue;

            var curr = i;
            int count = 0;
            while (!seen[curr])
            {
                seen[curr] = true;
                curr = nums[curr];
                count++;
            }

            best = Math.Max(best, count);
        }

        return best;
    }

    public int NetworkDelayTime(int[][] times, int n, int k)
    {
        var adj = new Dictionary<int, List<(int, int)>>();

        for (int i = 1; i <= n; i++)
        {
            adj[i] = new List<(int, int)>();
        }

        foreach (var item in times)
        {
            var src = item[0];
            var dest = item[1];
            var w = item[2];
            adj[src].Add((dest, w));
        }

        var visited = new bool[n + 1];
        var s = new Stack<int>();
        var dist = Enumerable.Repeat(int.MaxValue, n + 1).ToArray();
        dist[k] = 0;
        s.Push(k);
        visited[k] = true;

        while (s.Count > 0)
        {
            var node = s.Pop();
            visited[node] = false;
            foreach (var (d, w) in adj[node])
            {
                if (dist[node] + w < dist[w])
                {
                    dist[d] = dist[node] + w;
                    if (!visited[d])
                    {
                        s.Push(d);
                    }

                    visited[d] = true;
                }
            }
        }


        var max = 0;

        for (int i = 1; i <= n; i++)
        {
            if (dist[i] == int.MaxValue)
            {
                return -1;
            }

            max = Math.Max(max, dist[i]);
        }

        return max;
    }

    public int SumEvenGrandparent(TreeNode root)
    {
        if (root == null) return 0;

        var s = new Stack<TreeNode>();

        s.Push(root);
        int sum = 0;
        while (s.Count > 0)
        {
            var node = s.Pop();

            if (node.val % 2 == 0)
            {
            }
        }

        return sum;
    }

    public int RemoveStones(int[][] stones)
    {
        int n = stones.Length;
        var visited = new bool[n];

        int count = 0;
        for (int i = 0; i < n; i++)
        {
            if (!visited[i])
            {
                count++;
                DFS(i);
            }
        }

        void DFS(int i)
        {
            visited[i] = true;
            for (int j = 0; j < stones.Length; j++)
            {
                if (!visited[j] &&
                    (stones[i][0] == stones[j][0] || stones[i][1] == stones[j][1]))
                {
                    DFS(j);
                }
            }
        }

        return n - count;
    }

    public List<int> EventualSafeNodes(int[][] graph)
    {
        var res = new List<int>();
        var adj = new Dictionary<int, List<int>>();

        int n = graph.Length;

        for (int i = 0; i < n; i++)
        {
            adj[i] = new List<int>();
        }

        var indegree = new int[n];
        var s = new Stack<int>();

        for (int i = 0; i < n; i++)
        {
            foreach (var node in graph[i])
            {
                adj[node].Add(i);
            }

            indegree[i] = graph[i].Length;
            if (indegree[i] == 0)
            {
                s.Push(i);
            }
        }

        while (s.Count > 0)
        {
            var terminal = s.Pop();
            foreach (var nei in adj[terminal])
            {
                indegree[nei]--;
                if (indegree[nei] == 0)
                {
                    s.Push(nei);
                }
            }
        }

        for (int i = 0; i < n; i++)
        {
            if (indegree[i] == 0) res.Add(i);
        }


        return res;
    }

    public int MaxLevelSum(TreeNode root)
    {
        if (root == null) return 0;
        var q = new Queue<TreeNode>();
        q.Enqueue(root);
        var max = int.MinValue;

        while (q.Count > 0)
        {
            var sum = 0;
            var levelCount = q.Count;
            for (int i = 0; i < levelCount; i++)
            {
                var node = q.Dequeue();
                sum += node.val;
                if (node.left != null) q.Enqueue(node.left);
                if (node.right != null) q.Enqueue(node.right);
            }

            max = Math.Max(max, sum);
            sum = 0;
        }

        return max;
    }

    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k)
    {
        var graph = new Dictionary<int, List<(int, int)>>();
        for (int i = 0; i < n; i++)
        {
            graph[i] = new List<(int, int)>();
        }

        foreach (var f in flights)
        {
            graph[f[0]].Add((f[1], f[2]));
        }

        var dist = new int[n];
        Array.Fill(dist, int.MaxValue);
        var q = new Queue<(int, int, int)>();
        q.Enqueue((src, 0, 0));
        dist[src] = 0;
        int minPrice = int.MaxValue;

        while (q.Count > 0)
        {
            var (city, cost, steps) = q.Dequeue();
            if (steps > k) continue;

            foreach (var (next, price) in graph[city])
            {
                int newCost = cost + price;
                if (newCost < dist[next])
                {
                    dist[next] = newCost;
                    if (next == dst)
                    {
                        minPrice = Math.Min(minPrice, newCost);
                    }

                    q.Enqueue((next, newCost, steps + 1));
                }
            }
        }

        if (minPrice == int.MaxValue) return -1;

        return minPrice;
    }

    public int ClosedIsland(int[][] grid)
    {
        int rows = grid.Length;
        int cols = grid[0].Length;
        var s = new Stack<(int, int)>();
        int count = 0;
        var dirs = new int[4][]
        {
            new int[2] { 0, 1 },
            new int[2] { 0, -1 },
            new int[2] { 1, 0 },
            new int[2] { -1, 0 },
        };
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (grid[r][c] == 0)
                {
                    grid[r][c] = 2;
                    s.Push((r, c));

                    bool isValid = !(r == 0 || r == rows - 1 || c == 0 || c == cols - 1);

                    while (s.Count > 0)
                    {
                        var (x, y) = s.Pop();


                        foreach (var d in dirs)
                        {
                            var nr = d[0] + x;
                            var nc = d[1] + y;

                            if (nr >= 0 && nr < rows && nc >= 0 && nc < cols && grid[nr][nc] == 0)
                            {
                                grid[nr][nc] = 2;
                                s.Push((nr, nc));
                            }
                        }
                    }

                    if (isValid) count++;
                }
            }
        }

        return count;
    }


    public bool ValidateBinaryTreeNodes(int n, int[] leftChild, int[] rightChild)
    {
        var parents = Enumerable.Range(0, n).ToArray();
        var components = n;

        for (int node = 0; node < n; node++)
        {
            foreach (var child in new int[] { leftChild[node], rightChild[node] })
            {
                if (child == -1) continue;

                var nodeRoot = FindRoot(parents, node);
                var childRoot = FindRoot(parents, child);

                if (nodeRoot == childRoot || childRoot != child) return false;

                parents[childRoot] = nodeRoot;
                components--;
            }
        }

        return true;
    }

    private int FindRoot(int[] parents, int node)
    {
        while (node != parents[node])
        {
            node = parents[node];
        }

        return node;
    }

    public int MakeConnected(int n, int[][] connections)
    {
        var graph = new List<int>[n];
        if (connections.Length < n - 1) return -1;

        for (int i = 0; i < n; i++)
        {
            graph[i] = new List<int>();
        }

        foreach (var c in connections)
        {
            var a = c[0];
            var b = c[1];
            graph[a].Add(b);
            graph[b].Add(a);
        }

        var components = 0;

        var visited = new bool[n];

        for (int i = 0; i < n; i++)
        {
            if (visited[i]) continue;
            components++;
            var s = new Stack<int>();

            s.Push(i);
            while (s.Count > 0)
            {
                var comp = s.Pop();

                foreach (var nei in graph[comp])
                {
                    if (!visited[nei])
                    {
                        visited[nei] = true;
                        s.Push(nei);
                    }
                }
            }
        }

        return components - 1;
    }

    private int count = 0;

    public int AverageOfSubtree(TreeNode root)
    {
        DFS(root);
        return count;
    }

    private (int, int) DFS(TreeNode root)
    {
        if (root == null) return (0, 0);

        var (left, leftCount) = DFS(root.left);
        var (right, rightCount) = DFS(root.right);

        int totalSum = left + right + root.val;
        int totalCount = leftCount + rightCount + 1;

        if (totalSum / totalCount == root.val) count++;

        return (totalSum, totalCount);
    }

    private Dictionary<int, List<(int, char)>> graph = new Dictionary<int, List<(int, char)>>();

    public string GetDirections(TreeNode root, int startValue, int destValue)
    {
        BuildGraph(root);

        var q = new Queue<(int, string)>();
        var visited = new HashSet<int>();
        q.Enqueue((startValue, ""));
        visited.Add(startValue);

        while (q.Count > 0)
        {
            var (val, path) = q.Dequeue();
            if (val == destValue) return path;

            foreach (var (nei, move) in graph[val])
            {
                if (!visited.Contains(nei))
                {
                    visited.Add(nei);
                    q.Enqueue((nei, path + move));
                }
            }
        }

        return "";
    }

    private void BuildGraph(TreeNode root)
    {
        DFFS(root);
    }

    private void DFFS(TreeNode root)
    {
        if (root == null) return;
        if (root.left != null)
        {
            AddEdge(root.val, root.left.val, 'L');
            AddEdge(root.left.val, root.val, 'R');
            DFFS(root.left);
        }

        if (root.right != null)
        {
            AddEdge(root.val, root.right.val, 'R');
            AddEdge(root.right.val, root.val, 'U');
            DFFS(root.right);
        }
    }

    private void AddEdge(int from, int to, char direction)
    {
        if (!graph.ContainsKey(from)) graph[from] = new List<(int, char)>();
        graph[from].Add((to, direction));
    }

    private int res = 0;

    public int PseudoPalindromicPaths(TreeNode root)
    {
        var freq = new int[10];
        DFS(freq, root);
        return res;
    }

    private void DFS(int[] freq, TreeNode root)
    {
        if (root == null) return;

        freq[root.val]++;
        if (root.left == null && root.right == null)
        {
            bool isPalindrome = true;
            var hasOdd = false;

            for (int i = 1; i <= 9; i++)
            {
                if (freq[i] % 2 != 0)
                {
                    if (hasOdd)
                    {
                        isPalindrome = false;
                        break;
                    }

                    hasOdd = true;
                }
            }

            if (isPalindrome) res++;
        }

        if (root.left != null) DFS(freq, root.left);
        if (root.right != null) DFS(freq, root.right);
        freq[root.val]--;
    }

    public List<List<string>> AccountsMerge(List<List<string>> accounts)
    {
        var emailsToNameMap = new Dictionary<string, string>();
        var graph = new Dictionary<string, HashSet<string>>();

        foreach (var acc in accounts)
        {
            string name = acc[0];

            for (int i = 1; i < acc.Count; i++)
            {
                string email = acc[i];
                if (!graph.ContainsKey(email)) graph[email] = new HashSet<string>(StringComparer.Ordinal);
                emailsToNameMap[email] = name;
            }

            for (int i = 2; i < acc.Count; i++)
            {
                string a = acc[1];
                string b = acc[i];
                graph[a].Add(b);
                graph[b].Add(a);
            }
        }

        var res = new List<List<string>>();
        var visited = new HashSet<string>(StringComparer.Ordinal);


        foreach (var start in graph.Keys)
        {
            if (visited.Contains(start)) continue;

            var q = new Queue<string>();
            var components = new List<string>();
            q.Enqueue(start);
            visited.Add(start);

            while (q.Count > 0)
            {
                var curr = q.Dequeue();
                components.Add(curr);
                foreach (var nei in graph[curr])
                {
                    if (!visited.Contains(nei))
                    {
                        visited.Add(nei);
                        q.Enqueue(nei);
                    }
                }
            }

            components.Sort(StringComparer.Ordinal);
            components.Insert(0, emailsToNameMap[start]);
            res.Add(components);
        }

        return res;
    }

    public int MinReorder(int n, int[][] connections)
    {
        var adj = new List<(int, int)>[n];
        for (int i = 0; i < n; i++)
        {
            adj[i] = new List<(int, int)>();
        }

        foreach (var e in connections)
        {
            int a = e[0];
            int b = e[1];
            adj[a].Add((b, 1));
            adj[b].Add((a, 0));
        }

        var q = new Queue<int>();
        var visited = new HashSet<int>();
        q.Enqueue(0);
        visited.Add(0);

        int switches = 0;

        while (q.Count > 0)
        {
            int u = q.Dequeue();

            foreach (var (v, w) in adj[u])
            {
                if (!visited.Contains(v))
                {
                    visited.Add(v);
                    switches += w;
                    q.Enqueue(v);
                }
            }
        }

        return switches;
    }

    public bool CanVisitAllRooms(List<List<int>> rooms)
    {
        var visited = new HashSet<int>();
        var s = new Stack<int>();
        visited.Add(0);
        s.Push(0);

        while (s.Count > 0)
        {
            var room = s.Pop();
            foreach (var key in rooms[room])
            {
                if (visited.Add(key))
                {
                    s.Push(key);
                }
            }
        }

        return visited.Count == rooms.Count;
    }

    public int ClosestMeetingNode(int[] edges, int node1, int node2)
    {
        int n = edges.Length;

        int[] dist1 = GetDistances(edges, node1, n);
        int[] dist2 = GetDistances(edges, node2, n);
        var minDist = int.MaxValue;
        var res = -1;

        for (int i = 0; i < n; i++)
        {
            if (dist1[i] != int.MaxValue && dist2[i] != int.MaxValue)
            {
                int maxDist = Math.Max(dist1[i], dist2[i]);

                if (maxDist < minDist || (maxDist == minDist && i < res))
                {
                    minDist = maxDist;
                    res = i;
                }
            }
        }

        return res;
    }

    private int[] GetDistances(int[] edges, int start, int n)
    {
        var dist = Enumerable.Repeat(int.MaxValue, n).ToArray();
        int d = 0;
        while (start != -1 && dist[start] == int.MaxValue)
        {
            dist[start] = d;
            d++;
            start = edges[start];
        }

        return dist;
    }

    public bool CanFinish(int numCourses, int[][] prerequisites)
    {
        var graph = new List<int>[numCourses];
        var degree = new int[numCourses];

        for (int i = 0; i < numCourses; i++)
        {
            graph[i] = new List<int>();
        }

        foreach (var prerequisite in prerequisites)
        {
            graph[prerequisite[1]].Add(prerequisite[0]);
            degree[prerequisite[0]]++;
        }

        var s = new Stack<int>();

        for (int i = 0; i < numCourses; i++)
        {
            if (degree[i] == 0)
            {
                s.Push(i);
            }
        }

        while (s.Count > 0)
        {
            int curr = s.Pop();
            numCourses--;

            foreach (var nei in graph[curr])
            {
                degree[nei]--;
                if (degree[nei] == 0)
                {
                    s.Push(nei);
                }
            }
        }

        return numCourses == 0;
    }

    public int MinScore(int n, int[][] roads) {
        var graph= new Dictionary<int,List<(int,int)>>();

        for(int i =1; i <=n;i++){
            graph[i] = new List<(int,int)>();
        }

        foreach(var r in roads){
            graph[r[0]].Add((r[1],r[2]));
            graph[r[1]].Add((r[0],r[2]));
        }

        var s = new Stack<int>();
        var visited = new HashSet<int>();
        s.Push(1);
        visited.Add(1);

        var min = int.MaxValue;

        while(s.Count > 0){
            var cur = s.Pop();
            foreach(var (nei,w) in graph[cur]){
                min = Math.Min(min,w);
                if(visited.Add(nei)){
                    s.Push(nei);
                }
            }
        }

        return min == int.MaxValue ?-1:min;
    }
}