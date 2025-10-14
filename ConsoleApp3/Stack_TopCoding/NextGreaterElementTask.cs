using System;
using System.Collections.Generic;

public class NextGreaterElementTask {
    public int[] NextGreaterElement(int[] nums1, int[] nums2) {
        Dictionary<int, int> nextGreaterMap = new Dictionary<int, int>();
        Stack<int> stack = new Stack<int>();

        // Build map of next greater elements for all elements in nums2
        foreach (int num in nums2) {
            while (stack.Count > 0 && stack.Peek() < num) {
                int smallerNum = stack.Pop();
                nextGreaterMap[smallerNum] = num;
            }
            stack.Push(num);
        }

        // Fill in -1 for elements with no next greater
        while (stack.Count > 0) {
            nextGreaterMap[stack.Pop()] = -1;
        }

        // Build result for nums1
        int[] result = new int[nums1.Length];
        for (int i = 0; i < nums1.Length; i++) {
            result[i] = nextGreaterMap[nums1[i]];
        }

        return result;
    }
}
