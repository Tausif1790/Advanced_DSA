Input 1:
            2
          /   \
         1    3
B = 2
Input 2:
            3
           /
          2
         /
        1
B = 1

Output 1: 2
Output 2: 1
//-------------------------------------------------//
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
    int k = 0;
    public int kthsmallest(TreeNode A, int B) {
        if(A == null){
            return -1;                        // Return -1 if the node is null (base case)
        }

        int left = kthsmallest(A.left, B);    // Recursively find the Bth smallest in the left subtree

        if(left != -1){
            return left;                      // If Bth smallest is found in the left subtree, return it
        }
        k++;                                  // Increment the counter as the current node is visited

        if(k == B){
            return A.val;                     // If the current node is the Bth smallest, return its value
        }

        return kthsmallest(A.right, B);       // Recursively find the Bth smallest in the right subtree
    }
}
