using System;
using System.Collections.Generic;

namespace Data
{
    [Serializable]
    public class HighScores
    {
        public List<HighScoreData> HighScoresDataList = new List<HighScoreData>();
    }
    
    
    [Serializable]
    public class HighScoreData
    {
        public int Score;
        public string Alias;
    }
}