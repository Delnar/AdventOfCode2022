public class Forest
{
    // Createa public  2d array of integers called trees
    public int[,] trees;
    public int Width;
    public int Height;

    // create a constructor that specifies the size of the array
    public Forest(int width, int height)
    {
        this.Width = width;
        this.Height = height;
        // create a new 2d array of integers with the specified width and height
        trees = new int[height, width];
    }

    // create a method that take a string as input and add the string characters as integers to the array
    public void AddRow(string row, int y)
    {
        // loop through each character in the string
        for (int x = 0; x < row.Length; x++) {
            int.TryParse(row[x].ToString(), out int v);
            trees[y, x] = v;
        }
    }

    public bool IsTreeVisibleFromLeft(int x, int y)
    {
        if (x <0) return false;
        if (y <0) return false;
        if (x >= Width) return false;
        if (y >= Height) return false;   

        var t = trees[y, x];
        x--;

        while(x>=0) {
            var v = trees[y,x];
            if (v >= t) return false;
            x--;
        }

        return true;
    }

    public bool IsTreeVisibleFromRight(int x, int y) {
        if (x <0) return false;
        if (y <0) return false;
        if (x >= Width) return false;
        if (y >= Height) return false;   

        var t = trees[y, x];
        x++;

        while(x<Width) {
            var v = trees[y,x];
            if (v >= t) return false;
            x++;
        }

        return true;
    }

    public bool IsTreeVisibleFromTop(int x, int y) {
        if (x <0) return false;
        if (y <0) return false;
        if (x >= Width) return false;
        if (y >= Height) return false;   

        var t = trees[y, x];
        y--;

        while(y>=0) {
            var v = trees[y,x];
            if (v >= t) return false;
            y--;
        }

        return true;
    }

    public bool IsTreeVisisbleFromBottom(int x, int y) {
        if (x <0) return false;
        if (y <0) return false;
        if (x >= Width) return false;
        if (y >= Height) return false;   

        var t = trees[y, x];
        y++;

        while(y<Height) {
            var v = trees[y,x];
            if (v >= t) return false;
            y++;
        }

        return true;
    }

    public bool IsTreeVisibleFromEdge(int x, int y)
    {
        return IsTreeVisibleFromLeft(x, y) || IsTreeVisibleFromRight(x, y) || IsTreeVisibleFromTop(x, y) || IsTreeVisisbleFromBottom(x, y);
    }

    // write a method that calculates the scenic score of a tree
    public int GetScenicScore(int x, int y)
    {
        int score = CountTreesToTop(x, y) * CountTreesToLeft(x,y) * CountTreesToBottom(x,y) * CountTreesToRight(x,y);
        return score;
    }    

    // Write a method to count the number of tree to the left of a tree until the view is blocked by a larger tree
    public int CountTreesToLeft(int x, int y)
    {
        if (x <0) return 0;
        if (y <0) return 0;
        if (x >= Width) return 0;
        if (y >= Height) return 0;   

        int count = 0;
        int t = trees[y, x];
        x--;
        while(x>=0) {
            var v = trees[y,x];
            count++;
            if (v >= t) break;
            x--;
        }
        return count;
    }
    public int CountTreesToRight(int x, int y) {
        if (x <0) return 0;
        if (y <0) return 0;
        if (x >= Width) return 0;
        if (y >= Height) return 0;   

        int count = 0;
        int t = trees[y, x];
        x++;
        while(x<Width) {
            var v = trees[y,x];
            count++;
            if (v >= t) break;
            x++;
        }
        return count;
    }
    public int CountTreesToTop(int x, int y) {
        if (x <0) return 0;
        if (y <0) return 0;
        if (x >= Width) return 0;
        if (y >= Height) return 0;   

        int count = 0;
        int t = trees[y, x];
        y--;
        while(y>=0) {
            var v = trees[y,x];
            count++;
            if (v >= t) break;
            y--;
        }
        return count;
    }
    public int CountTreesToBottom(int x, int y) {
        if (x <0) return 0;
        if (y <0) return 0;
        if (x >= Width) return 0;
        if (y >= Height) return 0;   

        int count = 0;
        int t = trees[y, x];
        y++;
        while(y<Height) {
            var v = trees[y,x];
            count++;
            if (v >= t) break;
            y++;
        }
        return count;
    }
    public int GetLargestScenicScore()
    {
        int largest = 0;
        for (int y = 0; y < Height; y++) {
            for (int x = 0; x < Width; x++) {
                var score = GetScenicScore(x, y);
                if (score > largest) largest = score;
            }
        }
        return largest;
    }
    // Print the tree array
    public void Print()
    {
        for (int y = 0; y < Height; y++) {
            for (int x = 0; x < Width; x++) {
                Console.Write(trees[y, x]);
            }
            Console.WriteLine();
        }
    }

    public void Print(int tx, int ty)
    {
        for (int y = 0; y < Height; y++) {
            for (int x = 0; x < Width; x++) {
                // Change Console color to yellow if this is the tree we are looking at
                if (x == tx && y == ty) Console.ForegroundColor = ConsoleColor.Yellow; else Console.ForegroundColor = ConsoleColor.White;
                Console.Write(trees[y, x]);
            }
            Console.WriteLine();
        }
    }    
    public void PrintScenicScore()
    {
        for (int y = 0; y < Height; y++) {
            for (int x = 0; x < Width; x++) {
                Console.Write($"{GetScenicScore(x, y):000} ");
            }
            Console.WriteLine();
        }
    }
    // Print Scenic Score for single tree
    public void PrintScenicScoreForTree(int x, int y)
    {
        Print(x,y);
        Console.WriteLine();

        Console.WriteLine($"T: {CountTreesToTop(x, y):000} ");
        Console.WriteLine($"L: {CountTreesToLeft(x, y):000} ");
        Console.WriteLine($"R: {CountTreesToRight(x, y):000} ");
        Console.WriteLine($"B: {CountTreesToBottom(x, y):000} ");
        Console.WriteLine($"T * L * R * B = {GetScenicScore(x, y):000} ");
    }
}
