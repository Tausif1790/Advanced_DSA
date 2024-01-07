Given an array of integers A, find and return the minimum value
 of | A [ i ] - A [ j ] | where i != j and |x| denotes the absolute value of x.

Input 1: A = [1, 2, 3, 4, 5]
Input 2: A = [5, 17, 100, 11]

Output 1: 1
Output 2: 6

//----------------// TC: O(nlogn) ///-----------------------//
class Solution {
    public int solve(List < int > A) {
        int n = A.Count;
        // we sort array because -> | A [ i ] - A [ j ] | is same for A[i] - A[j] or A[j] - A[i]
        A.Sort();
        // initialize the ans variable
        int ans = int.MaxValue;
        for (int i = 1; i < n; i++) {
            // we can find minimum diff at adjacent place only
            ans = Math.Min(ans, A[i] - A[i - 1]);
        }
        return ans;
    }
}

//-------------// TC: is higher for this then above, almost 2x //---------------//
class Solution {
    int ans = int.MaxValue;
    public int solve(List<int> A) {

        MergeSort(A, 0, A.Count - 1);
        return ans;
    }

    void MergeSort(List<int> A, int left, int right) {
        if (left == right) {
            return;
        }
        int mid = (left + right) / 2;

        MergeSort(A, left, mid);
        MergeSort(A, mid + 1, right);

        Merge(A, left, mid, right);
    }

    void Merge(List<int> A, int left, int mid, int right) {
        int n1 = mid - left + 1;
        int n2 = right - mid;

        List<int> leftArray = new List<int>(A.GetRange(left, n1));
        List<int> rightArray = new List<int>(A.GetRange(mid + 1, n2));

        int i = 0, j = 0, idx = left;                   // imp -> idx = left

        while (i < n1 && j < n2) {
            int currDiff = Math.Abs(leftArray[i] - rightArray[j]);          // only ischange here
            ans = Math.Min(ans, currDiff);                                  // only is change here

            if (leftArray[i] <= rightArray[j]) {
                A[idx] = leftArray[i];
                i++;
            } else {
                A[idx] = rightArray[j];
                j++;
            }
            idx++;
        }

        while (i < n1) {
            A[idx] = leftArray[i];
            i++;
            idx++;
        }

        while (j < n2) {
            A[idx] = rightArray[j];
            j++;
            idx++;
        }
    }
}
