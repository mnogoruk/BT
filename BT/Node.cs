using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT
{
    class Node<T>
    {
        public Node(int key, T value, Node<T> right, Node<T> left) 
            : this(key, value)
        {

            Left = left;
            Right = right;
        }

        public Node(int key, T value) 
        {
            Key = key;
            Value = value;
        }
        public T Value { get; set; }
        public int Key { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
    }
}
