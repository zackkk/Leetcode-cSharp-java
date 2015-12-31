Given two numbers represented as strings, return multiplication of the numbers as a string.

Note: The numbers can be arbitrarily large and are non-negative.


public class Solution {
    // Reverse index
    public string Multiply(string num1, string num2) {
        int m = num1.Length, n = num2.Length;
        int[] product = new int[m+n];
        for(int i = m - 1; i >= 0; i--){
            for(int j = n - 1; j >= 0; j--){
                int index = m - 1 - i + n - 1 - j;
                product[index] += (num1[i] - '0') * (num2[j] - '0');
                product[index+1] += (product[index] / 10);
                product[index] %= 10;
            }
        }
        
        StringBuilder sb = new StringBuilder();
        for(int i = m + n - 1; i > 0; i--){
            if(product[i] == 0 && sb.Length == 0) continue; // zeros at the beginning
            sb.Append(product[i]);
        }
        sb.Append(product[0]); // special case: only one "0"
        return sb.ToString();
    }
}