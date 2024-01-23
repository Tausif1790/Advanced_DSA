You are given an array of N integers, A1, A2 ,..., AN and an integer B. Return the of count of distinct numbers in all windows of size B.
Formally, return an array of size N-B+1 where i'th element in this array contains number of distinct elements in sequence Ai, Ai+1 ,..., Ai+B-1.
NOTE: if B > N, return an empty array.
A = [1, 2, 1, 3, 4, 3]
B = 3

A = [1, 1, 2, 2]
B = 1

Output 1: [2, 3, 3, 2]
Output 2: [1, 1, 1, 1]

//--------------------// O(n),O(B) //------------------------//
class Solution {
    public List<int> dNums(List<int> A, int B) {
        int n = A.Count;
        Dictionary<int, int> dict = new Dictionary<int, int>();
        List<int> result = new List<int>();
        if(B > n) return result;

        // first window
        for(int i=0; i<B; i++){
            if(dict.ContainsKey(A[i])){
                int freq = dict[A[i]];
                dict[A[i]] = freq + 1;
            }else{
                dict.Add(A[i], 1);
            }
        }
        result.Add(dict.Count);

        // rest of the window
        int left = 0;
        int right = B;
        while(right < n){
            // add el in dict
            if(dict.ContainsKey(A[right])){
                int freq = dict[A[right]];
                dict[A[right]] = freq + 1;
            }else{
                dict.Add(A[right], 1);
            }

            // remove el in dict
            if(dict.ContainsKey(A[left])){
                if(dict[A[left]] == 1) dict.Remove(A[left]);
                else{
                    int freq = dict[A[left]];
                    dict[A[left]] = freq - 1;
                }
            }
            result.Add(dict.Count);
            left++;
            right++;
        }
        return result;
    }
}

//-------------------------------------------------------------//
class Solution {
    public List<int> dNums(List<int> A, int B) {
        int n=A.Count;
        List<int> ret = new List<int>();
        Dictionary <int, int> m = new Dictionary<int, int>();
        for(int i=0; i<n; i++){
            //increase key
            if(m.ContainsKey(A[i]))m[A[i]]++;
            else m.Add(A[i], 1);
            if(i-B+1>=0){
    
                //decrease key
                ret.Add(m.Count);
                m[A[i-B+1]]--;
    
                //remove if count becomes 0
                if(m.ContainsKey(A[i - B + 1]) && m[A[i-B+1]]==0)m.Remove(A[i-B+1]);
            }
        }
        return ret;
    }
}