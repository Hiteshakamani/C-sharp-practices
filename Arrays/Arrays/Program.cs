//Given two sorted arrays nums1 and nums2 of size m and n respectively, return the median of the two sorted arrays.



//Example 1:

//Input: nums1 = [1, 3], nums2 = [2]
//Output: 2.00000
//Explanation: merged array = [1, 2, 3] and median is 2
using System;

namespace arrays
{
    public class Program
    {
        int[] arr1 = { 1, 2, 3 };
        int[] arr2 = { 4, 5, 6 };

        public double MedianOfShortedArrays(int[] arr1, int[] arr2)
        {
            int m = arr1.Length;
            int n = arr2.Length;
            int[] merge = new int[m + n];
            int i = 0, j = 0, k = 0;
            while (i < m && j < n)
            {
                if (arr1[i] <= arr2[j])
                {
                    merge[k++] = arr1[i++];
                }
                else
                {
                    merge[k++] = arr2[j++];
                }
            }
            while (i < m)
            {
                merge[k++] = arr2[i++];
            }
            while (j < n)
            {
                merge[k++] = arr2[j++];
            }

            int mid = (m + n) / 2;
            if ((m + n) % 2 == 0)
            {
                return (merge[mid - 1] + merge[mid]) / 2.0;
            }
            else
            {
                return merge[mid];
            }
        }

        public static void Main(string[] args)
        {
            Program p = new Program();
            double median = p.MedianOfShortedArrays(p.arr1, p.arr2);
            Console.WriteLine("Median of the two sorted arrays is: " + median);
        }
    }
}



