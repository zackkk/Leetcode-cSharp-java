There are N gas stations along a circular route, where the amount of gas at station i is gas[i].

You have a car with an unlimited gas tank and it costs cost[i] of gas to travel from station i to its next station (i+1). 
You begin the journey with an empty tank at one of the gas stations.

Return the starting gas stations index if you can travel around the circuit once, otherwise return -1.


public class Solution {
    // tricky, thinking about filling gaps
    public int CanCompleteCircuit(int[] gas, int[] cost) {
        int n = gas.Length, rem_total = 0, result = 0;
        int[] rem = new int[n];
        for(int i = 0; i < n; i++){
            rem[i] = gas[i] - cost[i];
            rem_total += rem[i];
        }
        if(rem_total < 0) return -1; // otherwise, there must be a start point
        
        rem_total = 0;
        for(int i = 0; i < n; i++){
            rem_total += rem[i];
            if(rem_total < 0){
                rem_total = 0;
                result = i+1;
            }
        }
        return result;
    }
}