public class Node<T>
{
    public T Value { get; set; }
    public Node<T>? Next { get; set; }

    public Node(T value, Node<T>? next)
    {
        Value = value;
        Next = next;
    }
}

public class LinkedList<T>
{
    private Node<T>? _head;

    public T? Read(int index)
    {
        var node = ReadNode(index);
        if (node != null)
        {
            return node.Value;
        }
        return default(T);
    }

    public Node<T>? ReadNode(int index)
    {
        var current = _head;
        var readIndex = 0;
        while(current != null && readIndex < index)
        {
            current = current.Next;
            readIndex++;
        }
        
        return current switch {
            null => default,
            not null => current
        };
    }

    public int IndexOf(T value)
    {
        var current = _head;
        var index = 0;
        while(current != null)
        {
            if (EqualityComparer<T>.Default.Equals(current.Value, value))
            {
                return index;
            }
            index++;
            current = current.Next;
        }
        return -1;
    }

    public void InsertAt(int index, T value)
    {
        var newNode = new Node<T>(value, null);
        if (index == 0)
        {
            newNode.Next = _head;
            _head = newNode;
            return;
        }

        var currentIndex = 0;
        var current = _head;

        while(current != null && currentIndex < index - 1)
        {
            currentIndex ++;
            current = current.Next;
        }

        if (current != null)
        {
            newNode.Next = current.Next;
            current.Next = newNode;
        }
        else
        {
            throw new InvalidOperationException("could not find the position to insert");
        }
    }

    public void Delete(int index)
    {
        if (index == 0)
        {
            _head = _head?.Next;
            return;
        }

        var currentNode = _head;
        var currentIndex = 0;

        while(currentIndex < index - 1)
        {
            currentIndex++;
            currentNode = currentNode?.Next;
        }

        if (currentNode != null)
        {
            var nodeAfterDeletedNode = currentNode?.Next?.Next;
            currentNode!.Next = nodeAfterDeletedNode;
        }
    }

    public T? Last()
    {
        if (_head == null)
        {
            return default(T);
        }

        var current = _head;
        var lastValue = _head.Value;

        while(current != null)
        {
            lastValue = current.Value;
            current = current.Next;
        }

        return lastValue;
    }

    public void Reverse()
    {
        var currentNode = _head;
        Node<T>? previousNode = null;

        while(currentNode != null)
        {
            var replaced = previousNode;
            previousNode = currentNode;
            currentNode = currentNode.Next;
            previousNode.Next = replaced;
        }

        _head = previousNode;
    }

    public void DeleteNode(Node<T> toDelete)
    {
        // copy the value and the next pointer and then delete the next pointers
        if (toDelete.Next != null)
        {
            var nextNode = toDelete.Next;
            toDelete.Value = nextNode.Value;
            toDelete.Next = toDelete.Next.Next;
            nextNode.Next = null;
        }
    }

    public override string? ToString()
    {
        var current = _head;
        var print = "";
        while(current != null)
        {
            print += current.Value + " -> ";
            current = current.Next;
        }
        print += " <NULL> ";
        return print;
    }
}