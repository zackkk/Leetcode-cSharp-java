Given an array of meeting time intervals consisting of start and end times [[s1,e1],[s2,e2],...] (si < ei), 
find the minimum number of conference rooms required.

For example,
Given [[0, 30],[5, 10],[15, 20]],
return 2.


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
    // Go through all times, +1 for all start times and -1 for all end times, keep track of the maximum number during the process
    // [[0, 30],[5, 10],[15, 20]]
    // 0  5  10 15 20 30
    // +1 +1 -1 +1 -1 -1
    // Use SortedDictionary to ganrantee iterate by "time"
    public int MinMeetingRooms(Interval[] intervals) {
        SortedDictionary<int, int> dict = new SortedDictionary<int, int>(); // <time, "event">
        foreach(Interval interval in intervals){
            dict[interval.start] = dict.ContainsKey(interval.start) ? dict[interval.start] + 1 : 1;
            dict[interval.end] = dict.ContainsKey(interval.end) ? dict[interval.end] - 1 : -1;
        }
        
        int roomsBeingUsed = 0, roomsHasBeenUsed = 0;
        foreach(KeyValuePair<int, int> entry in dict){
            roomsBeingUsed += entry.Value;
            roomsHasBeenUsed = Math.Max(roomsHasBeenUsed, roomsBeingUsed);
        }
        return roomsHasBeenUsed;
    }
}