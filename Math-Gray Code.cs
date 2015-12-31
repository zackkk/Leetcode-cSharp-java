The gray code is a binary numeral system where two successive values differ in only one bit.

Given a non-negative integer n representing the total number of bits in the code, 
print the sequence of gray code. A gray code sequence must begin with 0.

For example, given n = 2, return [0,1,3,2]. Its gray code sequence is:

00 - 0
01 - 1
11 - 3
10 - 2


public class Solution {
    // [0]
    // n = 1 [0, 1]   +1
    // n = 2 [0, 1, 11, 10]   +2
    // n = 3 [0, 1, 11, 10, 110, 111, 101, 100]   +4
    public IList<int> GrayCode(int n) {
        IList<int> result = new List<int>();
        result.Add(0);
        for(int i = 1; i <= n; i++){
            int factor = (int)Math.Pow(2, i - 1);
            for(int j = result.Count - 1; j >= 0; j--){
                result.Add(result[j] + factor);
            }
        }
        return result;
    }
}