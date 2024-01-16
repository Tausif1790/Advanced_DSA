Problem Description
Given an array of integers A.
A represents a histogram i.e A[i] denotes the height of the ith histogram's bar. Width of each bar is 1.
Find the area of the largest rectangle formed by the histogram.
A = [2, 1, 5, 6, 2, 3]
Output 1: 10

//------------------------// O(n), O(n) //----------------------------//
class Solution {
    public int largestRectangleArea(List<int> A) {
        int n = A.Count;
        int maxArea = 0;
        List<int> leftSmallerEl = leftSmaller(A);        // Reference to leftSmaller function
        List<int> rightSmallerEl = rightSmaller(A);       // Reference to rightSmaller function

        for(int i=0; i<n; i++){
            int height = A[i];
            int widht = rightSmallerEl[i] - leftSmallerEl[i] - 1;  // Width calculation
            int currArea = height*widht;
            maxArea = Math.Max(maxArea, currArea);
        }
        return maxArea;
    }

    public List<int> leftSmaller(List<int> A){
        List<int> res = new List<int>();        
        Stack<int> st = new Stack<int>();              // Stack to store idx of elements

        for(int i=0; i<A.Count; i++){
            while(st.Count != 0 && A[i] <= A[st.Peek()]){
                st.Pop();
            }

            if(st.Count != 0){
                res.Add(st.Peek());                   // Add left smaller element's index
            }
            else{
                res.Add(-1);                          // No left smaller element
            }
            st.Push(i);
        }
        return res;
    }

    public List<int> rightSmaller(List<int> A){
        int n = A.Count;
        List<int> res = new List<int>(new int[n]);        
        Stack<int> st = new Stack<int>();              // Stack to store idx of elements

        for(int i=n-1; i>=0; i--){
            while(st.Count != 0 && A[i] <= A[st.Peek()]){
                st.Pop();
            }

            if(st.Count != 0){
                res[i] = st.Peek();                     // Assign right smaller element's index
            }
            else{
                res[i] = n;                           // No right smaller element (use size of array to cal the width)
            }
            st.Push(i);
        }
        return res;
    }
}


// Brute force
// class Solution {
//     public int largestRectangleArea(List<int> A) {
//         int n = A.Count;
//         int maxArea = 0;
//         for(int i=0; i<n; i++){
//             int minHeight = A[i];
//             for(int j=i; j<n; j++){
//                 minHeight = Math.Min(minHeight, A[j]);
//                 int width = j - i + 1;
//                 maxArea = Math.Max(maxArea, minHeight*width);
//             }
//         }
//         return maxArea;
//     }
// }