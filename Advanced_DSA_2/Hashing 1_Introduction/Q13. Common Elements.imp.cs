Problem Description
Given two integer arrays, A and B of size N and M, respectively. Your task is to find all the common elements in both the array.
NOTE:
Each element in the result should appear as many times as it appears in both arrays.
The result can be in any order.

Input 1:
 A = [1, 2, 2, 1]
 B = [2, 3, 1, 2]
Input 2:
 A = [2, 1, 4, 10]
 B = [3, 6, 2, 10, 10]

 Output 1: [1, 2, 2]
Output 2: [2, 10]

//----------------------------------------------------------//
class Solution {
    public List<int> solve(List<int> A, List<int> B) {
        int n = A.Count;
        int m = B.Count;
        Dictionary<int, int> dictA = new Dictionary<int, int>();
        Dictionary<int, int> dictB = new Dictionary<int, int>();
        List<int> ans = new List<int>();

        // Count the frequency of elements in list A
        foreach(int el in A){
            if(dictA.ContainsKey(el)){
                int freq = dictA[el];
                dictA[el] = freq + 1;
            }else{
                dictA.Add(el, 1);
            }
        }

        // Count the frequency of elements in list B
        foreach(int el in B){
            if(dictB.ContainsKey(el)){
                int freq = dictB[el];
                dictB[el] = freq + 1;
            }else{
                dictB.Add(el, 1);
            }
        }

        // Iterate through the keys of dictA to find the intersection with frequency considerations
        foreach(int keyA in dictA.Keys){
            if(dictB.ContainsKey(keyA)){
                int freqAB = Math.Min(dictA[keyA], dictB[keyA]);        // Determine the minimum frequency of the element in both lists
                while(freqAB > 0){                                      // Add the element to the result list freqAB times
                    ans.Add(keyA);                  
                    freqAB--;
                }
            }
        }

        return ans;
    }
}
