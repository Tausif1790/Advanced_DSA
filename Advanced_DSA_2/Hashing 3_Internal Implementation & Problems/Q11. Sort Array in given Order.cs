Given two arrays of integers A and B, Sort A in such a way that the relative order among the elements will be the same as those are in B.
For the elements not present in B, append them at last in sorted order.
Return the array A after sorting from the above method.
NOTE: Elements of B are unique.

Input 1:
A = [1, 2, 3, 4, 5, 4]
B = [5, 4, 2]
Input 2:
A = [5, 17, 100, 11]
B = [1, 100]
//--------------------------------------------//
class Solution {
    public List<int> solve(List<int> A, List<int> B) {
        int n = A.Count;
        int m = B.Count;
        List<int> result = new List<int>();
        Dictionary<long, int> dict = new Dictionary<long, int>();
        
        // Count the frequency of elements in list A.
        for(int i = 0; i < n; i++){
            // Update the frequency if the element is already in the dictionary.
            if(dict.ContainsKey(A[i])){
                int freq = dict[A[i]];
                dict[A[i]] = freq + 1;
            }
            // Add the element to the dictionary with frequency 1 if it's not present.
            else{
                dict.Add(A[i], 1);
            }
        }

        // Process list B and maintain the frequency of elements from list A.
        for(int j = 0; j < m; j++){
            int currEl = B[j];
            // Skip if the element is not in list A.
            if(!dict.ContainsKey(currEl)) continue;
            int times = dict[currEl];

            // Add the element to the result list according to its frequency.
            for(int k = 0; k < times; k++){
                result.Add(currEl);
            }
            // Remove the element from the dictionary to avoid duplication.
            dict.Remove(currEl);
        }

        // Process remaining elements in the dictionary (elements not in list B).
        List<long> remKeys = dict.Keys.ToList();
        remKeys.Sort();

        for(int j = 0; j < remKeys.Count; j++){
            long currEl = remKeys[j];
            // Skip if the element is not in list B.
            if(!dict.ContainsKey(currEl)) continue;
            int times = dict[currEl];

            // Add the element to the result list according to its frequency.
            for(int k = 0; k < times; k++){
                result.Add((int)currEl);
            }
        }

        // Return the merged and sorted result list.
        return result;
    }
}
