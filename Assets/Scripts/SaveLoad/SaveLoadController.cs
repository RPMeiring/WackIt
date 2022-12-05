using System.Collections.Generic;
using Controllers;
using Data;
using UnityEngine;

namespace SaveLoad
{
    /// <summary>
    /// Responsible for saving and loading of the highscore list.
    /// Uses Json utility for saving and loading a list into playerprefs.
    /// </summary>
    public class SaveLoadController : Singleton<SaveLoadController>
    {
        private const string HIGHSCORE_DATA_KEY = "highscores";
        
        public void SaveHighScores(List<HighScoreData> highScoreList)
        {
            HighScores highScores = new HighScores { HighScoresDataList = highScoreList };
            string json = JsonUtility.ToJson(highScores);
            PlayerPrefs.SetString(HIGHSCORE_DATA_KEY, json);
            PlayerPrefs.Save();
        }

        public List<HighScoreData> LoadHighScores()
        {
            HighScores highScores = new HighScores();
            string json = PlayerPrefs.GetString(HIGHSCORE_DATA_KEY, "");
            if (!string.IsNullOrEmpty(json))
                highScores = JsonUtility.FromJson<HighScores>(json);

            return highScores.HighScoresDataList;
        }

        /// <summary>
        /// Creates some test data.
        /// </summary>
        /// <returns></returns>
        private List<HighScoreData> createTestList()
        {
            List<HighScoreData> data = new List<HighScoreData>()
            {
                new HighScoreData { Score = 200, Alias = "AAA" },
                new HighScoreData { Score = 300, Alias = "BBB" },
                new HighScoreData { Score = 100, Alias = "BBB" },
                new HighScoreData { Score = 250, Alias = "CCC" },
                new HighScoreData { Score = 50, Alias = "DDD" },
                new HighScoreData { Score = 50, Alias = "AAA" },
                new HighScoreData { Score = 50, Alias = "ZZZ" },
                new HighScoreData { Score = 50, Alias = "RPM" },
                new HighScoreData { Score = 50, Alias = "TST" },
                new HighScoreData { Score = 50, Alias = "ZZZ" },
            };
            
            return data;
        }
    }
}