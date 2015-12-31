Description:

Count the number of prime numbers less than a non-negative number, n.


public class Solution {
    // mark multiply of 2, 3, 5 ... to be non primes
    public int CountPrimes(int n) {
        int count = 0;
        bool[] notPrimes = new bool[n];  // initialize to all true seems complicated in C#
        for (int i = 2; i < n; i++) {
            if (notPrimes[i] == false) { 
                count++;
                for (int j = 2; j * i < n; j++) notPrimes[j*i] = true;
            }
        }
        return count;
    }
}