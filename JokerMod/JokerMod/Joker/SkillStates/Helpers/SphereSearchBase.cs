using System;
using System.Collections.Generic;
using System.Text;
using RoR2;
using UnityEngine;

namespace JokerMod.Joker.SkillStates.Helpers
{
    public abstract class SphereSearchBase
    {
        // please don't sue me

        //public static float duration;

        public Vector3 origin;

        public TeamIndex teamIndex = TeamIndex.None;

        public float radius;

        public GameObject effectPrefab;

        public TeamMask teamMask = default;

        internal float fxScale;

        // public float overShield;

        // private readonly List<HealthComponent> healedTargets = new List<HealthComponent>();

        private readonly SphereSearch sphereSearch;

        private readonly List<HurtBox> hurtBoxesList = new List<HurtBox>();

        public void Fire() {
            SphereSearch obj = new SphereSearch {
                mask = LayerIndex.entityPrecise.mask,
                origin = origin,
                queryTriggerInteraction = QueryTriggerInteraction.Collide,
                radius = radius
            };
            teamMask.AddTeam(teamIndex);
            obj.RefreshCandidates();
            obj.FilterCandidatesByDistinctHurtBoxEntities();
            obj.RefreshCandidates().FilterCandidatesByHurtBoxTeam(teamMask).FilterCandidatesByDistinctHurtBoxEntities()
                .GetHurtBoxes(hurtBoxesList);

            int i = 0;
            for (int count = hurtBoxesList.Count; i < count; i++) {
                HandleHurtbox(hurtBoxesList[i]);
            }

            if (effectPrefab != null) {
                EffectManager.SpawnEffect(effectPrefab, new EffectData {
                    origin = origin,
                    rotation = Quaternion.identity,
                    scale = fxScale
                }, transmit: true);
                hurtBoxesList.Clear();
            }
        }
        public abstract void HandleHurtbox(HurtBox hurtBox);
    }
}
