public class Game {
    public ResponseTypeEnum Player1Response { get; set; }
    public ResponseTypeEnum Player2Response { get; set; }
    public int GameNumber { get; set; } = default;

    public Game(string player1Response, string player2Response) {
        // Console.WriteLine($"Game({player1Response}, {player2Response})");
        var GameResult = player2Response.GetGameResult();
        Player1Response = player1Response.GetResponseType();
        Player2Response = GetGameResultResponse(Player1Response, GameResult);
    }

    private ResponseTypeEnum GetGameResultResponse(ResponseTypeEnum Player01, GameResultEnum Result)  =>
        Result switch {
            GameResultEnum.WIN => Player01.GetWinningResponse(),
            GameResultEnum.DRAW => Player01.GetDrawResponse(),
            GameResultEnum.LOOSE => Player01.GetLoosingResponse(),
            _ => ResponseTypeEnum.INVALID
        };        


    public int Player01Score() => CalculateResponseScore(Player1Response) + CalculateGamePlayScore(Player1Response, Player2Response);
    public int Player02Score() => CalculateResponseScore(Player2Response) + CalculateGamePlayScore(Player2Response, Player1Response);

    private bool WinningResponse(ResponseTypeEnum player1Response, ResponseTypeEnum player2Response) {
        return player1Response switch {
            ResponseTypeEnum.ROCK => player2Response == ResponseTypeEnum.SCISSOR,
            ResponseTypeEnum.PAPER => player2Response == ResponseTypeEnum.ROCK,
            ResponseTypeEnum.SCISSOR => player2Response == ResponseTypeEnum.PAPER,
            _ => false
        };
    }

    private int CalculateResponseScore(ResponseTypeEnum rsp1) {
        return rsp1 switch {
            ResponseTypeEnum.ROCK => 1,
            ResponseTypeEnum.PAPER => 2,
            ResponseTypeEnum.SCISSOR => 3,
            _ => 0
        };
    }
    private int CalculateGamePlayScore(ResponseTypeEnum rsp1, ResponseTypeEnum rsp2) {
        if (rsp1 == rsp2) { return 3; }
        if (WinningResponse(rsp1, rsp2)) { return 6; }
        return 0;
    }

    // Function to list who wins the game
    public string Winner() {
        if (Player1Response == Player2Response) { return "Draw"; }
        if (WinningResponse(Player1Response, Player2Response)) { return "Player 1"; }
        return "Player 2";
    }

    public override string ToString()
    {
        return $"{GameNumber:00000} Player1 Response: {Player1Response.ToString().PadRight(10)} Player2 Resposne: {Player2Response.ToString().PadRight(10)} Winner: {Winner()}";
    }

}