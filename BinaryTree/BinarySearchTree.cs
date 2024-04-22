using data_structure_and_algo.BinaryTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_structure_and_algo.BinaryTree
{
    internal class BinarySearchTree : Tree
    {
        public new int Min()
        {
            if (root == null)
                throw new Exception("Invalid Operation");

            var last = root;
            var current = root;

            if (current.leftChild != null)
            {
                last = current;
                current = current.leftChild;
            }
            return last.Value;
        }
    }
}


//Binary Tree Examples



//Binary Search Tree


//using data_structure_and_algo.BinaryTree;

//var tree = new Tree();

//tree.Insert(7);
//tree.Insert(4);
//tree.Insert(9);
//tree.Insert(1);
//tree.Insert(6);
//tree.Insert(8);
//tree.Insert(10);

//Console.WriteLine(tree.Find(6));

//Console.WriteLine("Begin Traverse Pre Order");
//tree.TraversePreOrder();
//Console.WriteLine("End of Traverse Pre Order\n\n");

//Console.WriteLine("Begin Traverse In Order");
//tree.TraverseInOrder();
//Console.WriteLine("End of Traverse In Order\n\n");

//Console.WriteLine("Begin Traverse Post Order");
//tree.TraversePostOrder();
//Console.WriteLine("End of Traverse Post Order");


//Console.WriteLine($"The height of the tree is {tree.Height()}");

////Equality
//var tree1 = new Tree();

//tree1.Insert(7);
//tree1.Insert(4);
//tree1.Insert(9);
//tree1.Insert(1);
//tree1.Insert(6);
//tree1.Insert(8);
//tree1.Insert(10);
//var equal = tree.Equal(tree1);
//Console.WriteLine(@$"The two trees are equal: {equal}");

//Console.WriteLine($"This is a binary search tree: {tree.IsBinarySearchTree()}");

//Console.WriteLine($"The node at the distance from root is {string.Join(',', tree.PrintNodesAtDistance(2))}");

//Console.WriteLine("Begin Level Order Traversal \n\n");
//tree.LevelOrderTraversal();