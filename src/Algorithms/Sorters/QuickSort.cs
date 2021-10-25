using System.Collections.Generic;


namespace AD
{
    public partial class QuickSort : Sorter
    {
        private static int CUTOFF = 3;

        public override void Sort(List<int> list)
        {
            Sort(list, 0, list.Count-1);
        }

        public static void Sort(List<int> list, int low, int high) {
            if (low + CUTOFF > high) {
                new InsertionSort().Sort(list);
            }
            else {
                int middle = (low + high) / 2;
                //Sort low, middle, high for pivot
                if (list[middle].CompareTo(list[low]) < 0) 
                    SwapReferences(list, low, middle);

                if (list[high].CompareTo(list[low]) < 0) 
                    SwapReferences(list, low, high);

                if (list[high].CompareTo(list[middle]) < 0) 
                    SwapReferences(list, middle, high);

                SwapReferences(list, middle, high);
                int pivot = list[high - 1];

                //Start partitioning
                int i, j;
                for (i = low, j = high - 1;;) {
                    //Find value on left side to swap with right
                    while (list[++i].CompareTo(pivot) < 0) ;
                    while (pivot.CompareTo(list[--j]) <= 0) {
                        //Out of bounds fix
                        if (j == 0) {
                            break;
                        }
                    };
                    if (i >= j)
                        break;
                    SwapReferences(list, i, j);
                }
                //Put pivot back
                SwapReferences(list, i, high - 1);

                Sort(list, low, i - 1);
                Sort(list, i + 1, high);
            }
        }

        private static void SwapReferences(List<int> list, int i, int j) {
            //Swap using tuples
            (list[i], list[j]) = (list[j], list[i]);
        }
    }
}
