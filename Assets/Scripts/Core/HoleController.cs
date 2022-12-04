using System;
using Controllers;
using General;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core
{
    public class HoleController : MonoBehaviour
    {
        [SerializeField] private NormalMoleController normalMole;
        [SerializeField] private BonusMoleController bonusMole;
        [SerializeField] private EvilMoleController evilMole;

        [SerializeField] private float spawnRateBonusMoleMedium;
        [SerializeField] private float spawnRateBonusMoleHard;
        [SerializeField] private float spawnRateEvilMoleMedium;
        [SerializeField] private float spawnRateEvilMoleHard;
        [SerializeField] private float showDurationBonusMoleMedium;
        [SerializeField] private float showDurationBonusMoleHard;

        private float currentShowDurationNormalMole = 2f;
        private float currentShowDurationEvilMole = 3f;
        private float currentShowDurationBonusMole = 0.1f;
        private float currentSpawnRateBonusMole = 0;
        private float currentSpawnRateEvilMole = 0;
        
        private NpcType currentNpc = NpcType.None;

        #region UNITY_METHODS

        private void Start()
        {
            setNpcVariablesBasedOnDifficulty();
        }

        #endregion

        public void Activate()
        {
            CreateNextNpc();
        }

        private void setNpcVariablesBasedOnDifficulty()
        {
            switch (GameController.Instance.CurrentDifficulty)
            {
                case Difficulty.Easy:
                    currentSpawnRateBonusMole = 0;
                    currentSpawnRateEvilMole = 0;
                    break;
                case Difficulty.Medium:
                    currentSpawnRateBonusMole = spawnRateBonusMoleMedium;
                    currentSpawnRateEvilMole = spawnRateEvilMoleMedium;
                    currentShowDurationBonusMole = showDurationBonusMoleMedium;
                    break;
                case Difficulty.Hard:
                    currentSpawnRateBonusMole = spawnRateBonusMoleHard;
                    currentSpawnRateEvilMole = spawnRateEvilMoleHard;
                    currentShowDurationBonusMole = showDurationBonusMoleHard;
                    break;
                default:
                    currentSpawnRateBonusMole = 0;
                    currentSpawnRateEvilMole = 0;
                    break;
            }
        }

        /// <summary>
        /// Detrmines which Npc to show based on spawn rates.
        /// </summary>
        private void CreateNextNpc()
        {
            // Making sure there is no Npc showing.
            if (currentNpc != NpcType.None)
            {
                string warningMsg = string.Format("There should still be an npc: {0}", currentNpc.ToString());
                Debug.LogWarning(warningMsg);
                return;
            }
            
            float random = Random.Range(0f, 1f);
            if (random < currentSpawnRateEvilMole)
            {
                currentNpc = NpcType.EvilMole;
                evilMole.gameObject.SetActive(true);
                evilMole.Spawn(currentShowDurationEvilMole);
            }
            else
            {
                random = Random.Range(0f, 1f);
                if (random < currentSpawnRateBonusMole)
                {
                    currentNpc = NpcType.BonusMole;
                    bonusMole.gameObject.SetActive(true);
                    bonusMole.Spawn(currentShowDurationBonusMole);
                }
                else
                {
                    currentNpc = NpcType.NormalMole;
                    normalMole.gameObject.SetActive(true);
                    normalMole.Spawn(currentShowDurationNormalMole);
                }
            }
        }
    }
}