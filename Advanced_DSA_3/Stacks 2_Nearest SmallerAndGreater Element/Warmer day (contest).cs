class Solution {
    public List<int> solve(List<int> A) {
        int n = A.Count;
        Stack<int> st = new Stack<int>();
        List<int> result = new List<int>(new int[n]);
        
        for(int i=n-1; i>=0; i--){
            int currVal = A[i];
            
            while(st.Count != 0 && A[i] >= st.Peek()){
                st.Pop();
            }
            
            if(st.Count != 0){
                result[i] = st.Peek() - A[i];
            }
            else{
                result[i] = -1;
            }
            st.Push(A[i]);
        }
        return result;
    }
}

