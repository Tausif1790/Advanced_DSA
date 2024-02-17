Problem Description
Given a binary tree. Check whether the given tree is a Sum-binary Tree or not.
Sum-binary Tree is a Binary Tree where the value of a every node is equal to sum of the nodes present in its left subtree and right subtree.
An empty tree is Sum-binary Tree and sum of an empty tree can be considered as 0. A leaf node is also considered as SumTree.
Return 1 if it sum-binary tree else return 0.
Input 1:
       26
     /    \
    10     3
   /  \     \
  4   6      3
Input 2:
       26
     /    \
    10     3
   /  \     \
  4   6      4

Output 1: 1
Output 2: 0
//----------------------------------------//
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
    bool check = true;
    public int solve(TreeNode A) {
        sum(A);
        return check ? 1 : 0;
    }

    // Recursive function to calculate the sum of a subtree and check for a Sum-binary Tree
    public long sum(TreeNode root){
        if(root == null){
            return 0;                        // Return 0 if the node is null (empty tree)
        }

        long left = sum(root.left);          // Calculate the sum of the left subtree
        long right = sum(root.right);        // Calculate the sum of the right subtree

        long currSum = left + right;         // Calculate the current sum of the subtree

        // Check if the current node violates the Sum-binary Tree property
        if(currSum != 0 && currSum != root.val){
            check = false;                   // Set the flag to false if the property is violated
        }
    
        return currSum + root.val;           // Return the updated sum including the current node's value
    }
}