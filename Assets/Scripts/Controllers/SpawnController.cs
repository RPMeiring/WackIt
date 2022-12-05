using System;
using System.Collections.Generic;
using Core;
using General;
using UnityEngine;

namespace Controllers
{
    public class SpawnController : MonoBehaviour
    {
        private const int MAX_HOLES_ACTIVE_EASY = 2;
        private const int MAX_HOLES_ACTIVE_MEDIUM = 5;
        private const int MAX_HOLES_ACTIVE_HARD = 9;
        
        [SerializeField] private HoleController[] holePool;
        
        private int currentMaxHolesActive = 1;
        private Dictionary<string, HoleController> activeHoles = new Dictionary<string, HoleController>();

        #region UNITY_METHODS

        private void Update()
        {
            HandlesActivationOfHoles();
        }

        #endregion

        public void Initialize()
        {
            currentMaxHolesActive = GameController.Instance.CurrentDifficulty == Difficulty.Easy ? MAX_HOLES_ACTIVE_EASY : 
                (GameController.Instance.CurrentDifficulty == Difficulty.Medium ? MAX_HOLES_ACTIVE_MEDIUM : MAX_HOLES_ACTIVE_HARD);
        }

        /// <summary>
        /// Remove a specified Hole from the active list, so it can be selected on a later point again.
        /// </summary>
        /// <param name="currentHoleId"></param>
        public void RemoveHoleFromActiveList(string currentHoleId)
        {
            if (activeHoles.ContainsKey(currentHoleId))
                activeHoles.Remove(currentHoleId);
        }

        public void DeactivateAllHoles()
        {
            foreach (HoleController hole in holePool)
            {
                hole.Deactivate();
            }
        }

        /// <summary>
        /// Activate a random hole if the maximum is not reached yet.
        /// Each hole is a spawn point for an npc
        /// Each Hole (controller) chooses an npc to spawn.
        /// </summary>
        private void HandlesActivationOfHoles()
        {
            if (LevelController.Instance.IsRunning)
            {
                if (activeHoles.Count < currentMaxHolesActive)
                {
                    int index = UnityEngine.Random.Range(0, holePool.Length);
                    HoleController selectedHole = holePool[index];
                    if (!activeHoles.ContainsKey(selectedHole.name))
                    {
                        activeHoles.Add(selectedHole.name, selectedHole);
                        selectedHole.Activate();
                    }
                }
            }
        }
    }
}