namespace data_structure_and_algo.BinaryTree
{
    public class Tree
    {
        protected class Node
        {
            public int Value;
            public Node leftChild;
            public Node rightChild;

            public Node(int value)
            {
                Value = value;
            }
        }

        protected Node root;

        public void Insert(int value)
        {
            var node = new Node(value);
            if (root == null)
            {
                root = node;
                return;
            }

            var current = root;
            while(true)
            {
                if (value < current.Value)
                {
                    if(current.leftChild == null)
                    {
                        current.leftChild = node;
                        break;
                    }
                    current = current.leftChild;
                }
                else
                {
                    if (current.rightChild == null)
                    {
                        current.rightChild = node;
                        break;
                    }
                    current = current.rightChild;
                }
            }
            
        }
        public bool Find(int value)
        {
            var current = root;

            while(current != null) 
            {
                if(value < current.Value)
                {
                    current = current.leftChild;
                }
                else if(value > current.Value)
                {
                    current=current.rightChild;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }
        public void TraversePreOrder()
        {
            TraversePreOrder(root);
        }
        private void TraversePreOrder(Node node)
        {
            // Root
            // Left node
            // Right node
            if(node == null)
                return;

            Console.WriteLine(node.Value);
            TraversePreOrder(node.leftChild);
            TraversePreOrder(node.rightChild);
        }

        public void TraverseInOrder()
        {
            TraverseInOrder(root);
        }
        private void TraverseInOrder(Node node)
        {
            //Left Node
            //Root Node
            //Right Node
            if (node == null)
                return;

            TraverseInOrder(node.leftChild);
            Console.WriteLine(node.Value);
            TraverseInOrder(node.rightChild);
        }

        public void TraversePostOrder()
        {
            TraversePostOrder(root);
        }
        private void TraversePostOrder(Node node)
        {
            //Left Node
            //Right Node
            //Root Node
            if (node == null)
                return;

            TraversePostOrder(node.leftChild);
            TraversePostOrder(node.rightChild);
            Console.WriteLine(node.Value);
        }

        public int Height()
        {
            return Height(root);
        }

        private int Height(Node node)
        {
            if (root == null)
                return -1;

            if(IsLeaf(node)) 
                return 0;

            return 1 + Math.Max(Height(node.leftChild), Height(node.rightChild));
        }

        public int Min()
        {
            return Min(root);
        }
        private int Min(Node node)
        {
            int left = Min(node.leftChild);
            int right = Min(node.rightChild);

            return Math.Min(Math.Min(left, right), root.Value);
        }
        private bool IsLeaf(Node node)
        {
            return node.rightChild is null && node.leftChild is null;
        }

        public bool Equal(Tree otherTree)
        {
            return Equal(root, otherTree.root);
        }

        private bool Equal(Node first, Node second)
        {
            if (first is null && second is null)
                return true;

            if (first is not null && second is not null)
            {
                return first.Value == second.Value
                    && Equals(first.leftChild, second.leftChild)
                    && Equals(first.rightChild, second.rightChild);
            }
            return false;
        }

        public bool IsBinarySearchTree()
        {
            return IsBinarySearchTree(root, int.MinValue, int.MaxValue);
        }

        private bool IsBinarySearchTree(Node node, int min, int max)
        {
            if (node is null)
                return true;

            if(node.Value < min || node.Value > max)
                return false;

            return IsBinarySearchTree(node.leftChild, min, node.leftChild.Value - 1) && IsBinarySearchTree(node.rightChild, node.rightChild.Value + 1, max);
        }

        public List<int> PrintNodesAtDistance(int distance)
        {
            var result = new List<int>();
            PrintNodesAtDistance(root, distance, result);
            return result;
        }

        private void PrintNodesAtDistance(Node root, int distance, List<int> result)
        {
            if (root is null)
                return;

            if(distance is 0)
            {
                result.Add(root.Value) ;
            }

            PrintNodesAtDistance(root.leftChild, distance - 1, result);
            PrintNodesAtDistance(root.rightChild, distance - 1, result);
        }

        public void LevelOrderTraversal()
        {
            for (int i = 0; i <= Height(); i++)
            {
                foreach(var item in PrintNodesAtDistance(i))
                {
                    Console.WriteLine(item) ;
                }
            }
        }
    }
}
