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
            size = capacity;
        }

        public void Add(int n) {
            for (int i = 0; i < size; i++) {
                if (data[i] == 0) {
                    data[i] = n;
                    return;
                }
            }

            throw new MyArrayListFullException();
        }

        public int Get(int index)
        {
            if (index >= 0 && index < size) {
                if (data[index] != 0) {
                    return data[index];
                }
                throw new MyArrayListIndexOutOfRangeException();
            }
            throw new MyArrayListIndexOutOfRangeException();
        }

        public void Set(int index, int n)
        {
            if (index >= 0 && index < size) {
                if (data[index] != 0) {
                    data[index] = n;
                }
                else {
                    throw new MyArrayListIndexOutOfRangeException();
                }
            }
            else {
                throw new MyArrayListIndexOutOfRangeException();
            }
        }

        public int Capacity() {
            return size;
        }

        public int Size() {
            return data.TakeWhile(number => number != 0).Count();
        }

        public void Clear()
        {
            data = new int[size - 1];
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
