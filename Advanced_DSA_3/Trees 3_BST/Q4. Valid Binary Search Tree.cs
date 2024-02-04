Input 1:
   1
  /  \
 2    3
Input 2:
  2
 / \
1   3

Output 1: 0
Output 2: 1
//------------------------------------//
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
    public int isValidBST(TreeNode A) {
        long min = int.MinValue;
        long max = int.MaxValue;
        bool result = check(A, min, max);
        if(result) return 1;
        return 0;
    }

    // this max and min value for curr node
    public bool check(TreeNode root, long min, long max){
        if(root == null){
            return true;
        }
        if(root.val > max || root.val < min){
            return false;
        }
        bool left = check(root.left, min, root.val - 1);
        bool right = check(root.right, root.val + 1, max);
        return left && right;
    }
}
