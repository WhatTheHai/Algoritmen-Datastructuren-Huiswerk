using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AD
{
    public partial class MyQueue<T> : IMyQueue<T>
    {
        MyLinkedList<T> queue;

        public MyQueue() {
            queue = new MyLinkedList<T>();
        }
        public bool IsEmpty()
        {
            return queue.Size() == 0;
        }

        public void Enqueue(T data)
        {
            queue.AddLast(data);
        }

        public T GetFront()
        {
            try {
                return queue.GetFirst();
            }
            catch (MyLinkedListEmptyException) {
                throw new MyQueueEmptyException();
            }
        }

        public T Dequeue()
        {
            try {
                var data = queue.GetFirst();
                queue.RemoveFirst();
                return data;
            }
            catch (MyLinkedListEmptyException) {
                throw new MyQueueEmptyException();
            }
        }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }

    }
}