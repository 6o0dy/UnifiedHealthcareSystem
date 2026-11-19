using System.Collections;

namespace UnifiedHealthcareSystem.DataStructures
{
    public class MyQueue<T> : IEnumerable<T>
    {
        private Node<T>? front;
        private Node<T>? rear;

        public int Count { get; private set; }
        public bool IsEmpty => Count == 0;

        public void Enqueue(T value)
        {
            Node<T> newNode = new Node<T>(value);
            if (rear == null)
            {
                front = newNode;
                rear = newNode;
            }
            else
            {
                rear.Next = newNode;
                rear = newNode;
            }
            Count++;
        }

        public T Dequeue()
        {
            if (front == null) throw new InvalidOperationException("Queue is empty.");

            T value = front.Data;
            front = front.Next;
            if (front == null) rear = null;
            Count--;
            return value;
        }

        public T Peek()
        {
            if (front == null) throw new InvalidOperationException("Queue is empty.");
            return front.Data;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (Node<T>? current = front; current != null; current = current.Next)
                yield return current.Data;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
