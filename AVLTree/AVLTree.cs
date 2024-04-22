using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_structure_and_algo.AVLTree
{
    public class AVLTree
    {
        private class AVLTreeNode
        {
            public int Value;
            public AVLTreeNode LeftChild;
            public AVLTreeNode RightChild;
            public int Height;

            public AVLTreeNode(int value)
            {
                Value = value;
            }
        }
        private AVLTreeNode root;

        public void Insert(int value)
        {
            root = Insert(root, value);
        }
        private AVLTreeNode Insert(AVLTreeNode root, int value)
        {
            if (root is null)
            {
                return new AVLTreeNode(value); ;
            }

            if (value < root.Value)
            {
                root.LeftChild = Insert(root.LeftChild, value);
            }
            else
            {
                root.RightChild = Insert(root.RightChild, value);
            }
            SetHeight(root);

            return Balanced(root);
        }

        private AVLTreeNode Balanced(AVLTreeNode root)
        {
            if(IsLeftHeavy(root))
            {
                if(BalanceFactor(root.LeftChild) < 0)
                {
                    Console.WriteLine($"Left Rotate on {root.LeftChild.Value}");
                    root.LeftChild = RotateLeft(root.LeftChild);
                }
                Console.WriteLine($"Right Rotate on {root.Value}");
                return RotateRight(root);
            }
            else if(IsRightHeavy(root))
            {
                if(BalanceFactor(root.RightChild) > 0)
                {
                    Console.WriteLine($"Right Rotate on {root.RightChild.Value}");
                    root.RightChild = RotateRight(root.RightChild);
                }
                Console.WriteLine($"Left Rotate on {root.Value}");
                return RotateLeft(root);
            }
            return root;
        }
        private AVLTreeNode RotateLeft(AVLTreeNode root)
        {
            var newRoot = root.RightChild;

            root.RightChild = newRoot.LeftChild;
            newRoot.LeftChild = root;

            SetHeight(newRoot);
            SetHeight(root);

            return newRoot;
        }

        private AVLTreeNode RotateRight(AVLTreeNode node)
        {
            var newRoot = root.LeftChild;

            root.LeftChild = newRoot.RightChild;
            newRoot.RightChild = root;

            SetHeight(newRoot);
            SetHeight(root);

            return newRoot;
        }
        private void SetHeight(AVLTreeNode node)
        {
             node.Height = Math.Max(
                Height(node.LeftChild),
                Height(node.RightChild)) + 1;
        }
        private int Height(AVLTreeNode node)
        {
            return node is null ? -1 : node.Height;
        }

        private bool IsLeftHeavy(AVLTreeNode node)
        {
            return BalanceFactor(node) > 1;
        }

        private int BalanceFactor(AVLTreeNode node)
        {
            return node is null ? 0 : Height(node.LeftChild) - Height(node.RightChild);
        }
        private bool IsRightHeavy(AVLTreeNode node)
        {
            return BalanceFactor(node) < -1;
        }
    }
}
