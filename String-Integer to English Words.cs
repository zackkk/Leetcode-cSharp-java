Convert a non-negative integer to its english words representation. Given input is guaranteed to be less than 231 - 1.

For example,
123 -> "One Hundred Twenty Three"
12345 -> "Twelve Thousand Three Hundred Forty Five"
1234567 -> "One Million Two Hundred Thirty Four Thousand Five Hundred Sixty Seven"


public class Solution {
    // group for each three digits
    string[] lessThan20 = {"", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", 
                               "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"};
    string[] tens = {"", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"};
    string[] thousands = {"", "Thousand", "Million", "Billion"};  // "" is used for 0 based index
    
    // numerous corner cases
    public string NumberToWords(int num) {
        if(num == 0) return "Zero";
        
        int thousandsIndex = 0;
        StringBuilder sb = new StringBuilder();
        while(num != 0){
            if(num % 1000 != 0)
                sb.Insert(0, Helper(num % 1000) + thousands[thousandsIndex] + " ");
            
            num /= 1000;
            thousandsIndex++;
        }
        return sb.ToString().Trim();
    }
    
    // Generate string for number less than 1000
    string Helper(int num){
        if(num == 0) return "";
        if(num < 20) return lessThan20[num] + " ";
        if(num < 100) return tens[num / 10] + " " + Helper(num % 10);
        return lessThan20[num / 100] + " Hundred " + Helper(num % 100);
    }
}