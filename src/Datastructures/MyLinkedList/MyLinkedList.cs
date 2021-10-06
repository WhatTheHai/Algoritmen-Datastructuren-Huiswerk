using System.Runtime.InteropServices;

namespace AD
{
    public partial class MyLinkedList<T> : IMyLinkedList<T>
    {
        public MyLinkedListNode<T> first;
        private int size;

        public MyLinkedList()
        {
            size = 0;
        }

        public void AddFirst(T data)
        {
            MyLinkedListNode<T> newNode = new MyLinkedListNode<T>()
            {
                data = data
            };
            if (size != 0)
            {
                newNode.next = first;
            }

            first = newNode;
            size++;
        }

        public void AddLast(T data)
        {
            MyLinkedListNode<T> newNode = new MyLinkedListNode<T>()
            {
                data = data
            };
            if (first != null) {
                MyLinkedListNode<T> traverseNode = first;
                while (traverseNode.next != null) {
                    traverseNode = traverseNode.next;
                }
                traverseNode.next = newNode;
                size++;
            }
            else {
                AddFirst(data);
            }
        }

        public T GetFirst()
        {
            if (size == 0)
            {
                throw new MyLinkedListEmptyException();
            }

            return first.data;
        }

        public void RemoveFirst()
        {
            if (size == 0)
            {
                throw new MyLinkedListEmptyException();
            }

            MyLinkedListNode<T> node = first.next;
            first = node;
            size--;
        }

        public int Size()
        {
            return size;
        }

        public void Clear()
        {
            this.first = null;
            size = 0;
        }

        public void Insert(int index, T data)
        {
            if (index < 0 || index > size)
            {
                throw new MyLinkedListIndexOutOfRangeException();
            }

            if (index == 0)
            {
                AddFirst(data);
                return;
            }

            MyLinkedListNode<T> newNode = null;
            MyLinkedListNode<T> firstNode = first;
            MyLinkedListNode<T> insertNode = new MyLinkedListNode<T>()
            {
                data = data
            };

            for (int i = 0; i < index + 1; i++)
            {
                if (i == index)
                {
                    if (newNode != null) {
                        insertNode.next = newNode.next;
                        newNode.next = insertNode;
                        size++;
                    }
                }

                //Create newNode to insert into
                if (firstNode != null)
                {
                    newNode = firstNode;
                    firstNode = firstNode.next;
                }
            }
        }

        public override string ToString()
        {
           var fullString = "NIL";
           if (size > 0) {
               MyLinkedListNode<T> traverseNode = first;
               fullString = "[";

               for (int i = 0; i < size; i++) {
                   fullString += traverseNode.data;

                   if (i < this.size - 1) {
                       fullString += ",";
                   }

                   traverseNode = traverseNode.next;
               }
               fullString += "]";
           }
           return fullString;
        }
    }
}