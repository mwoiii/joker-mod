using BepInEx.Configuration;
using RiskOfOptions;
using RiskOfOptions.OptionConfigs;
using RiskOfOptions.Options;

namespace JokerMod {

    public class Options {

        private static bool? _rooEnabled;

        public static bool rooEnabled {
            get {
                if (_rooEnabled == null) {
                    _rooEnabled = BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey("com.rune580.riskofoptions");
                }
                return (bool)_rooEnabled;
            }
        }

        public static ConfigEntry<float> jokerVoiceVolume { get; set; }
        public static ConfigEntry<bool> playCompressedCallouts { get; set; }

        private static void JokerVoiceVolumeSettingChanged() {
            AkSoundEngine.SetRTPCValue("JokerVoiceVolume", jokerVoiceVolume.Value * 50f);
        }

        private static void PlayCompressedCalloutsSettingChange() {
            AkSoundEngine.SetRTPCValue("JokerCrustyLines", Options.playCompressedCallouts.Value ? 1f : 0f);
        }

        public static void Init() {
            jokerVoiceVolume = JokerPlugin.config.Bind("Sound", "Joker Voice Volume", 1f, "How loud Joker's voice is relative to other sound effects.");
            jokerVoiceVolume.SettingChanged += (obj, args) => {
                JokerVoiceVolumeSettingChanged();
            };

            playCompressedCallouts = JokerPlugin.config.Bind("Sound", "Play Compressed Callouts", true, "Whether or not to play Persona callouts that originate from P5R (distinctly more compressed than the rest of the SFX, which are from P5S).");
            playCompressedCallouts.SettingChanged += (obj, args) => {
                PlayCompressedCalloutsSettingChange();
            };

            if (rooEnabled) {
                RoOInit();
            }
        }

        public static void OnLoadFinished() {
            JokerVoiceVolumeSettingChanged();
            PlayCompressedCalloutsSettingChange();
        }

        private static void RoOInit() {
            ModSettingsManager.AddOption(new StepSliderOption(jokerVoiceVolume, new StepSliderConfig() { min = 0, max = 2f, increment = 0.01f }));
            ModSettingsManager.AddOption(new CheckBoxOption(playCompressedCallouts, new CheckBoxConfig()));

            ModSettingsManager.SetModDescription("Config options relating to the Joker survivor mod.");
            // ModSettingsManager.SetModIcon(icon);
        }
    }
}