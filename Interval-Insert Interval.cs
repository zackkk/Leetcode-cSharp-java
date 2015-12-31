Given a set of non-overlapping intervals, insert a new interval into the intervals (merge if necessary).

You may assume that the intervals were initially sorted according to their start times.

Example 1:
Given intervals [1,3],[6,9], insert and merge [2,5] in as [1,5],[6,9].

Example 2:
Given [1,2],[3,5],[6,7],[8,10],[12,16], insert and merge [4,9] in as [1,2],[3,10],[12,16].

This is because the new interval [4,9] overlaps with [3,5],[6,7],[8,10].


/**
 * Definition for an interval.
 * public class Interval {
 *     public int start;
 *     public int end;
 *     public Interval() { start = 0; end = 0; }
 *     public Interval(int s, int e) { start = s; end = e; }
 * }
 */
public class Solution {
    // maintain a current interval
    public IList<Interval> Insert(IList<Interval> intervals, Interval newInterval) {
        IList<Interval> result = new List<Interval>();
        foreach(Interval interval in intervals){
            if(interval.end < newInterval.start){
                result.Add(interval);
            }
            else if(interval.start > newInterval.end){
                result.Add(newInterval);
                newInterval = interval;
            }
            else{ // has overlap: this case is more complicated, so identify other cases first
                newInterval.start = Math.Min(interval.start, newInterval.start);
                newInterval.end = Math.Max(interval.end, newInterval.end);
            }
        }
        result.Add(newInterval);
        return result;
    }
}