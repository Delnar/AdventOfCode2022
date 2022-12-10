public class MoveInstruction {
    public int NumberOfItems { get; set; } = 0;
    public int FromColumn { get; set; } = 0;
    public int ToColumn { get; set; } = 0;

    public MoveInstruction(string instruction) {
        // move 16 from 4 to 5
        // Split the instruction by space
        string[] values = instruction.Split(' ');
        // Get the number of items to move
        NumberOfItems = int.Parse(values[1]);
        // Get the from column
        FromColumn = int.Parse(values[3]) - 1;
        // Get the to column
        ToColumn = int.Parse(values[5]) - 1;
    }

    public override string ToString() {
        return $"Move {NumberOfItems} from {FromColumn + 1} to {ToColumn + 1}";
    }
}