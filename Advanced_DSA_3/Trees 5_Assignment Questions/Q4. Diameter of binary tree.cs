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

Output 1: 3
Output 2: 4
//------------------------------------------------//
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
    int maxDiameter = -1;
    public int solve(TreeNode A) {
        diameter(A);
        return maxDiameter;
    }

    // Recursive function to calculate the diameter and height by edges
    public int diameter(TreeNode A){
        // Base case: if the node is null, return -1 (height by edges)
        if(A == null){
            return -1;                                      // return 0; // in height by nodes
        }

        int left = diameter(A.left);
        int right = diameter(A.right);

        int currDiameter = left + right + 2;                // left + right; // in height by nodes
        maxDiameter = Math.Max(maxDiameter, currDiameter);

        // Return the height by edges of the current subtree
        return (Math.Max(left, right) + 1);
    }
}
