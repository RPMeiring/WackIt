using System;
using System.Collections.Generic;
using System.Linq;
using Controllers;
using General;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core
{
    [Serializable]
    public struct MoleDefinition
    {
        public GameObject Mole;
        public NpcType Type;
    }
    
    public class HoleController : MonoBehaviour
    {
        private const float DURATION_SHOW_BONUS_MOLE_IN_SECONDS_MEDIUM = 1f;
        private const float DURATION_SHOW_BONUS_MOLE_IN_SECONDS_HARD = 0.3f;

        [SerializeField] private List<MoleDefinition> moleOptions;
        [SerializeField] private float spawnRateBonusMoleMedium;
        [SerializeField] private float spawnRateBonusMoleHard;
        [SerializeField] private float spawnRateEvilMoleMedium;
        [SerializeField] private float spawnRateEvilMoleHard;

        private float currentShowDurationNormalMole = 1f;
        private float currentShowDurationEvilMole = 2f;
        private float currentShowDurationBonusMole = 0.1f;
        private float currentSpawnRateBonusMole = 0;
        private float currentSpawnRateEvilMole = 0;
        private float currentMoleDuration = 0;

        private IMoleHandler currentNpc;

        private Action OnFinishAnimation;

        #region UNITY_METHODS

        private void OnEnable()
        {
            setNpcVariablesBasedOnDifficulty();
        }

        #endregion

        public void Activate()
        {
            OnFinishAnimation -= Deactivate;
            OnFinishAnimation += Deactivate;
            CreateNextNpc();
        }

        public void Deactivate()
        {
            DeSpawnCurrentNpc();
            currentNpc = null;
            LevelController.Instance.DeactivateSpawn(name);
        }

        private void DeSpawnCurrentNpc()
        {
            if (currentNpc != null)
                currentNpc.DeSpawn();
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
                    currentShowDurationBonusMole = DURATION_SHOW_BONUS_MOLE_IN_SECONDS_MEDIUM;
                    break;
                case Difficulty.Hard:
                    currentSpawnRateBonusMole = spawnRateBonusMoleHard;
                    currentSpawnRateEvilMole = spawnRateEvilMoleHard;
                    currentShowDurationBonusMole = DURATION_SHOW_BONUS_MOLE_IN_SECONDS_HARD;
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
            if (currentNpc != null)
            {
                string warningMsg = string.Format("There should still be an npc: {0}", currentNpc.ToString());
                Debug.LogWarning(warningMsg);
                return;
            }
            
            float random = Random.Range(0f, 1f);
            if (random < currentSpawnRateEvilMole)
            {
                currentNpc = moleOptions.Single(s => s.Type == NpcType.EvilMole).Mole.GetComponent<IMoleHandler>();
                currentMoleDuration = currentShowDurationEvilMole;
            }
            else
            {
                random = Random.Range(0f, 1f);
                if (random < currentSpawnRateBonusMole)
                {
                    currentNpc = moleOptions.Single(s => s.Type == NpcType.BonusMole).Mole.GetComponent<IMoleHandler>();
                    currentMoleDuration = currentShowDurationBonusMole;
                }
                else
                {
                    currentNpc = moleOptions.Single(s => s.Type == NpcType.NormalMole).Mole.GetComponent<IMoleHandler>();
                    currentMoleDuration = currentShowDurationNormalMole;
                }
            }
            
            currentNpc.Spawn(currentMoleDuration, OnFinishAnimation);
        }
    }
}