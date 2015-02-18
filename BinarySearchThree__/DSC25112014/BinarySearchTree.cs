using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSC25112014
{
    class BinarySearchTree<T> where T:IComparable
    {
        public TNode<T> root;
        public int height()
        {
            return height(root);
        }
        public int height(TNode<T> myRoot)
        {
            if (myRoot == null)
                return 0;
            else if (height(myRoot.Left) > height(myRoot.Right))
                return 1 + height(myRoot.Left);
            else
                return 1 + height(myRoot.Right);

        }
        public bool isBalanced()
        {
            return isBalanced(root);
        }
        public bool isBalanced(TNode<T> currentRoot)
        {
            if (Math.Abs(height(currentRoot.Left) - height(currentRoot.Right)) > 1)
                return false;
            return true;
        }
        public bool search(TNode<T> currentRoot, T val)
        {
            TNode<T> iterator = currentRoot;
            while (iterator != null)
            {
                if (iterator.Value.CompareTo(val) == 1)
                    iterator = iterator.Left;
                else if (iterator.Value.CompareTo(val) == -1)
                    iterator = iterator.Right;
                else
                    return true;
            }
            return false;

        }
        public void rotateRight(TNode<T> nodeN)
        {
            TNode<T> nodeC = nodeN.Left;
            nodeN.Left = nodeC.Right;
            nodeC.Right = nodeN;
            if (root == nodeN)
                root = nodeC;
            else
            {
                TNode<T> parent = findParent(nodeN.Value);
                if (parent.Left == nodeN)
                    parent.Left = nodeC;
                else
                    parent.Right = nodeC;
            }

        }
        public void insertAVL(T val)
        {
            this.insert(val);


        }

        public void insert(T val)
        {
            TNode<T> newNode = new TNode<T>(val);
            if (root == null)
                root = newNode;
            else
            {
                TNode<T> iterator = root;
                while (iterator != null)
                {
                    if (iterator.Value.CompareTo(val) >= 0)
                    {
                        if (iterator.Left == null)
                        {
                            iterator.Left = newNode;
                            break;
                        }
                        else
                            iterator = iterator.Left;
                    }
                    else
                    {
                        if (iterator.Right == null)
                        {
                            iterator.Right = newNode;
                            break;
                        }
                        else
                            iterator = iterator.Right;
                    }

                }

            }


        }
        public void insertRecursively(T val)
        {
            root = insertRecursively(root, val);
        }
        public TNode<T> insertRecursively(TNode<T> currentRoot, T val)
        {
            if (currentRoot == null)
                return new TNode<T>(val);
            else if (currentRoot.Value.CompareTo(val) >= 0)
                currentRoot.Left = insertRecursively(currentRoot.Left, val);
            else
                currentRoot.Right = insertRecursively(currentRoot.Right, val);

            return currentRoot;
        }
        public bool search(T val)
        {
            TNode<T> iterator = root;
            while (iterator != null)
            {
                if (iterator.Value.CompareTo(val) == 1)
                    iterator = iterator.Left;
                else if (iterator.Value.CompareTo(val) == -1)
                    iterator = iterator.Right;
                else
                    return true;
            }
            return false;
        }
        public bool searchRecursively(T val)
        {
            return searchRecursively(root, val);
        }
        public bool searchRecursively(TNode<T> currentRoot, T val)
        {
            if (currentRoot == null)
                return false;
            else if (currentRoot.Value.CompareTo(val) == 1)
                return searchRecursively(currentRoot.Left, val);
            else if (currentRoot.Value.CompareTo(val) == -1)
                return searchRecursively(currentRoot.Right, val);
            else
                return true;
        
        }
        public void inorder()
        {
            inorder(root);
            Console.WriteLine();
        }
        public void inorder(TNode<T> currentRoot)
        {
            if (currentRoot != null)
            {
                inorder(currentRoot.Left);
                Console.WriteLine(currentRoot.Value);
                inorder(currentRoot.Right);
            }
        }
        public void postOrder()
        {
            postOrder(root);
            Console.WriteLine();
        }
        public void postOrder(TNode<T> currentRoot)
        {
            if (currentRoot != null)
            {
                postOrder(currentRoot.Left);
                postOrder(currentRoot.Right);
                Console.WriteLine(currentRoot.Value);
            }
        }
        public void preOrder()
        {
            preOrder(root);
            Console.WriteLine();
        }
        public void preOrder(TNode<T> currentRoot)
        {
            if (currentRoot != null)
            {
                Console.WriteLine(currentRoot.Value);
                preOrder(currentRoot.Left);
                preOrder(currentRoot.Right);
            }
        }

        public TNode<T> findNode(T val)
        {
            TNode<T> iterator = root;
            while (iterator != null)
            {
                if (iterator.Value.CompareTo(val) == 1)
                    iterator = iterator.Left;
                else if (iterator.Value.CompareTo(val) == -1)
                    iterator = iterator.Right;
                else
                    return iterator;
            }
            return null; 
        }
        public TNode<T> findParent(T val)
        {
            if (!search(val) || root.Value.CompareTo(val) == 0)
                return null;//or throw exception
            else
            {
                TNode<T> parent = root, iterator = root;
                while (iterator != null)
                {
                    if (iterator.Value.CompareTo(val) == 0)
                        return parent;
                    else
                        parent=iterator;
                    if (iterator.Value.CompareTo(val) == 1)
                        iterator = iterator.Left;
                    else
                        iterator = iterator.Right;
                }
                return parent;

            }
        }

        public TNode<T> findInorderSuccessor(T val)
        {
            TNode<T> current = findNode(val);
            TNode<T> parent=findParent(val);
            if (current != null)
            {
                if (current.Right != null)//sağ cocuk varsa
                {
                    TNode<T> iterator = current.Right;
                    while (iterator.Left != null)
                        iterator = iterator.Left;
                    return iterator;
                }//parent varsa ve parentin solundaysa
                else if (parent != null && parent.Left == current)
                    return parent;
 
            }
            return null;
   
        }
        public void delete(T val)
        {
            if (root != null && root.Right == null && root.Value.CompareTo(val) == 0)
                root = root.Left;
            else
            {
                TNode<T> current = findNode(val);
                TNode<T> parent = findParent(val);
                if (current != null)
                {
                    if (current.Left == null && current.Right == null)
                    {
                        if (parent.Left == current)
                            parent.Left = null;
                        else
                            parent.Right = null;

                    }else if (current.Left != null && current.Right != null)
                    {
                        TNode<T> successor = findInorderSuccessor(val);
                        delete(successor.Value);
                        current.Value = successor.Value;
  
                    }
                    else
                    {
                        TNode<T> child;
                        if (current.Left == null)
                            child = current.Right;
                        else
                            child = current.Left;
                        if (parent.Left == current)
                            parent.Left = child;
                        else
                            parent.Right = child;
                     }
 
                }
            }
        }

    }
}
