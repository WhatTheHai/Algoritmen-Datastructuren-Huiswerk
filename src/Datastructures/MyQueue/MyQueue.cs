using System.Collections.Generic;

namespace AD
{
    public partial class MyQueue<T> : IMyQueue<T>
    {
        MyLinkedList<T> linkedList;

        public MyQueue() {
            linkedList = new MyLinkedList<T>();
        }
        public bool IsEmpty()
        {
            return true;
        }

        public void Enqueue(T data)
        {
            throw new System.NotImplementedException();
        }

        public T GetFront()
        {
            throw new System.NotImplementedException();
        }

        public T Dequeue()
        {
            throw new System.NotImplementedException();
        }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }

    }
}