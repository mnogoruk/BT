using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT
{
    class NodeFunc<T>
    {
        public static Node<T> MostLeft(Node<T> node)
        {
            if (node.Left is null)
                return node;
            else
                return MostLeft(node.Left);
        } 

        public static Node<T> MostRight(Node<T> node)
        {
            if (node.Right is null)
                return node;
            else
                return MostRight(node.Right);
        }
    }
}
