using System;
using System.Collections.Generic;
using System.Text;
using RoR2;
using UnityEngine;

namespace JokerMod.Modules {
    public class HealingPulsePercentage {
        // please don't sue me

        public static float duration;

        public float healFlat;

        public float healFraction;

        public Vector3 origin;

        public TeamIndex teamIndex;

        public float radius;

        public GameObject effectPrefab;

        public float overShield;

        private readonly List<HealthComponent> healedTargets = new List<HealthComponent>();

        private readonly SphereSearch sphereSearch;

        private TeamMask teamMask;

        internal float fxScale;

        private readonly List<HurtBox> hurtBoxesList = new List<HurtBox>();

        public void Fire() {
            SphereSearch obj = new SphereSearch {
                mask = LayerIndex.entityPrecise.mask,
                origin = origin,
                queryTriggerInteraction = QueryTriggerInteraction.Collide,
                radius = radius
            };
            teamMask = default(TeamMask);
            teamMask.AddTeam(teamIndex);
            obj.RefreshCandidates();
            obj.FilterCandidatesByDistinctHurtBoxEntities();
            obj.RefreshCandidates().FilterCandidatesByHurtBoxTeam(teamMask).FilterCandidatesByDistinctHurtBoxEntities()
                .GetHurtBoxes(hurtBoxesList);
            int i = 0;
            for (int count = hurtBoxesList.Count; i < count; i++) {
                HealthComponent healthComponent = hurtBoxesList[i].healthComponent;
                if (!healedTargets.Contains(healthComponent)) {
                    healedTargets.Add(healthComponent);
                    HealTarget(healthComponent);
                    if (overShield > 0f) {
                        healthComponent.AddBarrierAuthority(overShield);
                    }
                }
            }
            EffectManager.SpawnEffect(effectPrefab, new EffectData {
                origin = origin,
                rotation = Quaternion.identity,
                scale = fxScale
            }, transmit: true);
            hurtBoxesList.Clear();
        }

        private void HealTarget(HealthComponent target) {
            target.Heal(healFlat + healFraction * target.body.maxHealth, default(ProcChainMask));
            Util.PlaySound("Play_item_proc_TPhealingNova_hitPlayer", target.gameObject);
        }
    }
}
