Write a program to find the n-th ugly number.

Ugly numbers are positive numbers whose prime factors only include 2, 3, 5. 
For example, 1, 2, 3, 4, 5, 6, 8, 9, 10, 12 is the sequence of the first 10 ugly numbers.

Note that 1 is typically treated as an ugly number.


public class Solution {
    // maintain three pointers for 2,3,5 
    // [1, 2, 3, 4, 5, 6, 8, ...]
    // 1×2, 2×2, 3×2, 4×2, 5×2, 6×2, 8×2, …
    // 1×3, 2×3, 3×3, 4×3, 5×3, 6×3, 8×3, …
    // 1×5, 2×5, 3×5, 4×5, 5×5, 6×5, 8×5, …
    public int NthUglyNumber(int n) {
        int[] ugly = new int[n];
        int ptr2 = 0, ptr3 = 0, ptr5 = 0;
        ugly[0] = 1;
        for(int i = 1; i < n; i++){
            ugly[i] = int.MaxValue;
            ugly[i] = Math.Min(Math.Min(ugly[ptr2] * 2, ugly[ptr3] * 3), ugly[ptr5] * 5); // choose min from three lists
            if(ugly[i] == ugly[ptr2] * 2) ptr2++; // move pointers accordingly
            if(ugly[i] == ugly[ptr3] * 3) ptr3++;
            if(ugly[i] == ugly[ptr5] * 5) ptr5++;
        }
        return ugly[n-1];
    }
}