
//---------------------------------------------------------------------//
class Solution {
    public int solve(string A, string B) {
        int n = A.Length;
        int m = B.Length;
        int ans = 0;
        
        // store first idx of char in map
        Dictionary<char, int> dict = new Dictionary<char, int>();
        for(int i=0; i<n; i++){
            char charA = A[i];
            if(!dict.ContainsKey(charA)){
                dict.Add(charA, i);
            }
        }
        
        for(int j=0; j<m; j++){
            char charB = B[j];
            if(dict.ContainsKey(charB)){
                int idxA = dict[charB];
                int diff = j - idxA;
                ans = Math.Max(ans, diff);
            }
        }
        return ans;
        
    }
}

//----------------------------------------------------------//
/*
class Solution {
    public int solve(string A, string B) {
        // brute force
        int n = A.Length;
        int m = B.Length;
        int ans = 0;
        
        for(int i=0; i<n; i++){
            char a = A[i];
            for(int j=i; j<m; j++){
                char b = B[j];
                
                int compare = a.CompareTo(b);
                if(compare >= 0){
                    ans = Math.Max(ans, j - i);
                }
            }
        }
        return ans;
        
    }
}
*/
