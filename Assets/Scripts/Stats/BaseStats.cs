﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Stats
{
    public class BaseStats : MonoBehaviour
    {
        [Range(1,99)]
        [SerializeField] int startingLevel = 1;
        [SerializeField] CharacterClass characterClass;
        [SerializeField] Progression progession = null;

        public float GetStat(Stat stat)
        {
            return progession.GetStat(stat, characterClass, startingLevel);
        }

        public float GetExperienceReward()
        {
            return 10;
        }
    }
}
