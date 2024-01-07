Problem Description
You are given an array A of N elements. Sort the given array in increasing order of number
 of distinct factors of each element, i.e., element having the least number 
 of factors should be the first to be displayed and the number having highest number
  of factors should be the last one. If 2 elements have same number of factors,
 then number with less value should come first.
Note: You cannot use any extra space

Input 1:
A = [6, 8, 9]
Input 2:
A = [2, 4, 7]

Output 1:
[9, 6, 8]
Output 2:
[2, 7, 4]

//------------------------------------------------------//
using System.Collections.Generic;

class Solution {
    public List<int> solve(List<int> A) {
        A.Sort(new FactorComparator());          // Sorted using FactorComparator
        return A;
    }
}

class FactorComparator : IComparer<int>{
    // Compare method to determine the order based on the number of factors
    public int Compare(int a, int b){
        int fa = CountFactors(a);        // Count factors for number a
        int fb = CountFactors(b);       // Count factors for number b

        if(fa < fb){
            return -1;                   // a should come before b
        }
        else if(fa > fb){
            return 1;                    // b should come before a
        }
        else{
            if(a < b){
                return -1;               // a should come before b if they have the same number of factors
            }
            else if(a > b){
                return 1;                // b should come before a if they have the same number of factors
            }
            return 0;                    // a and b are equal in terms of factors
        }
    }

    // CountFactors method to calculate the number of factors for a given number
    public int CountFactors(int number) {
        if (number <= 0) {
            return 0;
        }
        int count = 0;
        for (int i = 1; i*i <= number; i++) {
            if (number % i == 0) {
                count++;
                if (number / i != i) {
                    count++;
                }
            }
        }
        return count;  // Return the total count of factors
    }
}
