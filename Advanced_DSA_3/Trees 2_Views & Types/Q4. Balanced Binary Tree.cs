Input 1:
    1
   / \
  2   3
Input 2:
       1
      /
     2
    /
   3

Output 1: 1
Output 2: 0
//-----------------------------------//
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
    bool flag = true;
    public int isBalanced(TreeNode A) {
        int height = heightBalanced(A);              // Calculate the height balance of the tree.
        if(flag) return 1;                           // If the tree is height balanced, return 1; otherwise, return 0.
        return 0;
    }
    
    public int heightBalanced(TreeNode A){
        if(A == null) return 0;                      // Base case: If the current node is null, its height is 0.

        int leftHeight = heightBalanced(A.left);     // Recursively calculate the height of the left subtree.
        int rightHeight = heightBalanced(A.right);   // Recursively calculate the height of the right subtree.

        int diff = Math.Abs(leftHeight - rightHeight); // Calculate the height difference between left and right subtrees.
        if(diff > 1){
            flag = false;                                    // If the height difference is greater than 1, set the flag to false.
        }
        int height = Math.Max(leftHeight, rightHeight) + 1; // Calculate the height of the current node.

        return height;                                       // Return the height of the current node.
    }
}
//--------------------------------------------------//
class Solution {
    public int isBalanced(TreeNode A) {
        int height = heightBalanced(A);
        if(height == -1) return 0;
        return 1;
    }
    
    public int heightBalanced(TreeNode A){
        if(A == null) return 0;

        int leftHeight = heightBalanced(A.left);
        if(leftHeight == -1) return -1;
        int rightHeight = heightBalanced(A.right);
        if(rightHeight == -1) return -1;

        int diff = Math.Abs(leftHeight - rightHeight);
        if(diff > 1){
            return -1;
        }
        int height = Math.Max(leftHeight, rightHeight) + 1;
        
        return height;
    }
}

