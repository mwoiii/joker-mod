using System;
using JokerMod.Modules;

namespace JokerMod.Joker {
    public static class JokerTokens {
        public static void Init() {
            AddJokerTokens();

            ////uncomment this to spit out a lanuage file with all the above tokens that people can translate
            ////make sure you set Language.usingLanguageFolder and printingEnabled to true
            //Language.PrintOutput("Joker.txt");
            ////refer to guide on how to build and distribute your mod with the proper folders
        }

        public static void AddJokerTokens() {
            string prefix = JokerSurvivor.JOKER_PREFIX;

            string desc = "Joker is a highly adaptable survivor who uses the power of the Wild Card to overcome any obstacle.<color=#CCD3E0>" + Environment.NewLine + Environment.NewLine
             + "< ! > Slash Flurry's finishers excel in different situations. Learning the differences is key to mastery." + Environment.NewLine + Environment.NewLine
             + "< ! > Fire doubles as both mobility and a high-damage burst option. Make sure to manage your bullets according to the situation." + Environment.NewLine + Environment.NewLine
             + "< ! > Phantom Dash is a simple but powerful skill, allowing you dash even mid-combo." + Environment.NewLine + Environment.NewLine
             + "< ! > Joker's stock of different Personas are his most valuable asset. Carefully manage your SP and forge powerful Persona combinations " +
             "to ensure you're always ahead of the curve." + Environment.NewLine + Environment.NewLine;

            string outro = "..and so he left, onto a roadless path.";
            string outroFailure = "..and so he vanished, his rebellion quelled.";

            Language.Add(prefix + "NAME", "Joker");
            Language.Add(prefix + "DESCRIPTION", desc);
            Language.Add(prefix + "SUBTITLE", "Prisoner of Fate");
            Language.Add(prefix + "LORE", "...You are held captive." + Environment.NewLine + Environment.NewLine +
                "A prisoner of fate to a future that has been sealed in advance." + Environment.NewLine + Environment.NewLine +
                "This is truly an unjust game - your chances of winning are almost none." + Environment.NewLine + Environment.NewLine +
                "But if my voice is reaching you, there may yet be a possibility open to you." + Environment.NewLine + Environment.NewLine +
                "I beg you. Please overcome this game... and save the world." + Environment.NewLine + Environment.NewLine +
                "The key to victory lies within the memories of your bonds - the truth that you and your friends grasped." + Environment.NewLine + Environment.NewLine +
                "It all began that day, when the game was started half a year ago." + Environment.NewLine + Environment.NewLine +
                "For the sake of your world's future, as well as your own..." + Environment.NewLine + Environment.NewLine +
                "You must remember.");
            Language.Add(prefix + "OUTRO_FLAVOR", outro);
            Language.Add(prefix + "OUTRO_FAILURE", outroFailure);

            #region Skins
            Language.Add(prefix + "MASTERY_SKIN_NAME", "Crow");
            #endregion

            #region Passive
            Language.Add(prefix + "PASSIVE_NAME", "Joker passive");
            Language.Add(prefix + "PASSIVE_DESCRIPTION", "Sample text.");
            #endregion

            #region Primary
            Language.Add(prefix + "PRIMARY_SLASH_FLURRY_NAME", "Slash Flurry");
            Language.Add(prefix + "PRIMARY_SLASH_FLURRY_DESCRIPTION", $"Slash in a wide arc for <style=cIsDamage>{100f * JokerStaticValues.slashFlurryDamageCoefficient}% damage</style>. " +
                $"Further attacks in the combo deal <style=cIsDamage>increased damage</style>, and unique combo finishers can be performed by using the <style=cIsUtility>Equipment</style> button.");
            #endregion

            #region Secondary
            Language.Add(prefix + "SECONDARY_FIRE_NAME", "Fire!");
            Language.Add(prefix + "SECONDARY_FIRE_DESCRIPTION", $"{Tokens.agilePrefix} Fire a bullet for <style=cIsDamage>{100f * JokerStaticValues.fireDamageCoefficient}% damage</style>. " +
                $"<style=cIsUtility>A bullet is restocked on kill.</style> Continue holding the skill to fire an additional burst, using all remaining bullets. " +
                $"<style=cIsDamage>The damage is proportional to the number of bullets used.</style>");
            #endregion

            #region Utility
            Language.Add(prefix + "UTILITY_PHANTOM_DASH_NAME", "Phantom Dash");
            Language.Add(prefix + "UTILITY_PHANTOM_DASH_DESCRIPTION", $"Dash forward a short distance, <style=cIsUtility>gaining immunity for the duration</style>. " +
                $"Hold the skill to instead perform an <style=cIsDamage>All-Out Attack</style>, unleashing a flurry of " +
                $"<style=cIsDamage>{100f * JokerStaticValues.aoaDamageCoefficient}% damage slayer</style> attacks on all nearby enemies. " +
                $"<style=cIsUtility>Slain enemies have an increased chance of dropping a mask, and reduce the skill cooldown</style>.");
            #endregion

            #region Special
            Language.Add(prefix + "SPECIAL_PERSONA_NAME", "Persona!");
            Language.Add(prefix + "SPECIAL_PERSONA_DESCRIPTION", $"Call forth your Persona, and cast a skill in exchange for either " +
                $"<style=cIsHealth>HP</style> or <style=cIsUtility>SP</style>.");

            #endregion

            #region Achievements
            Language.Add(Tokens.GetAchievementNameToken(JokerMasteryAchievement.identifier), "Joker: Mastery");
            Language.Add(Tokens.GetAchievementDescriptionToken(JokerMasteryAchievement.identifier), "As Joker, beat the game or obliterate on Monsoon.");
            #endregion
        }
    }
}
