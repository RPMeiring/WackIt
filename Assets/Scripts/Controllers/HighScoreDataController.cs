using System.Collections.Generic;
using System.Linq;
using Data;
using SaveLoad;

namespace Controllers
{
    /// <summary>
    /// Keeps track of the highscore list.
    /// Also responsible for adjusting the list if needed.
    /// </summary>
    public class HighScoreDataController : Singleton<HighScoreDataController>
    {
        private const int MAX_ENTRIES_IN_HIGHSCORE_LIST = 10;

        private List<HighScoreData> highScoreDataList;

        public List<HighScoreData> HighScoreDataList
        {
            get { return highScoreDataList; }
            private set { highScoreDataList = value; }
        }

        #region UNITY_METHODS

        private void Start()
        {
            retrieveData();
            sortData();
        }

        #endregion

        /// <summary>
        /// Add new entry to highScore list.
        /// List has max entries.
        /// </summary>
        /// <param name="newEntry"></param>
        public void UpdateData(HighScoreData newEntry)
        {
            HighScoreDataList.Add(newEntry);
            sortData();
            int excessEntries =  HighScoreDataList.Count - MAX_ENTRIES_IN_HIGHSCORE_LIST;
            if (excessEntries > 0)
            {
                for (int i = 0; i < excessEntries; i++)
                {
                    int indexToRemove = HighScoreDataList.Count - i;
                    HighScoreDataList.RemoveAt(indexToRemove);
                }
                
                HighScoreDataList.TrimExcess();
            }
        }

        public void SaveData()
        {
            SaveLoadController.Instance.SaveHighScores(HighScoreDataList);
        }

        /// <summary>
        /// Compares given score to last entry of high score list.
        /// last entry is the lowest score.
        /// </summary>
        /// <param name="score"></param>
        /// <returns></returns>
        public bool IsScoreNewHighScore(int score)
        {
            int lastIndex = HighScoreDataList.Count - 1;
            return lastIndex < MAX_ENTRIES_IN_HIGHSCORE_LIST || HighScoreDataList[lastIndex].Score < score;
        }

        private void retrieveData()
        {
            HighScoreDataList = SaveLoadController.Instance.LoadHighScores();
        }

        /// <summary>
        /// Sorted the order by descending. First entry is the highest score.
        /// </summary>
        private void sortData()
        {
            if (HighScoreDataList != null)
                HighScoreDataList = HighScoreDataList.OrderByDescending(d => d.Score).ToList();
        }
    }
}