using JokerMod.Modules;
using RoR2;
using UnityEngine;

namespace JokerMod.Joker {
    public static class JokerAssets {
        // Why does this exist
        // particle effects
        public static GameObject swordSwingEffect;

        public static GameObject swordHitImpactEffect;

        public static GameObject bombExplosionEffect;

        // networked hit sounds
        public static NetworkSoundEventDef[] castSkillAttackSoundEvents;

        public static NetworkSoundEventDef[] castSkillSupportSoundEvents;

        public static NetworkSoundEventDef[] summonPersonaSoundEvents;

        public static NetworkSoundEventDef[] primarySlashSoundEvents;

        public static NetworkSoundEventDef[] primarySwingSoundEvents;

        public static NetworkSoundEventDef[] primaryVoiceWeakSoundEvents;

        public static NetworkSoundEventDef[] primaryVoiceMediumChargeSoundEvents;

        public static NetworkSoundEventDef[] primaryVoiceMediumSoundEvents;

        public static NetworkSoundEventDef[] primaryVoiceStrongSoundEvents;

        public static NetworkSoundEventDef[] primaryVoiceStrongAltSoundEvents;

        public static NetworkSoundEventDef[] hurtSoundEvents;

        public static NetworkSoundEventDef[] deathSoundEvents;

        public static NetworkSoundEventDef fireSoundEvent;

        public static NetworkSoundEventDef unleashSoundEvent;

        public static NetworkSoundEventDef dashSoundEvent;

        public static NetworkSoundEventDef thrashStartSoundEvent;

        public static NetworkSoundEventDef thrashStopSoundEvent;

        public static NetworkSoundEventDef thrashFinisherSoundEvent;

        //projectiles
        public static GameObject bombProjectilePrefab;

        private static AssetBundle _assetBundle;


        public static void Init(AssetBundle assetBundle) {

            _assetBundle = assetBundle;

            CreateSounds();

            // swordSwingEffect = _assetBundle.LoadEffect("HenrySwordSwingEffect", true);
            // swordHitImpactEffect = _assetBundle.LoadEffect("ImpactHenrySlash");
        }

        private static void CreateSounds() {
            castSkillAttackSoundEvents = [
                Content.CreateAndAddNetworkSoundEventDef("Play_Joker_Voice_RavageThem"),
                Content.CreateAndAddNetworkSoundEventDef("Play_Joker_Voice_TakeThis"),
                Content.CreateAndAddNetworkSoundEventDef("Play_Joker_Voice_WithThis"),
                Content.CreateAndAddNetworkSoundEventDef("Play_Joker_Voice_YoureMine"),
            ];

            castSkillSupportSoundEvents = [
                // Content.CreateAndAddNetworkSoundEventDef("Play_Joker_Voice_IllUseThis"),
                Content.CreateAndAddNetworkSoundEventDef("Play_Joker_Voice_Okay"),
                Content.CreateAndAddNetworkSoundEventDef("Play_Joker_Voice_There"),
                Content.CreateAndAddNetworkSoundEventDef("Play_Joker_Voice_ThisOne"),
            ];

            summonPersonaSoundEvents = [
                Content.CreateAndAddNetworkSoundEventDef("Play_Joker_Voice_Come"),
                Content.CreateAndAddNetworkSoundEventDef("Play_Joker_Voice_LetsGo"),
                Content.CreateAndAddNetworkSoundEventDef("Play_Joker_Voice_Persona1"),
                Content.CreateAndAddNetworkSoundEventDef("Play_Joker_Voice_Persona2"),
                Content.CreateAndAddNetworkSoundEventDef("Play_Joker_Voice_ThisPower"),
            ];

            primarySlashSoundEvents = [
                Content.CreateAndAddNetworkSoundEventDef("Play_Slash1"),
                Content.CreateAndAddNetworkSoundEventDef("Play_Slash2"),
                Content.CreateAndAddNetworkSoundEventDef("Play_Slash3"),
            ];

            primarySwingSoundEvents = [
                Content.CreateAndAddNetworkSoundEventDef("Play_Swing_A"),
                Content.CreateAndAddNetworkSoundEventDef("Play_Swing_B"),
                Content.CreateAndAddNetworkSoundEventDef("Play_Swing_C"),
                Content.CreateAndAddNetworkSoundEventDef("Play_Swing_D"),
                Content.CreateAndAddNetworkSoundEventDef("Play_Swing_Strong_A"),
                Content.CreateAndAddNetworkSoundEventDef("Play_Swing_Strong_B"),
                Content.CreateAndAddNetworkSoundEventDef("Play_Swing_Strong_C"),
            ];

            primaryVoiceWeakSoundEvents = [
                Content.CreateAndAddNetworkSoundEventDef("Play_Joker_Voice_LightGrunt1"),
                Content.CreateAndAddNetworkSoundEventDef("Play_Joker_Voice_LightGrunt2"),
                Content.CreateAndAddNetworkSoundEventDef("Play_Joker_Voice_LightGrunt3"),
                Content.CreateAndAddNetworkSoundEventDef("Play_Joker_Voice_LightGrunt4"),
            ];

            primaryVoiceMediumChargeSoundEvents = [
                Content.CreateAndAddNetworkSoundEventDef("Play_Joker_Voice_MediumGrunt2"),
                Content.CreateAndAddNetworkSoundEventDef("Play_Joker_Voice_MediumGrunt3"),
            ];

            primaryVoiceMediumSoundEvents = [
                Content.CreateAndAddNetworkSoundEventDef("Play_Joker_Voice_MediumGrunt1"),
                Content.CreateAndAddNetworkSoundEventDef("Play_Joker_Voice_MediumGrunt4"),
            ];

            primaryVoiceStrongSoundEvents = [
                Content.CreateAndAddNetworkSoundEventDef("Play_Joker_Voice_HeavyGrunt1"),
                Content.CreateAndAddNetworkSoundEventDef("Play_Joker_Voice_HeavyGrunt2"),
                Content.CreateAndAddNetworkSoundEventDef("Play_Joker_Voice_HeavyGrunt3"),
            ];

            primaryVoiceStrongAltSoundEvents = [
                Content.CreateAndAddNetworkSoundEventDef("Play_Joker_Voice_GotYou"),
                Content.CreateAndAddNetworkSoundEventDef("Play_Joker_Voice_ItsOver"),
                Content.CreateAndAddNetworkSoundEventDef("Play_Joker_Voice_RightHere"),
                Content.CreateAndAddNetworkSoundEventDef("Play_Joker_Voice_ThisIsIt"),
            ];

            hurtSoundEvents = [
                Content.CreateAndAddNetworkSoundEventDef("Play_Joker_Voice_Hurt1"),
                Content.CreateAndAddNetworkSoundEventDef("Play_Joker_Voice_Hurt2"),
                Content.CreateAndAddNetworkSoundEventDef("Play_Joker_Voice_Hurt3"),
                Content.CreateAndAddNetworkSoundEventDef("Play_Joker_Voice_Hurt4"),
                Content.CreateAndAddNetworkSoundEventDef("Play_Joker_Voice_Hurt5"),
                Content.CreateAndAddNetworkSoundEventDef("Play_Joker_Voice_Hurt6"),
                Content.CreateAndAddNetworkSoundEventDef("Play_Joker_Voice_Hurt7"),
            ];

            deathSoundEvents = [
                Content.CreateAndAddNetworkSoundEventDef("Play_Joker_Voice_NotHere"),
                Content.CreateAndAddNetworkSoundEventDef("Play_Joker_Voice_NotLikeThis"),
                Content.CreateAndAddNetworkSoundEventDef("Play_Joker_Voice_Sorry"),
                Content.CreateAndAddNetworkSoundEventDef("Play_Joker_Voice_ThisIsBad"),
                Content.CreateAndAddNetworkSoundEventDef("Play_Joker_Voice_What"),
            ];

            fireSoundEvent = Content.CreateAndAddNetworkSoundEventDef("Play_Fire");

            unleashSoundEvent = Content.CreateAndAddNetworkSoundEventDef("Play_Unleash");

            dashSoundEvent = Content.CreateAndAddNetworkSoundEventDef("Play_RandomDash");

            thrashStartSoundEvent = Content.CreateAndAddNetworkSoundEventDef("Play_Thrashing");

            thrashStopSoundEvent = Content.CreateAndAddNetworkSoundEventDef("Stop_Thrashing");

            thrashFinisherSoundEvent = Content.CreateAndAddNetworkSoundEventDef("Play_ThrashingFinisher");
        }

        #region effects
        /*
        private static void CreateEffects() {
            CreateBombExplosionEffect();

            swordSwingEffect = _assetBundle.LoadEffect("HenrySwordSwingEffect", true);
            swordHitImpactEffect = _assetBundle.LoadEffect("ImpactHenrySlash");
        }

        private static void CreateBombExplosionEffect() {
            bombExplosionEffect = _assetBundle.LoadEffect("BombExplosionEffect", "HenryBombExplosion");

            if (!bombExplosionEffect)
                return;

            ShakeEmitter shakeEmitter = bombExplosionEffect.AddComponent<ShakeEmitter>();
            shakeEmitter.amplitudeTimeDecay = true;
            shakeEmitter.duration = 0.5f;
            shakeEmitter.radius = 200f;
            shakeEmitter.scaleShakeRadiusWithLocalScale = false;

            shakeEmitter.wave = new Wave {
                amplitude = 1f,
                frequency = 40f,
                cycleOffset = 0f
            };

        }
        */
        #endregion effects
    }
}
