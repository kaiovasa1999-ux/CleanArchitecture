using System.ComponentModel.Design;
using System.Formats.Asn1;
using System.Runtime.ExceptionServices;

namespace Refresh_TopCoding;

public class GraphBFS_MID
{
    private List<int>[] adjList;
    private int seats;
    private int fuel = 0;
    public int NumIslands(char[][] grid)
    {
        var rows = grid.Length;
        var cols = grid[0].Length;
        var s = new Stack<(int,int)>();
        int count =0;

        var dirs = new int[4][]
        {
            new int[2] { 0, 1 },
            new int[2] { 0, -1 },
            new int[2] { 1, 0 },
            new int[2] { -1, 0 },
        };

        for(int r =0;r <rows; r++){
            for(int c =0; c < cols;c++){
                if(grid[r][c] =='1'){
                    s.Push((r,c));
                    grid[r][c] = '2';
                    count++;

                    while(s.Count >0){
                        var(row,col) = s.Pop();

                        foreach(var d in dirs){
                            var nr = d[0] +row;
                            var nc = d[1] +col;
                            if(nr >= 0 && nr < rows && nc >=0 && nc < cols && grid[nr][nc] =='1'){
                                s.Push((nr,nc));
                                grid[nr][nc] = '2';
                            }
                        }
                    }
                }
            }
        }   


        return count;  
    }

    public int FindBottomLeftValue(TreeNode root)
    {
        var q = new Queue<TreeNode>();
        if (root == null) return 0;

        var maxLeft = root.val;

        while (q.Count > 0)
        {
            for (int i = 0; i < q.Count; i++)
            {
                var node = q.Dequeue();
                if (node.left != null)
                {
                    q.Enqueue(node.left);
                    maxLeft = node.left.val;
                }

                if (node.right != null)
                {
                    q.Enqueue(node.right);
                }
            }
        }

        return maxLeft;
    }

    public bool CanFinish(int numCourses, int[][] prerequisites)
    {
        var graph = new List<int>[numCourses];
        var indegree = new int[numCourses];

        for (int i = 0; i < numCourses; i++)
        {
            graph[i] = new List<int>();
        }

        foreach (var p in prerequisites)
        {
            graph[p[1]].Add(p[0]);
            indegree[p[0]]++;
        }

        var s = new Stack<int>();
        for (int i = 0; i < numCourses; i++)
        {
            if (indegree[i] == 0)
            {
                s.Push(i);
            }
        }

        while (s.Count > 0)
        {
            int curr = s.Pop();
            numCourses--;

            foreach (var next in graph[curr])
            {
                indegree[next]--;
                if (indegree[next] == 0)
                {
                    s.Push(next);
                }
            }
        }

        return numCourses == 0;

        // var graph = new List<int>[numCourses];
        // var indegree = new int[numCourses];
        //
        // for(int i = 0; i < numCourses; i++){
        //     graph[i] = new List<int>();
        // }
        //
        // foreach(var preq in prerequisites){
        //     graph[preq[1]].Add(preq[0]);
        //     indegree[preq[0]]++;
        // }
        //
        // var stack = new Stack<int>();
        //
        // for(int i = 0; i < numCourses; i++){
        //     if(indegree[i] == 0){
        //         stack.Push(i);
        //     }
        // }
        //
        // while(stack.Count >0){
        //     int curr = stack.Pop();
        //     numCourses--;
        //
        //     foreach(var next in graph[curr]){
        //         indegree[next]--;
        //         if(indegree[next] == 0){
        //             stack.Push(next);
        //         }
        //     }
        // }
        //
        // return numCourses == 0;
    }

    public int MaxAreaOfIsland(int[][] grid)
    {
        int maxArea = 0;

        int rows = grid.Length;
        int cols = grid[0].Length;

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (grid[r][c] == 1)
                {
                    var area = GetIslandArea(grid, r, c);
                    maxArea = Math.Max(maxArea, area);
                }
            }
        }

        return maxArea;
    }

    private int GetIslandArea(int[][] grid, int r, int c)
    {
        if (r < 0 || r >= grid.Length || c < 0 || c >= grid[0].Length) return 0;
        if (grid[r][c] != 1) return 0;

        grid[r][c] = 0;
        int count = 1;

        count += GetIslandArea(grid, r + 1, c);
        count += GetIslandArea(grid, r - 1, c);
        count += GetIslandArea(grid, r, c + 1);
        count += GetIslandArea(grid, r, c - 1);

        return count;
    }

    public int NetworkDelayTime(int[][] times, int n, int k)
    {
        var graph = new Dictionary<int, List<(int, int)>>();

        for (int i = 0; i < n; i++)
        {
            graph[i] = new List<(int, int)>();
        }

        foreach (var node in times)
        {
            int source = node[0];
            int target = node[1];
            int time = node[2];

            if (!graph.ContainsKey(source))
            {
                graph[source] = new List<(int, int)>();
            }

            graph[source].Add((target, time));
        }

        var dist = Enumerable.Repeat(int.MaxValue, n + 1).ToArray();
        dist[k] = 0;

        var pq = new PriorityQueue<int, int>();
        pq.Enqueue(k, dist[k]);

        while (pq.Count > 0)
        {
            pq.TryDequeue(out int source, out int currDist);

            if (currDist > dist[source]) continue;

            foreach (var neigh in graph[source])
            {
                var (destination, weight) = neigh;

                var newDist = currDist + weight;
                if (newDist < dist[destination])
                {
                    dist[destination] = newDist;
                    pq.Enqueue(destination, newDist);
                }
            }
        }

        int max = 0;

        for (int i = 1; i <= n; i++)
        {
            if (dist[i] == int.MaxValue) return -1;

            max = Math.Max(max, dist[i]);
        }

        return max;
    }

    public bool IsEvenOddTree(TreeNode root)
    {
        if(root==null) return false;

        var q= new Queue<TreeNode>();
        int level = 0;
        q.Enqueue(root);
        while(q.Count >0){
            var nodes = q.Count;
            var levelData = new List<int>();

            for(int i =0; i <nodes;i++){
                var node = q.Dequeue();
                levelData.Add(node.val);
                if(node.left != null){
                    q.Enqueue(node.left);
                }
                if(node.right != null){
                    q.Enqueue(node.right);
                }
            }

            var fNode =0;

            if(level%2==0){
                fNode =levelData[0];
                if(levelData.Count ==1){
                    if(fNode % 2== 0) return false;
                }
                else{
                    for(int i=1; i <levelData.Count;i++){
                        if(levelData[i] % 2==0) return false;
                        if(fNode >= levelData[i]) return false;
                    }
                }
            }
            else{
                fNode = levelData[0];
                if(levelData.Count ==1){
                    if(fNode % 2 ==1) return false;
                }
                else{
                    for(int i =1; i <levelData.Count;i++){
                        if(levelData[i] %2 == 1) return false;
                        if(fNode <= levelData[i]) return false;
                    }
                }
            }

            levelData.Clear();
            level++;
        }

        return true;
    }

    public int OpenLock(string[] deadends, string target)
    {
        var visited = new HashSet<string>(deadends);
        if (visited.Contains("0000")) return -1;

        visited.Add("0000"); //initial

        var q = new Queue<(string, int)>();
        var deltas = new int[2] { -1, 1 };

        q.Enqueue(("0000", 0));

        while (q.Count > 0)
        {
            var (curr, moves) = q.Dequeue();
            if (curr == target) return moves;

            for (int i = 0; i < 4; i++)
            {
                foreach (var delta in deltas)
                {
                    var digit = ((curr[i] - '0') + delta + 10) % 10;
                    var next = curr.Substring(0, i) + digit + curr.Substring(i + 1);
                    if (visited.Add(next))
                    {
                        q.Enqueue((next, moves + 1));
                    }
                }
            }
        }

        return -1;
    }

    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k)
    {
        //k = stops
        //from = flights[0];
        //to = flights[1];
        //price = flights[2];

        var graph = new Dictionary<int, List<(int, int)>>();

        for (int i = 0; i < n; i++)
        {
            graph[i] = new List<(int, int)>();
        }

        foreach (var f in flights)
        {
            graph[f[0]].Add((f[1], f[2]));
        }

        var q = new Queue<(int, int, int)>();
        q.Enqueue((src, 0, 0));

        int cheapest = int.MaxValue;
        var dist = new int[n];
        Array.Fill(dist, int.MaxValue);
        dist[src] = 0;

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
                        cheapest = Math.Min(cheapest, newCost);
                    }

                    q.Enqueue((next, newCost, steps + 1));
                }
            }
        }

        return cheapest == int.MaxValue ? -1 : cheapest;
    }

    public List<List<int>> AllPathsSourceTarget(int[][] graph)
    {
        int target = graph.Length - 1;
        var res = new List<List<int>>();
        var q = new Queue<List<int>>();
        q.Enqueue(new List<int> { 0 });

        while (q.Count > 0)
        {
            var path = q.Dequeue();
            var lastNode = path[path.Count - 1];

            foreach (var nei in graph[lastNode])
            {
                var newPath = new List<int>(path) { nei };
                if (nei == target)
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

    public bool CanVisitAllRooms(List<List<int>> rooms)
    {
        var visited = new HashSet<int>();
        var stack = new Stack<int>();
        visited.Add(0);
        stack.Push(0);

        while (stack.Count > 0)
        {
            var room = stack.Pop();
            foreach (var key in rooms[room])
            {
                if (visited.Add(key))
                {
                    stack.Push(key);
                }
            }
        }

        return visited.Count == rooms.Count;
    }

    public int MaxLevelSum(TreeNode root)
    {
        if (root == null) return 0;
        int level = 1;
        int levelMax = 0;
        int maxSum = int.MinValue;
        var q = new Queue<TreeNode>();
        q.Enqueue(root);

        while (q.Count > 0)
        {
            var nodesPerLevel = q.Count;
            var sumPerLevel = 0;
            for (int i = 0; i < nodesPerLevel; i++)
            {
                var node = q.Dequeue();
                sumPerLevel += node.val;
                if (node.left != null) q.Enqueue(node.left);
                if (node.right != null) q.Enqueue(node.right);
            }

            if (maxSum < sumPerLevel)
            {
                maxSum = sumPerLevel;
                levelMax = level;
            }

            level++;
        }

        return levelMax;
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
            bool isEven = node.val % 2 == 0;

            if (node.left != null)
            {
                s.Push(node.left);
                if (isEven)
                {
                    if (node.left.left != null)
                    {
                        sum += node.left.left.val;
                    }

                    if (node.left.right != null)
                    {
                        sum += node.left.right.val;
                    }
                }
            }

            if (node.right != null)
            {
                s.Push(node.right);
                if (isEven)
                {
                    if (node.right.right != null)
                    {
                        sum += node.right.right.val;
                    }

                    if (node.right.left != null)
                    {
                        sum += node.right.left.val;
                    }
                }
            }
        }

        return sum;
    }

    // public bool ValidateBinaryTreeNodes(int n, int[] leftChild, int[] rightChild)
    // {
    //     int[] parent = new int[n];
    //     Array.Fill(parent, -1);
    //
    //     // Step 1: Assign parents and check no node has >1 parent
    //     for (int i = 0; i < n; i++)
    //     {
    //         if (leftChild[i] != -1)
    //         {
    //             if (parent[leftChild[i]] != -1) return false; // multiple parents
    //             parent[leftChild[i]] = i;
    //         }
    //
    //         if (rightChild[i] != -1)
    //         {
    //             if (parent[rightChild[i]] != -1) return false; // multiple parents
    //             parent[rightChild[i]] = i;
    //         }
    //     }
    //
    //     // Step 2: Find root (node without parent)
    //     int root = -1;
    //     for (int i = 0; i < n; i++)
    //     {
    //         if (parent[i] == -1)
    //         {
    //             if (root != -1) return false; // multiple roots
    //             root = i;
    //         }
    //     }
    //
    //     if (root == -1) return false; // no root
    //
    //     // Step 3: BFS/DFS to ensure connectivity and no cycles
    //     var visited = new HashSet<int>();
    //     var queue = new Queue<int>();
    //     queue.Enqueue(root);
    //
    //     while (queue.Count > 0)
    //     {
    //         int node = queue.Dequeue();
    //         if (!visited.Add(node)) return false; // cycle detected
    //
    //         if (leftChild[node] != -1) queue.Enqueue(leftChild[node]);
    //         if (rightChild[node] != -1) queue.Enqueue(rightChild[node]);
    //     }
    //
    //     return visited.Count == n;
    // }

    public List<int> EventualSafeNodes(int[][] graph)
    {
        var n = graph.Length;
        var safe = new Dictionary<int, bool>();
        var res = new List<int>();

        for (int i = 0; i < n; i++)
        {
            if (DFS(i))
            {
                res.Add(i);
            }
        }

        bool DFS(int i)
        {
            if (safe.ContainsKey(i))
            {
                return safe[i];
            }

            safe[i] = false;

            foreach (var nei in graph[i])
            {
                if (!DFS(nei))
                {
                    return false;
                }
            }

            safe[i] = true;
            return safe[i];

            return true;
        }

        return res;
    }

    public int ShortestPathBinaryMatrix(int[][] grid)
    {
        int rows = grid.Length;
        int cols = grid[0].Length;
        if (rows == 1 && cols == 1) return -1;
        if (grid[0][0] == 1 || grid[rows - 1][cols - 1] == 1) return -1;

        var q = new Queue<(int, int, int)>();
        q.Enqueue((0, 0, 1));
        grid[0][0] = 1;

        var dirs = new int[8][]
        {
            new int[2] { 0, 1 },
            new int[2] { 0, -1 },
            new int[2] { 1, 0 },
            new int[2] { -1, 0 },

            new int[2] { 1, 1 },
            new int[2] { -1, -1 },
            new int[2] { 1, -1 },
            new int[2] { -1, 1 },
        };

        while (q.Count > 0)
        {
            var (r, c, visit) = q.Dequeue();
            foreach (var dir in dirs)
            {
                var nextR = r + dir[0];
                var nextC = c + dir[1];
                if (nextR >= 0 && nextR < rows && nextC >= 0 && nextC < cols && grid[nextR][nextC] != 1)
                {
                    if (nextR == rows - 1 && nextC == cols - 1) return visit + 1;

                    q.Enqueue((nextR, nextC, visit + 1));
                }
            }
        }

        return -1;
    }

    public int RemoveStones(int[][] stones)
    {
        var n = stones.Length;
        var visited = new bool[n];

        void DFS(int i)
        {
            visited[i] = true;
            for (int j = 0; j < n; j++)
            {
                if (!visited[j] && (stones[i][0] == stones[j][0] || stones[i][1] == stones[j][1]))
                {
                    DFS(j);
                }
            }
        }

        int count = 0;

        for (int i = 0; i < n; i++)
        {
            if (!visited[i])
            {
                count++;
                DFS(i);
            }
        }

        return n - count;
    }

    public int SnakesAndLadders(int[][] board)
    {
        int n = board.Length;
        var cells = new (int, int)[n * n + 1];
        var cols = Enumerable.Range(0, n).ToList();
        var label = 1;

        for (int r = n - 1; r >= 0; r--)
        {
            foreach (var c in cols)
            {
                cells[label++] = (r, c);
            }
            cols.Reverse();
        }

        var dist = Enumerable.Repeat(-1, n * n + 1).ToArray();
        var q = new Queue<int>();
        q.Enqueue(1);
        dist[1] = 0;

        while (q.Count > 0)
        {
            var curr = q.Dequeue();
            for (int i = curr + 1; i < Math.Min(curr + 6, n * n); i++)
            {
                var (row, col) = cells[i];
                int dest = board[row][col] != -1 ? board[row][col] : i;
                if (dist[dest] == -1)
                {
                    dist[dest] = dist[curr] + 1;
                    if (dest == n * n) return dist[dest];

                    q.Enqueue(dest);
                }
            }
        }

        return dist[n * n];
    }
    
    
    public int OrangesRotting(int[][] grid)
    {
        var dirs = new int[4][] {
            new int[2] {0,1},
            new int[2] {0,-1},
            new int[2] {1,0},
            new int[2] {-1,0},
        };
        
        int rows = grid.Length;
        int cols = grid[0].Length;

        var q = new Queue<(int, int)>();
        var fresh = 0;

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if(grid[r][c] == 2) q.Enqueue((r, c));
                
                else if (grid[r][c] == 1) fresh++;
            }
        }
        
        int count = 0;

        while (q.Count >0 && fresh > 0)
        {
            var curretnLevel = q.Count;

            for (int i = 0; i < curretnLevel; i++)
            {
                var (r,c) = q.Dequeue();

                foreach (var dir in dirs)
                {
                    var nextR = r + dir[0];
                    var nextC = c + dir[1];
                    if (nextR >= 0 && nextR < rows && nextC >= 0 && nextC < cols && grid[nextR][nextC] == 1)
                    {
                        grid[nextR][nextC] = 2;
                        q.Enqueue((nextR, nextC));
                        fresh--;
                    }
                }
            }

            count++;
        }
        
        return fresh > 0? -1 : count;

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

        return components == 1;
    }

    private int FindRoot(int[] parents, int node)
    {
        while (node != parents[node])
        {
            node = parents[node];
        }

        return node;
    }
    
    public int ClosedIsland(int[][] grid) {
        int m = grid.Length;
        int n = grid[0].Length;
        var s = new Stack<(int,int)>();

        var dirs = new int[4][] {
            new int[2] {0,1},
            new int[2] {0,-1},
            new int[2] {1,0},
            new int[2] {-1,0},
        };

        var count =0;

        for(int r =0; r < m;r++){
            for(int c =0; c <n;c++){
                if(grid[r][c] == 0){
                    grid[r][c]=2;
                    s.Push((r,c));
                    var isValid = true;

                    while(s.Count >0){
                        var(x,y) = s.Pop();
                        if(r == 0 || r == m-1 || c == 0 || c == n-1){
                            isValid = false;
                        }
                        
                        foreach(var d in dirs){
                            var nr = x + d[0];
                            var nc = y + d[1];
                            if(nr >=0 && nr < m && nc >=0 && nc < n && grid[nr][nc] == 0){
                                grid[nr][nc] = 2;
                                s.Push((nr,nc));
                            }
                        }
                    }
                    if(isValid) count++;
                }
            }
        }

        return count;
    }
    
    public long MinimumFuelCost(int[][] roads, int seats) {
        this.seats = seats;
        var n = roads.Length + 1;
        for (int i = 0; i < n; i++)
        {
            adjList[i] = new List<int>();
        }

        foreach (var road in roads)
        {
            adjList[road[0]].Add(road[1]);
            adjList[road[1]].Add(road[0]);
        }

        DFS(0, -1);

        return this.fuel;
    }

    private int DFS(int node, int parent)
    {
        int reps = 1;
        foreach (var nei in adjList[node])
        {
            if(nei == parent) continue;
            int childReps = DFS(nei, node);
            this.fuel += (childReps + seats - 1) / seats;
            reps += childReps;
        }

        return reps;
    }
    
    public int MakeConnected(int n, int[][] connections)
    {
        if(connections.Length < n-1) return -1;

        int count = 0;
        
        var graph = new Dictionary<int,List<int>>();

        for (int i = 0; i < n; i++)
        {
            graph[i] =new List<int>();
        }

        foreach (var connection in connections)
        {
            var x = connection[0];
            var y = connection[1];
            graph[x].Add(y);
            graph[y].Add(x);
        }

        int components = 0;

        var visited = new bool[n];

        for (int i = 0; i < n; i++)
        {
            if(visited[i]) continue;
            visited[i] = true;
            
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
    public List<string> WatchedVideosByFriends(List<List<string>> watchedVideos, int[][] friends, int id, int level)
    {
        int n = friends.Length;

        var visited = new bool[n];
        var q = new Queue<int>();
        visited[id] = true;
        q.Enqueue(id);

        int currLevel = 0;
        while (q.Count > 0 && currLevel < level)
        {
            int size = q.Count;
            for (int i = 0; i < size; i++)
            {
                int u = q.Dequeue();
                foreach (int v in friends[u])
                {
                    if (!visited[v])
                    {
                        visited[v] = true;
                        q.Enqueue(v);
                    }
                }
            }
            currLevel++;
        }

        var freq = new Dictionary<string, int>(StringComparer.Ordinal);
        foreach (int person in q)
        {
            foreach (var video in watchedVideos[person])
            {
                if (!freq.TryAdd(video, 1))
                    freq[video]++;
            }
        }
        
        return freq.OrderBy(x => x.Value).ThenBy(x => x.Key).Select(x => x.Key).ToList();
    }
    
    public int PseudoPalindromicPaths (TreeNode root)
    {
        if(root == null) return -1;

        var s = new Stack<TreeNode>();
        var data = new List<string>();
        s.Push(root);

        var x = string.Empty;
        while (s.Count > 0)
        {
            var node = s.Pop();
            x += node.val.ToString();
            if (node.left == null && node.right == null)
            {
                data.Add(x);
                x = string.Empty;
            }

            if (node.left != null)
            {
                s.Push(node.left);
            }

            if (node.right != null)
            {
                s.Push(node.right);
            }
        }

        foreach (var item in data)
        {
                        
        }

        return 0;
    }

    private void DFS(TreeNode root,string x, List<string>data){
        if(root == null) return;

        x += root.val.ToString();
        if (root.left == null && root.right == null)
        {
            data.Add(x);
        }
        DFS(root.left,x,data);
        DFS(root.right,x,data);
        
        return;
    }
    
    public int AmountOfTime(TreeNode root, int start) {
        if(root == null) return 0;
        if(root.val == start && root.left == null && root.right==null)  return 0;
        
        var graph = new Dictionary<int,List<int>>();
        var q = new Queue<TreeNode>();
        q.Enqueue(root);
        graph[root.val] = new List<int>();

        while (q.Count > 0)
        {
            var node = q.Dequeue();
            if (node.left != null)
            {
                q.Enqueue(node.left);
                graph[node.left.val] = new List<int>();
                graph[node.left.val].Add(node.val);
                graph[node.val].Add(node.left.val);
            }

            if (node.right != null)
            {
                q.Enqueue(node.right);
                graph[node.right.val] = new List<int>();
                graph[node.right.val].Add(node.val);
                graph[node.val].Add(node.right.val);
            }
        }

        int minutes = 0;
        var infected = new Queue<int>();
        var visited = new HashSet<int>();
        infected.Enqueue(start);
        visited.Add(start);

        while (infected.Count > 0)
        {
            var size = infected.Count;
            for (int i = 0; i < size; i++)
            {
                var infectedNode = infected.Dequeue();
                foreach (var nei in graph[infectedNode])
                {
                    if (visited.Add(nei))
                    {
                        infected.Enqueue(nei);
                    }
                }
            }
            if(infected.Count > 0)
                minutes++;
        }

        return minutes;

    }
    
    public int MinReorder(int n, int[][] connections)
    {
        var graph = new Dictionary<int, List<(int, bool)>>();

        foreach (var edge in connections)
        {
            var a = edge[0];
            var b = edge[1];
            if(!graph.ContainsKey(a)) graph[a] = new List<(int, bool)>();
            if(!graph.ContainsKey(b)) graph[b] = new List<(int, bool)>();
            
            graph[a].Add((b, true));
            graph[b].Add((a, false));
        }

        int count = 0;

        var s = new Stack<int>();
        var visited = new HashSet<int>();
        
        s.Push(0);

        while (s.Count >0)
        {
            var node = s.Pop();
            visited.Add(node);

            foreach (var (nei, orginalD) in graph[node])
            {
                if (!visited.Contains(nei))
                {
                    s.Push(nei);
                    if (orginalD) count++;
                }
            }
        }

        return count;
    }
    public int MinScore(int n, int[][] roads)
    {

        var graph = new Dictionary<int, List<(int, int)>>();

        for (int i = 1; i <= n; i++)
        {
            graph[i] = new List<(int, int)>();
        }

        foreach (var road in roads)
        {
            graph[road[0]].Add((road[1],road[2]));
            graph[road[1]].Add((road[0], road[2]));
        }
        
        var s = new Stack<int>();
        var visited = new HashSet<int>();
        int min = int.MaxValue;
        
        s.Push(1);
        visited.Add(1);

        while (s.Count >0)
        {
            var road = s.Pop();
            visited.Add(road);
            foreach (var (toR,distane)in graph[road])
            {
                min = Math.Min(min, distane);

                if (visited.Add(toR))
                {
                    s.Push(toR);
                }
            }
        }

        return min == int.MaxValue ? -1 : min;
    }
    
    public int MaximumSafenessFactor(List<List<int>> grid)
    {
        int n = grid.Count;
        if (grid[0][0] == 1 || grid[n-1][n-1] == 1) return 0;

        var q = new Queue<(int, int)>();
        var visited = new bool[n, n];
        
        var dirs = new int[4][] {
            new int[2] {0,1},
            new int[2] {0,-1},
            new int[2] {1,0},
            new int[2] {-1,0},
        };

        for (int r = 0; r < n; r++)
        {
            for (int c = 0; c < n; c++)
            {
                if (grid[r][c] == 1)
                {
                    q.Enqueue((r,c));
                    visited[r, c] = true;
                }
            }
        }


        var level = 0;
        var distance = new int[n, n];

        while (q.Count >0)
        {
            int size =q.Count;
            level++;

            for (int i = 0; i < size; i++)
            {
                var (r,c) = q.Dequeue();

                foreach (var d in dirs)
                {
                    var nr = d[0] + r;
                    var nc = d[1] + c;

                    if (nr >= 0 && nr < n && nc >= 0 && nc < n && !visited[nr, nc])
                    {
                        visited[nr, nc] = true;
                        q.Enqueue((nr, nc));
                        distance[nr, nc] = level;
                    }
                }
            }
        }
        
        visited = new bool[n, n];
        var pq = new PriorityQueue<(int, int, int), int>();
        var startSafe = distance[0, 0];
        pq.Enqueue((0,0,startSafe),-startSafe);

        while (pq.Count > 0)
        {
            var (r,c,currSafe) = pq.Dequeue();
            
            if(visited[r,c]) continue;
            visited[r,c] = true;

            if (r == n - 1 && c == n - 1)
            {
                return currSafe;
            }

            foreach (var d in dirs)
            {
                var nr = d[0] + r;
                var nc = d[1] + c;

                if (nr >= 0 && nr < n && nc >= 0 && nc  < n && !visited[nr, nc])
                {
                    int nextSafe = Math.Min(currSafe,distance[nr, nc]);
                    pq.Enqueue((nr, nc, nextSafe), -nextSafe);
                }
            }
        }
        

        return -1;
    }
}