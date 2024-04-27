namespace data_structure_and_algo.Heaps
{
    public class Heap
    {
        int[] items = new int[30];
        int size = 0;


        public void Insert(int num)
        {
            IsFull();

            items[size++] = num;

            BubbleUp();
        }
        public void Remove()
        {
            IsEmpty();

            items[0] = items[--size];

            var index = 0;

            while(index <= size && !IsValidParent(index))
            {
                var largerChildIndex = LargerChildIndex(index);
                Swap(index, largerChildIndex);

                index = largerChildIndex;
            }
        }
        private void BubbleUp()
        {
            int index = size - 1;
            while (index > 0 && items[index] > items[Parent(index)])
            {
                Swap(index, Parent(index));
                index = Parent(index);
            }
        }

        private int LeftChildIndex(int index)
        {
            return index * 2 + 1;
        }
        private int RightChildIndex(int index)
        {
            return index * 2 + 2;
        }
        private int LargerChildIndex(int index)
        {
            return items[LeftChildIndex(index)] > items[RightChildIndex(index)] ? LeftChildIndex(index) : RightChildIndex(index);
        }
        private bool IsValidParent(int index)
        {
            return items[index] > items[LeftChildIndex(index)] && items[index] > items[RightChildIndex(index)];
        }
        private void IsFull()
        {
            if (size == items.Length)
            {
                throw new Exception("Illegal State Exception");
            }
        }
        private void IsEmpty()
        {
            if(items.Length == 0)
            {
                throw new Exception("Illegal State Exception");
            }
        }
        private int Parent(int index)
        {
            return (index - 1) / 2;
        }
        private void Swap(int firstIndex, int secondIndex)
        {
            int temp = items[firstIndex];
            items[firstIndex] = items[secondIndex];
            items[secondIndex] = temp;
        }


        public void ShowValues()
        {
            Console.Write(string.Join(", ", items));
        }
    }
}
