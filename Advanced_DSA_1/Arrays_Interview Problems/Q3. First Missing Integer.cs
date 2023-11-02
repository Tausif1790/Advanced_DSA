Given an unsorted integer array, A of size N. Find the first missing positive integer.
Note: Your algorithm should run in O(n) time and use constant space.

//Expected ==> TC: O(n), SC: O(1)

Input 1:
[1, 2, 0]
Input 2:
[3, 4, -1, 1]
Input 3:
[-8, -7, -6]

Output 1: 3
Output 2: 2
Output 3: 1

//---------------- Brute force // using 2 loops // TC: O(n^2), SC: O(1)---------------------//
class Solution {
    public int firstMissingPositive(List<int> A) {
        int n = A.Count;
        for(int i=1; i<=n; i++){
            bool found = false;
            for(int j=0; j<n; j++){
                if(i == A[j]){
                    found = true;
                    continue; // This will skip the rest of the inner loop for that particular iteration.
                }
            }
            if(!found){
                return i;
            }
        }
        return n+1;
    }
}

//---------------- 2. Using HashSet // TC: O(n), SC: O(n)---------------------//
class Solution {
    public int firstMissingPositive(List<int> A) {
       int n = A.Count;
       HashSet<int> sett = new HashSet<int>();

       // Add positive integers to the HashSet
       foreach(int el in A){
           if(el > 0){
               sett.Add(el);
           }
       }
       // Check for the first missing positive integer
       for(int i=1; i<=n; i++){
           if(!sett.Contains(i)){
               return i;
           }
       }
       return n+1; // If all positive integers from 1 to n are present, the missing one is n+1.
    }
}

//----------------3. Correct soln // TC: O(n), SC: O(1)--------------------------------------//
class Solution {
    public int firstMissingPositive(List<int> A) {
       int n = A.Count;
       int i = 0;

       while(i<n){
           int correctIdx = A[i] - 1;   // Calculate the correct index of the ith element
           // Check if the element is within the valid range and not already in its correct position
           if(A[i] >= 1 && A[i] <= n && A[i] != A[correctIdx]){    // element I care and it is not at correct position
                   swap(A, i, correctIdx);                          // Swap the element to its correct position
           }
           else{
               i++;
           }
       }

       for(int k=0; k<n; k++){
           if(k+1 != A[k]){
               return k+1;          // Return the first missing positive integer
           }
       }

       return n+1;
    }

    void swap(List<int> A, int a, int b){
        int temp = A[a];
        A[a] = A[b];
        A[b] = temp;
    }
}
