public class DirectoryObject {

    public string Name { get; set; } = "";
    public List<FileObject> Files { get; set; } = new();
    public List<DirectoryObject> Directories { get; set; } = new();
    public DirectoryObject? Parent { get; set; } = null;

    public DirectoryObject(string text) {
        string[] parts = text.Split(' ');
        Name = parts[1];
    }

    public void AddFile(FileObject file) {
        file.Parent = this;
        Files.Add(file);
    }

    public void AddDirectory(DirectoryObject directory) {
        directory.Parent = this;
        Directories.Add(directory);
    }

    public long GetSize() {
        long size = 0;
        foreach (FileObject file in Files) {
            size += file.Size;
        }
        foreach (DirectoryObject directory in Directories) {
            size += directory.GetSize();
        }
        return size;
    }

    public override string ToString() {
        return $"{Name} ({GetSize()})";
    }

    public IEnumerable<DirectoryObject> GetEnumerable() {
        yield return this;
        foreach (DirectoryObject directory in Directories) {
            foreach (DirectoryObject subDirectory in directory.GetEnumerable()) {
                yield return subDirectory;
            }
        }
    }

}