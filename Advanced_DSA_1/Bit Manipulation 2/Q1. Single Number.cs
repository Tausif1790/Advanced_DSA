Problem Description
Given an array of integers A, every element appears twice except for one. Find that integer that occurs once.

NOTE: Your algorithm should have a linear runtime complexity. Could you implement it without using extra memory?

Input 1: A = [1, 2, 2, 3, 1]
Input 2: A = [1, 2, 2]

Output 1: 3
Output 2: 1

Expected: TC: O(n), SC: O(1).

//---------------------Brute force //TC: O(n^2), SC: O(1).------------------------//
nexted loop 

//------------------Using HashMap // TC: O(n), SC: O(n) --------------------------------------//
class Solution {
    public int singleNumber(List<int> A) {
        int n = A.Count;
        // store all el in Dictionary
        Dictionary<int, int> dict = new Dictionary<int, int>();
        // Iterate through the list and count the frequency of each element.
        foreach(int el in A){
            if(dict.ContainsKey(el)){
                int freq = dict[el];
                dict[el] = freq + 1;
            }
            else{
                dict.Add(el, 1);
            }
        }

        // Iterate through the dictionary's keys to find the element with a frequency of 1.
        foreach(int key in dict.Keys){
            if(dict[key] == 1){
                return key;
            }
        }

        return 1;
    }
}

//----------------// Using XOR operator // TC: O(n), SC: O(1) -----------------//
class Solution {
    public int singleNumber(List<int> A) {
        int n = A.Count;
        int ans = 0;

        for(int i=0; i<n; i++){
            ans = ans^A[i];            //1^2^2^3^1 => 3
        }
        return ans;
    }
}

