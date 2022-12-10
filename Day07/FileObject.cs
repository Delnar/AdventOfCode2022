public class FileObject {

    public string Name { get; set; } = "";
    public long   Size { get; set; } = 0;
    public DirectoryObject Parent { get; set; } = null!;

    public FileObject(string name, long size) {
        Name = name;
        Size = size;
    }

    public FileObject(string command) {
        string[] parts = command.Split(' ');
        Size = long.Parse(parts[0]);
        Name = parts[1];
    }
}