using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT
{
    interface ITree<T>
    {
        public void Add(int key, T value);
        public void Remove(int key);
        public Node<T> Search(int key);
    }
}
