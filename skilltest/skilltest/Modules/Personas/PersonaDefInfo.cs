using System;
using System.Collections.Generic;
using System.Text;
using JokerMod.Joker.SkillStates.BaseStates;
using JokerMod.Joker.SkillStates;
using UnityEngine;
using RoR2;
using RoR2.Skills;

namespace JokerMod.Modules.Personas {
    public struct PersonaDefInfo {

        public SkillDef skillDef;

        public ItemDef itemDef;

        public float spCost;

        public GameObject modelPrefab;
    }
}
