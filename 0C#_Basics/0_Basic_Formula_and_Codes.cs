//---------------// GCD, LCM //---------------------//
1. a*b = gcd(a, b)*lcm(a, b);

//By Euclid algo GCD

class Solution {
    public int gcd(int A, int B) {
        if(B == 0){
            return A;
        }
        return gcd(B, A%B);
    }
}
//TC: Log(max(a,b))

//--------------------// Sorting //--------------------------------//
intervals.Sort((a, b) => a.start - b.start);       // 1st way //TC: O(nlog(n))  //SC: O(1)

intervals.Sort(new IntervalSort());                // 2nd way
class IntervalSort : IComparer<Interval>{
    public int Compare(Interval a, Interval b){
        if(a.start < b.start){
            return -1;
        }
        else if(a.start > b.start){
            return 1;
        }
        return 0;
    }
}

//-------------------// //Right most significant bit // example:- 000010 //---------------//
int rmsb = x & twosCompliment(x);
int twosCompliment(int a){
        int num = ~a;
        num = num + 1;
        return num;
    }

//----------------// count factor //-----------------------------------------//
public int CountFactors(int number) {
        if (number <= 0) {
            return 0;
        }
        int count = 0;
        for (int i = 1; i <= Math.Sqrt(number); i++) {
            if (number % i == 0) {
                count++;
                if (number / i != i) {
                    count++;
                }
            }
        }
        return count;
    }

//------------// Compare //---------------------------//
if(A < B){
    return -1;
}
else if(A > B){
    return 1;
}
else{
    return 0;
}
return 0;

(or)
return Math.Sign(pointA - pointB);
(or)
return pointA.CompareTo(pointB);

A.Sort((a,b) => a - b);                 // we can do without create comparator class
