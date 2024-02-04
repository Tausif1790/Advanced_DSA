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

Output 1: [1, 3, 7, 8]
Output 2: [1, 3, 4, 5]

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
    public List<int> solve(TreeNode A) {
        List<int> result = new List<int>();                // List to store values at the current level
        Queue<TreeNode> que = new Queue<TreeNode>();       // Queue for level-order traversal
        
        if(A == null){
            return result;
        }
        
        que.Enqueue(A);
        
        while(que.Count != 0){
            int size = que.Count;                    // Number of nodes at the current level
            
            for(int i=1; i<=size; i++){              
                TreeNode curr = que.Dequeue(); 
                if(i == size){
                    result.Add(curr.val);
                }
            
                if(curr.left != null){ que.Enqueue(curr.left); }         // Enqueue left child if exists
                if(curr.right != null){ que.Enqueue(curr.right); }       // Enqueue right child if exists
            }
        }
        
        return result;
    }
}
