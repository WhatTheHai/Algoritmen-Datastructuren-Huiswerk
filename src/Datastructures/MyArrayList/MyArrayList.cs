using System.Collections;
using System.Linq;

namespace AD
{
    public partial class MyArrayList : IMyArrayList
    {
        private int[] data;
        private int size;

        public MyArrayList(int capacity)
        {
            data = new int[capacity];
            size = 0;
        }

        public void Add(int n) {
            if (size >= data.Length) {
                throw new MyArrayListFullException();
            }

            data[size] = n;
            size++;
        }

        public int Get(int index)
        {
            if (index < 0 || index > (size - 1) || size == 0) {
                throw new MyArrayListIndexOutOfRangeException();
            }

            return data[index];
        }

        public void Set(int index, int n)
        {
            if (index < 0 || index > (size - 1)) {
                throw new MyArrayListIndexOutOfRangeException();
            }

            data[index] = n;
        }

        public int Capacity() {
            return data.Length;
        }

        public int Size() {
            return size;
        }

        public void Clear()
        {
            data = new int[data.GetLength(0)];
            size = 0;
        }

        public int CountOccurences(int n) {
            var count = data.Count(number => number == n);
            return count;
        }
        public override string ToString() {
            var fullString = "";
            if (Size() > 0) {
                fullString += "[" + data[0];
                if (Size() > 1) {
                    for (var i = 1; i < Size(); i++) {
                        fullString += "," + data[i];
                    }
                }
                fullString += "]";
            }
            else {
                fullString = "NIL";
            }

            return fullString;
        }
    }
}
