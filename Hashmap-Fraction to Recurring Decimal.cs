Given two integers representing the numerator and denominator of a fraction, return the fraction in string format.

If the fractional part is repeating, enclose the repeating part in parentheses.

For example,

Given numerator = 1, denominator = 2, return "0.5".
Given numerator = 2, denominator = 1, return "2".
Given numerator = 2, denominator = 3, return "0.(6)".


public class Solution {
    // straight implementation, use HashMap to generate repeating part
    public string FractionToDecimal(int numerator, int denominator) {
        string sign = (((numerator > 0) == (denominator > 0)) || (numerator == 0)) ? "" : "-";
        StringBuilder sb = new StringBuilder();
        long x = numerator, y = denominator;
        x = Math.Abs(x);
        y = Math.Abs(y);
        
        sb.Append(sign).Append(x / y);
        long remainder = x % y;
        if(remainder == 0) return sb.ToString();
        
        sb.Append(".");
        Dictionary<long, int> dict = new Dictionary<long, int>(); // position of repeating part
        while(!dict.ContainsKey(remainder)){
            dict[remainder] = sb.Length;
            sb.Append(remainder * 10 / y);
            remainder = remainder * 10 % y;
        }
        
        sb.Insert(dict[remainder], "(");
        sb.Append(")");
        return sb.ToString().Replace("(0)", "");  // delete "()" if there is no repeating part
    }
}