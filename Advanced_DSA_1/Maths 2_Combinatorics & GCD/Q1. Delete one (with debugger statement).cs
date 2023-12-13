Given an integer array A of size N. You have to delete one element such that
 the GCD(Greatest common divisor) of the remaining array is maximum.
Find the maximum value of GCD.

A = [12, 15, 18]
A = [5, 15, 30]

Output 1: 6
Output 2: 15
//---------------------------------------------------------------------------//
class Solution {
    // Function to find the maximum GCD after deleting one element from the array
    public int solve(List<int> A) {
        int n = A.Count;
        List<int> pfGcd = prefixGCD(A);
        List<int> sfGcd = suffixGCD(A);
        int ans = 0;

        // for 1st idx and last idx // these are not included in a loop because of edge cases
        int afterDeleting1stIdx = sfGcd[1];
        int afterDeletingLastIdx = pfGcd[n-2];
        ans = Math.Max(afterDeleting1stIdx, afterDeletingLastIdx);

        // Loop through the elements and find the maximum GCD after deleting an element
        for(int i=1; i<n-1; i++){
            int currGdc = gcd(pfGcd[i-1], sfGcd[i+1]);
            ans = Math.Max(ans, currGdc);
        }

        return ans;
    }

    // Function to compute the prefix GCD of the array
    List<int> prefixGCD(List<int> A){
        int n = A.Count;
        List<int> pfg = new List<int>();
        pfg.Add(A[0]);

        // Loop through the elements and calculate the prefix GCD
        for(int i=1; i<n; i++){
            int currGcd = gcd(pfg[i-1], A[i]);
            pfg.Add(currGcd);
        }

        return pfg;
    }

    // Function to compute the suffix GCD of the array
    List<int> suffixGCD(List<int> A){
        int n = A.Count;
        List<int> sfg = new List<int>(new int[n]); // this creates a list of n size, all values are zeros
        sfg[n-1] = A[n-1]; 

        // Loop through the elements and calculate the suffix GCD
        for(int i=n-2; i>=0; i--){
            int currGcd = gcd(sfg[i+1], A[i]);
            sfg[i] = currGcd; // Update the value at index i
        }

        return sfg;
    }

    // Function to calculate the Greatest Common Divisor (GCD) using Euclidean algorithm
    public int gcd(int A, int B){
        if(B == 0){
            return A;
        }
        return gcd(B, A%B);
    }
}

//------------------------// with better naming convention //-------------------------------------//
class Solution {
    // Function to find the maximum GCD after deleting one element from the array
    public int FindMaxGCDAfterDeletion(List<int> array) {
        int length = array.Count;
        List<int> prefixGCDs = ComputePrefixGCDs(array);
        List<int> suffixGCDs = ComputeSuffixGCDs(array);
        int maxGCD = 0;

        // Calculate the maximum GCD after deleting the first and last elements
        int afterDeletingFirstIndex = suffixGCDs[1];
        int afterDeletingLastIndex = prefixGCDs[length - 2];
        maxGCD = Math.Max(afterDeletingFirstIndex, afterDeletingLastIndex);

        // Loop through the elements and find the maximum GCD after deleting an element
        for(int i = 1; i < length - 1; i++) {
            int currentGCD = gcd(prefixGCDs[i - 1], suffixGCDs[i + 1]);
            maxGCD = Math.Max(maxGCD, currentGCD);
        }

        return maxGCD;
    }

    // Function to compute the prefix GCD of the array
    List<int> ComputePrefixGCDs(List<int> array) {
        int length = array.Count;
        List<int> prefixGCDs = new List<int>();
        prefixGCDs.Add(array[0]);

        // Loop through the elements and calculate the prefix GCD
        for(int i = 1; i < length; i++) {
            int currentGCD = gcd(prefixGCDs[i - 1], array[i]);
            prefixGCDs.Add(currentGCD);
        }

        return prefixGCDs;
    }

    // Function to compute the suffix GCD of the array
    List<int> ComputeSuffixGCDs(List<int> array) {
        int length = array.Count;
        List<int> suffixGCDs = new List<int>(new int[length]); // this creates a list of n size, all values are zeros
        suffixGCDs[length - 1] = array[length - 1];

        // Loop through the elements and calculate the suffix GCD
        for(int i = length - 2; i >= 0; i--) {
            int currentGCD = gcd(suffixGCDs[i + 1], array[i]);
            suffixGCDs[i] = currentGCD; // Update the value at index i
        }

        return suffixGCDs;
    }

    // Function to calculate the Greatest Common Divisor (GCD) using Euclidean algorithm
    public int gcd(int a, int b) {
        if(b == 0) {
            return a;
        }
        return gcd(b, a % b);
    }
}


//---------------------------------// with debugger statement //------------------------------------------//
class Solution {
    // Function to find the maximum GCD after deleting one element from the array
    public int solve(List<int> A) {
        int n = A.Count;
        List<int> pfGcd = prefixGCD(A);
        List<int> sfGcd = suffixGCD(A);
        int ans = 0;

        // for 1st idx and last idx // these are not included in a loop because of edge cases
        int afterDeleting1stIdx = sfGcd[1];
        int afterDeletingLastIdx = pfGcd[n-2];
        ans = Math.Max(afterDeleting1stIdx, afterDeletingLastIdx);

        Console.WriteLine("Debug: afterDeleting1stIdx = " + afterDeleting1stIdx);
        Console.WriteLine("Debug: afterDeletingLastIdx = " + afterDeletingLastIdx);

        for(int i=1; i<n-1; i++){
            // Calculate the GCD after deleting an element
            int currGdc = gcd(pfGcd[i-1], sfGcd[i+1]);
            ans = Math.Max(ans, currGdc);

            Console.WriteLine("Debug: i = " + i + ", currGdc = " + currGdc);
        }

        return ans;
    }

    // Function to compute the prefix GCD of the array
    List<int> prefixGCD(List<int> A){
        int n = A.Count;
        List<int> pfg = new List<int>();
        pfg.Add(A[0]);
        
        for(int i=1; i<n; i++){
            // Calculate the GCD for the prefix
            int currGcd = gcd(pfg[i-1], A[i]);
            pfg.Add(currGcd);

            // Debug statement for prefixGCD
            Console.WriteLine($"Debug: prefixGCD - i = {i}, A[i] = {A[i]}, pfg[i - 1] = {pfg[i - 1]}, currGcd = {currGcd}");
        }
        
        Console.WriteLine(); // Add an empty line for better readability in the output
        return pfg;
    }

    // Function to compute the suffix GCD of the array
    List<int> suffixGCD(List<int> A){
        int n = A.Count;
        List<int> sfg = new List<int>(new int[n]); // this creates a list of n size, all values are zeros
        sfg[n-1] = A[n-1]; 

        for(int i=n-2; i>=0; i--){
            // Calculate the GCD for the suffix
            int currGcd = gcd(sfg[i+1], A[i]);
            sfg[i] = currGcd; // Update the value at index i

            // Debug statement for suffixGCD
            Console.WriteLine($"Debug: suffixGCD - i = {i}, A[i] = {A[i]}, sfg[i + 1] = {sfg[i + 1]}, currGcd = {currGcd}");
        }
        
        Console.WriteLine(); // Add an empty line for better readability in the output
        return sfg;
    }

    // Function to calculate the Greatest Common Divisor (GCD) using Euclidean algorithm
    public int gcd(int A, int B){
        if(B == 0){
            return A;
        }
        return gcd(B, A%B);
    }
}
