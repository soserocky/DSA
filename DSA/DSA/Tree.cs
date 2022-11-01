namespace DSA
{
    internal class Tree
    {
        internal static void Start()
        {
            var root = ConstructTree();
            //InOrderTraversal(root);
            //PreOrderTraversal(root);
            //PostOrderTraversal(root);
            //HeightOfBinaryTree(root);
            //PrintNodesAtDistanceKFromRoot(root, 2, 0);
            //LevelOrderTraversal_Naive(root);
            //var queue = new Queue<TreeNode>();
            //queue.Enqueue(root);
            //LevelOrderTraversal_Efficient(queue);
            //SizeOfBinaryTree(root);
            //MaximumOfBinaryTree(root);
            //PrintLeftViewOfBinaryTree(root);
            //ChildrenSumProperty(root);
        }

        private static TreeNode ConstructTree()
        {
            var root = new TreeNode(0);
            var one = new TreeNode(1);
            var two = new TreeNode(2);
            var three = new TreeNode(3);
            var four = new TreeNode(4);
            var five = new TreeNode(5);
            var six = new TreeNode(6);
            var seven = new TreeNode(7);
            var eight = new TreeNode(8);
            var nine = new TreeNode(9);
            var ten = new TreeNode(10);

            root.Left = one;
            root.Right = two;

            one.Left = three;
            one.Right = four;

            two.Left = five;
            two.Right = six;

            three.Left = seven;
            three.Right = eight;

            four.Left = nine;
            four.Right = ten;

            return root;
        }
        private static void InOrderTraversal(TreeNode root)
        {
            if (root != null)
            {
                InOrderTraversal(root.Left);
                Console.Write(root.Value + "  ");
                InOrderTraversal(root.Right);
            }
        }
        private static void PreOrderTraversal(TreeNode root)
        {
            if (root != null)
            {
                PreOrderTraversal(root.Left);
                PreOrderTraversal(root.Right);
                Console.Write(root.Value + "  ");
            }
        }
        private static void PostOrderTraversal(TreeNode root)
        {
            if (root != null)
            {
                Console.Write(root.Value + "  ");
                PostOrderTraversal(root.Left);
                PostOrderTraversal(root.Right);
            }
        }
        private static int HeightOfBinaryTree(TreeNode root)
        {
            if (root == null) return 0;

            var h1 = HeightOfBinaryTree(root.Left);
            var h2 = HeightOfBinaryTree(root.Right);

            if (h1 > h2) return h1 + 1;

            else return h2 + 1;
        }
        private static void PrintNodesAtDistanceKFromRoot(TreeNode root, int k, int distance)
        {
            if (root == null) return;

            if (k == distance)
            {
                Console.Write($"{root.Value} ");
                return;
            }

            PrintNodesAtDistanceKFromRoot(root.Left, k, distance + 1);
            PrintNodesAtDistanceKFromRoot(root.Right, k, distance + 1);
        }
        private static void LevelOrderTraversal_Naive(TreeNode root)
        {
            var height = HeightOfBinaryTree(root);
            for (int i = 0; i <= height; i++)
            {
                PrintNodesAtDistanceKFromRoot(root, i, 0);
                Console.WriteLine("");
            }
        }
        private static void LevelOrderTraversal_Efficient(Queue<TreeNode> queue)
        {
            var queue2 = new Queue<TreeNode>();
            while (queue.Count() > 0)
            {
                var node = queue.Dequeue();
                Console.Write(node.Value + " ");
                if (node.Left != null) queue2.Enqueue(node.Left);
                if (node.Right != null) queue2.Enqueue(node.Right);
            }
            if (queue2.Count() > 0)
            {
                Console.WriteLine("");
                LevelOrderTraversal_Efficient(queue2);
            }
        }
        private static int SizeOfBinaryTree(TreeNode root)
        {
            if (root == null) return 0;

            return 1 + SizeOfBinaryTree(root.Left) + SizeOfBinaryTree(root.Right);
        }
        private static int MaximumOfBinaryTree(TreeNode root)
        {
            if (root == null) return int.MinValue;

            var leftMax = MaximumOfBinaryTree(root.Left);
            var rightMax = MaximumOfBinaryTree(root.Right);
            var current = root.Value;

            if (current >= leftMax && current >= rightMax) return current;

            else if (leftMax >= current && leftMax >= rightMax) return leftMax;

            return rightMax;
        }
        private static void PrintLeftViewOfBinaryTree(TreeNode root)
        {
           if (root == null) return;

           var queue = new Queue<TreeNode>();
           queue.Enqueue(root);
           PrintLeftViewOfBinaryTree_Helper(queue);
        }
        private static void PrintLeftViewOfBinaryTree_Helper(Queue<TreeNode> queue)
        {
            var queue2 = new Queue<TreeNode>();
            var count = 0;
            while (queue.Count() > 0)
            {
                var node = queue.Dequeue();
                if (count == 0)
                {
                    Console.WriteLine(node.Value + " ");
                    count++;
                }
                if (node.Left != null) queue2.Enqueue(node.Left);
                if (node.Right != null) queue2.Enqueue(node.Right);
            }
            if (queue2.Count() > 0) PrintLeftViewOfBinaryTree_Helper(queue2);
        }
        private static bool ChildrenSumProperty(TreeNode root)
        {
            if (root == null) return true;

            var left  = root.Left;
            var right = root.Right;

            if (left == null && right == null) return true;

            var leftValue = left == null ? 0 : left.Value;
            var rightValue = right == null ? 0 : right.Value;

            if (root.Value == leftValue + rightValue) return ChildrenSumProperty(left) && ChildrenSumProperty(right);

            return false;
        }
        private static int MaxWidthOfBinaryTree(TreeNode root)
        {
            if (root == null) return 0;

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            return MaxWidthOfBinaryTree_Helper(queue, 1);
        }
        private static int MaxWidthOfBinaryTree_Helper(Queue<TreeNode> queue, int maxWidth)
        {
            var queue2 = new Queue<TreeNode>();
            var count = 0;
            while (queue.Count() > 0)
            {
                var node = queue.Dequeue();
                count++;

                if (node.Left != null) queue2.Enqueue(node.Left);
                if (node.Right != null) queue2.Enqueue(node.Right);
            }
            if (count > maxWidth) maxWidth = count;
            if (queue2.Count() > 0) return MaxWidthOfBinaryTree_Helper(queue2, maxWidth);

            return maxWidth;
        }

    }

    internal class TreeNode
    {
        internal TreeNode(int value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
        internal TreeNode Left { get; set; }
        internal TreeNode Right { get; set; }
        internal int Value { get; set; }
    }
}