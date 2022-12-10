// Read all lines as list from data.txt
var lines = File.ReadAllLines("data.txt");

// Create a list of games
var games = new List<Game>();
int LineNumber = 1;
lines.ToList().ForEach(line => {
    // split line into two parts delimited by space
    var parts = line.Split(" ");
    // create a new game with the two parts
    var game = new Game(parts[0], parts[1]);
    game.GameNumber = LineNumber;
    Console.WriteLine(game.ToString());
    // add the game to the list
    games.Add(game);    
    LineNumber++;
});

// Get and Print the sum of Player02Score for all games
var player02Score = games.Sum(g => g.Player02Score());
Console.WriteLine($"Player02Score: {player02Score}");
