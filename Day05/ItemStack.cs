public class ItemStack {
    public List<string> items = new List<string>();
    public int Size { get { return items.Count; } }

    public string GetItemAtIndex(int id)
    {        
        if (id >= Size) return "   ";
        if (id < 0) return "   ";
        var ret = items.ElementAt(id);
        return $"[{ret}]";
    }

    public void Push(string item) {
        items.Add(item);
    }
    public string Pop() {
        var ret = items.Last();
        items.Remove(ret);
        return ret;        
    }

    public override string ToString() {
        return string.Join(", ", items);
    }

    // reverse list
    public void Reverse() {
        items.Reverse();
    }
}