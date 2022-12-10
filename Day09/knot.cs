public class Knot {

    public Point Loc { get; set;} = new Point();    
    public Point Start { get; set;} = new Point();    
    public Knot? Next {get; set;} = null;

    public string Pic {get; set;} = "😎";

    public List<Point> Path { get; set; } = new List<Point>();
    public List<Point> PathUnique { get; set; } = new List<Point>();

    public Knot() { 
        StoreLocation();
        StoreUniqueLocation();        
    }
    public Knot(int x, int y) {
        this.Loc.x = x;
        this.Loc.y = y;
        this.Start.x = x;
        this.Start.y = y;
        StoreLocation();
        StoreUniqueLocation();        
    }

    public void Move(string dir, int count, Playfield pf = null)
    {
        if (pf != null) {
            Console.Clear();
            Console.WriteLine($"Moving {dir} {count}");
            pf.PrintPlayField();            
            Console.ReadKey();
        }
        for(int x = 0; x< count; x++) {            
            if (pf != null) {
                Console.Clear();
                Console.WriteLine($"Moving {dir} {x+1} of {count}");
            }
            Move(dir);
            if (pf != null) {
                pf.PrintPlayField();
                Console.ReadKey();
                Thread.Sleep(100);            
            }
        }
        if (pf != null) {
            Console.ReadKey();
        }
    }

    public void Move(string dir) {
        var px = this.Loc.x;
        var py = this.Loc.y;        

        switch (dir) {
            case "U": Loc.y++; break;
            case "D": Loc.y--; break;
            case "L": Loc.x--; break;
            case "R": Loc.x++; break;
        }
        StoreLocation();
        StoreUniqueLocation();
        if (Next != null) {
            Next.MoveAbsolute(px, py, Loc.x, Loc.y);
        }
    }

    public void MoveAbsolute(int lx, int ly, int cx, int cy) {
        var px = this.Loc.x;
        var py = this.Loc.y;        

        var dx = Math.Abs(px - cx);
        var dy = Math.Abs(py - cy);

        // Console.WriteLine($"dx: {dx}, dy: {dy}");

        if (dx > 1 || dy > 1) {
            this.Loc.x = lx;
            this.Loc.y = ly;
        }

        StoreLocation();
        StoreUniqueLocation();

        if (Next != null) {
            Next.MoveAbsolute(px, py, Loc.x, Loc.y);
        }
    }

    public void StoreUniqueLocation() {
        if (PathUnique.Any(p => p.x == Loc.x && p.y == Loc.y)) return;
        PathUnique.Add(new Point(Loc.x, Loc.y));
    }

    public void StoreLocation() {
        Path.Add(new Point(Loc.x, Loc.y));
    }



}
