using System;
using System.Collections.Generic;
class Solution {
    public string solve(int A) {
        Queue<int> myQueue = new  Queue<int>();

        myQueue.Enqueue(1);
        myQueue.Enqueue(2);

        int i = 1;                  // curr position
        int AthNumber = 0;
        while(AthNumber<=A){                            //result.Count < A
            int x = myQueue.Dequeue();
            int a = x*10 + 1;
            int b = x*10 + 2;

            if(IsPalindrome(a) && IsNumberOfDigitsEven(a)){
                AthNumber++;
                if(AthNumber == A) return a.ToString();
            }
            if(IsPalindrome(b) && IsNumberOfDigitsEven(b)){
                AthNumber++;
                if(AthNumber == A) return b.ToString();
            }


            myQueue.Enqueue(a);
            myQueue.Enqueue(b);
            i += 2;
        }

        return "-1";
    }

    public bool IsPalindrome(int num) {
        string strNum = num.ToString();
        int left = 0;
        int right = strNum.Length - 1;

        while (left < right) {
            if (strNum[left] != strNum[right]) {
                return false;
            }
            left++;
            right--;
        }
        return true;
    }

    static bool IsNumberOfDigitsEven(int number) {
        string numberString = Math.Abs(number).ToString();
        return (numberString.Length % 2 == 0);
    }
}
