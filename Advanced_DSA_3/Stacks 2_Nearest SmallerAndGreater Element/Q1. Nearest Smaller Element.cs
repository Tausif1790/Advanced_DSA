Given an array A, find the nearest smaller element G[i] for every element A[i] in the array such that the element has an index smaller than i.
More formally,
G[i] for an element A[i] = an element A[j] such that
j is maximum possible AND
j < i AND
A[j] < A[i]
Elements for which no smaller element exist, consider the next smaller element as -1.

Input: A = [4, 5, 2, 10, 8]
Output: [-1, 4, -1, 2, 2]

//------------------// O(n), O(n) /---------------------------//
class Solution {
    public List<int> prevSmaller(List<int> A) {
        int n = A.Count;
        Stack<int> st = new Stack<int>();         // Stack to store elements
        List<int> res = new List<int>();          // List to store previous smaller elements
        
        for(int i=0; i<n; i++){
            while(st.Count > 0 && A[i] <= st.Peek()){
                st.Pop();                         // Pop elements greater than or equal to A[i] from the stack
            }

            if(st.Count == 0){
                res.Add(-1);                      // If no smaller element found, add -1 to the result list
            }
            else{
                res.Add(st.Peek());               // Add the top element from the stack (previous smaller element)
            }

            st.Push(A[i]);                            // Push the current element's index onto the stack
        }

        return res;
    }
}

// Brute force
class Solution {
    public List<int> prevSmaller(List<int> A) {
        int n = A.Count;
        List<int> res = new List<int>();
        res.Add(-1);

        for(int i=1; i<n; i++){
            for(int j=i-1; j>=0; j--){
                if(A[i] > A[j]){
                    res.Add(A[j]);
                    break;
                }
                if(j == 0){
                    res.Add(-1);
                }
            }
        }

        return res;
    }
}

