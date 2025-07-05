using JokerMod.Modules.Achievements;
using RoR2;

namespace JokerMod.Joker {
    //automatically creates language tokens "ACHIEVMENT_{identifier.ToUpper()}_NAME" and "ACHIEVMENT_{identifier.ToUpper()}_DESCRIPTION" 
    [RegisterAchievement(identifier, unlockableIdentifier, null, 10, null)]
    public class JokerMasteryAchievement : BaseMasteryAchievement {
        public const string identifier = JokerSurvivor.JOKER_PREFIX + "masteryAchievement";
        public const string unlockableIdentifier = JokerSurvivor.JOKER_PREFIX + "masteryUnlockable";

        public override string RequiredCharacterBody => JokerSurvivor.instance.bodyName;

        //difficulty coeff 3 is monsoon. 3.5 is typhoon for grandmastery skins
        public override float RequiredDifficultyCoefficient => 3;
    }
}