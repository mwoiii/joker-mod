using EntityStates;
using JokerMod.Joker.Components;
using UnityEngine;
using UnityEngine.Networking;

namespace JokerMod.Joker.SkillStates {


    public class CollapseDeathState : GenericCharacterDeath {

        public override bool shouldAutoDestroy {
            get {
                return false;
            }
        }

        public override void OnEnter() {
            base.OnEnter();
            Log.Info("Entering death state");
            if ((bool)base.characterMotor) {
                base.characterMotor.enabled = true;
            }

            if (isAuthority) {
                VoiceController.PlayRandomNetworkedSound(JokerAssets.deathSoundEvents, characterBody.gameObject);
            }
        }

        public override void PlayDeathAnimation(float crossfadeDuration = 0.1f) {
            PlayAnimation("FullBody, Override", "Death");
        }

        public override void FixedUpdate() {
            base.FixedUpdate();

            // sort of band-aid fix but idk why sometimes the animation just doesn't happen / gets overridden
            Animator animator = GetModelAnimator();
            if (animator != null) {
                AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(animator.GetLayerIndex("FullBody, Override"));
                bool isPlaying = stateInfo.IsName("Death");
                if (!isPlaying) {
                    PlayDeathAnimation();
                }
            }

            if (NetworkServer.active && base.fixedAge > 4f) {
                Destroy(base.gameObject);
            }
        }

        public override InterruptPriority GetMinimumInterruptPriority() {
            return InterruptPriority.Death;
        }
    }
}