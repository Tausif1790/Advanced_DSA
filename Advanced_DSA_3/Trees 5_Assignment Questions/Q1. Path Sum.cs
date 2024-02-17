Tree:    5
         / \
        4   8
       /   / \
      11  13  4
     /  \      \
    7    2      1
 B = 22
Input 2:
 Tree:    5
         / \
        4   8
       /   / \
     -11 -13  4

 B = -1

Output 1: 1
Output 2: 0

//-----------------------------------------------//
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
    public int hasPathSum(TreeNode A, int B) {
        if(A == null){
            return 0;
        }
        // Leaf node check: if the current node is a leaf and its value equals B, return 1
        if(A.left == null && A.right == null){
            if(A.val == B){
                return 1;
            }
        }
        
        int left = hasPathSum(A.left, B - A.val);    // Check if there is a path sum in the left subtree
        if(left == 1) return 1;                     // If a path is found in the left subtree, return 1

        return hasPathSum(A.right, B - A.val);      // Otherwise, check if there is a path sum in the right subtree
    }
}
