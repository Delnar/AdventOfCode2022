public class SectionPair {
    public SectionAssignment First { get; set; }
    public SectionAssignment Second { get; set; }

    public SectionPair(SectionAssignment first, SectionAssignment second) {
        First = first;
        Second = second;
    }

    // Print both SectionAssignments 
    public void PrintAssignment() {
        Console.WriteLine($"{First}");
        Console.WriteLine($"{Second}");
    }

    // Check if the First SectionAssignment is between the Second SectionAssignment or the Second SectionAssignment is between the First SectionAssignment
    public bool IsBetween() {
        return First.IsBetween(Second) || Second.IsBetween(First);
    }

    // CHec if the First SectionAssignment overlaps the Second SectionAssignment or the Second SectionAssignment overlaps the First SectionAssignment
    public bool Overlaps() {
        return First.Overlaps(Second) || Second.Overlaps(First);
    }


}