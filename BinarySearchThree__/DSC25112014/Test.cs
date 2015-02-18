using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSC25112014
{
    class Test
    {

        static void Main(string[] args)
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();
            bst.insertRecursively(20);
            
            bst.insert(10);
            bst.insert(30);
            bst.insert(35);

            bst.insert(15);
            bst.insert(5);
            bst.insert(3);
            bst.insert(6);
            bst.insert(2);
            //bst.insert(25);
            //bst.insertRecursively(17);
            bst.rotateRight(bst.root.Left);
            Console.WriteLine(bst.root.Left.Value);
            bst.inorder();
            //Console.WriteLine(bst.height());
            //Console.WriteLine(bst.isBalanced());
            //bst.postOrder();
            //bst.preOrder();
            //bst.delete(30);
            //bst.inorder();
            //Console.WriteLine(bst.search(5));
            //Console.WriteLine(bst.search(55));
            //Console.WriteLine(bst.searchRecursively(5));
            //Console.WriteLine(bst.searchRecursively(55));
            //Console.WriteLine(bst.findParent(10));

            //Console.WriteLine(bst.findInorderSuccessor(30));

        }
    }
}
