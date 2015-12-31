Find the kth largest element in an unsorted array. 
Note that it is the kth largest element in the sorted order, not the kth distinct element.

For example,
Given [3,2,1,5,6,4] and k = 2, return 5.

Note: 
You may assume k is always valid, 1 ≤ k ≤ arrays length.


public class Solution {
    // sort: O(NlogN) + O(1)
    // heap: O(NlogK) + O(K) 
    // parition(quick sort idea): O(N) - best + O(1) - https://en.wikipedia.org/wiki/Quicksort
    public int FindKthLargest(int[] nums, int k) {
        int n = nums.Length;
        return partition(nums, 0, n - 1, n + 1 - k); // transfer Kth largest to Kth smallest
    }
    
    // return the Kth smallest
    int partition(int[] a, int low, int high, int k){
        int pivot = a[high];
        int i = low; // place for swapping
        for (int j = i; j < high; j++){
            if (a[j] <= pivot) {
                swap(a, i, j);
                i++;
            }
        }
        swap(a, i, high);
        int num = i - low + 1;
        if (num == k) return pivot;
        else if (num > k) return partition(a, low, i - 1, k);
        else return partition(a, i + 1, high, k - num);
    }

    void swap(int[] a, int x, int y) {
        int tmp = a[x];
        a[x] = a[y];
        a[y] = tmp;
    }
}