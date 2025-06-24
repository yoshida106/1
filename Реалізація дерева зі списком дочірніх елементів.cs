using System;
using System.Collections.Generic;

public class TreeNode
{
    public int Value { get; set; }
    public List<TreeNode> Children { get; private set; }
    
    public TreeNode(int value)
    {
        Value = value;
        Children = new List<TreeNode>();
    }
    
    public void AddChild(TreeNode child)
    {
        Children.Add(child);
    }
    
    public bool RemoveChild(TreeNode child)
    {
        return Children.Remove(child);
    }
}

public class Tree
{
    public TreeNode Root { get; private set; }
    
    public Tree(int rootValue)
    {
        Root = new TreeNode(rootValue);
    }
    
    public void TraverseDFS(TreeNode node, Action<TreeNode> action)
    {
        if (node == null) return;
        
        action(node);
        
        foreach (var child in node.Children)
        {
            TraverseDFS(child, action);
        }
    }
    
    public void TraverseBFS(Action<TreeNode> action)
    {
        if (Root == null) return;
        
        var queue = new Queue<TreeNode>();
        queue.Enqueue(Root);
        
        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            action(current);
            
            foreach (var child in current.Children)
            {
                queue.Enqueue(child);
            }
        }
    }
    
    public TreeNode Find(int value)
    {
        TreeNode result = null;
        TraverseDFS(Root, node =>
        {
            if (node.Value == value)
            {
                result = node;
            }
        });
        return result;
    }
}