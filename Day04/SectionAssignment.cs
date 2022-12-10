using System.Text;
public class SectionAssignment {


    public int MinValue { get; set; } = 0;
    public int MaxValue { get; set; } = 0;

    // Split a string by - and set the first value as MinValue and the Second Value as MaxValue
    public SectionAssignment(string line) {
        string[] values = line.Split('-');
        MinValue = int.Parse(values[0]);
        MaxValue = int.Parse(values[1]);
    }

    public override string ToString() {
        return $"{MinValue:00}-{MaxValue:00} {GetLongDisplay()}";
    }

    public string GetLongDisplay() {
        StringBuilder sb = new StringBuilder();
        for(int x=1; x<=100; x++) {
            if (x >= MinValue && x <= MaxValue) {
                sb.Append("*");
            } else {
                sb.Append("-");
            }
        }
        return sb.ToString();
    }

    // Check if a SectionAssignment MinValue and MaxValue is between this MinValue and MaxValue
    public bool IsBetween(SectionAssignment sectionAssignment) {
        return sectionAssignment.MinValue >= MinValue && sectionAssignment.MaxValue <= MaxValue;
    }

    public bool IsBetween(int value) {
        return value >= MinValue && value <= MaxValue;
    }

    // Check if a SectionAssignment MinValue and MaxValue overlaps this MinValue and MaxValue
    public bool Overlaps(SectionAssignment sectionAssignment) {
        return IsBetween(sectionAssignment.MinValue) ||  IsBetween(sectionAssignment.MaxValue);
    }

    // CHeck if a SectionAssignment MinValue and MaxValue intercets this MinValue and MaxValue or overlaps this MinValue and MaxValue
    public bool Intersects(SectionAssignment sectionAssignment) {
        return IsBetween(sectionAssignment) || Overlaps(sectionAssignment);
    }
}