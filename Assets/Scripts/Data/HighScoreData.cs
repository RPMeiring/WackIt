using System;
using System.Collections.Generic;

namespace Data
{
    /// <summary>
    /// Data class for all highscores that need to be saved.
    /// </summary>
    [Serializable]
    public class HighScores
    {
        public List<HighScoreData> HighScoresDataList = new List<HighScoreData>();
    }
    
    /// <summary>
    /// data entry for the highscore list that need to be saved.
    /// </summary>
    [Serializable]
    public class HighScoreData
    {
        public int Score;
        public string Alias;
    }
}