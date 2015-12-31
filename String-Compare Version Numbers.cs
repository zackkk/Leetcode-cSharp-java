Compare two version numbers version1 and version2.
If version1 > version2 return 1, if version1 < version2 return -1, otherwise return 0.

You may assume that the version strings are non-empty and contain only digits and the . character.
The . character does not represent a decimal point and is used to separate number sequences.
For instance, 2.5 is not "two and a half" or "half way to version three", 
it is the fifth second-level revision of the second first-level revision.

Here is an example of version numbers ordering:

0.1 < 1.1 < 1.2 < 13.37


public class Solution {
    // Straight forward implementation
    // Fill with zeros: for example, if version1 = "1.0.2", and version2 = "1.0", the I will convert the version2 to "1.0.0".
    public int CompareVersion(string version1, string version2) {
        string[] s1 = version1.Split('.');
        string[] s2 = version2.Split('.');
        for (int i = 0; i < Math.Max(s1.Length, s2.Length); i++) {
            int num1 = (i >= s1.Length ? 0 : int.Parse(s1[i])); 
            int num2 = (i >= s2.Length ? 0 : int.Parse(s2[i])); 
            if(num1 > num2) return 1;
            if(num1 < num2) return -1;
        }
        return 0;
    }
}