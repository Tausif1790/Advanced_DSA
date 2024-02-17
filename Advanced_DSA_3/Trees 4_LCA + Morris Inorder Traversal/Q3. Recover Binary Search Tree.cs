Two elements of a Binary Search Tree (BST), represented by root A are swapped by mistake. Tell us the 2 values, when swapped, will restore the Binary Search Tree (BST).
A solution using O(n) space is pretty straightforward. Could you devise a constant space solution?
Note: The 2 values must be returned in ascending order

//----------------------// SC: O(n) //-------------------------------//
class Solution {
    List<int> inorderList = new List<int>();
    public List<int> recoverTree(TreeNode A) {
        List<int> ans = new List<int>();
        
        // Step 1: Perform inorder traversal to get the sorted values
        inorder(A);
        
        int n = inorderList.Count;
        int a = -1;
        int b = -1;

        // Step 2: Iterate through the sorted array to find the misplaced elements
        for (int i = 0; i < n - 1; i++) {
            // Check for elements in the wrong order
            if (inorderList[i] > inorderList[i + 1]) {
                // First misplaced element
                if (a == -1) {
                    a = inorderList[i];
                    b = inorderList[i + 1];
                } else {
                    // Second misplaced element found, break the loop
                    b = inorderList[i + 1];
                    break;
                }
            }
        }

        // Step 3: Add the misplaced elements to the result list
        ans.Add(Math.Min(a, b));
        ans.Add(Math.Max(a, b));
        return ans;
    }

    // Step 4: Perform inorder traversal and store the values in a list
    public void inorder(TreeNode root){
        if(root == null){
            return;
        }
        inorder(root.left);
        inorderList.Add(root.val);
        inorder(root.right);
    }
}

//------------------// Optimised approach, SC: O(1) //--------------------------------//
class Solution {
    // Remove the inorderList as it is not allowed to use extra space
    // List<int> inorderList = new List<int>();

    // Instead of using a list, use two variables to track the incorrectly placed nodes
    TreeNode prev = null;
    TreeNode first = null;
    TreeNode second = null;

    public List<int> recoverTree(TreeNode A) {
        List<int> ans = new List<int>();
        
        // Call the correct helper function
        inorder(A);

        // Add the values in ascending order to the result list
        ans.Add(Math.Min(first.val, second.val));
        ans.Add(Math.Max(first.val, second.val));

        return ans;
    }

    public void inorder(TreeNode root){
        if(root == null){
            return;
        }

        // Recursive inorder traversal
        inorder(root.left);

        // Check for incorrectly placed nodes
        if (prev != null && prev.val > root.val) {
            if (first == null) {
                first = prev;
            }
            second = root;
        }

        prev = root;

        inorder(root.right);
    }
}

