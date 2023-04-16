public class Tracker
{
    public int Total => Combos.Count;
    public HashSet<string> Combos { get; private set; } = new HashSet<string>();

    public void Found(string combo)
    {
        Combos.Add(combo.Replace("0", ""));
    }
}