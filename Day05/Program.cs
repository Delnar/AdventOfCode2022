// See https://aka.ms/new-console-template for more information
// Create a list of Move instructions
List<MoveInstruction> moves = new List<MoveInstruction>();
// Read all move instructions from instructions.txt
string[] instructions = File.ReadAllLines("instructions.txt");
// Loop through all instructions
foreach (string instruction in instructions) {
    // Create a new MoveInstruction
    MoveInstruction move = new MoveInstruction(instruction);
    // Add the MoveInstruction to the list
    moves.Add(move);
}

// Read all lines from Data.txt
string[] lines = File.ReadAllLines("data.txt");
// Create a new Machine
Machine machine = new Machine();
// interate through lines  
foreach (string line in lines) {
    // Add the initial stack data
    machine.AddInitialStackData(line);
}

machine.FlipStacks();
machine.PrintStacks();


// Loop through all moves
foreach (MoveInstruction move in moves) {
    Console.WriteLine(move);
    // Move the items
    machine.Move(move);
    // Print the stacks
    // machine.PrintStacks();
    // Console.ReadLine();
}

machine.PrintStacks();

Day5.Solve();