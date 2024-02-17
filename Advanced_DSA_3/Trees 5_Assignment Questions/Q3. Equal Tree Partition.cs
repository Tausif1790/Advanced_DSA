Given a binary tree A. Check whether it is possible to partition the tree to two trees which have equal sum of values after removing exactly one edge on the original tree.

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
    bool check = false;                     // Flag to indicate if a valid partition is found
    public int solve(TreeNode A) {
        long totalSum = sum(A, -1);          // Calculate the total sum of the binary tree
        if(totalSum % 2 != 0) return 0;      // If the total sum is odd, return 0 (not possible to partition)
        sum(A, totalSum / 2);                // Check for a valid partition with half of the total sum
        return check ? 1 : 0;                // Return 1 if a valid partition is found, otherwise 0
    }

    // Recursive function to calculate the sum of a subtree and check for a valid partition
    public long sum(TreeNode root, long B){
        if(root == null){
            return 0;                        // Return 0 if the node is null
        }

        long left = sum(root.left, B);       // Calculate the sum of the left subtree
        long right = sum(root.right, B);     // Calculate the sum of the right subtree

        long currSum = left + right + root.val; // Calculate the current sum of the subtree
        if(currSum == B){
            check = true;                        // Set the flag to true if a valid partition is found
        }

        return currSum;                          // Return the current sum
    }
}