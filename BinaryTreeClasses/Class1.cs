



using System.ComponentModel.Design.Serialization;
using System.Reflection.Metadata.Ecma335;
using System.Transactions;

namespace BinaryTreeClasses;

public class BinaryTree
{

    TreeNode _root;
    public BinaryTree()
    {
        _root = null;
    }
    public void Add(int v)
    {
        TreeNode newNode = new TreeNode(v);

        TreeNode current = _root;
        TreeNode parent = null;
        
        while (current != null)
        {
            parent = current;

            if (v >= current._value)
            {
                current = current._right;
            }
            else
            {
                current = current._left;
            }
        }

        if (v>=parent._value)
        {
            parent._right = newNode;
        }
        else
        {
            parent._left = newNode;
        }
    }

    public int Count()
    {
       return CountNodes(_root);
    }

    private int CountNodes(TreeNode node)
    {
        if (node == null)
        {
            return 0;
        }

        else
        {
            return 1 + CountNodes(node._left) + CountNodes(node._right);
        }
    }

    public bool Contains(int v)
    {
        TreeNode current = _root;

        while (current != null)
        {
            if (current._value == v)
            {
                return true;
            }

            if (current._value > v)
            {
                current = current._right;
            }

            else
            {
                current = current._left;
            }
        }
        return false;
    }

    public int Sum()
    {
        return _root._value + SumNode(_root);
    }

    private int SumNode(TreeNode node)
    {
        if (node == null)
        {
            return 0;
        }
        else
        {
            return node._value + SumNode(node._left) + SumNode(node._right);
        }
    }

    public override string ToString()
    {
        return _root == null ? "{}" : $"{{{_root}}}";    
    }

    public bool DuplicatesPresent()
    {
        TreeNode current = _root;
        TreeNode? iterate = null;

        while (iterate == null)
        {
            int count = 0;
            iterate = _root;
            if (current._value > iterate._value)
            {
                iterate = iterate._right;
            }
            else if (current._value == iterate._value)
            {
                count = count + 1;
                iterate = iterate._right;
            }
            else
            {
                iterate = iterate._left;
            }

            if (count >= 2)
            {
                return true;
            }
        }

        return false;
    }

    public int Depth()
    {
        if (_root == null)
        {
            return 0;
        }
        else
        {
            return 1 + DepthNode(_root._left) + DepthNode(_root._left);
        }
    }

    private int DepthNode(TreeNode node)
    {
        if (node == null)
        {
            return 0;
        }
        else
        {
            return 1 + DepthNode(node._left) + DepthNode(node._right);
        }
    }

    public bool isBalanced()
    {
        if (CountNodes(_root._left) == CountNodes(_root._right))
        {
            return true;
        }

        else
        {
            return false;
        }
    }

    public int LowestCommonAncestor(TreeNode node,int a, int b)
    {
        if (node == null || node._value == a || node._value ==b)
        {
            return node._value;
        }

        int left = LowestCommonAncestor(node._left, a, b);
        int right = LowestCommonAncestor(node._right, a, b);

        if (left != null && right != null)
        {
            return node._value;
        }

        if (left != null)
        {
            return left;
        }
        else
        {
            return right;
        }
    }
}


public class TreeNode
{
    public int _value;
    public TreeNode _left;
    public TreeNode _right;

    internal TreeNode(int v)
    {
        _value = v;
        _left = null;
        _right = null;
    }

    public override string ToString()
    {
        string left = _left == null ? "" : $"{_left}, ";
        string right = _right == null ? "" : $", {_right}";

        return $"{left}{_value}{right}";
    }
    
}