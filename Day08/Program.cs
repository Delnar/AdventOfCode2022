// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
// Read all lines in data.txt file
List<string> lines = File.ReadAllLines("data.txt").ToList();
var height = lines.Count;
var width = lines.Max(x => x.Length);

// Create a new forest object
Forest forest = new Forest(width, height);
// Load all lines into forest
for (int y = 0; y < height; y++) {
    forest.AddRow(lines[y], y);
}

// Count all trees visible form edge
int count = 0;
for (int y = 0; y < height; y++) {
    for (int x = 0; x < width; x++) {
        if (forest.IsTreeVisibleFromEdge(x, y)) count++;
    }
}


// Print result
Console.WriteLine($"Trees visible from edge: {count}");

// Print the highest scenic score
Console.WriteLine($"Highest scenic score: {forest.GetLargestScenicScore()}");
// clear the console
// Console.Clear();
// forest.PrintScenicScoreForTree(2, 1);
