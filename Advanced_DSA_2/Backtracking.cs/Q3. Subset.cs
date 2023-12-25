Problem Description
Given a set of distinct integers A, return all possible subsets.

NOTE:
Elements in a subset must be in non-descending order.
The solution set must not contain duplicate subsets.
Also, the subsets should be sorted in ascending ( lexicographic ) order.
The initial list is not necessarily sorted.

A = [1, 2, 3]

Output:
[
 []
 [1]
 [1, 2]
 [1, 2, 3]
 [1, 3]
 [2]
 [2, 3]
 [3]
]

//-------------// TC: (2^n * n * log(n)), SC: O(n + 2^n) //--------------------------//
class Solution
{
    List<List<int>> ans = new List<List<int>>();

    public List<List<int>> subsets(List<int> A)
    {
        List<int> currAns = new List<int>();

        A.Sort();                           // sorting first is needed
        subSet(A, 0, currAns);              // Generate subsets starting from index 0    
        ans.Sort(new SetComparator());      // Sort the final list of subsets lexicographically
        return ans;
    }

    // Recursive function to generate subsets
    void subSet(List<int> A, int idx, List<int> currAns)
    {
        // If the current index is equal to the size of the input list, add the subset to the result
        if (idx == A.Count)
        {
            ans.Add(new List<int>(currAns));            // Create a copy of currAns before adding it to ans
            return;
        }

        currAns.Add(A[idx]);                            // Include the current element in the subset and move to the next index
        subSet(A, idx + 1, currAns);

        currAns.RemoveAt(currAns.Count - 1);            // Exclude the current element from the subset and move to the next index
        subSet(A, idx + 1, currAns);
    }
}


class SetComparator : IComparer<List<int>>
{
    // Compare and sort set array lexicographically
    public int Compare(List<int> arr1, List<int> arr2)
    {
        int n1 = arr1.Count;             // Number of elements in arr1
        int n2 = arr2.Count;             // Number of elements in arr2

        int i = 0;                       // Index for arr1
        int j = 0;                       // Index for arr2

        // Iterate through both arrays until one is exhausted
        while (i < n1 && j < n2)
        {
            // Compare elements at the current index
            if (arr1[i] != arr2[j])
            {
                return arr1[i] - arr2[j];        // Return the result of the comparison
            }
            i++;                                // Move to the next index in both arrays
            j++;
        }

        // If arr1 is longer than arr2, return 1
        if (i < n1)
        {
            return 1;
        }
        else if (j < n2)           // If arr2 is longer than arr1, return -1
        {
            return -1;
        }

        return 0;                 // Both arrays are equal, return 0
    }
}

/*
-1 indicates that arr1 should be sorted before arr2.
1 indicates that arr1 should be sorted after arr2.
0 indicates that arr1 and arr2 are considered equal in terms of sorting order.
*/