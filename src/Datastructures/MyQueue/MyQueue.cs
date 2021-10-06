using System.Collections.Generic;
using System.Linq.Expressions;

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
            return linkedList.Size() == 0;
        }

        public void Enqueue(T data)
        {
            linkedList.AddLast(data);
        }

        public T GetFront()
        {
            return linkedList.GetFirst();
        }

        public T Dequeue()
        {
            var data = linkedList.GetFirst();
            linkedList.RemoveFirst();
            return data;
        }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }

    }
}