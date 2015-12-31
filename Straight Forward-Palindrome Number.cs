Determine whether an integer is a palindrome. Do this without extra space.


public class Solution {
    // compare half of digits 
    public bool IsPalindrome(int x) {
        if ((x < 0) || (x > 0 && x % 10 == 0)) return false;
        int reverse = 0;
        while (x > reverse){ // point ! 
            reverse = reverse * 10 + x % 10;
            x /= 10;
        }
        return x == reverse || x == reverse / 10; // even and odd 
    }
}