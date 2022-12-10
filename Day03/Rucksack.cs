public class Rucksack {
    public string Contents { get; set; }

    private int HalfSize => Contents.Length / 2;
    public string FirstCompartment { get => Contents.Substring(0, HalfSize); }
    public string ScondCompartment { get => Contents.Substring(HalfSize, HalfSize); }

    public int DuplicateValue { get => GetValueOfString(GetDuplicateItem()); }

    public Rucksack(string contents) {
        Contents = contents;
    }

    public string GetDuplicateItem() {
        string dupItem = "";
        foreach (char item in FirstCompartment) {
            if (ScondCompartment.Contains(item)) {
                dupItem = item.ToString();
                break;
            }
        }
        return dupItem;
    }

    private int GetValueOfChar(char inputCharacter) {
        var baseLowerCase = char.ToLower(inputCharacter);
        int value = (int)baseLowerCase - 96;
        if (char.IsUpper(inputCharacter)) {
            value += 26;
        }
        return value;
    }
    private int GetValueOfString(string s) {
        int value = 0;
        foreach (char c in s) {
            value += GetValueOfChar(c);
        }
        return value;
    }

    public override string ToString()
    {
        return $"{FirstCompartment.PadRight(30)} ---- {ScondCompartment.PadRight(30)} -- Dupe: {GetDuplicateItem()} {GetValueOfString(GetDuplicateItem())}";
    }
}