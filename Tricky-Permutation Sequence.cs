The set [1,2,3,…,n] contains a total of n! unique permutations.

By listing and labeling all of the permutations in order,
We get the following sequence (ie, for n = 3):

"123"
"132"
"213"
"231"
"312"
"321"
Given n and k, return the kth permutation sequence.


public class Solution {
    // pattern finding
    // {1,2,3,4}
    // {1}{2,3,4} => permutation of {2,3,4} => has 6 elements
    // {2}{1,3,4} => permutation of {1,3,4} => has 6 elements
    // {3}{1,2,4} => permutation of {1,2,4} => has 6 elements
    // {4}{1,2,3} => permutation of {1,2,3} => has 6 elements
    // if k = 14  => k-- (start from 0)
    // k / 6 = 2  => the first element is "3"
    // k % 6 = 1  => find the "index 1" number in {1,2,4}
    // it would be easy when only two numbers left
    public string GetPermutation(int n, int k) {
        int[] factorial = new int[n + 1];
        IList<int> leftDigits = new List<int>();
        for(int i = 1; i <= n; i++){
            factorial[i] = (i == 1 ? 1 : factorial[i-1] * i);
            leftDigits.Add(i);
        }
        
        k--; // index start from 0
        string result = "";
        while(n > 0){
            if (n == 1) {
                result += leftDigits[0].ToString();
                break;
            }
            int i = k / factorial[n - 1];
            result += leftDigits[i].ToString();
            leftDigits.RemoveAt(i);
            k = k % factorial[n - 1];
            n--;
        }
        return result;
    }
}