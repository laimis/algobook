public class SpaceConstraints
{
    public static void Reverse(Array arr)
    {
        for(var i=0; i < arr.Length / 2; i++)
        {
            var temp = arr.GetValue(i);
            arr.SetValue(arr.GetValue(arr.Length - 1 - i), i);
            arr.SetValue(temp, arr.Length - 1 - i);
        }
    }
}