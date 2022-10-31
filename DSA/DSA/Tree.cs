namespace DSA
{
    internal class Tree
    {
        internal static void Start()
        {
            var root = ConstructTree();
            //InOrderTraversal(root);
            //PreOrderTraversal(root);
            PostOrderTraversal(root);
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
                PostOrderTraversal(root.Left);
                PostOrderTraversal(root.Right);
                Console.Write(root.Value + "  ");
            }
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