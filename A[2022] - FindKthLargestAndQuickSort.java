import java.util.HashMap;
import java.util.Map;


// 找K大的元素，可以使用快排的思路
public class FindKthLargestAndQuickSort {

    // 选最右为pivot, 把小于pivot的元素放置于数组的左侧；返回pivot的index：index左侧均小，右侧均大
    private static int partition(int[] nums, int low, int high) {
        int pivot = nums[high];
        int left = low;
        for (int i = low; i < high; i++) {
            if (nums[i] <= pivot) {
                swap(nums, left, i);
                left++;
            }
        }
        swap(nums, left, high);
        return left;
    }

    // 判断partition后的index：如果target在右侧，则可以忽略左边的元素，直接去右侧寻找
    private static int findKthSmallest(int[] nums, int targetIndex, int low, int high) {
        int currentIndex = partition(nums, low, high);
        if (currentIndex == targetIndex) {
            return nums[currentIndex];
        } else if (currentIndex < targetIndex) {
            return findKthSmallest(nums, targetIndex, currentIndex+1, high);
        } else {
            return findKthSmallest(nums, targetIndex, low, currentIndex-1);
        }
    }
    
    // 协助方法
    private static void swap(int[] nums, int i, int j) {
        int tmp = nums[i];
        nums[i] = nums[j];
        nums[j] = tmp;
    }
  
    // 找从大到小，转为找从小到大
    private static int findKthLargest(int[] nums, int k) {
        return findKthSmallest(nums, nums.length-k, 0, nums.length-1);
    }

    public static void main(String[] args) {
        int[] a = {3,2,3,1,2,4,5,5,6};
        int r = findKthLargest(a, 4);
        System.out.println(r);
    }


    private static void quickSort(int[] nums, int low, int high) {
        if (low >= high) {
            return;
        }
        int pivot = partition(nums, low, high);
        quickSort(nums, low, pivot-1);
        quickSort(nums, pivot+1, high);
    }
  
  
    // 第二种近似暴力的解法
    public int findKthLargestInHash(int[] nums, int k) {
        int len = nums.length;
        if (len == 0 || k <= 0) {
            return 0;
        }

        Map<Integer, Integer> m = new HashMap<>();
        for (int i = 0; i < len; i++) {
            int cur = nums[i];
            if (m.containsKey(cur)) {
                m.put(cur, m.get(cur) + 1);
            } else {
                m.put(cur, 1);
            }
        }

        for (int i = 10000; i >= -10000; i--) {
            if (m.containsKey(i)) {
                k = k - m.get(i);
                if (k <= 0) {
                    return i;
                }
            }
        }
        return -1;
    }
}
