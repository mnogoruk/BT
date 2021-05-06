using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT
{
    class Caclculator
    {
        private Stack<string> Stack { get; set; }
        public BinaryTree<string> BinaryTree { get; set; }
        public Caclculator(Node<string> rootNode) {
            BinaryTree = new BinaryTree<string>(Visting);
            BinaryTree.RootNode = rootNode;
            Stack = new Stack<string>();
        }
        public float Calculate()
        {
            BinaryTree.LRN();
            return float.Parse(Stack.Pop());
        }
        private void Visting(Node<string> node)
        {
            if (IsOpertor(node.Value))
                Stack.Push(Operate(Stack.Pop(), Stack.Pop(), node.Value));
            else if (IsDigit(node.Value))
                Stack.Push(node.Value);
            else
                throw new ArithmeticException("Wrong node value");
        }
        private string Operate(string number1, string number2, string op)
        {
            switch (op)
            {
                case "+":
                    return (float.Parse(number1) + float.Parse(number2)).ToString();
                case "-":
                    return (float.Parse(number1) - float.Parse(number2)).ToString();
                case "*":
                    return (float.Parse(number1) * float.Parse(number2)).ToString();
                case "/":
                    return (float.Parse(number1) / float.Parse(number2)).ToString();
                default:
                    throw new ArithmeticException("Wrong operator.");
            }
        }

        private bool IsOpertor(string value)
        {
            switch (value)
            {
                case "+":
                    return true;
                case "/":
                    return true;
                case "*":
                    return true;
                case "-":
                    return true;
                default:
                    return false;
            }
        }
        private bool IsDigit(string value)
        {
            try
            {
                float.Parse(value);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
