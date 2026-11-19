namespace UnifiedHealthcareSystem.DataStructures
{
    public class MyPriorityQueue<T>
    {
        private readonly MyQueue<T> emergencies = new MyQueue<T>();
        private readonly MyQueue<T> normal = new MyQueue<T>();

        public int Count => emergencies.Count + normal.Count;
        public bool IsEmpty => Count == 0;
        public int EmergencyCount => emergencies.Count;
        public int NormalCount => normal.Count;

        public void Enqueue(T item, bool isEmergency)
        {
            if (isEmergency) emergencies.Enqueue(item);
            else normal.Enqueue(item);
        }

        public T Dequeue()
        {
            if (!emergencies.IsEmpty) return emergencies.Dequeue();
            if (!normal.IsEmpty) return normal.Dequeue();
            throw new InvalidOperationException("Queue is empty.");
        }

        public T Peek()
        {
            if (!emergencies.IsEmpty) return emergencies.Peek();
            if (!normal.IsEmpty) return normal.Peek();
            throw new InvalidOperationException("Queue is empty.");
        }

        public IEnumerable<T> InServiceOrder()
        {
            foreach (T item in emergencies) yield return item;
            foreach (T item in normal) yield return item;
        }
    }
}
