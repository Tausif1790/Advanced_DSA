using System;
using System.IO;

class MAIN  {
    public static void Main(string[] args) {
        int n = int.Parse(Console.ReadLine());

        int[] dp = new int[n + 1];
        // Assigning -1 to all elements of the array
        for (int i = 0; i < dp.Length; i++)
        {
            dp[i] = -1;
        }
        
        int ans = fib1(n, dp);
        //int ans = fib3(n);
        Console.WriteLine(ans);
    }

// Memorization
public static int fib(int n, int[] dp){
    if(n == 0 || n == 1){
        // Base case: return n for fib(0) and fib(1)
        return n;
    }

    if(dp[n] != -1){
        // If already calculated, return stored result
        return dp[n];
    }

    int first = fib(n - 1, dp);
    int second = fib(n - 2, dp);
    
    // Memorize and store the result for future use
    dp[n] = first + second;
    
    return dp[n];
}

// Tabulation approach
public static int fib2(int n, int[] dp){
    if(n == 0 || n == 1){
        // Base case: return n for fib(0) and fib(1)
        return n;
    }

    // Initialize base cases
    dp[0] = 0;
    dp[1] = 1;

    // Populate the dp array in a bottom-up manner
    for(int i=2; i<=n; i++){
        dp[i] = dp[i-1] + dp[i-2];
    }

    // Return the final result
    return dp[n];
}

// Space-Optimized approach
public static int fib3(int n){
    if(n == 0 || n == 1){
        // Base case: return n for fib(0) and fib(1)
        return n;
    }

    // Initialize variables to store the last two Fibonacci numbers
    int a = 0;
    int b = 1;
    int c = -1;

    // Calculate Fibonacci numbers in a space-optimized manner
    for(int i=2; i<=n; i++){
        c = a + b;
        a = b;
        b = c;
    }

    // Return the final result
    return c;
}

}