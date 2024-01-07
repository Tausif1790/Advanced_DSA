Given an array of integers A, sort the array into a wave-like array and return it.
In other words, arrange the elements into a sequence such that
a1 >= a2 <= a3 >= a4 <= a5..... 
NOTE: If multiple answers are possible, return the lexicographically smallest one.

Input 1:
A = [1, 2, 3, 4]
Input 2:
A = [1, 2]

Output 1:
[2, 1, 4, 3]
Output 2:
[2, 1]

//-----------------------------------------------//
class Solution {
    public List<int> wave(List<int> A) {
        int n = A.Count();
        A.Sort(new sortComparator());
        if(n == 1){
           return A;
        }

        int i = 0, j = 1;
        while(j<n){
            swap(A, i, j);
            i += 2;
            j += 2;
        }

        return A;
    }

    public void swap(List<int> A, int a, int b){
        int temp = A[a];
        A[a] = A[b];
        A[b] = temp;
    }
}

class sortComparator : IComparer<int>{
    public int Compare(int a, int b){
        return a.CompareTo(b);
    }
}

//TC: O(n log n)

/*
array = {5, 1, 3, 4, 2}
Sort the above array. 
array = {1, 2, 3, 4, 5}
Now swap adjacent elements in pairs.
swap(1, 2)
swap(3, 4)
Now, our array = {2, 1, 4, 3, 5}
And voila! the array is in the wave-form. 
*/