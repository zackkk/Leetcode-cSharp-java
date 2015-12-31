Implement strStr().

Returns the index of the first occurrence of needle in haystack, or -1 if needle is not part of haystack.


public class Solution {
    // straight forward, may add corner cases check
    public int StrStr(string haystack, string needle) {
        for (int i = 0; i <= haystack.Length - needle.Length; i++) {
            if (haystack.Substring(i, needle.Length).Equals(needle)) return i;
        }
        return -1;
    }
}