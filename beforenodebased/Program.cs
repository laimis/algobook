// See https://aka.ms/new-console-template for more information
using System.Text;

Console.WriteLine("Hello, World!");


int[] Intersection(int[] arr1, int[] arr2)
{
    var result = new List<int>();
    var set1 = new HashSet<int>(arr1);
    var set2 = new HashSet<int>(arr2);
    foreach (var item in set1)
    {
        if (set2.Contains(item))
        {
            result.Add(item);
        }
    }
    return result.ToArray();
}
var arr1 = new int[] { 5, 2, 4, 6, 1, 3 };
var arr2 = new int[] { 2, 4, 6 };
var result = Intersection(arr1, arr2);
Console.WriteLine("Intersection");
Console.WriteLine(string.Join(", ", result));


string? Duplicate(string[] arr)
{
    var set = new HashSet<string>();
    foreach (var item in arr)
    {
        if (set.Contains(item))
        {
            return item;
        }
        set.Add(item);
    }
    return null;
}
var duplicate = Duplicate(new string[] { "a", "b", "c", "a" });
Console.WriteLine("Duplicate");
Console.WriteLine(duplicate);


char FindMissingLetter(string str)
{
    var set = new HashSet<char>(str.ToCharArray());
    foreach (var item in "abcdefghijklmnopqrstuvwxyz")
    {
        if (!set.Contains(item))
        {
            return item;
        }
    }
    return ' ';
}
var missingLetter = FindMissingLetter("abcdefghijklmnopqrstuvwyz");
Console.WriteLine("Missing letter");
Console.WriteLine(missingLetter);


char FindNonDuplicatedCharacter(string str)
{
    var set = new Dictionary<char, int>();
    foreach (var item in str)
    {
        if (set.ContainsKey(item))
        {
            set[item]++;
        }
        else
        {
            set.Add(item, 1);
        }
    }

    foreach(var item in str)
    {
        if (set[item] == 1)
        {
            return item;
        }
    }

    return ' ';
}

var nonDuplicate = FindNonDuplicatedCharacter("aabbccdefghijklmnopqrstuvwyz");
Console.WriteLine("Non duplicate");
Console.WriteLine(nonDuplicate);

string Reverse(string input)
{
    // reverse using stack
    var stack = new Stack<char>();
    foreach (var item in input)
    {
        stack.Push(item);
    }
    var result = new StringBuilder();
    while (stack.Count > 0)
    {
        result.Append(stack.Pop());
    }
    return result.ToString();
}

var reversed = Reverse("abcdefghijklmnopqrstuvwyz");
Console.WriteLine("Reversed");
Console.WriteLine(reversed);

void Countdown(int start)
{
    // base case
    if (start == 0)
    {
        Console.WriteLine(start);
        return;
    }
    Console.WriteLine(start);
    Countdown(start - 1);
}
Console.WriteLine("Countdown");
Countdown(10);

int Factorial(int number)
{
    // base case
    if (number == 1)
    {
        return 1;
    }
    return number * Factorial(number - 1);
}
var factorial = Factorial(4);
Console.WriteLine("Factorial");
Console.WriteLine(factorial);

void PrintAllNumbers(object[] arr)
{
    foreach(var a in arr)
    {
        if (a is int i)
        {
            Console.WriteLine(i);
        }
        else if (a is object[] o)
        {
            PrintAllNumbers(o);
        }
    }
}
var numbers = new object[] { 
    1, 2, 3,
    new object[] {
        4, 5, 6, new object[] {
            7, 8, 9
        }
    }
};
Console.WriteLine("Numbers");
PrintAllNumbers(numbers);

void DoubleNumbers(int[] arr, int index = 0)
{
    if (index == arr.Length)
    {
        return;
    }
    arr[index] *= 2;
    DoubleNumbers(arr, index + 1);
}

var arr = new int[] { 1, 2, 3, 4, 5 };
Console.WriteLine("Double numbers");
DoubleNumbers(arr);
Console.WriteLine(string.Join(", ", arr));

int SumArray(int[] arr, int index = 0)
{
    if (index == arr.Length)
    {
        return 0;
    }

    return arr[index] + SumArray(arr, ++index);
}
var sum = SumArray(new int[] { 1, 2, 3, 4, 5 });
Console.WriteLine("Sum array");
Console.WriteLine(sum);

string ReverseUsingRecursion(string input)
{
    // if (input.Length == 1)
    // {
    //     return input;
    // }
    // return  input[input.Length - 1] + ReverseUsingRecursion(input.Substring(0, input.Length - 1));

    if (input.Length == 1)
    {
        return input;
    }
    return ReverseUsingRecursion(input.Substring(1)) + input[0];
}
var reversedRecursive = ReverseUsingRecursion("abcdefghijklmnopqrstuvwyz");
Console.WriteLine("Reversed using recursion");
Console.WriteLine(reversedRecursive);

int CountX(string input)
{
    if (input.Length == 0)
    {
        return 0;
    }
    var toAdd = input[0] == 'x' ? 1 : 0;

    return toAdd + CountX(input.Substring(1));
}
var countX = CountX("xaxbx");
Console.WriteLine("Count x");
Console.WriteLine(countX);

int[] PossibleSteps()
{
    return new [] { 0, 1, 2, 3};
}

void HowManyWaysToClimbStaircase(
    int totalSteps,
    int currentStep,
    int[] stepCombinations,
    Tracker tracker)
{
    if (currentStep == totalSteps)
    {
        // we need to evaluate here
        var sum = stepCombinations.Sum();
        if (sum == totalSteps)
        {
            tracker.Found(String.Join("", stepCombinations));
        }
        return;
    }

    foreach(var possibleStep in PossibleSteps())
    {
        stepCombinations[currentStep] = possibleStep;
        var newArray = new int[stepCombinations.Length];
        stepCombinations.CopyTo(newArray, 0);
        HowManyWaysToClimbStaircase(totalSteps, currentStep + 1, newArray, tracker);
    }
}

int HowManyWaysToClimbStaircase2(int n)
{
    if (n < 0) return 0;
    if (n == 1 || n == 0) return 1;

    return
        HowManyWaysToClimbStaircase2(n-1)
        + HowManyWaysToClimbStaircase2(n-2)
        + HowManyWaysToClimbStaircase2(n-3);
}

var steps = 3;// Int32.Parse(Console.ReadLine());
// var tracker = new Tracker();
// var stepCombinations = new int[staircases];
// HowManyWaysToClimbStaircase(staircases, 0, stepCombinations, tracker);
var combos = HowManyWaysToClimbStaircase2(steps);
Console.WriteLine("Ways to climb staircase");
Console.WriteLine(combos);


// generate all anagrams of a string
string[] AllAnagrams(string input)
{
    if (input.Length == 1)
    {
        return new string[] { input };
    }

    var result = new List<string>();
    foreach(var item in AllAnagrams(input.Substring(1)))
    {
        for (int i = 0; i <= item.Length; i++)
        {
            result.Add(item.Insert(i, input[0].ToString()));
        }
    }
    return result.ToArray();
}

for(var i=1; i<=5; i++)
{
    var input = Guid.NewGuid().ToString("N").Substring(0, i);
    var anagrams = AllAnagrams(input);
    Console.WriteLine($"{i}: {input} {anagrams.Length}");
}

int TotalChars(string[] input)
{
    // base case
    if (input.Length == 0)
    {
        return 0;
    }

    return input[0].Length + TotalChars(input.Skip(1).ToArray());
}

var total = TotalChars(new string[] { "abc", "def", "ghi" });
Console.WriteLine("Total chars");
Console.WriteLine(total);

int[] JustEvenNumbers(int[] input)
{
    var array = new List<int>();
    if (input.Length == 0)
    {
        return array.ToArray();
    }

    if (input[0] % 2 == 0)
    {
        array.Add(input[0]);
    }

    array.AddRange(
        JustEvenNumbers(
            input.Skip(1).ToArray()
        )
    );

    return array.ToArray();
}
var even = JustEvenNumbers(new [] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12});
Console.WriteLine("Just even");
Console.WriteLine(string.Join(",", even));

int TriangularNumbers(int n)
{
    if (n == 1)
    {
        return 1;
    }

    return n + TriangularNumbers(n-1);
}
var triangular = TriangularNumbers(7);
Console.WriteLine("Triangular");
Console.WriteLine(triangular);

int FindXIndex(string input, int position = 0)
{
    if (input[position] == 'x')
    {
        return position;
    }
    else
    {
        return FindXIndex(input, position+1);
    }
}
var indexOfX = FindXIndex("abcdxefghijklmnopqrstuvwxy");
Console.WriteLine("Index of X");
Console.WriteLine(indexOfX);


int ShortestPaths(int rows, int cols)
{
    if (rows == 0 || cols == 0)
    {
        return 1;
    }
    
    return ShortestPaths(rows-1, cols)
            + ShortestPaths(rows, cols-1);
}

var paths = ShortestPaths(rows: 3, cols: 7);
Console.WriteLine("Shortest Paths");
Console.WriteLine(paths);

int largestCounter = 0;
int max(int[] arr)
{
    // Console.WriteLine("recursion");
    largestCounter++;
    if(arr.Length == 1)
    {
        return arr[0];
    }

    var otherMax = max(arr.Skip(1).ToArray());

    return arr[0] > otherMax ? arr[0] : otherMax;
}
var largest = max(new [] { 1, 9, 3, 4, 5, 6, 7, 8});
Console.WriteLine("Largest");
Console.WriteLine(largest);
Console.WriteLine(largestCounter);

int fibCounter = 0;
int Fib(int n, Dictionary<int, int> memory)
{
    fibCounter++;
    if (n == 0 || n == 1) return n;
    
    if (!memory.TryGetValue(n-2, out var one))
    {
        one = Fib(n-2, memory);
        memory.Add(n-2, one);
    }

    if (!memory.TryGetValue(n-1, out var two))
    {
        two = Fib(n-1, memory);
        memory.Add(n-1, two);
    }

    return one + two;
}
var fib = Fib(6, new Dictionary<int, int>());
Console.WriteLine("Fib");
Console.WriteLine(fib);
Console.WriteLine(fibCounter);

int bottomUpFib(int n)
{
    if (n == 0) return 0;

    var a = 0;
    var b = 1;
    for (var i = 1; i < n; i++)
    {
        var temp = a + b;
        a = b;
        b = temp;
    }
    return b;
}
Console.WriteLine("Fib2");
Console.WriteLine(bottomUpFib(6));

int AddUntil100(int[] input)
{
    if (input.Length == 0)
    {
        return 0;
    }

    var previousSum = AddUntil100(input.Skip(1).ToArray());
    return previousSum + input[0] > 100 ? previousSum : input[0] + previousSum;
}
var addUntil = AddUntil100(new [] { 1, 4, 51, 97, 1 });
Console.WriteLine("AddUntil");
Console.WriteLine(addUntil);

int Golomb(int n, Dictionary<int, int> memory)
{
    if (n == 1) return 1;

    if (!memory.ContainsKey(n))
    {
        memory[n] = 1 + Golomb(
            n - Golomb(
                Golomb(n-1, memory),
                memory
            ),
            memory
        );
    }
    return memory[n];
}

Console.WriteLine("Golomb");
var memory = new Dictionary<int, int>();
for(var i = 1; i<=2; i++)
{
    var golomb = Golomb(i, memory);
    Console.WriteLine($"{i}: {golomb}");
}

int UniquePathsWithMemory(int rows, int cols, Dictionary<string, int> memory)
{
    if (rows == 1 || cols == 1)
    {
        return 1;
    }

    var key = $"{rows}x{cols}";
    if (!memory.ContainsKey(key))
    {
        memory[key] =
            UniquePathsWithMemory(rows - 1, cols, memory)
            + UniquePathsWithMemory(rows, cols - 1, memory);
    }

    return memory[key];
}
Console.WriteLine("Unique with memory");
Console.WriteLine(UniquePathsWithMemory(3, 7, new Dictionary<string, int>()));


int GreatestProductOfThree(int[] input)
{
    Array.Sort<int>(input);

    var x = 1;
    if (input.Length > 0)
    {
        x = input[input.Length-1];
    }

    var y = 1;
    if (input.Length > 1)
    {
        y = input[input.Length-2];
    }

    var z = 1;
    if (input.Length > 2)
    {
        z = input[input.Length-3];
    }

    return x * y * z;
}

var product = GreatestProductOfThree(new int[] {9, 3, 2, 7});
Console.WriteLine("Greatesdt Product");
Console.WriteLine(product);

int findMissingNumber(int[] input)
{
    Array.Sort<int>(input);

    for(var i = 0; i<input.Length; i++)
    {
        if (input[i] != i)
        {
            return i;
        }
    }

    return -1;
}
var missing = findMissingNumber(new []{0, 1, 5, 4, 2});
Console.WriteLine("Missing number");
Console.WriteLine(missing);

int greatestNumber(int[] input)
{
    var greatest = 0;
    for(var i = 0; i < input.Length; i++)
    {
        for(var j = 0; j < input.Length; j++)
        {
            if (input[i] > input[j])
            {
                greatest = input[i];
            }
        }
    }
    return greatest;
}

var greatest = greatestNumber(new[] {0, 1, 6, 8, 2});
Console.WriteLine("Greatest number");
Console.WriteLine(greatest);