Input 1:

 A = [2, 1, 3]
 B = [2, 3, 1]
Input 2:

 A = [6, 1, 3, 2]
 B = [6, 3, 2, 1]


Example Output
Output 1:

   1
  / \
 2   3
Output 2:

   1  
  / \
 6   2
    /
   3
//---------------------------------------------------------//
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
    Dictionary<int, int> inorderIndexMap = new Dictionary<int, int>();

    public TreeNode buildTree(List<int> A, List<int> B) {
        int inOrderLength = A.Count;
        int postOrderLength = B.Count;

        // Populate the index map for faster lookup during tree construction
        for (int i = 0; i < inOrderLength; i++) {
            inorderIndexMap.Add(A[i], i);
        }

        // Build the tree using helper function
        TreeNode root = Build(A, B, 0, inOrderLength - 1, 0, postOrderLength - 1);

        return root;
    }

    private TreeNode Build(List<int> inorder, List<int> postorder, int inLeftIdx, int inRightIdx, int poLeftIdx, int poRightIdx) {
        // Base case: If the indices cross each other, return null
        if (inLeftIdx > inRightIdx) {
            return null;
        }

        // Create a new TreeNode with the value from the postorder array
        TreeNode root = new TreeNode(postorder[poRightIdx]);

        // Find the index of the root value in the inorder array
        int idx = inorderIndexMap[root.val];

        // Update indices for left and right subtrees
        int leftSubtreeLength = idx - inLeftIdx;

        // Recursively build left and right subtrees
        root.left = Build(inorder, postorder, inLeftIdx, idx - 1, poLeftIdx, poLeftIdx + leftSubtreeLength - 1);
        root.right = Build(inorder, postorder, idx + 1, inRightIdx, poLeftIdx + leftSubtreeLength, poRightIdx - 1);

        return root;
    }
}

