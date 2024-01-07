Given an array with N objects colored red, white, or blue, sort them so that objects of the same color are adjacent, with the colors in the order red, white, and blue.
We will represent the colors as,
red -> 0
white -> 1
blue -> 2
Note: Using the library sort function is not allowed.

Input 1 : A = [0, 1, 2, 0, 1, 2]
Input 2: A = [0]

Output 1: [0, 0, 1, 1, 2, 2]
Output 2: [0]

//-----------------// this is using library function which is not allowed //--------------//
class Solution {
    public List<int> sortColors(List<int> A) {
        if(A.Count == 1){
            return A;
        }
        A.Sort((a,b) => a - b);
        return A;
    }
}

//----------// approach 1: using count sort ans using space: O(1), TC: O(n) //-----------//
class Solution {
    public List<int> sortColors(List<int> A) {
        List<int> freq = new List<int>(new int[3]);

        foreach(int el in A){
            freq[el] = freq[el] + 1;
        }

        int idx = 0;
        for(int i=0; i<freq.Count; i++){
            int fr = freq[i];
            for(int j=0; j<fr; j++){
                A[idx] = i;
                idx++;
            }
        }

        return A;
    }
}

//--------------// iterate :- using 3 pointers //--------------------//
class Solution {
    public List<int> sortColors(List<int> A) {
        int zero = 0, two = A.Count - 1;
        
        for (int i = 0; i <= two;)
        {
            if (A[i] == 0)
            {
                Swap(A, i, zero);
                zero++;
                i++;
            }
            else if (A[i] == 2)
            {
                Swap(A, i, two);
                two--;
            }
            else
            {
                i++;
            }
        }
        return A;
    }

    public void Swap(List<int> A, int i, int j)
    {
        int temp = A[i];
        A[i] = A[j];
        A[j] = temp;
    }
}

