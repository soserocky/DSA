using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA
{
    internal class LinkedList
    {
        private Node _head;
        internal static void Start()
        {
            var head = CreateSinglyLinkedList();
            //TraverseLinkedList(head);
            //RecursiveTraverseLinkedList(head);
            //head = InsertAtBeginningOfLinkedList(head, 0);
            //head = InsertAtEndOfLinkedList(head, 11);
            //head = DeleteHeadNodeOfLinkedList(head);
            //head = DeleteEndNodeOfLinkedList(head);
            //head = InsertAtGivenPositionOfLinkedList(head, 12, 12);
            //Console.WriteLine(SearchAGivenKeyLinkedListIterative(head, 12));
            var dllHead = CreateDoublyLinkedList();
            //InsertAtBeginningOfDoublyLinkedList(dllHead, 0);
            ReverseDoublyLinkedList(dllHead, null);
        }
        private static Node CreateSinglyLinkedList()
        {
            var head = new Node(1);
            var node2 = new Node(2);
            var node3 = new Node(3);
            var node4 = new Node(4);
            var node5 = new Node(5);
            var node6 = new Node(6);
            var node7 = new Node(7);
            var node8 = new Node(8);
            var node9 = new Node(9);
            var node10 = new Node(10);

            head.Next = node2;
            node2.Next = node3;
            node3.Next = node4;
            node4.Next = node5;
            node5.Next = node6;
            node6.Next = node7;
            node7.Next = node8;
            node8.Next = node9;
            node9.Next = node10;

            return head;
        }
        private static void TraverseLinkedList(Node head)
        {
            if (head == null) return;

            while (head != null)
            {
                Console.WriteLine($"Node with value: {head.Value}");
                head = head.Next;
            }
        }
        
        private static void RecursiveTraverseLinkedList(Node head)
        {
            if (head == null) return;
            Console.WriteLine($"Node with value: {head.Value}");
            RecursiveTraverseLinkedList(head.Next);
        }
        
        private static Node InsertAtBeginningOfLinkedList(Node head, int number)
        {
            Node newHead = new Node(number);
            newHead.Next = head;
            return newHead;
        }

        private static Node InsertAtEndOfLinkedList(Node head, int number)
        {
            var endNode = new Node(number);
            if (head == null) return endNode;

            var node = head;
            while (node.Next != null)
            {
                node = node.Next;
            }
            node.Next = endNode;
            return head;
        }
        private static Node DeleteHeadNodeOfLinkedList(Node head)
        {
            if (head == null || head.Next == null) return null;
            var node = head.Next;
            head = null;
            return node;
        }
        private static Node DeleteEndNodeOfLinkedList(Node head)
        {
            if (head == null || head.Next == null) return null;

            var node = head;
            while (node.Next != null)
            {
                node = node.Next;
            }
            node.Next = null;
            return head;
        }

        private static Node InsertAtGivenPositionOfLinkedList(Node head, int number, int position)
        {
            var n = new Node(number);

            if (position < 1) return head;
            if (position == 1)
            {
                if (head != null) n.Next = head;

                return n;
            }

            int count = 1;
            Node prevNode = head;
            var node = prevNode.Next;

            while (node != null)
            {
                count++;
                if (count == position) break;
                node = node.Next;
                prevNode = node;
            }

            if (count == position)
            {
                n.Next = node;
                prevNode.Next = n;
            }
            return head;
        }

        private static int SearchAGivenKeyLinkedListIterative(Node head, int key)
        {
            if (head == null) return -1;

            int position = 1;
            var node = head;
            while (node != null)
            {
                if (node.Value == key) return position;
                node = node.Next;
            }
            return -1;
        }

        private static int SearchAGivenKeyLinkedListRecursive(Node head, int key, int position)
        {
            if (head == null) return -1;

            if (head.Value == key) return position + 1;

            return SearchAGivenKeyLinkedListRecursive(head.Next, key, position + 1);
        }

        private static DLLNode CreateDoublyLinkedList()
        {
            var head = new DLLNode(1);
            var node2 = new DLLNode(2);
            var node3 = new DLLNode(3);
            var node4 = new DLLNode(4);
            var node5 = new DLLNode(5);
            var node6 = new DLLNode(6);
            var node7 = new DLLNode(7);
            var node8 = new DLLNode(8);
            var node9 = new DLLNode(9);
            var node10 = new DLLNode(10);

            head.Next = node2;

            node2.Previous = head;
            node2.Next = node3;

            node3.Previous = node2;
            node3.Next = node4;

            node4.Previous = node3;
            node4.Next = node5;

            node5.Previous = node4;
            node5.Next = node6;

            node6.Previous = node5;
            node6.Next = node7;

            node7.Previous = node6;
            node7.Next = node8;

            node8.Previous = node7;
            node8.Next = node9;

            node9.Previous = node8;
            node9.Next = node10;

            node10.Previous = node9;

            return head;
        }

        private static void TraverseDoublyLinkedList(DLLNode head)
        {
            if (head == null) return;

            while (head != null)
            {
                Console.WriteLine($"Doubly Linked List Node with value: {head.Value}");
                head = head.Next;
            }
        }
        private static DLLNode InsertAtBeginningOfDoublyLinkedList(DLLNode head, int number)
        {
            var newHead = new DLLNode(number);
            if (head != null)
            {
                newHead.Next = head;
                head.Previous = newHead;
            }
            return newHead;
        }
        private static DLLNode ReverseDoublyLinkedList(DLLNode head, DLLNode prev)
        {
            if (head != null) head.Next = prev;
            if (prev != null) prev.Previous = head;
            
            if (head.Next == null) return head;
            return ReverseDoublyLinkedList(head.Next, head);
        }
    }

    internal class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }

        public Node(int value)
        {
            Value = value;
            Next = null;
        }
    }

    internal class DLLNode
    {
        public int Value { get; set; }
        public DLLNode Next { get; set; }
        public DLLNode Previous { get; set; }

        public DLLNode(int value)
        {
            Value = value;
            Next = null;
            Previous = null;
        }
    }
}