using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSC25112014
{
    class TNode<T> where T:IComparable
    {
        T value;

        public T Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
        TNode<T> left, right;

        internal TNode<T> Right
        {
            get { return right; }
            set { right = value; }
        }

        internal TNode<T> Left
        {
            get { return left; }
            set { left = value; }
        }
        public TNode(T val)
        {
            value = val;
        }
        public override string ToString()
        {
            return value.ToString();
        }

    }
}
