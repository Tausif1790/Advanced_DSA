Given a Binary Search Tree(BST) A. If there is a node with value B present in the tree delete it and return the tree.
Note - If there are multiple options, always replace a node by its in-order predecessor

Input 1:
            15
          /    \
        12      20
        / \    /  \
       10  14  16  27
      /
     8
     B = 10

Input 2:
            8
           / \
          6  21
         / \
        1   7
     B = 6

Output 1:
            15
          /    \
        12      20
        / \    /  \
       8  14  16  27

Output 2:
            8
           / \
          1  21
           \
            7

//---------------------------------------------//
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
    public TreeNode solve(TreeNode A, int B) {
        // Base case: If the current node is null or the node to be deleted is found
        if(A == null) return null;
        if(A.val == B && A.left == null && A.right == null) return null;
        if(A.val == B && A.left != null && A.right == null) return A.left;
        if(A.val == B && A.left == null && A.right != null) return A.right;
        
        if(A.val == B){
            // If the node to be deleted has both left and right children
            TreeNode curr = A.left;
            while(curr.right != null){
                curr = curr.right;
            }
            swap(A, curr);                  // Swap the values of the current node and its in-order predecessor
            //return solve(A.left, B);      // previous mistake
            A.left = solve(A.left, B);      // Recursively delete the node in the left subtree
            return A;
        }
        if(B < A.val){
            //return solve(A.left, B);      // previous mistake
            A.left = solve(A.left, B);      // If the value to be deleted is less than the current node's value, search in the left subtree
        }else{
            //return solve(A.right, B);       // previous mistake
            A.right = solve(A.right, B);    // If the value to be deleted is greater than the current node's value, search in the right subtree
        }
        return A;
    }

    public void swap(TreeNode a, TreeNode b){
        int temp = a.val;
        a.val = b.val;
        b.val = temp;
    }

}

//     10
//    /  \
//   5   15
//      / \
//     12  20
//          \
//          25

// =>>> in-order predecessor of a node is the node with the largest value that is smaller than the given node's value.
// - In-order predecessor of the node with value 15 is 12.
// - In-order predecessor of the node with value 12 is 10.
// - In-order predecessor of the node with value 10 is 5.
// - In-order predecessor of the node with value 5 is null (as it is the smallest value in the tree).

// =>>> in-order successor of a node is the node with the smallest value that is greater than the given node's value.
// - In-order successor of the node with value 15 is 20.
// - In-order successor of the node with value 12 is 15.
// - In-order successor of the node with value 10 is 12.
// - In-order successor of the node with value 25 is null (as it is the largest value in the tree).

// The node is a leaf node - In this cases, we can just delete the node and return the root, since deleting any leaf node doesn’t affect the remainig tree.

// The node has one child - In this case, replace the node with the child node and return the root.

// The node has 2 children - In this case, in order to conserve the BST properties, we need to replace the node with it’s inorder predecssor (The node that comes before in the inorder traversal) i.e; we need to replace it with :
// The greatest value node in it’s left subtree and return the root.

