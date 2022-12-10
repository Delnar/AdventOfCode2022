// Read all lines in data.txt file
List<string> lines = File.ReadAllLines("data.txt").ToList();


// Create Root directory object
DirectoryObject root = new DirectoryObject("DIR /");

DirectoryObject? currentDirectory = root;

// interate between each line  

lines.ForEach(line => {
    if (currentDirectory == null) { currentDirectory = root; }
    switch(line) {
         case "$ cd /":  { currentDirectory = root; return; }
         case "$ cd ..": { currentDirectory = currentDirectory?.Parent; return; }
         case "$ ls": { return; }
    }

    if (line.StartsWith("$ cd ")) {
        string directoryName = line.Substring(5);
        DirectoryObject? directory = currentDirectory.Directories.FirstOrDefault(d => d.Name == directoryName);
        if (directory != null) {
            currentDirectory = directory;
        }
        return;
    }

    if (line.StartsWith("dir ")) {
        DirectoryObject directory = new DirectoryObject(line);
        currentDirectory.AddDirectory(directory);
        // currentDirectory = directory;
    } else {
        FileObject file = new FileObject(line);
        currentDirectory.AddFile(file);
    }    
});

var TotalSpace = 70000000;
var TargetSize = 30000000;
var TotalSpaceUsed = root.GetSize();
var TotalSpaceFree = TotalSpace - TotalSpaceUsed;
var GetToTarget = TargetSize - TotalSpaceFree;


Console.WriteLine($"Total Space: {TotalSpace}");
Console.WriteLine($"Total Space Used: {TotalSpaceUsed}");
Console.WriteLine($"Total Space Free: {TotalSpaceFree}");
Console.WriteLine($"Target Size: {TargetSize}");
Console.WriteLine($"Get To Target: {GetToTarget}");

// Find the smallest directory greater than GetToTarget
var smallestDirectory = root.GetEnumerable().ToList().Where(x => x.GetSize() >= GetToTarget).OrderBy(x => x.GetSize()).FirstOrDefault();
Console.WriteLine($"Smallest Directory: {smallestDirectory}");



// var allDirectories = root.GetEnumerable().ToList().Where();
// var total = allDirectories.Where(x => x.GetSize() <= 100000).ToList().Sum(x => x.GetSize());
// Console.WriteLine(total);





