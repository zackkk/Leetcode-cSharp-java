Given an integer, write a function to determine if it is a power of two.


public class Solution {
    // tricks
    public bool IsPowerOfTwo(int n) {
        if(n <= 0) return false; // include n == 0
        return (n & (n - 1)) == 0;
    }
    
    public bool IsPowerOfTwo2(int n) {
        if(n <= 0) return false;
        int count = 0;
        for(int i = 0; i < 31; i++){ 
            if((n >> i & 1) != 0){
                count++;
            }
        }
        return count == 1;
    }
}