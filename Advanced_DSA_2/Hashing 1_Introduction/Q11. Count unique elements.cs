You are given an array A of N integers. Return the count of elements with frequncy 1 in the given array.

Input 1:
A = [3, 4, 3, 6, 6]
Input 2:
A = [3, 3, 3, 9, 0, 1, 0]

//--------------------------------------------------------------//
class Solution {
    public int solve(List<int> A) {
        int n = A.Count;
        int count = 0;
        Dictionary<int, int> dict = new Dictionary<int, int>();

        foreach(int el in A){
            if(dict.ContainsKey(el)){
                int freq = dict[el];
                dict[el] = freq + 1;
            }else{
                dict.Add(el, 1);
            }
        }

        for(int i=0; i<n; i++){
            if(dict.ContainsKey(A[i]) && dict[A[i]] == 1){
                count++;
            }
        }

        return count;
    }
}
