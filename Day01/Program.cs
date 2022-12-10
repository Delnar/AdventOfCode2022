

// Read all lines from data.txt
var lines = File.ReadAllLines("data.txt");
// Create a list of elfs
var elfs = new List<Elf>();
int id = 1;
var elf = new Elf(id);

lines.ToList().ForEach(line => {
    if (string.IsNullOrEmpty(line.Trim())) {
        elfs.Add(elf);
        elf = new Elf(id++);
    } else {
        elf.AddCalories(int.Parse(line));
    }
});

elfs.Add(elf);
// var maxC = elfs.Max( x=> x.TotalCalories);
// var maxElf = elfs.Where(x => x.TotalCalories == maxC).FirstOrDefault();
// Console.WriteLine($"Elf {maxElf.Id} has the most calories: {maxElf.TotalCalories}");

// Find the top three elves with max total calories
var top3 = elfs.OrderByDescending(x => x.TotalCalories).Take(3);
Console.WriteLine("Top 3 elves with most calories:");
top3.ToList().ForEach(x => Console.WriteLine($"Elf {x.Id} has {x.TotalCalories} calories"));

Console.WriteLine($"Total Calories: {top3.Sum(x => x.TotalCalories)}");