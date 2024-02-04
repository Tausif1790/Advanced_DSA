Input 1:
            1
          /   \
         2    3
        / \  / \
       4   5 6  7
      /
     8 
Input 2:
            1
           /  \
          2    3
           \
            4
             \
              5

Output 1: [1, 2, 4, 8, 3, 7]
Output 2: [1, 2, 3]

//--------------------------------------------------------///
/**
 * Definition for binary tree
 * class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) {this.val = x; this.left = this.right = null;}
 * }
 */
class Solution {
    public List<int> solve(TreeNode A) {
        List<int> topView = new List<int>();
        if (A == null) return topView;                            // Check if the tree is empty, return an empty result
        Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>(); // Dictionary to store nodes at each column
        Queue<Pair> q = new Queue<Pair>();                       // Queue for level-order traversal
        q.Enqueue(new Pair(A, 0));                               // Enqueue the root node with column 0
        int minCol = 0; int maxCol = 0;                          // Saving min and max column values for final result

        while (q.Count != 0) {
            int size = q.Count;
            for (int i = 1; i <= size; i++) {                    // Process each node at the current level
                Pair currPair = q.Dequeue();
                minCol = Math.Min(minCol, currPair.col);
                maxCol = Math.Max(maxCol, currPair.col);

                AddColToMap(dict, currPair);                     // Add current node to the dictionary

                TreeNode left = currPair.node.left;
                TreeNode right = currPair.node.right;
                if (left != null) q.Enqueue(new Pair(left, currPair.col - 1));   // Enqueue left child if it exists
                if (right != null) q.Enqueue(new Pair(right, currPair.col + 1)); // Enqueue right child if it exists
            }
        }

        // Add first el of each vertical oder traversa
        for (int i = 0; i >= minCol; i--){
            List<int> currCol = dict[i];
            topView.Add(currCol[0]);
        }
        for (int i = 1; i <= maxCol; i++){
            List<int> currCol = dict[i];
            topView.Add(currCol[0]);
        }
        return topView;
    }

    public void AddColToMap(Dictionary<int, List<int>> dict, Pair currPair) {
        int key = currPair.col;
        int nodeValue = currPair.node.val;
        if (dict.ContainsKey(key)) {
            List<int> temp = dict[key];
            temp.Add(nodeValue);                                 // Add the nodeValue to the list
            dict[key] = temp;
        } else {
            dict.Add(key, new List<int> { nodeValue });          // Create a new list for the key
        }
    }

    public class Pair {
        public TreeNode node;
        public int col;
        public Pair(TreeNode node, int col) {
            this.node = node;
            this.col = col;
        }
    }
}
