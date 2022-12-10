public class Machine {
    List<ItemStack> stacks = new List<ItemStack>();
    private readonly int NumberOfStacks = 12;

    public Machine() {
        // Create 9 stacks
        for (int i = 0; i < NumberOfStacks; i++) {
            stacks.Add(new ItemStack());
        }
    }
    
    public void AddInitialStackData(string stackData) {

        if (stackData.Contains("[") == false) { return;  }
        // Take every 4 characters and create a list of them
        List<string> items = new List<string>();
        for (int i = 0; i < stackData.Length; i += 4) {
            var val = stackData.PadRight(50).Substring(i, 4).Trim();
            val = val.Replace("[", "").Replace("]", "");
            items.Add(val);
        }
    
        for (int i = 0; i < items.Count; i++) {
            if (string.IsNullOrWhiteSpace(items[i])) continue;
            stacks[i].Push(items[i]);
        }
    }

    public void FlipStacks()
    {
        for (int i = 0; i < NumberOfStacks; i++) {
            stacks[i].Reverse();
        }
    }

    public void Move(MoveInstruction move) {        
        // Get the from stack
        ItemStack fromStack = stacks[move.FromColumn];
        // Get the to stack
        ItemStack toStack = stacks[move.ToColumn];

        // Console.WriteLine(fromStack);
        // Console.WriteLine(toStack);

        // Loop through the number of items to move
        for (int i = 0; i < move.NumberOfItems; i++) {
            // Get the item from the from stack
            string item = fromStack.Pop();
            // Push the item to the to stack
            toStack.Push(item);
        }
    }

    public void PrintStacks() {
        var talestStackSize = stacks.Max(x => x.Size);

        // Loop through all stacks
        for (int i = talestStackSize - 1; i >=0; i--) {
            // Loop through all stacks
            for (int j = 0; j < stacks.Count; j++) {
                // Get the item at the current index
                string item = stacks[j].GetItemAtIndex(i);
                // Print the item
                Console.Write($"{item} ");
            }
            // Print a new line
            Console.WriteLine();
        }
        for (int j = 0; j < stacks.Count; j++) {
            Console.Write($" {j+1}  ");
        }
        Console.WriteLine();
    }

}
