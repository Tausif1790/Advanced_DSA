Input 1:
            15
          /    \
        12      20
        / \    /  \
       10  14  16  27
      /
     8

     B = 16
Input 2:
            8
           / \
          6  21
         / \
        1   7

     B = 9

Output 1: 1
Output 2: 0
//------------------------------------------//
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
    public int solve(TreeNode A, int B) {
        if(A == null){
            return 0;
        }
        if(A.val == B){
            return 1;
        }
        if(B < A.val){
            return solve(A.left, B);
        }
        return solve(A.right, B);
    }
}
