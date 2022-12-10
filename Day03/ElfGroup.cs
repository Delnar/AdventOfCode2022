public class ElfGroup {

    public List<Rucksack> Rucksacks { get; set; } = new ();

    public string DuplicateItem { get => GetDuplicateLetterInRucksacks(); }
    public int DuplicateValue { get => GetValueOfString(GetDuplicateLetterInRucksacks());}
    public void AddRange(IEnumerable<Rucksack> rucksacks) {
        Rucksacks.AddRange(rucksacks);
    }

    public string GetDuplicateLetterInRucksacks()
    {
        string dupLetter = "";
        foreach (char letter in Rucksacks[0].Contents) {
            if (Rucksacks[1].Contents.Contains(letter) && Rucksacks[2].Contents.Contains(letter)) {
                dupLetter = letter.ToString();
                break;
            }
        }
        return dupLetter;
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
}