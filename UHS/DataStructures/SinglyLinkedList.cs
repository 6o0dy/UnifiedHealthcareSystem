using System.Collections;

namespace UnifiedHealthcareSystem.DataStructures
{
    // قائمة مرتبطة مفردة (Singly Linked List):
    // العناصر بتتربط بالمراجع (Next) مش بتتخزن ورا بعض في الذاكرة
    // بنحتفظ بـ Head و Tail و Count — مرجع إضافي واحد بيخلي الإضافة في الطرفين O(1)
    public class SinglyLinkedList<T> : ICollection<T>
    {
        public Node<T>? Head { get; private set; }
        public Node<T>? Tail { get; private set; }
        public int Count { get; private set; }
        public bool IsReadOnly => false;

        // Add = AddLast، ومحتاجينها كمان علشان System.Text.Json يعرف يقرأ القائمة من الملف
        public void Add(T value) => AddLast(value);

        // إضافة في أول القائمة — O(1)
        public void AddFirst(T value)
        {
            Node<T> newNode = new Node<T>(value);
            newNode.Next = Head;          // ① العقدة الجديدة بتشاور على أول عقدة
            Head = newNode;               // ② الـ Head بيتحرك للعقدة الجديدة
            if (Tail == null)             // القائمة كانت فاضية: العقدة الجديدة هي كمان الأخيرة
                Tail = newNode;
            Count++;                      // ③
        }

        // إضافة في آخر القائمة باستخدام الـ Tail — O(1)
        public void AddLast(T value)
        {
            Node<T> newNode = new Node<T>(value);
            if (Head == null)             // حالة القائمة الفاضية
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                Tail!.Next = newNode;     // ① آخر عقدة بتشاور على العقدة الجديدة
                Tail = newNode;           // ② الـ Tail بيتقدم
            }
            Count++;                      // ③
        }

        // حذف قيمة معينة: بنوصل للعقدة اللي قبل المطلوبة وبعدين بنعديها — البحث O(n) والربط O(1)
        public bool Remove(T value)
        {
            if (Head is null) return false;   // قائمة فاضية

            if (EqualityComparer<T>.Default.Equals(Head.Data, value))   // العقدة المطلوبة هي الـ Head
            {
                Head = Head.Next;
                if (Head is null) Tail = null;   // القائمة بقت فاضية
                Count--;
                return true;
            }

            Node<T>? current = Head;   // بنمشي لحد العقدة اللي قبل المطلوبة
            while (current.Next is not null &&
                   !EqualityComparer<T>.Default.Equals(current.Next.Data, value))
            {
                current = current.Next;
            }

            if (current.Next is null) return false;    // مش موجودة
            if (current.Next == Tail) Tail = current;  // لو المطلوبة هي آخر عقدة، الـ Tail يرجع خطوة
            current.Next = current.Next.Next;          // تعدية العقدة المطلوبة
            Count--;
            return true;
        }

        // حذف كل العناصر اللي بتحقق شرط معين — بترجع عدد اللي اتحذف
        public int RemoveAll(Predicate<T> match)
        {
            int removed = 0;

            while (Head is not null && match(Head.Data))
            {
                Head = Head.Next;
                if (Head is null) Tail = null;
                Count--;
                removed++;
            }

            Node<T>? current = Head;
            while (current?.Next is not null)
            {
                if (match(current.Next.Data))
                {
                    if (current.Next == Tail) Tail = current;
                    current.Next = current.Next.Next;
                    Count--;
                    removed++;
                }
                else
                {
                    current = current.Next;
                }
            }

            return removed;
        }

        public bool Contains(T value)
        {
            for (Node<T>? current = Head; current != null; current = current.Next)
            {
                if (EqualityComparer<T>.Default.Equals(current.Data, value))
                    return true;
            }
            return false;
        }

        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            for (Node<T>? current = Head; current != null; current = current.Next)
            {
                array[arrayIndex++] = current.Data;
            }
        }

        // نفس دالة المرور اللي في اللاب: زيارة كل عقدة لحد ما نوصل لـ null
        public void Print()
        {
            Node<T>? current = Head;
            while (current != null)
            {
                Console.Write(current.Data);
                if (current.Next != null)
                {
                    Console.Write(" -> ");
                }
                current = current.Next;
            }
            Console.WriteLine();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (Node<T>? current = Head; current != null; current = current.Next)
                yield return current.Data;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
