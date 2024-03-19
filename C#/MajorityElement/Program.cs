// the majority element is the element that appears more than ⌊n / 2⌋ times
// n being the size of the array

/*

int[] arr = {1, 2, 2, 2, 1, 1, 1, 3, 5, 2, 3, 2};

find the element which appears the most number of times


Boyer Moore's Voting Algorithm  time = O(n) and space = O(1)

class Solution {
    public int majorityElement(int[] nums) {
        int count = 0;
        Integer candidate = null;

        for (int num : nums) {
            if (count == 0) {
                candidate = num;
            }
            count += (num == candidate) ? 1 : -1;
        }

        return candidate;
    }
}


//approach 2 O(n) but uses extra space for Hashmap
create a hashmap/Dictionary with key value pairs of <int, int>
then iterate over the given array, say array = [2, 1, 1, 2, 1]

foreach num in array
1) num=2 so increase the value at hashmap Key (2) by 1.(by default all values in hashmap are zero for int)
2) num=1 increase value at hashMap key (1) by 1 and so on for the other numbers

in the end the hashmap will look like

mapkey mapvalue
  2      2
  1      3

  then we return the max value which is greater than sizeOfGivenArray/2 as
  the majority element is the element that appears more than ⌊n / 2⌋ times. 
*/