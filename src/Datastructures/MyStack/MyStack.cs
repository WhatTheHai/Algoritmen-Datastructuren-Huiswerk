namespace AD
{
    public partial class MyStack<T> : IMyStack<T> {
        MyLinkedList<T> linkedList;

        public MyStack() {
            linkedList = new MyLinkedList<T>();
        }
        public bool IsEmpty() {
            return linkedList.Size() == 0;
        }

        public T Pop()
        {
            if (this.IsEmpty()) {
                throw new MyStackEmptyException();
            }

            T data = linkedList.GetFirst();
            linkedList.RemoveFirst();
            return data;
        }

        public void Push(T data)
        {
            this.linkedList.AddFirst(data);
        }

        public T Top()
        {
            if (this.IsEmpty()) {
                throw new MyStackEmptyException();
            }

            return linkedList.first.data;
        }
    }
}
