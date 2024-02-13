Input 1:
           1
         /   \
        2     3
       / \
      4   5
Input 2:
            1
          /   \
         2     3
        / \     \
       4   5     6
Output 1:
 [1, 2, 3, 4, 5, -1, -1, -1, -1, -1, -1]
Output 2:
 [1, 2, 3, 4, 5, -1, 6, -1, -1, -1, -1, -1, -1]
 //-------------------------------------------------------//
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
        Queue<TreeNode> q = new Queue<TreeNode>();
        List<int> result = new List<int>();

        if(A == null) return result;

        q.Enqueue(A);

        // Perform Level Order Traversal
        while(q.Count != 0){
            // Get the number of nodes at the current level
            int size = q.Count;
            
            // Process each node at the current level
            for(int i=1; i<=size; i++){
                // Dequeue the current node
                TreeNode curr = q.Dequeue();

                result.Add(curr.val);
                if(curr.val == -1) continue;            // if curr is -1 
                
                // Check if the left child is present and enqueue it, or enqueue a placeholder (-1)
                if(curr.left != null){
                    q.Enqueue(curr.left);
                }else{
                    q.Enqueue(new TreeNode(-1));
                }

                // Check if the right child is present and enqueue it, or enqueue a placeholder (-1)
                if(curr.right != null){
                    q.Enqueue(curr.right);
                }else{
                    q.Enqueue(new TreeNode(-1));
                }
            }
        }
        return result;
    }
}
