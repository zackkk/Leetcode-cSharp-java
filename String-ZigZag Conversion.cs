he string "PAYPALISHIRING" is written in a zigzag pattern on a given number of rows like this: 
(you may want to display this pattern in a fixed font for better legibility)

P   A   H   N
A P L S I I G
Y   I   R
And then read line by line: "PAHNAPLSIIGYIR"

Write the code that will take a string and make this conversion given a number of rows:

string convert(string text, int nRows);
convert("PAYPALISHIRING", 3) should return "PAHNAPLSIIGYIR".


public class Solution {
    // string buffer for each row + two loops: one for downward, and one for upward
    public string Convert(string s, int numRows){
        StringBuilder[] sb = new StringBuilder[numRows];
        for (int row = 0; row < numRows; row++) sb[row] = new StringBuilder();

        int i = 0;
        while (i < s.Length){
            for (int row = 0; row < numRows && i < s.Length; row++){
                sb[row].Append(s[i++]);
            }
            for (int row = numRows - 2; row > 0 && i < s.Length; row--){
                sb[row].Append(s[i++]);
            }
        }

        // concatenate all string buffers
        for (int row = 1; row < numRows; row++){
            sb[0].Append(sb[row]);
        }
        return sb[0].ToString();
    }
}