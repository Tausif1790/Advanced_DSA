class Solution {
    public List<int> prevSmaller(List<int> A) {
        int n = A.Count;
        Stack<int> st = new Stack<int>();           // Stack to store idx of elements
        List<int> res = new List<int>();
        
        for(int i=0; i<n; i++){
            // While stack is not empty and current element is less than or equal to the element at the top of the stack
            while(st.Count > 0 && A[i] <= A[st.Peek()]){
                st.Pop();
            }
            
            // If stack is empty, there is no previous smaller element
            // Otherwise, the previous smaller element is the one at the top of the stack
            if(st.Count == 0){
                res.Add(-1);
            }
            else{
                res.Add(st.Peek());
            }

            // Push the current index onto the stack
            st.Push(i);
        }

        return res;
    }
}
