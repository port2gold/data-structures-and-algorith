using System.Security;

namespace data_structure_and_algo.LinkedList
{
    public class LinkedList<T>
    {
        private Node<T> Head;
        private Node<T> Tail;
        //5 10 -> 20 -> 30 ->

        public void AddFirst(T value)
        {
            var node = new Node<T>(value);
            if (IsEmpty())
            {
                Head = node;
                Tail = node;
                return;
            }
            var prevHead = Head;
            node.Next = prevHead;
            Head = node;
        }

        public void AddLast(T value)
        {
            var node = new Node<T>(value);
            if (IsEmpty())
            {
                Head = node;
                Tail = node;
                return;
            }

            var current = Head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = node;
            Tail = node;
        }

        public void RemoveFirst()
        {
            if (IsEmpty())
            {
                Console.WriteLine("List is empty");
                return;
            }

            var prevHead = Head;
            Head = prevHead.Next;
            prevHead = null;
        }
        public void RemoveLast()
        {
            if (IsEmpty()) return;

            var current = Head;
            var nextAfter = Head;
            if(current.Next == null)
            {
                Head = null;
                Tail = null;
                return;
            }

            if(current.Next != null)
            {
                nextAfter = current.Next;
            }

            while(nextAfter.Next != null)
            {
                current = current.Next;
                nextAfter = nextAfter.Next;
            }
            current.Next = null;
            Tail = current;
        }

        public void GetValues()
        {
            var result = new List<T>();
            var current = Head;
            if (Head == null)
            {
                Console.WriteLine("List is empty");
                return;
            }

            while (current.Next != null)
            {
                result.Add(current.Value);
                current = current.Next;
            }
            result.Add(current.Value);

            Console.WriteLine(string.Join(", ", result));
        }


        private bool IsEmpty()
        {
            return Head == null;
        }
    }
}
