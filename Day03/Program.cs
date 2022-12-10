// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
// Create a list of Rucksacks  
List<Rucksack> rucksacks = new List<Rucksack>();
// Read all lines in data.txt
string[] lines = File.ReadAllLines("data.txt");
// Loop through all lines
foreach (string line in lines) {
    // Create a new Rucksack
    Rucksack rucksack = new Rucksack(line);
    // Add the Rucksack to the list
    rucksacks.Add(rucksack);
}

// print all rucksacks
// foreach (Rucksack rucksack in rucksacks.OrderBy(x => x.DuplicateValue)) {
//     Console.WriteLine(rucksack);
// }

// Print the sum of all duplicate values
// Console.WriteLine($"Sum of all duplicate values: {rucksacks.Sum(x => x.DuplicateValue)}");

// Create a list of ElfGroups
List<ElfGroup> elfGroups = new List<ElfGroup>();
// Break up the rucksacks into groups of 3 and add them to the ElfGroups   
for (int i = 0; i < rucksacks.Count; i += 3) {
    ElfGroup elfGroup = new ElfGroup();
    elfGroup.AddRange(rucksacks.GetRange(i, 3));
    elfGroups.Add(elfGroup);
}

// Print all Duplicate Items from the ElfGroups
foreach (ElfGroup elfGroup in elfGroups) {
    Console.WriteLine($"{elfGroup.DuplicateItem}");
}

// Print the sum of all duplicate items from the ElfGroups\
Console.WriteLine($"Sum of all duplicate items: {elfGroups.Sum(x => x.DuplicateValue)}");