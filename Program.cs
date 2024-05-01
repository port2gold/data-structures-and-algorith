//Heap

using data_structure_and_algo.Heaps;

var list = new List<int> { 20, 30, 10, 90, 100, 60, 80, 200 };

var heap = new Heap();

//heap.Insert(20);
//heap.Insert(30);
//heap.Insert(10);
//heap.Insert(90);
//heap.Insert(100);
//heap.Insert(60);
//heap.Insert(80);
//heap.Insert(200);
//heap.Remove();
//heap.ShowValues();


foreach (var num in list)
{
    heap.Insert(num);
}

// sorting 
//sorting in descending order

//for(int i = 0; i < list.Count; i++)
//{
//    list[i] = heap.Remove();
//}
//Console.WriteLine($"[{string.Join(',', list)}]");

//result [200,100,90,80,60,30,20,10]


//sorting in ascending order
for (int i = list.Count -1; i >= 0; i--)
{
    list[i] = heap.Remove();
}
Console.WriteLine($"[{string.Join(',', list)}]");

