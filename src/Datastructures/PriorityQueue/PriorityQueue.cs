using System;


namespace AD
{
    public partial class PriorityQueue<T> : IPriorityQueue<T>
        where T : IComparable<T>
    {
        public static int DEFAULT_CAPACITY = 100;
        public int size;   // Number of elements in heap
        public T[] array;  // The heap array

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------
        public PriorityQueue() {
            size = 0;
            array = new T[DEFAULT_CAPACITY + 1];
        }

        //----------------------------------------------------------------------
        // Interface methods that have to be implemented for exam
        //----------------------------------------------------------------------
        public int Size() {
            return size;
        }

        public void Clear() {
            //No need to overwrite
            size = 0;
        }

        public void Add(T x)
        {
            if (size + 1 == array.Length) {
                doubleArray();
            }


            //Percolate up
            int hole = ++size;
            //Add to dummy position to prevent going from root
            array[0] = x;
            while (compare(x, array[hole / 2]) < 0) {
                array[hole] = array[hole / 2];
                hole /= 2;
            }
            array[hole] = x;
        }

        private int compare(T leftHalfSide, T rightHalfSide) {
            return leftHalfSide.CompareTo(rightHalfSide);
        }

        public void doubleArray() {
            T[] copyFromOld = array;

            array = new T[size * 2 + 1];

            for (int i = 0; i <= size; i++) {
                array[i] = copyFromOld[i];
            }
        }

        // Removes the smallest item in the priority queue
        public T Remove() {
            //Basically returns array[1];
            T minItem = Element();
            array[1] = array[size--];
            percolateDown(1);
            return minItem;
        }

        private void percolateDown(int hole) {
            int child;
            T temp = array[hole];
            while (hole * 2 <= size) {
                child = hole * 2;

                if (child != size && compare(array[child + 1], array[child]) < 0) {
                    child++;
                }

                if (compare(array[child], temp) < 0) {
                    array[hole] = array[child];
                }
                else {
                    break;
                }

                hole = child;
            }
            array[hole] = temp;
        }

        private T Element() {
            if (size == 0) {
                throw new PriorityQueueEmptyException();
            }
            return array[1];
        }

        public override string ToString() {
            string s = "";
            for (int i = 1; i <= size; i++) {
                s += ((i != 1) ? " " : "") + array[i].ToString();
            }

            return s;
        }


        //----------------------------------------------------------------------
        // Interface methods that have to be implemented for homework
        //----------------------------------------------------------------------

        public void AddFreely(T x)
        {
            throw new System.NotImplementedException();
        }

        public void BuildHeap()
        {
            throw new System.NotImplementedException();
        }

    }
}
