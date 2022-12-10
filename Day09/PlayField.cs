public class Playfield {

    public int Width { get; set; } = 0;
    public int Height { get; set; } = 0;

    public Knot Head { get; set; } = null;

    public Playfield(int Width, int Height)
    {
        this.Width = Width;
        this.Height = Height;
    }


    public void PrintPlayField()
    {
        // Console.Clear();
        for (int y = Height-1; y >= 0 ; y--)
        {
            for (int x = 0; x < Width; x++) {
                var knot = GetKnot(x, y);
                if (knot != null) {
                    Console.Write(knot.Pic);
                } else {
                    Console.Write(".");
                }
            }
            Console.WriteLine();
        }
    }

    public Knot GetKnot(int x, int y)
    {
        var knot = Head;
        while (knot != null) {
            if (knot.Loc.x == x && knot.Loc.y == y) {
                return knot;
            }
            knot = knot.Next;
        }
        return null;
    }
}