using System;
using System.Collections.Generic;

namespace BinaryTreeClasses;

public class BinaryTree
{
    private TreeNode? _root;

    public BinaryTree()
    {
        _root = null;
    }

    public void Add(int v)
    {
        TreeNode newNode = new TreeNode(v);

        if (_root == null)
        {
            _root = newNode;
            return;
        }

        TreeNode current = _root;
        TreeNode? parent = null;

        while (current != null)
        {
            parent = current;

            if (v >= current._value)
                current = current._right;
            else
                current = current._left;
        }

        if (v >= parent._value)
            parent._right = newNode;
        else
            parent._left = newNode;
    }

    public int Count()
    {
        return CountNodes(_root);
    }

    private int CountNodes(TreeNode? node)
    {
        if (node == null) return 0;
        return 1 + CountNodes(node._left) + CountNodes(node._right);
    }

    public bool Contains(int v)
    {
        TreeNode? current = _root;

        while (current != null)
        {
            if (current._value == v) return true;
            if (v < current._value)
                current = current._left;
            else
                current = current._right;
        }

        return false;
    }

    public int Sum()
    {
        return SumNode(_root);
    }

    private int SumNode(TreeNode? node)
    {
        if (node == null) return 0;
        return node._value + SumNode(node._left) + SumNode(node._right);
    }

    public override string ToString()
    {
        return _root == null ? "{}" : $"{{{_root}}}";
    }

    public bool DuplicatesPresent()
    {
        HashSet<int> seen = new HashSet<int>();
        return CheckDuplicates(_root, seen);
    }

    private bool CheckDuplicates(TreeNode? node, HashSet<int> seen)
    {
        if (node == null) return false;
        if (!seen.Add(node._value)) return true; 
        return CheckDuplicates(node._left, seen) || CheckDuplicates(node._right, seen);
    }

    public int Depth()
    {
        return DepthNode(_root);
    }

    private int DepthNode(TreeNode? node)
    {
        if (node == null) return 0;
        return 1 + Math.Max(DepthNode(node._left), DepthNode(node._right));
    }

    public bool IsBalanced()
    {
        return CheckBalanced(_root) != -1;
    }

    private int CheckBalanced(TreeNode? node)
    {
        if (node == null) return 0;

        int leftHeight = CheckBalanced(node._left);
        if (leftHeight == -1) return -1;

        int rightHeight = CheckBalanced(node._right);
        if (rightHeight == -1) return -1;

        if (Math.Abs(leftHeight - rightHeight) > 1) return -1;

        return 1 + Math.Max(leftHeight, rightHeight);
    }

    public int? LowestCommonAncestor(TreeNode? node, int a, int b)
    {
        if (node == null || node._value == a || node._value == b)
            return node?._value;

        int? left = LowestCommonAncestor(node._left, a, b);
        int? right = LowestCommonAncestor(node._right, a, b);

        if (left != null && right != null) return node._value;
        return left ?? right;
    }

    public void Delete(int v)
    {
        _root = DeleteNode(_root, v);
    }

    private TreeNode? DeleteNode(TreeNode? root, int key)
    {
        if (root == null) 
            return null;
        

        if (key < root._value)
            root._left = DeleteNode(root._left, key);
        else if (key > root._value)
            root._right = DeleteNode(root._right, key);
        else
        {
            if (root._left == null) return root._right;
            if (root._right == null) return root._left;

            TreeNode successor = MinValueNode(root._right);
            root._value = successor._value;
            root._right = DeleteNode(root._right, successor._value);
        }

        return root;
    }

    private TreeNode MinValueNode(TreeNode node)
    {
        TreeNode current = node;
        while (current._left != null) current = current._left;
        return current;
    }
}

public class TreeNode
{
    public int _value;
    public TreeNode? _left;
    public TreeNode? _right;

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