using System;

namespace BT
{
    class Program
    {
        static void Visiter(Node<string> node)
        {
            string node_right;
            string node_left;
            if (!(node.Right is null))
                node_right = node.Right.Value + " : " + node.Right.Key.ToString();
            else
                node_right = "null";

            if (!(node.Left is null))
                node_left = node.Left.Value + " : " + node.Left.Key.ToString();
            else
                node_left = "null";
            Console.WriteLine("{0:N} - {1}: (({2}) | ({3}))", node.Key, node.Value, node_left, node_right);
        }

        static void Main(string[] args)
        {
            BinaryTree<string> bt = new BinaryTree<string>(Visiter);
            bt.Add(59, "a");
            bt.Add(30, "b");
            bt.Add(98, "c");
            bt.Add(16, "d");
            bt.Add(45, "e");
            bt.Add(125, "f");
            Console.WriteLine("Прямой обход");
            bt.NLR();
            Console.WriteLine("Обратный обход");
            bt.LRN();
            Console.WriteLine("Кольцевой обход");
            bt.LNR();

            Node<string> node1 = new Node<string>(-1, "2");
            Node<string> node2 = new Node<string>(-1, "3");
            Node<string> node3 = new Node<string>(-1, "4");
            Node<string> node4 = new Node<string>(-1, "7");
            Node<string> node5 = new Node<string>(-1, "3");
            Node<string> node6 = new Node<string>(-1, "+", node2, node1);
            Node<string> node7 = new Node<string>(-1, "-", node4, node3);
            Node<string> node8 = new Node<string>(-1, "*", node6, node7);
            Node<string> node9 = new Node<string>(-1, "/", node8, node5);
            Console.WriteLine("Значение обхода дереав");
            Caclculator caclculator = new Caclculator(node9);
            Console.WriteLine(caclculator.Calculate());
        }
    }
}
