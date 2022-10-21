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
            //dllHead = ReverseDoublyLinkedList(dllHead, null);
            //TraverseDoublyLinkedList(dllHead);
            //dllHead = DeleteHeadOfDoublyLinkedList(dllHead);
            var circularHead = CreateCircularLinkedList();
            //TraverseCircularLinkedList(circularHead);
            //InsertAtBeginningOfCircularLinkedList(head, 5);
            //circularHead = DeleteHeadOfCircularLinkedList(circularHead);
            //ReverseLinkedList_Iterative(head);
            //ReverseLinkedListInGroupsOfK(head, 3);
            DetectLoopInLinkedList(head);
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
            if (head == null) return prev;
            if (prev != null) prev.Previous = head;
            var next = head.Next;
            head.Next = prev;
            if (next == null) return head;
            return ReverseDoublyLinkedList(next, head);
        }
        private static DLLNode DeleteHeadOfDoublyLinkedList(DLLNode head)
        {
            if (head == null || head.Next == null)
            {
                head = null;
                return null;
            }
            var next = head.Next;
            head = null;
            return next;
        }
        private static DLLNode DeleteEndOfDoublyLinkedList(DLLNode head)
        {
            if (head == null) return null;

            var node = head;
            DLLNode prevNode = null;
            while (node.Next != null)
            {
                node = node.Next;
                prevNode = node;
            }
            prevNode.Next = null;
            node.Previous = null;

            return prevNode;
        }
        private static Node CreateCircularLinkedList()
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
            node10.Next = head;

            return head;
        }
        private static void TraverseCircularLinkedList(Node head)
        {
            var node = head;
            while (true)
            {
                Console.WriteLine($"Circular Linked List - Node with value: {node.Value}");
                node = node.Next;
                if (node == head) return;
            }
        }
        private static Node InsertAtBeginningOfCircularLinkedList(Node head, int number)
        {
            Node newNode = new Node(number);
            if (head == null) return newNode;
            var node = head;
            while (node.Next != head)
            {
                node = node.Next;
            }
            
            node.Next = newNode;
            newNode.Next = head;
            return newNode;
        }
        private static Node InsertAtEndOfCircularLinkedList(Node head, int number)
        {
            Node newNode = new Node(number);
            if (head == null) return newNode;
            var node = head;
            while (node.Next != head)
            {
                node = node.Next;
            }

            node.Next = newNode;
            newNode.Next = head;
            return head;
        }
        private static Node DeleteHeadOfCircularLinkedList(Node head)
        {
            if (head == null || head.Next == null) return null;
            var next = head.Next;
            var node = next;
            while (node.Next != head)
            {
                node = node.Next;
            }

            node.Next = next;
            head = null;
            return next;
        }
        private static Node DeleteEndOfCircularLinkedList(Node head)
        {
            if (head == null || head.Next == null) return null;
            var next = head.Next;
            var node = next;
            while (node.Next != head)
            {
                node = node.Next;
            }

            node.Next = next;
            head = null;
            return next;
        }

        private static Node DeletKthNodeOfCircularLinkedList(Node head, int k)
        {
            if (head == null) return null;

            var node = head;
            var count = 1;
            var prevNode = head;
            while (count < k && node != null)
            {
                prevNode = node;
                node = node.Next;
                count++;
            }
            var next = node.Next;
            prevNode.Next = next;

            if (node == head) return head.Next;

            return head;
        }

        private static Node SortedInsertInASortedLinkedList(Node head, int number)
        {
            var newNode = new Node(number);
            if (head == null) return newNode;
            var node = head;
            while (node.Value < number)
            {
                node = node.Next;
            }

            if (node.Next == null) node.Next = newNode;
            else
            {
                var next = node.Next;
                node.Next = newNode;
                newNode.Next = next;
            }
            return head;
        }
        private static Node MiddleOfLinkedList(Node head)
        {
            if (head == null) return null;
            if (head.Next == null || head.Next.Next == null) return head;
            var slow = head;
            var fast = head;
            while (fast.Next != null && fast.Next.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }
            return slow;
        }

        private static Node ReverseLinkedList_Iterative(Node head)
        {
            if (head == null) return null;
            var current = head;
            Node previous = null, next = null;
            while (current != null)
            {
                next = current.Next;
                current.Next = previous;
                previous = current;
                current = next;
            }
            return previous;
        }
        private static Node ReverseLinkedList_Recursive(Node current, Node previous = null)
        {
            if (current == null) return previous;
            if (current.Next == null)
            {
                current.Next = previous;
                return previous;
            }
            var next = current.Next;
            current.Next = previous;
            return ReverseLinkedList_Recursive(next, current);
        }
        private static Node RemoveDuplicatesFromSortedLinkedList(Node head)
        {
            var node = head;
            while (node != null)
            {
                if (node.Next != null && node.Value == node.Next.Value) node.Next = node.Next.Next;
                node = node.Next;
            }
            return head;
        }
        private static Node ReverseLinkedListInGroupsOfK(Node head, int k)
        {
            var current = head;
            Node previous = null, next = null, tailOfPrevGroup = head;
            int count = 0; var isHeadFlag = true;
            while (current != null)
            {
                next = current.Next;
                current.Next = previous;
                previous = current;
                current = next;
                count++;
                if (count == k)
                {
                    if (isHeadFlag)
                    {
                        head = previous;
                        isHeadFlag = false;
                    }
                    tailOfPrevGroup.Next = previous;
                    tailOfPrevGroup = current;
                }

            }
            tailOfPrevGroup.Next = previous;
            if (isHeadFlag && count > 0) head = previous;
            return head;
        }
        private static bool DetectLoopInLinkedList(Node head)
        {
            if (head == null || head.Next == null) return false;

            Node slow = head, fast = head;
            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;

                if (slow == fast) return true;
            }
            return false;
        }

        private static Node DetectAndRemoveLoopInLinkedList(Node head)
        {
            if (head == null || head.Next == null) return head;

            Node slow = head, fast = head;
            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;

                if (slow == fast)
                {
                    slow = head;
                    while (slow.Next != fast.Next)
                    {
                        slow = slow.Next;
                        fast = fast.Next;
                    }
                    fast.Next = null;
                    return head;
                }
            }
            return head;
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