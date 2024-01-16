Given an array A, find the next greater element G[i] for every element A[i] in the array.
The next greater element for an element A[i] is the first greater element on the right side of A[i] in the array, A.
More formally:
G[i] for an element A[i] = an element A[j] such that 
    j is minimum possible AND 
    j > i AND
    A[j] > A[i]

Input 1: A = [4, 5, 2, 10] 
Output 1: [5, 10, 10, -1]

//----------------//O(n), O(n) //-----------------------------//
class Solution {
    public List<int> nextGreater(List<int> A) {
        int  n = A.Count;
        List<int> res = new List<int>(new int[n]);
        Stack<int> st = new Stack<int>();

        for(int i=n-1; i>=0; i--){
            while(st.Count != 0 && A[i] >= st.Peek()){
                st.Pop();
            }

            if(st.Count != 0){
                res[i] = st.Peek();
            }
            else{
                res[i] = -1;
            }
            st.Push(A[i]);
        }

        return res;
    }
}
