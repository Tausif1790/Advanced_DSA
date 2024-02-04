Input 1:

 A = [1, 2, 3]
 B = [2, 1, 3]
Input 2:

 A = [1, 6, 2, 3]
 B = [6, 1, 3, 2]


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
    Dictionary<int, int> inorderIndexMap = new Dictionary<int, int>();
    public TreeNode buildTree(List<int> A, List<int> B) {
        int inOrderLength = B.Count;
        int preOrderLength = A.Count;

        // Populate the index map for faster lookup during tree construction
        for (int i = 0; i < inOrderLength; i++) {
            inorderIndexMap.Add(B[i], i);
        }

        // Build the tree using helper function // A => preOrder, B => inOrder
        TreeNode root = Build(B, A, 0, inOrderLength - 1, 0, preOrderLength - 1);

        return root;
    }

    public TreeNode Build(List<int> inOrder, List<int> preOrder, int inLeftIdx, int inRightIdx, int preLeftIdx, int preRightIdx){
        if(inLeftIdx > inRightIdx){
            return null;
        }

        // create subTree root node
        TreeNode root = new TreeNode(preOrder[preLeftIdx]);

        // find idx of root in inOrder tree
        int idx = inorderIndexMap[root.val];
        int lengthLeftTree = idx - inLeftIdx;

        // Recursively build left and right subtrees
        root.left = Build(inOrder, preOrder, inLeftIdx, idx - 1, preLeftIdx + 1, preLeftIdx + lengthLeftTree);
        root.right = Build(inOrder, preOrder, idx + 1, inRightIdx, preLeftIdx + lengthLeftTree + 1, preRightIdx);
        //root.right = Build(inOrder, preOrder, idx + 1, inRightIdx, lenghtLeftTree + 1 , preRightIdx);

        return root;
    }
}
