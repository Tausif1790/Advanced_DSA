Given an array of integers A of size N and an integer B.
The College library has N books. The ith book has A[i] number of pages.
You have to allocate books to B number of students so that the maximum number of pages allocated to a student is minimum.

A book will be allocated to exactly one student.
Each student has to be allocated at least one book.
Allotment should be in contiguous order, for example: A student cannot be allocated book 1 and book 3, skipping book 2.
Calculate and return that minimum possible number.

NOTE: Return -1 if a valid assignment is not possible.

Input 1:
A = [12, 34, 67, 90]
B = 2
Input 2:
A = [12, 15, 78] 
B = 4

Output 1: 113
Output 2: -1

//---------------------------------------------------------------//
public class Solution {
    public int Books(List<int> A, int B) {
        int n = A.Count;
        int start = MaxElement(A);  // Comment: Find the maximum element in the list A
        int end = Sum(A);           // Comment: Find the sum of all elements in the list A
        int ans = -1;                // Comment: Initialize the answer to -1

        // only addition line from Painter paint the board problem
        if (n < B) {
            return -1;            // Comment: Return -1 if the number of books is less than the number of students
        }

        while (start <= end) {
            int midPages = (start + end) >> 1;
            if (IsPossible(A, B, midPages)) {
                ans = midPages;              // Comment: Update the answer if it's possible to allocate books
                end = midPages - 1;
            } else {
                start = midPages + 1;
            }
        }

        return ans;
    }

    public bool IsPossible(List<int> A, int B, int mid) {
        int sum = 0, student = 1;
        foreach (int el in A) {
            sum += el;
            if (sum > mid) {
                student++;
                sum = el;
            }
        }
        if (student <= B) {
            return true;          // Comment: Check if it's possible to allocate books to B students
        }
        return false;
    }

    public int MaxElement(List<int> A) {
        int ans = int.MinValue;
        foreach (int el in A) {
            if (el > ans) {
                ans = el;
            }
        }
        return ans;           // Comment: Return the maximum element in the list A
    }

    public int Sum(List<int> A) {
        int sum = 0;
        foreach (int el in A) {
            sum += el;
        }
        return sum;  // Comment: Return the sum of all elements in the list A
    }
}

//--------------------// this shit is not working //-------------------------//

class Solution {
    public int books(List<int> A, int B) {
        int n = A.Count;
        int start = maxEl(A);
        int end = sum(A);
        int ans = -1;

        while(start <= end){
            int midPages = (start + end) >> 1;

            int isPossible = IsPossible(A, B, midPages);
            if(isPossible == 1){
                ans = midPages;
                end = midPages - 1;
            }
            else if(isPossible == 2){
                end = midPages - 1;
            }
            else{
                start = midPages + 1;
            }
        }

        return ans;
    }

    public int IsPossible(List<int> A, int B, int mid){
        int sum = 0, student = 1;
        foreach(int el in A){
            sum += el;
            if(sum > mid){
                student++;
                sum = el;
            }
        }
        if(student == B){
            return 1;
        }
        else if(student < B){
            return 2;
        }

        return 0;
    }

    public int maxEl(List<int> A){
        int ans = int.MinValue;
        foreach(int el in A){
            if(el > ans){
                ans = el;
            }
        }
        return ans;
    }

    public int sum(List<int> A){
        int sum = 0;
        foreach(int el in A){
           sum += el;
        }
        return sum;
    }
}
