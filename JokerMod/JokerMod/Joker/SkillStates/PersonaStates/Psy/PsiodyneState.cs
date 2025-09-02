using JokerMod.Joker.SkillStates.BaseStates;
using JokerMod.Modules.DamageTypes;
using JokerMod.Modules.PersonaSkills;
using R2API;
using RoR2;

namespace JokerMod.Joker.SkillStates.PersonaStates {
    public class PsiodyneState : PersonaSkillBaseState {

        public override SkillTypes.SkillType skillType => SkillTypes.SkillType.Psy;
        public override float baseSPCost { get; } = 12f;

        // private static GameObject seekerVFX = Addressables.LoadAssetAsync<GameObject>("RoR2/DLC2/Seeker/MeditateSuccessVFX.prefab").WaitForCompletion();

        protected override void ActivateSkill() {
            BlastAttack blastAttack = new BlastAttack();
            blastAttack.attacker = gameObject;
            blastAttack.baseDamage = characterBody.damage * 8f;
            blastAttack.attackerFiltering = AttackerFiltering.NeverHitSelf;
            blastAttack.crit = characterBody.RollCrit();
            blastAttack.damageColorIndex = DamageColorIndex.Item;
            blastAttack.damageType = DamageType.Generic;
            blastAttack.falloffModel = BlastAttack.FalloffModel.None;
            blastAttack.inflictor = gameObject;
            blastAttack.position = characterBody.corePosition;
            blastAttack.procChainMask = default(ProcChainMask);
            blastAttack.procCoefficient = 1f;
            blastAttack.radius = 30f;
            blastAttack.losType = BlastAttack.LoSType.NearestHit;
            blastAttack.teamIndex = characterBody.teamComponent.teamIndex;
            blastAttack.AddModdedDamageType(PsyHeavyType.damageType);
            blastAttack.Fire();
        }
    }
}