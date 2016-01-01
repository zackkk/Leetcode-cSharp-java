Additive number is a string whose digits can form additive sequence.

A valid additive sequence should contain at least three numbers. Except for the first two numbers, 
each subsequent number in the sequence must be the sum of the preceding two.

For example:
"112358" is an additive number because the digits can form an additive sequence: 1, 1, 2, 3, 5, 8.

1 + 1 = 2, 1 + 2 = 3, 2 + 3 = 5, 3 + 5 = 8
"199100199" is also an additive number, the additive sequence is: 1, 99, 100, 199.
1 + 99 = 100, 99 + 100 = 199
Note: Numbers in the additive sequence cannot have leading zeros, so sequence 1, 2, 03 or 1, 02, 3 is invalid.

Given a string containing only digits '0'-'9', write a function to determine if its an additive number.


public class Solution {
    // Generate the first and second of the sequence, check if the rest of the string match the sum 
    public bool IsAdditiveNumber(string num) {
        int n = num.Length;
        for(int len1 = 1; len1 * 2 <= n; len1++){ // number 2 can be short, number 3 should be at least as long as number 1
            for(int len2 = 1; len1 + len2 + Math.Max(len1, len2) <= n; len2++){
                string str1 = num.Substring(0, len1);
                string str2 = num.Substring(len1, len2);
                if(IsValid(num, str1, str2)) return true;
            }
        }
        return false;
    }
    
    bool IsValid(string num, string str1, string str2){
        if(str1.Length > 1 && str1[0] == '0') return false;
        if(str2.Length > 1 && str2[0] == '0') return false;
        StringBuilder sb = new StringBuilder().Append(str1).Append(str2);
        long a = Int32.Parse(str1), b = Int32.Parse(str2);
        while(sb.Length < num.Length){
            sb.Append((a + b).ToString());
            long tmp = a;
            a = b;
            b = tmp + a;
        }
        return sb.ToString() == num;
    }
}