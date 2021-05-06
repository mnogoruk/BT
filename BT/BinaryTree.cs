using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT
{
    class BinaryTree<T> : ITree<T>
    {
        public delegate void VisitFunc(Node<T> node);
        
        public VisitFunc Visit { get; set; }
        public Node<T> RootNode { get; set; } = null;
       
        public BinaryTree (VisitFunc visit)
        {
            Visit = visit;
        }
        public void Add(int key, T value)
        {
            Node<T> node = new Node<T>(key, value);
            if (RootNode is null)
            {
                RootNode = node;
                return;
            }
            
            _add(RootNode, node);

        }
        private void _add(Node<T> current, Node<T> node)
        {
            if (current.Key < node.Key)
            {
                if (current.Right is null)
                    current.Right = node;
                else
                    _add(current.Right, node);
            }
            else
            {
                if (current.Left is null)
                    current.Left = node;
                else
                    _add(current.Left, node);
            }
        }

        public void Remove(int key)
        {
            _delete(RootNode, key);
        }
        private void _delete(Node<T> current, int key)
        {
            if (current.Key >= key)
            {
                if (current.Left is null)
                    return;
                if (current.Left.Key == key)
                {
                    current.Left = _recurcive_delete(current.Left);
                    return;
                }

                _delete(current.Left, key);

            }
            else
            {
                if (current.Right is null)
                    return;
                if (current.Right.Key == key)
                {
                    current.Right = _recurcive_delete(current.Right);
                    return;
                }
                _delete(current.Right, key);
            }
        }

        private Node<T> _recurcive_delete(Node<T> current)
        {

            if (current.Right is null)
                return current.Left;

            if (current.Left is null)
                return current.Right;

            Node<T> mostLeft = NodeFunc<T>.MostLeft(current.Right);
            mostLeft.Left = current.Left;
            return current.Right;
        }
        public Node<T> Search(int key)
        {
            return _search(RootNode, key);
        }
        private Node<T> _search(Node<T> node, int key)
        {
            if (node is null)
                return null;
            if (node.Key < key)
                return _search(node.Left, key);
            else if (node.Key > key)
                return _search(node.Right, key);
            else
                return node;

        }
        // прямой обход
        public void NLR() { _NLR(RootNode); }
        // кольцевой обход
        public void LNR() { _LNR(RootNode); }
        // обратный обход
        public void LRN() { _LRN(RootNode); }
        private void _NLR(Node<T> node)
        {
            if (node is null)
                return;

            Visit(node);
            _NLR(node.Left);
            _NLR(node.Right);
        }
        private void _LNR(Node<T> node)
        {
            if (node is null)
                return;
            _LNR(node.Left);
            Visit(node);
            _LNR(node.Right);
        }
        private void _LRN(Node<T> node)
        {
            if (node is null)
                return;
            _LRN(node.Left);
            _LRN(node.Right);
            Visit(node);
        }


    }
}
