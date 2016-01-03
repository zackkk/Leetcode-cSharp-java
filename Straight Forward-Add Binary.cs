Given two binary strings, return their sum (also a binary string).

For example,
a = "11"
b = "1"
Return "100".


public class Solution {
    // straight forward implementation
    public string AddBinary(string a, string b) {
        StringBuilder sb = new StringBuilder();
        int i = a.Length - 1;
        int j = b.Length - 1;
        int carry = 0;
        while(i >= 0 || j >= 0){
            int sum = carry;
            if(i >= 0) { sum += (a[i] - '0'); i--; }
            if(j >= 0) { sum += (b[j] - '0'); j--; }
            sb.Insert(0, sum % 2);
            carry = sum / 2;
        }
        if(carry != 0) sb.Insert(0, carry);
        return sb.ToString();
    }
}