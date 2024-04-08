/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINIDTION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK


*/

using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace ISM6225_Spring_2024_Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            int numberOfUniqueNumbers = RemoveDuplicates(nums1);
            Console.WriteLine(numberOfUniqueNumbers);

            //Question 2:
            Console.WriteLine("Question 2:");
            int[] nums2 = { 0, 1, 0, 3, 12 };
            IList<int> resultAfterMovingZero = MoveZeroes(nums2);
            string combinationsString = ConvertIListToArray(resultAfterMovingZero);
            Console.WriteLine(combinationsString);

            //Question 3:
            Console.WriteLine("Question 3:");
            int[] nums3 = { -1, 0, 1, 2, -1, -4 };
            IList<IList<int>> triplets = ThreeSum(nums3);
            string tripletResult = ConvertIListToNestedList(triplets);
            Console.WriteLine(tripletResult);

            //Question 4:
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 1, 0, 1, 1, 1 };
            int maxOnes = FindMaxConsecutiveOnes(nums4);
            Console.WriteLine(maxOnes);

            //Question 5:
            Console.WriteLine("Question 5:");
            int binaryInput = 101010;
            int decimalResult = BinaryToDecimal(binaryInput);
            Console.WriteLine(decimalResult);

            //Question 6:
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 6, 9, 1 };
            int maxGap = MaximumGap(nums5);
            Console.WriteLine(maxGap);

            //Question 7:
            Console.WriteLine("Question 7:");
            int[] nums6 = { 2, 1, 2 };
            int largestPerimeterResult = LargestPerimeter(nums6);
            Console.WriteLine(largestPerimeterResult);

            //Question 8:
            Console.WriteLine("Question 8:");
            string result = RemoveOccurrences("daabcbaabcbc", "abc");
            Console.WriteLine(result);
        }

        /*
        
        Question 1:
        Given an integer array nums sorted in non-decreasing order, remove the duplicates in-place such that each unique element appears only once. The relative order of the elements should be kept the same. Then return the number of unique elements in nums.

        Consider the number of unique elements of nums to be k, to get accepted, you need to do the following things:

        Change the array nums such that the first k elements of nums contain the unique elements in the order they were present in nums initially. The remaining elements of nums are not important as well as the size of nums.
        Return k.

        Example 1:

        Input: nums = [1,1,2]
        Output: 2, nums = [1,2,_]
        Explanation: Your function should return k = 2, with the first two elements of nums being 1 and 2 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
        Example 2:

        Input: nums = [0,0,1,1,1,2,2,3,3,4]
        Output: 5, nums = [0,1,2,3,4,_,_,_,_,_]
        Explanation: Your function should return k = 5, with the first five elements of nums being 0, 1, 2, 3, and 4 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
 

        Constraints:

        1 <= nums.length <= 3 * 104
        -100 <= nums[i] <= 100
        nums is sorted in non-decreasing order.
        */

        public static int RemoveDuplicates(int[] nums)
        {
            try
            {
                // Check if the array is empty
                if (nums.Length == 0)
                    return 0;

                // Initialize a pointer for unique elements
                int uniqueIndex = 0;

                // Iterate through the array
                for (int i = 1; i < nums.Length; i++)
                {
                    // If the current element is different from the previous unique element
                    if (nums[i] != nums[uniqueIndex])
                    {
                        // Move the unique index pointer forward
                        uniqueIndex++;
                        // Update the element at the unique index to the current element
                        nums[uniqueIndex] = nums[i];
                    }
                }

                // Adding 1 to unique index to get the count of unique elements
                return uniqueIndex + 1;
            }
            catch (Exception)
            {
                // Rethrow the exception if any
                throw;
            }
        }


        /*
         * Self-analysis:
         
        The `RemoveDuplicates` function eliminates duplicates in-place while maintaining the relative order of elements. 
        It takes an integer array {nums} that has been sorted in a non-decreasing order. To keep track of the unique elements, it initializes a pointer called {uniqueIndex}. 
        It goes through {nums} iteratively, comparing each element to the last distinct element. In the event that an alternative element is found, duplicates are eliminated by updating {uniqueIndex} and swapping out the element at the updated index with the new element. Ultimately, the count of unique elements is returned. 
        Exception handling is incorporated to detect unforeseen mistakes. This algorithm has a time complexity of O(n), where n is the length of the input array. 
        */

        /*
        
        Question 2:
        Given an integer array nums, move all 0's to the end of it while maintaining the relative order of the non-zero elements.

        Note that you must do this in-place without making a copy of the array.

        Example 1:

        Input: nums = [0,1,0,3,12]
        Output: [1,3,12,0,0]
        Example 2:

        Input: nums = [0]
        Output: [0]
 
        Constraints:

        1 <= nums.length <= 104
        -231 <= nums[i] <= 231 - 1
        */

        public static IList<int> MoveZeroes(int[] nums)
        {
            try
            {
                // Check if the input array is null or empty
                if (nums == null || nums.Length == 0)
                    return new List<int>(); // Return an empty list if the input array is empty

                int nonZeroIndex = 0; // Pointer to track the position for non-zero elements

                // Iterate through the array
                for (int i = 0; i < nums.Length; i++)
                {
                    // If the current element is non-zero
                    if (nums[i] != 0)
                    {
                        // Swap the current element with the element at nonZeroIndex
                        int temp = nums[i];
                        nums[i] = nums[nonZeroIndex];
                        nums[nonZeroIndex] = temp;

                        // Move the nonZeroIndex pointer forward
                        nonZeroIndex++;
                    }
                }

                // Convert the modified array to a list and return
                return nums.ToList();
            }
            catch (Exception)
            {
                // Rethrow the exception if any
                throw;
            }
        }



        /*
         * Self-analysis:
        While maintaining the relative order of non-zero elements, the `MoveZeroes` function effectively moves all zero elements to the end of the input array. 
        It optimizes memory usage by doing this in-place rather than replicating the array. The function iterates through the array using a two-pointer approach, where one pointer keeps track of the position for non-zero elements. 
        It moves zeros to the end by substituting an element at the non-zero pointer's location for any non-zero element it encounters. 
        This method is effective for large arrays because it guarantees linear time complexity with respect to the array size. 
          
        */

        /*

        Question 3:
        Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.

        Notice that the solution set must not contain duplicate triplets.

 

        Example 1:

        Input: nums = [-1,0,1,2,-1,-4]
        Output: [[-1,-1,2],[-1,0,1]]
        Explanation: 
        nums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0.
        nums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0.
        nums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0.
        The distinct triplets are [-1,0,1] and [-1,-1,2].
        Notice that the order of the output and the order of the triplets does not matter.
        Example 2:

        Input: nums = [0,1,1]
        Output: []
        Explanation: The only possible triplet does not sum up to 0.
        Example 3:

        Input: nums = [0,0,0]
        Output: [[0,0,0]]
        Explanation: The only possible triplet sums up to 0.
 

        Constraints:

        3 <= nums.length <= 3000
        -105 <= nums[i] <= 105

        */

        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            try
            {
                // Check if the input array is null or its length is less than 3
                if (nums == null || nums.Length < 3)
                    return new List<IList<int>>(); // If there are less than 3 elements, no triplets are possible

                IList<IList<int>> result = new List<IList<int>>();

                // Sort the array
                Array.Sort(nums);

                // Loop through the array to find triplets
                for (int firstIndex = 0; firstIndex < nums.Length - 2; firstIndex++)
                {
                    // Skip duplicates
                    if (firstIndex > 0 && nums[firstIndex] == nums[firstIndex - 1])
                        continue;

                    int left = firstIndex + 1;
                    int right = nums.Length - 1;

                    while (left < right)
                    {
                        int currentSum = nums[firstIndex] + nums[left] + nums[right];
                        if (currentSum == 0)
                        {
                            // Found a triplet with sum zero
                            result.Add(new List<int> { nums[firstIndex], nums[left], nums[right] });

                            // Skip duplicates
                            while (left < right && nums[left] == nums[left + 1])
                                left++;
                            while (left < right && nums[right] == nums[right - 1])
                                right--;

                            left++;
                            right--;
                        }
                        else if (currentSum < 0)
                        {
                            // Increment left pointer if sum is less than zero
                            left++;
                        }
                        else
                        {
                            // Decrement right pointer if sum is greater than zero
                            right--;
                        }
                    }
                }

                return result;
            }
            catch (Exception)
            {
                // Rethrow the exception if any
                throw;
            }
        }



        /* 
         Self-analysis:
        In the input array {nums}, the {ThreeSum` function effectively locates unique triplets that sum up to zero. 
        It sorts the array and uses a two-pointer technique, which lowers the time complexity to O(n^2). In order to find triplets whose sum equals zero, the function iterates through the sorted array, ignoring duplicates and utilizing two pointers A list of lists with distinct triplets meeting the requirement is what the function returns. 
        Large input sizes may cause the function's time complexity to become significant, despite its efficiency. 
        Its overall performance remains good, though, offering a brief and efficient solution to the problem statement along with accessible code.
        */

        /*

        Question 4:
        Given a binary array nums, return the maximum number of consecutive 1's in the array.

        Example 1:

        Input: nums = [1,1,0,1,1,1]
        Output: 3
        Explanation: The first two digits or the last three digits are consecutive 1s. The maximum number of consecutive 1s is 3.
        Example 2:

        Input: nums = [1,0,1,1,0,1]
        Output: 2
 
        Constraints:

        1 <= nums.length <= 105
        nums[i] is either 0 or 1.

        */

        public static int FindMaxConsecutiveOnes(int[] nums)
        {
            try
            {
                // Check if the input array is null or empty
                if (nums == null || nums.Length == 0)
                    return 0;

                int maxConsecutiveOnes = 0; // Initialize the maximum consecutive ones count
                int currentConsecutiveOnes = 0; // Initialize the current consecutive ones count

                // Iterate through the array
                foreach (int num in nums)
                {
                    if (num == 1)
                    {
                        // If the current element is 1, increment the current consecutive ones count
                        currentConsecutiveOnes++;
                    }
                    else
                    {
                        // If the current element is 0, update the maximum consecutive ones count if necessary
                        maxConsecutiveOnes = Math.Max(maxConsecutiveOnes, currentConsecutiveOnes);
                        // Reset the current consecutive ones count
                        currentConsecutiveOnes = 0;
                    }
                }

                // Update the maximum consecutive ones count if necessary for the last sequence of consecutive ones
                maxConsecutiveOnes = Math.Max(maxConsecutiveOnes, currentConsecutiveOnes);

                return maxConsecutiveOnes;
            }
            catch (Exception)
            {
                // Rethrow the exception if any
                throw;
            }
        }



        /* 
           * Analysis:
        
          The binary array {nums} can be used to efficiently find the maximum number of consecutive 1's by using the `FindMaxConsecutiveOnes` function. 
        It makes one iteration through the array, recording the maximum count so far ({maxConsecutiveOnes{) and the current count of consecutive 1s ({currentConsecutiveOnes}). 
        The function resets {currentConsecutiveOnes` and updates {maxConsecutiveOnes` if a 0 is encountered. It updates {maxConsecutiveOnes` again after going through the entire array to handle the situation where the final sequence of 1s extends to the end of the array. 
        This function makes a single pass through the array, so its time complexity is O(n), where n is the length of the input array. 
         */

        /*

        Question 5:
        You are tasked with writing a program that converts a binary number to its equivalent decimal representation without using bitwise operators or the `Math.Pow` function. You will implement a function called `BinaryToDecimal` which takes an integer representing a binary number as input and returns its decimal equivalent. 

        Requirements:
        1. Your program should prompt the user to input a binary number as an integer. 
        2. Implement the `BinaryToDecimal` function, which takes the binary number as input and returns its decimal equivalent. 
        3. Avoid using bitwise operators (`<<`, `>>`, `&`, `|`, `^`) and the `Math.Pow` function for any calculations. 
        4. Use only basic arithmetic operations such as addition, subtraction, multiplication, and division. 
        5. Ensure the program displays the input binary number and its corresponding decimal value.

        Example 1:
        Input: num = 101010
        Output: 42


        Constraints:

        1 <= num <= 10^9

        */

        public static int BinaryToDecimal(int binary)
        {
            try
            {
                int decimalResult = 0; // Initialize the decimal result
                int baseValue = 1; // Initialize the base value

                // Convert binary to decimal
                while (binary > 0)
                {
                    int lastDigit = binary % 10; // Get the last digit of the binary number
                    decimalResult += lastDigit * baseValue; // Add the contribution of the current digit to the decimal result
                    binary /= 10; // Move to the next digit of the binary number
                    baseValue *= 2; // Increment the base value for the next digit
                }

                return decimalResult; // Return the decimal result
            }
            catch (Exception)
            {
                // Rethrow the exception if any
                throw;
            }
        }


        /* 
           * Analysis:
        An integer representation of a binary number can be effectively converted to its decimal representation using the `BinaryToDecimal` function. 
        It works by processing the binary number iteratively, multiplying each digit by the corresponding power of 2, and adding up the result. The only mathematical operations needed to complete this process are addition, subtraction, multiplication, and division. 
        The function uses descriptive variable names like `decimalResult}, `baseValue`, and `lastDigit` to ensure readability and clarity. Overall, the function satisfies the requirements without the use of bitwise operators or the `Math.Pow` function, offering a simple and effective solution to the binary-to-decimal conversion problem. 
        Its time complexity is proportional to the number of digits in binary number.
         */

        /*

        Question:6
        Given an integer array nums, return the maximum difference between two successive elements in its sorted form. If the array contains less than two elements, return 0.
        You must write an algorithm that runs in linear time and uses linear extra space.

        Example 1:

        Input: nums = [3,6,9,1]
        Output: 3
        Explanation: The sorted form of the array is [1,3,6,9], either (3,6) or (6,9) has the maximum difference 3.
        Example 2:

        Input: nums = [10]
        Output: 0
        Explanation: The array contains less than 2 elements, therefore return 0.


        Constraints:

        1 <= nums.length <= 105
        0 <= nums[i] <= 109

        */

        public static int MaximumGap(int[] nums)
        {
            try
            {
                // Check if the array contains less than two elements
                if (nums.Length < 2)
                    return 0;

                // Find the maximum and minimum values in the array
                int minVal = nums[0];
                int maxVal = nums[0];
                foreach (int num in nums)
                {
                    minVal = Math.Min(minVal, num);
                    maxVal = Math.Max(maxVal, num);
                }

                // Calculate the bucket size and the number of buckets
                int bucketSize = Math.Max(1, (maxVal - minVal) / (nums.Length - 1));
                int bucketCount = (maxVal - minVal) / bucketSize + 1;

                // Initialize the buckets
                int[] minBucket = new int[bucketCount];
                int[] maxBucket = new int[bucketCount];
                Array.Fill(minBucket, int.MaxValue);
                Array.Fill(maxBucket, int.MinValue);

                // Put elements into buckets
                foreach (int num in nums)
                {
                    int index = (num - minVal) / bucketSize;
                    minBucket[index] = Math.Min(minBucket[index], num);
                    maxBucket[index] = Math.Max(maxBucket[index], num);
                }

                // Calculate the maximum gap
                int maxGap = 0;
                int prevMax = minVal;
                for (int i = 0; i < bucketCount; i++)
                {
                    if (minBucket[i] != int.MaxValue && maxBucket[i] != int.MinValue)
                    {
                        maxGap = Math.Max(maxGap, minBucket[i] - prevMax);
                        prevMax = maxBucket[i];
                    }
                }

                return maxGap;
            }
            catch (Exception)
            {
                // Rethrow the exception if any
                throw;
            }
        }



        /* * Analysis:
        In the sorted form of the input array {nums}, the `MaximumGap` function effectively determines the maximum difference between two successive elements. 
        By using the bucketing technique, it achieves linear time complexity in doing so. It first determines the array's lowest and maximum values. Based on the range of values, it then determines the size and quantity of buckets. 
        It then adds elements from the array to the buckets. Next, it determines the maximum distance between consecutive buckets by iteratively going through the buckets. 
        Ultimately, the maximum gap discovered is returned. Readability is improved by using comments and variable names that are descriptive
        
         */

        /*

        Question:7
        Given an integer array nums, return the largest perimeter of a triangle with a non-zero area, formed from three of these lengths. If it is impossible to form any triangle of a non-zero area, return 0.

        Example 1:

        Input: nums = [2,1,2]
        Output: 5
        Explanation: You can form a triangle with three side lengths: 1, 2, and 2.
        Example 2:

        Input: nums = [1,2,1,10]
        Output: 0
        Explanation: 
        You cannot use the side lengths 1, 1, and 2 to form a triangle.
        You cannot use the side lengths 1, 1, and 10 to form a triangle.
        You cannot use the side lengths 1, 2, and 10 to form a triangle.
        As we cannot use any three side lengths to form a triangle of non-zero area, we return 0.

        Constraints:

        3 <= nums.length <= 104
        1 <= nums[i] <= 106

        */

        public static int LargestPerimeter(int[] nums)
        {
            try
            {
                // Sort the array in non-decreasing order
                Array.Sort(nums);

                // Iterate over the sorted array from right to left
                for (int i = nums.Length - 1; i >= 2; i--)
                {
                    // Check if the sum of the two smaller sides is greater than the largest side
                    if (nums[i - 2] + nums[i - 1] > nums[i])
                    {
                        // Return the perimeter of the valid triangle
                        return nums[i - 2] + nums[i - 1] + nums[i];
                    }
                }

                // If no valid triangle is found, return 0
                return 0;
            }
            catch (Exception)
            {
                // Rethrow the exception if any
                throw;
            }
        }



        /* 
         * Analysis:
        In the provided array, the {LargestPerimeter} function effectively determines the largest perimeter of a triangle with a non-zero area made up of three side lengths. 
        It takes O(n log n) time complexity to sort the array of side lengths in a non-decreasing order. Next, iterating from right to left over the sorted array, it verifies each triplet of successive side lengths. 
        It checks to see if the sum of the two smaller sides for each triplet is greater than the largest side, signifying a legitimate triangle. Because of the sorted order, the function returns the perimeter of the first valid triangle encountered, which will always be the largest. 
        Because of the sorting process, the algorithm's worst-case time complexity is O(n log n). 
      
         */

        /*

        Question:8

        Given two strings s and part, perform the following operation on s until all occurrences of the substring part are removed:

        Find the leftmost occurrence of the substring part and remove it from s.
        Return s after removing all occurrences of part.

        A substring is a contiguous sequence of characters in a string.

 

        Example 1:

        Input: s = "daabcbaabcbc", part = "abc"
        Output: "dab"
        Explanation: The following operations are done:
        - s = "daabcbaabcbc", remove "abc" starting at index 2, so s = "dabaabcbc".
        - s = "dabaabcbc", remove "abc" starting at index 4, so s = "dababc".
        - s = "dababc", remove "abc" starting at index 3, so s = "dab".
        Now s has no occurrences of "abc".
        Example 2:

        Input: s = "axxxxyyyyb", part = "xy"
        Output: "ab"
        Explanation: The following operations are done:
        - s = "axxxxyyyyb", remove "xy" starting at index 4 so s = "axxxyyyb".
        - s = "axxxyyyb", remove "xy" starting at index 3 so s = "axxyyb".
        - s = "axxyyb", remove "xy" starting at index 2 so s = "axyb".
        - s = "axyb", remove "xy" starting at index 1 so s = "ab".
        Now s has no occurrences of "xy".

        Constraints:

        1 <= s.length <= 1000
        1 <= part.length <= 1000
        s​​​​​​ and part consists of lowercase English letters.

        */

        public static string RemoveOccurrences(string s, string p)
        {
            try
            {
                int i;
                // Repeat until all occurrences of part are removed
                while ((i = s.IndexOf(p)) != -1)
                {
                    // Remove the leftmost occurrence of part from s
                    s = s.Remove(i, p.Length);
                }
                return s;
            }
            catch (Exception)
            {
                // Rethrow the exception if any
                throw;
            }
        }


        /* * Analysis:
        Using the `RemoveOccurrences` function, you can effectively eliminate every instance of a specific substring {part} from the input string {s}. 
        With an O(n) time complexity, iterating through {s}, it uses the `IndexOf` method to find the leftmost occurrence of {part}. 
        If discovered, it employs the O(n) time complexity {Remove} method to extract {part} from {s}. This procedure keeps going until there are no more instances of {part} discovered. Consequently, the function's overall time complexity is O(n^2), where n is the input string {s}'s length. 
        This method is simple, but because it involves nested iterations, it might not be the most effective for large inputs. 
           
         */


        /* Inbuilt Functions - Don't Change the below functions */
        static string ConvertIListToNestedList(IList<IList<int>> input)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("["); // Add the opening square bracket for the outer list

            for (int i = 0; i < input.Count; i++)
            {
                IList<int> innerList = input[i];
                sb.Append("[" + string.Join(",", innerList) + "]");

                // Add a comma unless it's the last inner list
                if (i < input.Count - 1)
                {
                    sb.Append(",");
                }
            }

            sb.Append("]"); // Add the closing square bracket for the outer list

            return sb.ToString();
        }


        static string ConvertIListToArray(IList<int> input)
        {
            // Create an array to hold the strings in input
            string[] strArray = new string[input.Count];

            for (int i = 0; i < input.Count; i++)
            {
                strArray[i] = "" + input[i] + ""; // Enclose each string in double quotes
            }

            // Join the strings in strArray with commas and enclose them in square brackets
            string result = "[" + string.Join(",", strArray) + "]";

            return result;
        }
    }
}