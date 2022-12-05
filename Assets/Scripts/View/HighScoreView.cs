using System.Collections.Generic;
using Data;
using UnityEngine;

namespace View
{
    /// <summary>
    /// Responsible for showing the list of all saved highscores.
    /// Atm delete and create all entries when HighScore Screen is being shown.
    /// Entries are instantiated and not reused.
    /// </summary>
    public class HighScoreView : MonoBehaviour
    {
        [SerializeField] private GameObject noHighScoreTxtContainer;
        [SerializeField] private HighScoreEntryView highScoreEntryPrefab;
        [SerializeField] private Transform highScoreEntryContainer;
        [SerializeField] private Color firstPlaceColor;
        [SerializeField] private Color secondPlaceColor;
        [SerializeField] private Color thirdPlaceColor;
        [SerializeField] private Color defaultColor;
        [SerializeField] private Color unevenPlaceBackgroundColor;
        [SerializeField] private Color evenPlaceBackgroundColor;

        public void CreateEntireHighScoreRanking(List<HighScoreData> highScores)
        {
            noHighScoreTxtContainer.SetActive(highScores.Count == 0);
            
            for (int i = 0; i < highScores.Count; i++)
            {
                int rank = i + 1;
                HighScoreData highScoreData = highScores[i];
                HighScoreEntryView entry = Instantiate(highScoreEntryPrefab, highScoreEntryContainer);
                entry.Format(rank, highScoreData.Score, highScoreData.Alias, determineColorBasedOnRank(rank),
                    determineBackgroundColorBasedOnRank(rank));
            }
        }

        public void ClearEntireHighScoreRanking()
        {
            foreach (Transform child in highScoreEntryContainer)
            {
                Destroy(child.gameObject);
            }
        }

        /// <summary>
        /// Adds an entry at a certain position in the table.
        /// When entries exceed its maximum remove "lowest/last entry" in list (Will be entry with lowest score).
        /// </summary>
        public void InsertEntry(int index)
        {
            // to be implemented
        }

        private Color determineBackgroundColorBasedOnRank(int rank)
        {
            return rank % 2 == 0 ? evenPlaceBackgroundColor : unevenPlaceBackgroundColor;
        }

        private Color determineColorBasedOnRank(int rank)
        {
            return rank == 1
                ? firstPlaceColor
                : (rank == 2 ? secondPlaceColor : (rank == 3 ? thirdPlaceColor : defaultColor));
        }
        
    }
}