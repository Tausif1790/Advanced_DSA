Input 1:

    3
   / \
  9  20
    /  \
   15   7
Input 2:

   1
  / \
 6   2
    /
   3


Example Output
Output 1:

 [
   [3],
   [9, 20],
   [15, 7]
 ]
Output 2:

 [ 
   [1]
   [6, 2]
   [3]
 ]
//---------------------------------------------------------//
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
    public List<List<int>> solve(TreeNode A) {
        List<List<int>> result = new List<List<int>>();
        Queue<TreeNode> que = new Queue<TreeNode>();                 // Queue for level-order traversal
        
        if(A == null){
            return result;
        }
        
        que.Enqueue(A);
        
        while(que.Count != 0){
            List<int> level = new List<int>();       // List to store values at the current level
            int size = que.Count;                    // Number of nodes at the current level
            
            for(int i=1; i<=size; i++){              // Process each node at the current level
                TreeNode curr = que.Dequeue();       // Dequeue the current node
                level.Add(curr.val);                 // Add the value to the current level list

                if(curr.left != null){ que.Enqueue(curr.left); }         // Enqueue left child if exists
                if(curr.right != null){ que.Enqueue(curr.right); }       // Enqueue right child if exists
            }
            
            result.Add(level);                        // Add the current level list to the result
        }
        
        return result;
    }
}
