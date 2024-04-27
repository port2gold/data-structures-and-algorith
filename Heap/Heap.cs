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
        private void BubbleUp()
        {
            int index = size - 1;
            while (index > 0 && items[index] > items[Parent(index)])
            {
                Swap(index, Parent(index));
                index = Parent(index);
            }
        }

        private void IsFull()
        {
            if (size == items.Length)
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
