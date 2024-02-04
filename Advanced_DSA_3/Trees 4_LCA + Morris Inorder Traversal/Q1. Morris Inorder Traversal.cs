Input 1:
   1
    \
     2
    /
   3
Input 2:
   1
  / \
 6   2
    /
   3

Output 1: [1, 3, 2]
Output 2: [6, 1, 3, 2]
//----------------------------// O(n), O(1) //--------------------//
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
        List<int> inOrder = new List<int>();    // List to store the inorder traversal result
        TreeNode curr = A;                      // Initialize current node to the root
        while(curr != null){
            if(curr.left == null){
                inOrder.Add(curr.val);            // If no left child, add current node's value to the result
                curr = curr.right;                // Move to the right child
            }
            else{
                TreeNode temp = curr.left;        // Temporary pointer to the left child
                while(temp.right != null && temp.right != curr){
                    temp = temp.right;            // Find the rightmost node in the left subtree
                } 
                if(temp.right == null){
                    temp.right = curr;            // Create a thread from rightmost to current node
                    curr = curr.left;             // Move to the left child
                }
                else{
                    temp.right = null;            // Remove the thread
                    inOrder.Add(curr.val);        // Add current node's value to the result
                    curr = curr.right;            // Move to the right child
                }
            }
        }
        return inOrder;                           // Return the inorder traversal result
    }
}
