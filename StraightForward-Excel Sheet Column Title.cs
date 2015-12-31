Given a positive integer, return its corresponding column title as appear in an Excel sheet.

For example:

    1 -> A
    2 -> B
    3 -> C
    ...
    26 -> Z
    27 -> AA
    28 -> AB 


public class Solution {
    // CAZ <- 3 * 26^2 + 1 * 26^1 + 26 * 26^0
    // mod result is 0 ~ 25, A - Z is 1 ~ 26, so need to use (n - 1)
    public string ConvertToTitle(int n) {
        StringBuilder sb = new StringBuilder();
        while (n > 0) {
            sb.Insert(0, (char)((n - 1) % 26 + 'A'));
            n = (n - 1) / 26;
        }
        return sb.ToString();
    }
}