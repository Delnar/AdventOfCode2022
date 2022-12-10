public enum ResponseTypeEnum {
    ROCK = 0,
    PAPER,
    SCISSOR,
    INVALID,
}

public enum GameResultEnum {
    DRAW = 0,
    WIN,
    LOOSE,
    INVALID,
}


static public class ResponseTypeExtension {
    static public GameResultEnum GetGameResult(this string r) => 
        r switch {
            "X" => GameResultEnum.LOOSE,
            "Y" => GameResultEnum.DRAW,
            "Z" => GameResultEnum.WIN,
            _ => GameResultEnum.INVALID
        };        
    static public ResponseTypeEnum GetResponseType(this string r) =>
        r switch {
            "A" => ResponseTypeEnum.ROCK,
            "B" => ResponseTypeEnum.PAPER,
            "C" => ResponseTypeEnum.SCISSOR,
            "X" => ResponseTypeEnum.ROCK,
            "Y" => ResponseTypeEnum.PAPER,
            "Z" => ResponseTypeEnum.SCISSOR,
            _ => ResponseTypeEnum.INVALID
        };

    static public ResponseTypeEnum GetWinningResponse(this ResponseTypeEnum r) => 
        r switch {
            ResponseTypeEnum.ROCK => ResponseTypeEnum.PAPER,
            ResponseTypeEnum.PAPER => ResponseTypeEnum.SCISSOR,
            ResponseTypeEnum.SCISSOR => ResponseTypeEnum.ROCK,
            _ => ResponseTypeEnum.INVALID
        };
    static public ResponseTypeEnum GetLoosingResponse(this ResponseTypeEnum r) => 
        r switch {
            ResponseTypeEnum.ROCK => ResponseTypeEnum.SCISSOR,
            ResponseTypeEnum.PAPER => ResponseTypeEnum.ROCK,
            ResponseTypeEnum.SCISSOR => ResponseTypeEnum.PAPER,
            _ => ResponseTypeEnum.INVALID
        };
    static public ResponseTypeEnum GetDrawResponse(this ResponseTypeEnum r) => 
        r switch {
            ResponseTypeEnum.ROCK => ResponseTypeEnum.ROCK,
            ResponseTypeEnum.PAPER => ResponseTypeEnum.PAPER,
            ResponseTypeEnum.SCISSOR => ResponseTypeEnum.SCISSOR,
            _ => ResponseTypeEnum.INVALID
        };    
}