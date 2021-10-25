using System;
using System.Collections.Generic;


namespace AD
{
    public partial class ShellSort : Sorter
    {
        public override void Sort(List<int> list) {
            int gap = 1;
            int key, j;
            while (gap < list.Count/3) {
                //Knuth Sequence, 
                //gap = gap*3 + 1;

                //Version with division by 2.2
                gap = (int)(list.Count / 2.2);
            }

            while (gap >= 1) {
                for (int i = gap; i < list.Count; i += gap) {
                    key = list[i];
                    j = i;
                    while (j > 0 && list[j - gap] > key) {
                        list[j] = list[j - gap];
                        j -= gap;
                    }
                    list[j] = key;
                }
                //Knuth Sequence
                //gap /= 3;

                //Version with divison by 2.2
                gap = (gap == 2) ? gap = 1 : (int)(gap / 2.2);
            }
        }
    }
}
