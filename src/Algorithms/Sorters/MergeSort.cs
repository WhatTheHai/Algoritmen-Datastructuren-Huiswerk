using System.Collections.Generic;


namespace AD
{
    public partial class MergeSort : Sorter
    {
        public override void Sort(List<int> list) {
            int[] tempArray = new int[list.Count];
            Sort(list, tempArray, 0, list.Count - 1);
        }

        private static void Sort(List<int> list, int[] tempArray, int left, int right) {
            //Stops when right is smaller or equal to left, since we're halving it.
            if (right > left) {
                //Splits in half, round down
                int middle = (left + right) / 2;

                Sort(list, tempArray, left, middle);
                //Rounds down, so the other side gets +1
                Sort(list, tempArray, middle+1, right);

                Merge(list, tempArray, left, middle + 1, right);
            }
        }

        private static void Merge(List<int> list, int[] tempArray, int left, int right, int stopRight) {
            int stopLeft = stopRight - 1;
            int temp = left;
            int numberOfElements = stopRight - left + 1;

            while (left <= stopLeft && right <= stopRight) {
                if (list[left] <= list[stopRight]) {
                    tempArray[temp++] = list[left++];
                }
                else {
                    tempArray[temp++] = list[right++];
                }
            }

            while (left <= stopLeft) {
                tempArray[temp++] = list[left++];
            }

            while (right <= stopRight) {
                tempArray[temp++] = list[right++];
            }

            for (int i = 0; i < numberOfElements; i++, stopRight--) {
                list[stopRight] = tempArray[stopRight];
            }
        }
        
    }
}
