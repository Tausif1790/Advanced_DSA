Input 1: A = 3
Input 2: A = 5
Output 1:
1 0 0 
1 1 0 
1 2 1 
Output 2:
1 0 0 0 0
1 1 0 0 0
1 2 1 0 0
1 3 3 1 0
1 4 6 4 1 
//-------------------------------------------------------//
class Solution {
    public List<List<int>> solve(int A) {
        List<List<int>> ans = new List<List<int>>();
        int n = A;

        for(int i=0; i<n; i++){
            List<int> temp = new List<int>();
            for(int j=0; j<n; j++){
                temp.Add(0);
            }
            ans.Add(temp);
        }

        for(int i=0; i<n; i++){
            // First and last element in each row is 1
            ans[i][0] = 1;
            ans[i][i] = 1;

            for(int j=1; j<i; j++){
                // Fill in the rest of the elements using the sum of two elements from the row above
                ans[i][j] = ans[i-1][j-1] + ans[i-1][j];
            }
        }

        return ans;
    }
}

//TC: O(n^2)
//SC: O(n^2) / O(1)
