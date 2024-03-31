public enum GameState
{
    None = 0,
    
    /// <summary>
    /// Lobby Step on Multiplayer Mode
    /// </summary>
    Lobby,

    /// <summary>
    /// Stage Select Step
    /// </summary>
    StageSelect,
    
    /// <summary>
    /// Stage Loaded But Not Started
    /// </summary>
    Ready, 

    /// <summary>
    /// Stage Started
    /// </summary>
    Playing,

    /// <summary>
    /// Stage Ended But Not Destroyed
    /// </summary>
    Finish
}
