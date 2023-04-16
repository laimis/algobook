public class Techniques
{
    public static int GreatestSum(int[] input)
    {
        var currentSum = 0;
        var greatestSum = 0;

        foreach(var n in input)
        {
            if (currentSum + n < 0)
            {
                currentSum = 0;
            }
            else
            {
                currentSum += n;
                if (currentSum > greatestSum)
                {
                    greatestSum = currentSum;
                }
            }
        }

        return greatestSum;
    }

    public static string[] CommonElements(string[] a, string[] b)
    {
        var common = new List<string>();
        var map = new HashSet<string>();

        foreach(var aElement in a)
        {
            map.Add(aElement);
        }

        foreach(var bElement in b)
        {
            if (map.Contains(bElement))
            {
                common.Add(bElement);
            }
        }

        return common.ToArray();
    }

    public static int? ReturnMissing(int[] arr)
    {
        var set = new HashSet<int>();
        for (var i = 0; i<arr.Length + 2; i++)
        {
            set.Add(i);
        }

        foreach(var n in arr)
        {
            set.Remove(n);
        }

        return set.FirstOrDefault();
    }

    public static int GreatestProfit(int[] input)
    {
        var buy = input[0];
        var greatestProfit = 0;

        foreach(var i in input)
        {
            var currentProfit = i - buy;
            if (currentProfit < 0)
            {
                buy = i;
            }

            if (currentProfit > greatestProfit)
            {
                greatestProfit = currentProfit;
            }
        }

        return greatestProfit;
    }

    public static IEnumerable<double> Sort(IEnumerable<double> input)
    {
        var offset = 970;
        var arr = new bool[21];

        foreach(var n in input)
        {
            var index = Convert.ToInt32(n * 10) - offset;
            arr[index] = true;
        }

        for(var i=0; i<arr.Length; i++)
        {
            if (arr[i])
            {
                yield return (offset + i) / 10.0;
            }
        }
    }
}