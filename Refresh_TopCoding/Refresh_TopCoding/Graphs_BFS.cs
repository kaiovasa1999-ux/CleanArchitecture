// using System.Data;
//
// public class Graphs_BFS
// {
//     public bool IsSameTree(TreeNode p, TreeNode q)
//     {
//         if (p == null || q == null) return false;
//
//         var pData = new List<int>();
//         var qData = new List<int>();
//         BFS(p, pData);
//         BFS(q, qData);
//
//         if (pData.Count != qData.Count) return false;
//
//         for (int i = 0; i < qData.Count; i++)
//         {
//             if (qData[i] != pData[i]) return false;
//         }
//
//         return true;
//     }
//
//
//     private void BFS(TreeNode root, List<int> data)
//     {
//         if (root == null) return;
//
//         BFS(root.left, data);
//         data.Add(root.val);
//         BFS(root.right, data);
//     }
//
//     public int GetMinimumDifference(TreeNode root)
//     {
//         var pq = new PriorityQueue<int, int>();
//
//         if (root == null) return 0;
//
//         var q = new Queue<TreeNode>();
//         q.Enqueue(root);
//
//         while (q.Count > 0)
//         {
//             var node = q.Dequeue();
//             pq.Enqueue(node.val, node.val);
//
//             if (node.left != null) q.Enqueue(node.left);
//             if (node.right != null) q.Enqueue(node.right);
//         }
//
//         int min = int.MaxValue;
//
//         while (pq.Count > 1)
//         {
//             var n1 = pq.Dequeue();
//             var n2 = pq.Dequeue();
//             var diff = Math.Abs(n2 - n1);
//             if (min > diff) min = diff;
//         }
//
//
//         return min;
//     }
//
//     public List<double> AverageOfLevels(TreeNode root)
//     {
//         var res = new List<double>();
//         if (root == null) return res;
//
//
//         var q = new Queue<TreeNode>();
//         q.Enqueue(root);
//
//         while (q.Count > 0)
//         {
//             double avg = 0.0;
//             double levelSum = 0.0;
//             int levelCount = q.Count;
//             for (int i = 0; i < levelCount; i++)
//             {
//                 var node = q.Dequeue();
//                 levelSum += node.val;
//                 if (node.left != null) q.Enqueue(node.left);
//                 if (node.right != null) q.Enqueue(node.right);
//             }
//
//             avg = levelSum / levelCount;
//             res.Add(avg);
//         }
//
//         return res;
//     }
//
//     public bool FindTarget(TreeNode root, int k)
//     {
//         var hSet = new HashSet<int>();
//         if (root == null) return false;
//
//         var q = new Queue<TreeNode>();
//         q.Enqueue(root);
//
//         while (q.Count > 0)
//         {
//             var node = q.Dequeue();
//             hSet.Add(node.val);
//             if (node.val == k) return true;
//             int left = k - node.val;
//             if (hSet.Contains(left)) return true;
//
//             if (node.left != null) q.Enqueue(node.left);
//             if (node.right != null) q.Enqueue(node.right);
//         }
//
//         return false;
//     }
//
//     public int[][] FloodFill(int[][] image, int sr, int sc, int color)
//     {
//         if (image[sr][sc] == color) return image;
//
//         var initialColor = image[sr][sc];
//
//         DFS(sr, sc, image, initialColor, color);
//
//         return image;
//     }
//
//     private void DFS(int r, int c, int[][] image, int initialColor, int color)
//     {
//         if (r < 0 || r >= image.Length || c < 0 || c >= image[0].Length || image[r][r] != initialColor) return;
//
//         image[r][r] = color;
//         DFS(r + 1, c, image, initialColor, color);
//         DFS(r - 1, c, image, initialColor, color);
//         DFS(r, c + 1, image, initialColor, color);
//         DFS(r, c - 1, image, initialColor, color);
//     }
//
//     public int IslandPerimeter(int[][] grid)
//     {
//         if (grid == null) return 0;
//
//         var rows = grid.Length;
//         var cols = grid[0].Length;
//         var visited = new bool[rows, cols];
//         var res = 0;
//
//         for (int r = 0; r < rows; r++)
//         {
//             for (int c = 0; c < cols; c++)
//             {
//                 if (grid[r][c] == 1)
//                 {
//                     res = DFS(r, c, grid);
//                 }
//             }
//         }
//
//         return res;
//     }
//
//     private int DFS(int r, int c, int[][] grid)
//     {
//         if (r < 0 || r >= grid.Length || c < 0 || c >= grid[0].Length || grid[r][c] == 0) return 1;
//         grid[r][c] = 2;
//
//         int perimeter = DFS(r + 1, c, grid);
//         perimeter += DFS(r - 1, c, grid);
//         perimeter += DFS(r, c + 1, grid);
//         perimeter += DFS(r, c - 1, grid);
//
//         return perimeter;
//     }
//
//     public int MinDiffInBST(TreeNode root)
//     {
//         if (root == null) return 0;
//
//         var q = new Queue<TreeNode>();
//         q.Enqueue(root);
//         int min = int.MaxValue;
//         int diff = 0;
//
//         while (q.Count > 0)
//         {
//             var node = q.Dequeue();
//             if (node.left == null && node.right == null)
//             {
//                 continue;
//             }
//
//             if (node.left != null)
//             {
//                 q.Enqueue(node.left);
//                 diff = Math.Abs(node.left.val - node.val);
//                 if (min > diff)
//                 {
//                     min = diff;
//                 }
//             }
//
//             if (node.right != null)
//             {
//                 q.Enqueue(node.right);
//                 diff = Math.Abs(node.right.val - node.val);
//             }
//         }
//
//         return min;
//     }
//
//     public bool ValidPath(int n, int[][] edges, int source, int destination)
//     {
//         if (edges.Length == 0) return true;
//         if (source == destination) return true;
//
//         var graph = new Dictionary<int, HashSet<int>>();
//         int rows = edges.Length;
//         int cols = edges[0].Length;
//         var visited = new bool[n];
//
//         foreach (var edge in edges)
//         {
//             int start = edge[0];
//             int end = edge[1];
//
//             if (!graph.ContainsKey(start))
//             {
//                 graph.Add(start, new HashSet<int>());
//             }
//
//             graph[start].Add(end);
//
//             if (!graph.ContainsKey(end))
//             {
//                 graph.Add(end, new HashSet<int>());
//             }
//
//             graph[end].Add(start);
//         }
//
//         var s = new Stack<int>();
//         s.Push(source);
//
//         while (s.Count > 0)
//         {
//             var v = s.Pop();
//             var neight = graph[v];
//
//             foreach (var nei in neight)
//             {
//                 if (!visited[nei])
//                 {
//                     if (nei == destination) return true;
//                 }
//
//                 s.Push(nei);
//             }
//
//             visited[v] = true;
//         }
//
//         return false;
//     }
//
//     public string LongestNiceSubstring(string s)
//     {
//         int left = 0;
//         int right = 1;
//
//         var hSet = new HashSet<string>();
//         int max = 0;
//         var res = string.Empty;
//
//         foreach (var c in s)
//         {
//             string x = c.ToString();
//             if (!hSet.Contains(x.ToLower()) || !hSet.Contains(x.ToUpper()))
//             {
//                 if (hSet.Count > max)
//                 {
//                     foreach (var e in hSet)
//                     {
//                         res += c;
//                     }
//                 }
//
//                 hSet.Clear();
//             }
//             else
//             {
//                 hSet.Add(x);
//             }
//         }
//
//         return res;
//     }
//
//     public int FindCircleNum(int[][] isConnected)
//     {
//         int n = isConnected.Length;
//         var visited = new bool[n];
//         int citiesCounnection = isConnected[0].Length;
//         var q = new Queue<int>();
//         var count = 0;
//
//
//         for (int i = 0; i < n; i++)
//         {
//             if (!visited[i])
//             {
//                 count++;
//                 visited[i] = true;
//                 q.Enqueue(i);
//
//                 while (q.Count > 0)
//                 {
//                     var city = q.Dequeue();
//
//                     for (int j = 0; j < citiesCounnection; j++)
//                     {
//                         if (isConnected[city][j] == 1 && !visited[j])
//                         {
//                             visited[j] = true;
//                             q.Enqueue(j);
//                         }
//                     }
//                 }
//             }
//         }
//
//         return count;
//     }
// }