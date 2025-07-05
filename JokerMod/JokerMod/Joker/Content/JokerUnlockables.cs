using RoR2;
using UnityEngine;

namespace JokerMod.Joker {
    public static class JokerUnlockables {
        public static UnlockableDef characterUnlockableDef = null;
        public static UnlockableDef masterySkinUnlockableDef = null;

        public static void Init() {
            masterySkinUnlockableDef = Modules.Content.CreateAndAddUnlockbleDef(
                JokerMasteryAchievement.unlockableIdentifier,
                Modules.Tokens.GetAchievementNameToken(JokerMasteryAchievement.identifier),
                JokerSurvivor.instance.assetBundle.LoadAsset<Sprite>("texMasteryAchievement"));
        }
    }
}
