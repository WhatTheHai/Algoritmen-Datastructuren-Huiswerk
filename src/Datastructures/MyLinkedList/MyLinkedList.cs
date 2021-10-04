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

            MyLinkedListNode<T> newNode = new MyLinkedListNode<T>();
            MyLinkedListNode<T> firstNode = first;
            MyLinkedListNode<T> insertNode = new MyLinkedListNode<T>()
            {
                data = data
            };

            for (int i = 0; i < index + 1; i++)
            {
                if (i == index)
                {
                    insertNode.next = newNode.next;
                    newNode.next = newNode;
                    size++;
                }
                if (firstNode != null)
                {
                    newNode.next = firstNode.next;
                    firstNode = firstNode.next;
                }
            }
        }

        public override string ToString()
        {
            // Write implementation here
            throw new System.NotImplementedException();
        }
    }
}