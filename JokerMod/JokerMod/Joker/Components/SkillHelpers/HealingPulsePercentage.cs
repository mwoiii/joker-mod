using RoR2;

namespace JokerMod.Joker.Components.SkillHelpers {
    public class HealingPulsePercentage : SphereSearchBase {

        public float healFlat;

        public float healFraction;

        public float overShield;

        public override void HandleHurtbox(HurtBox hurtBox) {
            HealthComponent healthComponent = hurtBox.healthComponent;
            HealTarget(healthComponent);
            if (overShield > 0f) {
                healthComponent.AddBarrierAuthority(overShield);
            }
        }

        private void HealTarget(HealthComponent target) {
            target.Heal(healFlat + healFraction * target.body.maxHealth, default);
            Util.PlaySound("Play_item_proc_TPhealingNova_hitPlayer", target.gameObject);
        }
    }
}
