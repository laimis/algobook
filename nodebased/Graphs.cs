public class Vertex<T>
{
    public T Value { get; }
    public List<Vertex<T>> AdjacetVertices = new List<Vertex<T>>();

    public Vertex(T value)
    {
        Value = value;
    }

    public void AddAdjacent(Vertex<T> vertex)
    {
        AdjacetVertices.Add(vertex);
    }
    
    public override int GetHashCode() => Value.GetHashCode();

    public override string ToString() => Value.ToString();

    public bool EqualsTo(T value) =>
        EqualityComparer<T>.Default.Equals(value, Value);

    public override bool Equals(object? obj)
    {
        return obj is Vertex<T> vertex &&
               EqualsTo(vertex.Value);
    }
}

public class WeightedVertex<T, W>
{
    public WeightedVertex(T value)
    {
        Value = value;
    }

    protected Dictionary<WeightedVertex<T, W>, W> AdjacentVertices
        = new Dictionary<WeightedVertex<T, W>, W>();

    public T Value { get; }

    public void AddAdjacent(WeightedVertex<T, W> vertex, W weight)
    {
        AdjacentVertices[vertex] = weight;
    }

    public override bool Equals(object? obj)
    {
        return obj is WeightedVertex<T, W> vertex &&
               EqualityComparer<T>.Default.Equals(Value, vertex.Value);
    }

    public override int GetHashCode() => Value!.GetHashCode();
}

public class City
{
    public City(string name)
    {
        Name = name;
    }
    
    public Dictionary<City, int> Routes = new Dictionary<City, int>();

    public string Name { get; }

    public void AddRoute(City city, int price) => Routes.Add(city, price);

    public override bool Equals(object? obj)
    {
        return obj is City city &&
               Name == city.Name;
    }

    public override int GetHashCode() => Name.GetHashCode();

    public override string ToString() => Name;
}

public class Graph
{
    public static void DfsTraverse<T>(Vertex<T> v, HashSet<T> visited)
    {
        visited.Add(v.Value);

        Console.WriteLine(v.Value);

        foreach(var a in v.AdjacetVertices)
        {
            if (visited.Contains(a.Value))
            {
                continue;
            }

            DfsTraverse(a, visited);
        }
    }

    public static void BfsTraversal<T>(Vertex<T> node, HashSet<T> visited)
    {
        var queue = new Queue<Vertex<T>>();

        visited.Add(node.Value);

        var currentNode = node;

        do
        {
            Console.WriteLine(currentNode.Value);
            foreach(var a in currentNode.AdjacetVertices)
            {
                if (!visited.Contains(a.Value))
                {
                    visited.Add(a.Value);
                    queue.Enqueue(a);
                }
            }

            if (!queue.Empty)
            {
                currentNode = queue.Dequeue();
            }
            else
            {
                currentNode = null;
            }
        }
        while(currentNode != null);
    }

    public static Vertex<T>? SearchBfs<T>(Vertex<T> node, T value, HashSet<T> visited)
    {
        var queue = new Queue<Vertex<T>>();

        if (node.EqualsTo(value))
        {
            return node;
        }

        visited.Add(node.Value);

        var currentNode = node;

        do
        {
            if (currentNode.EqualsTo(value))
            {
                return currentNode;
            }

            foreach(var a in currentNode.AdjacetVertices)
            {
                if (!visited.Contains(a.Value))
                {
                    visited.Add(a.Value);
                    queue.Enqueue(a);
                }
            }

            if (!queue.Empty)
            {
                currentNode = queue.Dequeue();
            }
            else
            {
                currentNode = null;
            }
        }
        while(currentNode != null);

        return null;
    }

    internal static Vertex<T>? Find<T>(Vertex<T> node, T value, HashSet<T> visited)
    {
        if (node.EqualsTo(value))
        {
            return node;
        }

        visited.Add(node.Value);

        Vertex<T>? found = null;
        foreach(var a in node.AdjacetVertices)
        {
            if (visited.Contains(a.Value))
            {
                continue;
            }

            found = Find(a, value, visited);
            if (found != null)
            {
                break;
            }
        }
        return found;
    }

    public static List<string>? ShortestPath(Vertex<string> start, Vertex<string> end)
    {
        var paths = new Dictionary<Vertex<string>, List<string>>();
        var visited = new HashSet<string>();
        var queue = new Queue<Vertex<string>>();

        queue.Enqueue(start);
        visited.Add(start.Value);

        var currentNode = start;

        paths[currentNode] = new List<string>(new[] { currentNode.Value });

        do
        {
            foreach(var a in currentNode.AdjacetVertices)
            {
                if (!visited.Contains(a.Value))
                {
                    paths[currentNode].Add(a.Value);
                    paths[a] = new List<string>(paths[currentNode]);
                    visited.Add(a.Value);
                    queue.Enqueue(a);
                }

                if (a == end)
                {
                    return paths[a];
                }
            }

            if (!queue.Empty)
            {
                currentNode = queue.Dequeue();
            }
            else
            {
                currentNode = null;
            }
        }
        while(currentNode != null);

        return null;        
    }

    public static List<City> DijkstraShortestPath(City start, City end)
    {
        var cheapestPrices = new Dictionary<City, int>();
        var cheapestPreviousStopOver = new Dictionary<City, City>();

        var unvisitedCities = new HashSet<City>();
        var visitedCities = new HashSet<City>();

        cheapestPrices[start] = 0;

        var currentCity = start;

        while (currentCity != null)
        {
            visitedCities.Add(currentCity);
            unvisitedCities.Remove(currentCity);

            foreach(var adjacentCity in currentCity.Routes)
            {
                if (!visitedCities.Contains(adjacentCity.Key))
                {
                    unvisitedCities.Add(adjacentCity.Key);
                }
                
                var priceThroughCurrentCity = cheapestPrices[currentCity] + adjacentCity.Value;

                if (!cheapestPrices.ContainsKey(adjacentCity.Key) ||
                    priceThroughCurrentCity < cheapestPrices[adjacentCity.Key])
                {
                    cheapestPrices[adjacentCity.Key] = priceThroughCurrentCity;
                    cheapestPreviousStopOver[adjacentCity.Key] = currentCity;
                }
            }

            if (unvisitedCities.Count == 0)
            {
                break;
            }

            var min = Int32.MaxValue;
            foreach(var unvisitedCity in unvisitedCities)
            {
                if (cheapestPrices.TryGetValue(unvisitedCity, out var price))
                {
                    if (price < min)
                    {
                        min = price;
                        currentCity = unvisitedCity;
                    }
                }
            }
        }

        var shortestPath = new List<City>();

        var currentCityToAdd = end;

        while (currentCityToAdd != start)
        {
            shortestPath.Add(currentCityToAdd);
            currentCityToAdd = cheapestPreviousStopOver[currentCityToAdd];
        }

        shortestPath.Add(start);

        shortestPath.Reverse();

        return shortestPath;   
    }
}