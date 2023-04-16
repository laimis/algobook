using System.Text;

public class TreeNode<T>
{
    public TreeNode<T>? Left;
    public TreeNode<T>? Right;
    public T Value;
    public TreeNode(T value, TreeNode<T>? left = null, TreeNode<T>? right = null)
    {
        Value = value;
        Left = left;
        Right = right;
    }

    private static int CompareValueToNode(TreeNode<T> node, T value)
    {
        return Comparer<T>.Default.Compare(value, node.Value);
    }

    public bool Equals(T value) => CompareValueToNode(this, value) == 0;
    public bool Smaller(T value) => CompareValueToNode(this, value) > 0;
    public bool Greater(T value) => CompareValueToNode(this, value) < 0;
}

public class Tree<T>
{
    private TreeNode<T> _root;
    public Tree(T root)
    {
        _root = new TreeNode<T>(root);
    }

    public override string ToString()
    {
        var levels = new Dictionary<int, string>();
        ToString(_root, 0, levels);
        var builder = new StringBuilder();
        for(var l = 0; l < levels.Count; l++)
        {
            builder.AppendLine(levels[l]);
        }
        return builder.ToString();
    }

    
    public TreeNode<T>? Search(T value)
    {
        var current = _root;
        while(current != null)
        {
            if (current.Equals(value))
            {
                return current;
            }
            else if (current.Greater(value))
            {
                current = current.Left;
            }
            else
            {
                current = current.Right;
            }
        }
        return null;
    }

    public TreeNode<T>? SearchR(T value) =>
        SearchRInternal(_root, value);

    public TreeNode<T>? SearchRInternal(TreeNode<T>? node, T value)
    {
        if (node == null)
        {
            return null;
        }
        
        if (node.Equals(value))
        {
            return node;
        }
        else if (node.Smaller(value))
        {
            return SearchRInternal(node.Right, value);
        }
        else
        {
            return SearchRInternal(node.Left, value);
        }
    }

    public void Insert(T value) => Insert(_root, value);

    private void Insert(TreeNode<T> node, T value)
    {
        if (node.Equals(value))
        {
            return;
        }

        if (node.Greater(value))
        {
            if (node.Left == null)
            {
                node.Left = new TreeNode<T>(value);
            }
            else
            {
                Insert(node.Left, value);
            }
        }
        else if (node.Smaller(value))
        {
            if (node.Right == null)
            {
                node.Right = new TreeNode<T>(value);
            }
            else
            {
                Insert(node.Right, value);
            }
        }
    }

    public TreeNode<T>? Delete(T value) => Delete(_root, value);
    private TreeNode<T>? Delete(TreeNode<T>? node, T value)
    {
        if (node == null)
        {
            return node;
        }
        else if (node.Greater(value))
        {
            node.Left = Delete(node.Left, value);
            return node;
        }
        else if (node.Smaller(value))
        {
            node.Right = Delete(node.Right, value);
            return node;
        }
        else
        {
            if (node.Left == null)
            {
                return node.Right;
            }
            else if (node.Right == null)
            {
                return node.Left;
            }
            else
            {
                node.Right = Lift(node.Right, node);
                return node;
            }
        }
    }

    private TreeNode<T>? Lift(TreeNode<T> node, TreeNode<T> nodeToDelete)
    {
        if (node.Left != null)
        {
            node.Left = Lift(node.Left, nodeToDelete);
            return node;
        }
        else
        {
            nodeToDelete.Value = node.Value;
            return node.Right;
        }
    }

    public IEnumerable<T> OrderedValues() => OrderedValues(_root);

    private IEnumerable<T> OrderedValues(TreeNode<T>? node)
    {
        if (node != null)
        {
            foreach(var v in OrderedValues(node.Left))
            {
                yield return v;
            }

            yield return node.Value;

            foreach(var v in OrderedValues(node.Right))
            {
                yield return v;
            }
        }
    }

    public T? Max() => Max(_root);
    private T? Max(TreeNode<T> node)
    {
        return node.Right == null ? node.Value : Max(node.Right);
    }

    private static void ToString(TreeNode<T> node, int level, Dictionary<int, string> levels)
    {
        if (node == null)
        {
            return;
        }

        if (!levels.ContainsKey(level))
        {
            levels[level] = "";
        }

        levels[level] += $",{node.Value}";

        if (node.Left != null)
        {
            ToString(node.Left, level + 1, levels);
        }
        
        if (node.Right != null)
        {
            ToString(node.Right, level + 1, levels);
        }
    }
}