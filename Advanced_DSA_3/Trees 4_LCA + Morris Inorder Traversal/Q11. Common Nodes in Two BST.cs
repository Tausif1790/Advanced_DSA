Input 1:

 Tree A:
    5
   / \
  2   8
   \   \
    3   15
        /
        9

 Tree B:
    7
   / \
  1  10
   \   \
    2  15
       /
      11

Output 1: 17

Explanation 1:
 Common Nodes are : 2, 15
 So answer is 2 + 15 = 17

//-----------------//   //-------------------------//
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
    HashSet<int> sett = new HashSet<int>();
    int ans = 0;
    int mod = (int)Math.Pow(10, 9) + 7;

    public int solve(TreeNode A, TreeNode B) {
        inorderA(A);             // Populate the set with values from tree A
        inorderB(B);             // Traverse tree B to find common nodes and update sum
        return ans % mod;
    }
    
    // Inorder traversal for tree A to populate the HashSet
    public void inorderA(TreeNode root){
        if(root == null){
            return;
        }
        inorderA(root.left);             // Traverse left subtree
        sett.Add(root.val);              // Add node value to the HashSet
        inorderA(root.right);            // Traverse right subtree
    }

    // Inorder traversal for tree B to find common nodes and update sum
    public void inorderB(TreeNode root){
        if(root == null){
            return;
        }

        inorderB(root.left);                                 // Traverse left subtree

        // Check if the current node's value is in the common set
        if(sett.Contains(root.val)){
            ans = (ans % mod + (root.val) % mod) % mod;      // Update the sum
        }

        inorderB(root.right);                                // Traverse right subtree
    }
}
