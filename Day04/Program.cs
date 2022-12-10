// See https://aka.ms/new-console-template for more information
// Read all lines from Data.txt
string[] lines = File.ReadAllLines("data.txt");

// Create a list of SectoinPairs   
List<SectionPair> sectionPairs = new List<SectionPair>();

// Loop through all lines  
foreach (string line in lines) {
    // Split the line by space
    string[] values = line.Split(',');
    // Create a new SectionPair
    SectionPair sectionPair = new SectionPair(new SectionAssignment(values[0]), new SectionAssignment(values[1]));
    // Add the SectionPair to the list
    sectionPairs.Add(sectionPair);
}

// Print all SectionPairs
foreach (SectionPair sectionPair in sectionPairs) {
    sectionPair.PrintAssignment();
    Console.WriteLine();
}

// Print the number of SectionPairs that overlap
Console.WriteLine($"Number of SectionPairs that overlap: {sectionPairs.Count(x => x.Overlaps())}");

