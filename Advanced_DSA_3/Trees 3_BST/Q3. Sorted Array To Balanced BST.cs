Input 1: A : [1, 2, 3]
Input 2: A : [1, 2, 3, 5, 10]

Output 1:
      2
    /   \
   1     3
Output 2:
      3
    /   \
   2     5
  /       \
 1         10
 //------------------------// O(n),O(logn) -----------------------------//
 using System.Collections.Generic;
using System;
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
    public TreeNode sortedArrayToBST(List<int> A) {
        int n = A.Count;
        TreeNode root = Build(A, 0, n-1);
        return root;
    }

    public TreeNode Build(List<int> A, int start, int end){
        if(start > end) return null;
        if(start == end){
            return new TreeNode(A[start]);
        }

        int mid = (start + end)/2;

        TreeNode root = new TreeNode(A[mid]);
        root.left = Build(A, start, mid - 1);
        root.right = Build(A, mid + 1, end);

        return root;
    }
}