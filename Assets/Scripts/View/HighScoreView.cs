using System.Collections.Generic;
using Data;
using UnityEngine;

namespace View
{
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
                entry.Format(rank, highScoreData.Score, highScoreData.Alias, DetermineColorBasedOnRank(rank),
                    DetermineBackgroundColorBasedonRank(rank));
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

        private Color DetermineBackgroundColorBasedonRank(int rank)
        {
            return rank % 2 == 0 ? evenPlaceBackgroundColor : unevenPlaceBackgroundColor;
        }

        private Color DetermineColorBasedOnRank(int rank)
        {
            return rank == 1
                ? firstPlaceColor
                : (rank == 2 ? secondPlaceColor : (rank == 3 ? thirdPlaceColor : defaultColor));
        }
        
    }
}