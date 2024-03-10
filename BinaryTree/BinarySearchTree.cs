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
