// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
// Read all lines from data.txt file
var lines = File.ReadAllLines("data-sample2.txt");
// Create Head Knot
var head = new Knot(20,20) { Pic = "H" };
Knot tail = head;

for(int x = 1; x<= 9; x++) {
    var n = new Knot(20,20) { Pic = x.ToString() };
    tail.Next = n;
    tail = n;
}

var pf = new Playfield(40, 40);
pf.Head = head;

// Interate over all lines
foreach (var line in lines) {
    // Split line into directions
    var parts = line.Split(' ');
    var dir = parts[0];
    var len = int.Parse(parts[1]);
    // Move head knot
    head.Move(dir, len, pf);
    // head.Move(dir, len);
}

// RunAndShow("Z");
// RunAndShow("R");
// RunAndShow("R");
// RunAndShow("R");
// RunAndShow("R");

// Print a count of all unique locations
Console.WriteLine(tail.PathUnique.Count);


void RunAndShow(string direction) {
    Console.Clear();
    head.Move(direction, 1);
    pf.PrintPlayField();
    Thread.Sleep(1000);
}

