using System;
using System.Collections.Generic;


namespace AD
{
    public partial class InsertionSort : Sorter
    {
        public override void Sort(List<int> list)
        {
            Sort(list, 0, list.Count - 1);
        }

        public void Sort(List<int> list, int lo, int hi) {
            int key, j;
            for (int i = lo; i <= hi; i++) {
                key = list[i];
                j = i;
                while (j > 0 && list[j-1] > key) {
                    list[j] = list[j-1];
                    j--;
                }

                list[j] = key;
            }
        }
    }
}
