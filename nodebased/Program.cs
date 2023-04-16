
var list = new LinkedList<int>();

list.InsertAt(0, 7);
Console.WriteLine(list.Read(0));
Console.WriteLine(list.IndexOf(8));
Console.WriteLine(list.IndexOf(7));
Console.WriteLine(list);
list.InsertAt(0, 8);
list.InsertAt(1, 9);
Console.WriteLine(list);
try { list.InsertAt(20, 10); } catch(Exception) { Console.WriteLine("Insert at wrong indx threw");}
list.Delete(0);
Console.WriteLine(list);
list.Delete(1);
Console.WriteLine(list);

list = new LinkedList<int>();
list.InsertAt(0, 7);
list.InsertAt(0, 8);
list.InsertAt(0, 9);
Console.WriteLine("before reverse: " + list);
list.Reverse();
Console.WriteLine("reversed: " + list);
var nodeToDelete = list.ReadNode(1);
Console.WriteLine("To delete " + nodeToDelete?.Value);
if (nodeToDelete != null)
{
    list.DeleteNode(nodeToDelete);
}
Console.WriteLine("After deletion " + list);

var doubly = new DoublyLinkedList<int>();

doubly.InsertAtEnd(7);
Console.WriteLine(doubly);

doubly.InsertAtEnd(8);
Console.WriteLine(doubly);

doubly.InsertAtEnd(9);
Console.WriteLine(doubly);

var queue = new Queue<int>();

queue.Enqueue(1);
queue.Enqueue(2);
queue.Enqueue(3);
queue.Enqueue(4);

Console.WriteLine("Peek " + queue.Peek());
Console.WriteLine("Read " + queue.Dequeue());
Console.WriteLine("Read " + queue.Dequeue());
Console.WriteLine("Peek " + queue.Peek());


// trees
var tree = new Tree<int>(50);
tree.Insert(25);
tree.Insert(75);

Console.WriteLine("tree");
Console.WriteLine(tree);

var result = tree.Search(25);
Console.WriteLine("Found 25? " + result?.Value);
result = tree.Search(26);
Console.WriteLine("Found 26? " + result?.Value);
result = tree.SearchR(25);
Console.WriteLine("Found 25 recursively? " + result?.Value);
tree.Insert(26);
result = tree.SearchR(26);
Console.WriteLine("After inserting, found " + result?.Value);
Console.WriteLine(tree);
tree.Delete(26);
tree.Insert(2);
tree.Insert(1);
tree.Insert(4);
tree.Insert(3);
Console.WriteLine(tree);
tree.Delete(1);
Console.WriteLine(tree);
Console.WriteLine(string.Join(";", tree.OrderedValues()));
Console.WriteLine("Max: " + tree.Max());

var books = new Tree<string>("Book 40");
books.Insert("Book 50");
books.Insert("Book 20");
Console.WriteLine("books");
Console.WriteLine(books);

Console.WriteLine(string.Join(";", books.OrderedValues()));

Console.WriteLine("HEAPS");

var heap = new Heap<int>();

// generate 5 random numbers, insert into heap
var rand = new Random(Environment.TickCount);

void ActionRandom(Random random, Action<int> feed)
{
    for(var i = 0; i<5; i++)
    {
        var value = random.Next(100);
        feed(value);
    }
}

Console.WriteLine("insertint into heap");
ActionRandom(rand, n => heap.Insert(n));
Console.WriteLine("heap: " + heap);
Console.WriteLine("Deleting");

while(!heap.IsEmpty)
{
    Console.WriteLine("Deleted " + heap.Delete());
    Console.WriteLine(heap);
}

// sorted set experiment
var comparer = Comparer<int>.Create((x, y) => y.CompareTo(x));

var sorted = new SortedSet<int>(comparer);

ActionRandom(rand, n => sorted.Add(n));

Console.WriteLine(string.Join(",", sorted));

// tries
Console.WriteLine("TRIIIES");

var trie = new Trie();
trie.Add("Lemonade");
trie.Add("Lemon");
trie.Add("Michael");
Console.WriteLine(trie);

void PrintMatches(Trie trie, string prefix)
{
    Console.WriteLine("Suggestions for " + prefix);
    foreach(var suggestion in trie.Matches(prefix))
    {
        Console.WriteLine(suggestion);
    }
}

PrintMatches(trie, "Lem");
PrintMatches(trie, "M");
PrintMatches(trie, "angel");

trie.PrintAllKeys(trie.Root);

Console.WriteLine("GRAPHHHHS");

var alice = new Vertex<string>("Alice");
var cynthia = new Vertex<string>("Cynthia");
var emily = new Vertex<string>("Emily");
var bob = new Vertex<string>("Bob");

alice.AddAdjacent(cynthia);
alice.AddAdjacent(new Vertex<string>("Michael"));
alice.AddAdjacent(new Vertex<string>("Victor"));
cynthia.AddAdjacent(alice);
cynthia.AddAdjacent(emily);
emily.AddAdjacent(bob);
bob.AddAdjacent(cynthia);

Graph.DfsTraverse<string>(alice, new HashSet<string>());

var vertex = Graph.Find<string>(alice, "Bob", new HashSet<string>());
Console.WriteLine("Found: " + vertex?.Value);

vertex = Graph.SearchBfs<string>(alice, "Bob", new HashSet<string>());
Console.WriteLine("Found BFS: " + vertex?.Value);

Console.WriteLine("BFS");
Graph.BfsTraversal<string>(alice, new HashSet<string>());

var dallas = new WeightedVertex<string, int>("Dallas");
var toronto = new WeightedVertex<string, int>("Toronto");

dallas.AddAdjacent(toronto, 210);
toronto.AddAdjacent(dallas, 158);

var atlanta = new City("Atlanta");
var boston = new City("Boston");
var chicago = new City("Chicago");
var denver = new City("Denver");
var elPaso = new City("El Paso");

atlanta.AddRoute(boston, 100);
atlanta.AddRoute(denver, 160);

boston.AddRoute(chicago, 120);
boston.AddRoute(denver, 180);

chicago.AddRoute(elPaso, 80);

denver.AddRoute(chicago, 40);
denver.AddRoute(elPaso, 140);

Console.WriteLine("Dijkstra shortest path");
var shortestPath = Graph.DijkstraShortestPath(atlanta, elPaso);

Console.WriteLine("Shortest Path: " + string.Join(" -> ", shortestPath));

Console.WriteLine("Shortest path for vertices");

var idris = new Vertex<string>("Idris");
var kamil = new Vertex<string>("Kamil");
var lina = new Vertex<string>("Lina");
var sasha = new Vertex<string>("Sasha");
var marco = new Vertex<string>("Marco");
var ken = new Vertex<string>("Ken");
var talia = new Vertex<string>("Talia");

idris.AddAdjacent(kamil);
idris.AddAdjacent(talia);
kamil.AddAdjacent(lina);
kamil.AddAdjacent(idris);
lina.AddAdjacent(sasha);
lina.AddAdjacent(kamil);
sasha.AddAdjacent(lina);
sasha.AddAdjacent(marco);
marco.AddAdjacent(ken);
marco.AddAdjacent(sasha);
ken.AddAdjacent(talia);
ken.AddAdjacent(marco);
talia.AddAdjacent(ken);
talia.AddAdjacent(idris);

var shortest = Graph.ShortestPath(idris, lina);

Console.WriteLine("Shortest for idris to sahasha: " + string.Join(" -> ", shortest));

var arr = new [] { 1, 2, 3, 4};

SpaceConstraints.Reverse(arr);

Console.WriteLine("Reversed: " + string.Join(",", arr));

var greatestStreak = new [] { 3, -4, 4, -3, 5, -9};
var sum = Techniques.GreatestSum(greatestStreak);
Console.WriteLine("Greatest sum: " + sum);

var common = Techniques.CommonElements(
    new [] { "laimonas", "tomas", "arunas"},
    new [] { "laimonas", "arunas"}
);

Console.WriteLine("Common elements: " + string.Join(",", common));

var missing = Techniques.ReturnMissing(
    new [] { 0, 1, 2, 3, 4, 5, 7, 8, 9, 10}
);
Console.WriteLine("Missing: " + missing);

var prices = new [] { 10, 7, 5, 8, 11, 2, 6};

var greatest = Techniques.GreatestProfit(prices);

Console.WriteLine("Greatest profit: " + greatest);

var readings = new [] {98.6, 98.0, 97.1, 99.0, 98.9, 97.8, 98.5, 98.2, 98.0, 97.1};

var sortedReadings = Techniques.Sort(readings);

Console.WriteLine("Sorted readings: " + string.Join(",", sortedReadings));