public class TrieNode
{
    public Dictionary<char, TrieNode> _map = new Dictionary<char, TrieNode>();

    internal void Collect(string current, List<string> words)
    {
        foreach(var d in _map.Keys)
        {
            if (d == '*')
            {
                words.Add(current);
            }
            else
            {
                _map[d].Collect(current + d, words);
            }
        }
    }
}

public class Trie
{
    public TrieNode Root { get; }

    public Trie()
    {
        Root = new TrieNode();
    }

    public void Add(string word)
    {
        var node = Root;
        foreach(var c in word)
        {
            if (!node._map.ContainsKey(c))
            {
                node._map.Add(c, new TrieNode());
            }
            node = node._map[c];
        }

        node._map['*'] = new TrieNode();
    }

    public override string ToString()
    {
        var words = new List<string>();

        Root.Collect("", words);

        return string.Join(";", words);
    }

    public void PrintAllKeys(TrieNode node)
    {
        Console.WriteLine(string.Join(",", node._map.Keys));
        foreach(var k in node._map.Keys)
        {
            PrintAllKeys(node._map[k]);
        }
    }

    // public string Autocorrect(string input)
    // {
    //     var node = Search(input);
    // }

    public TrieNode? Search(string word)
    {
        var node = Root;
        foreach(var c in word)
        {
            if (!node._map.ContainsKey(c))
            {
                return null;
            }
            node = node._map[c];
        }
        return node;
    }

    internal List<string> Matches(string prefix)
    {
        var list = new List<string>();

        var node = Search(prefix);
        if (node == null)
        {
            return list;
        }

        node.Collect(prefix, list);

        return list;
    }
}