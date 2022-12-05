namespace General
{
    /// <summary>
    /// Definition of all possible windows.
    /// </summary>
    public enum WindowType
    {
        None,
        Index,
        Level,
        GameOver,
        HighScore
    }

    /// <summary>
    /// Definition of the different difficulty settings.
    /// Has impact on timing and NPC's spawns.
    /// </summary>
    public enum Difficulty
    {
        Easy,
        Medium,
        Hard
    }

    /// <summary>
    /// Definition of all the different NPC's that can spawn.
    /// </summary>
    public enum NpcType
    {
        None,
        NormalMole,
        BonusMole,
        EvilMole
    }
}
