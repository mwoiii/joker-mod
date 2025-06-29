using System;
using JokerMod.Joker.Components.SkillHelpers;
using JokerMod.Modules.Buffs;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using R2API;
using RoR2;
using UnityEngine;

namespace JokerMod.Modules.DamageTypes {
    public static class WindLightType {

        public static DamageAPI.ModdedDamageType damageType;

        public static void Init() {
            damageType = DamageAPI.ReserveDamageType();
            DamageTypeCollection.damageTypes.Add(damageType);
            Hooks.Handle_HealthComponentTakeDamageProcess_Actions += AddLightWindDamage;
            Hooks.IL_Handle_OverlapAttackFire_Actions += CorrectOverlapAttackYForce;
        }

        private static void AddLightWindDamage(HealthComponent self, DamageInfo damageInfo) {
            CharacterBody attackerBody = damageInfo?.attacker?.GetComponent<CharacterBody>();
            if (self?.body?.teamComponent?.teamIndex != null && attackerBody?.teamComponent?.teamIndex != null && damageInfo.HasModdedDamageType(damageType)) {
                bool sameTeam = self.body.teamComponent.teamIndex == attackerBody.teamComponent.teamIndex;
                bool isFriendlyFire = FriendlyFireManager.friendlyFireMode != FriendlyFireManager.FriendlyFireMode.Off;
                bool isNoTeam = attackerBody.teamComponent.teamIndex == TeamIndex.None;

                if (!sameTeam || isFriendlyFire || isNoTeam) {
                    self.body.AddTimedBuff(SweptDebuff.buffDef, 8f, 1);
                    damageInfo.damage += attackerBody.damage * 3f;
                    damageInfo.procCoefficient = 1f;
                }

                // always pushing up on joker to prevent jank
                if (self.body == attackerBody) {
                    if (attackerBody.characterMotor.velocity.y < 0f) {
                        attackerBody.characterMotor.velocity.y = 0f;
                    }
                }
            }
        }

        private static void CorrectOverlapAttackYForce(ILContext il) {
            GameObject attacker = null;

            var nabAttackerDelegate = delegate (OverlapAttack overlapAttack) {
                WindForceInfo windForceInfo = overlapAttack?.hitBoxGroup?.GetComponent<WindForceInfo>();
                if (windForceInfo != null) {
                    if (windForceInfo.shouldPushAllies) {
                        attacker = overlapAttack.attacker;
                        overlapAttack.attacker = null;
                    }
                }
            };

            var absAndAttackerDelegate = delegate (OverlapAttack overlapAttack) {
                WindForceInfo windForceInfo = overlapAttack?.hitBoxGroup?.GetComponent<WindForceInfo>();
                if (windForceInfo != null) {
                    if (windForceInfo.shouldPushAllies) {
                        overlapAttack.attacker = attacker;
                        overlapAttack.teamIndex = TeamIndex.None;
                    }
                    if (windForceInfo.shouldAbsY) {
                        for (int i = 0; i < overlapAttack.overlapList.Count; i++) {
                            OverlapAttack.OverlapInfo infoCopy = overlapAttack.overlapList[i];
                            infoCopy.pushDirection.y = Math.Abs(infoCopy.pushDirection.y);
                            overlapAttack.overlapList[i] = infoCopy;
                        }
                    }
                }
            };

            ILCursor c = new ILCursor(il);
            // HitBox[] hitBoxes = hitBoxGroup.hitBoxes;
            if (c.TryGotoNext(x => x.MatchLdarg(0)) &&
                c.TryGotoNext(x => x.MatchLdfld<OverlapAttack>("hitBoxGroup")) &&
                c.TryGotoNext(x => x.MatchLdfld<HitBoxGroup>("hitBoxes")) &&
                c.TryGotoNext(x => x.MatchStloc(0))) {
                c.Emit(OpCodes.Ldarg_0);
                c.EmitDelegate(nabAttackerDelegate);
                // idk but the bit just before ProcessHits(overlapList); but like the actual part because ilspy is wrong
                if (c.TryGotoNext(x => x.MatchLdloc(1)) &&
                    c.TryGotoNext(x => x.MatchLdloc(0)) &&
                    c.TryGotoNext(x => x.MatchLdlen()) &&
                    c.TryGotoNext(x => x.MatchConvI4()) &&
                    c.TryGotoNext(MoveType.After, x => x.MatchBlt(out var _))) {
                    c.Emit(OpCodes.Ldarg_0);
                    c.EmitDelegate(absAndAttackerDelegate);
                } else {
                    Log.Error("CorrectOverlapAttackYForce ILHook failed (2). Enemies will not boingy boof in the wind :(");
                }
            } else {
                Log.Error("CorrectOverlapAttackYForce ILHook failed (1). Enemies will not boingy boof in the wind :(");
            }
        }
    }
}