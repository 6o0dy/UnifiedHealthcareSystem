namespace UnifiedHealthcareSystem.DataStructures
{ 
    public class MyStack<T>
    {
        private Node<T>? top;

        public int Count { get; private set; }
        public bool IsEmpty => Count == 0;

        public void Push(T value)
        {
            Node<T> newNode = new Node<T>(value);
            newNode.Next = top;
            top = newNode;
            Count++;
        }

        public T Pop()
        {
            if (top is null) throw new InvalidOperationException("Stack is empty.");

            T value = top.Data;
            top = top.Next;
            Count--;
            return value;
        }

        public T Peek()
        {
            if (top is null) throw new InvalidOperationException("Stack is empty.");
            return top.Data;
        }
    }
}
