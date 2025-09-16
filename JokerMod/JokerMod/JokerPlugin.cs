using System.Security;
using System.Security.Permissions;
using BepInEx;
using BepInEx.Configuration;
using JokerMod.Joker;
using JokerMod.Joker.Components;
using JokerMod.Joker.SkillStates;
using JokerMod.Modules;
using R2API;
using R2API.Networking;
using R2API.Utils;
using RoR2;

[module: UnverifiableCode]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]

namespace JokerMod {

    [BepInDependency(R2API.ContentManagement.R2APIContentManager.PluginGUID)]

    [BepInDependency(LanguageAPI.PluginGUID)]

    [BepInDependency(NetworkingAPI.PluginGUID)]

    [BepInDependency("com.rune580.riskofoptions", BepInDependency.DependencyFlags.SoftDependency)]

    [NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.EveryoneNeedSameModVersion)]

    [BepInPlugin(MODUID, MODNAME, MODVERSION)]

    public class JokerPlugin : BaseUnityPlugin {

        public const string MODUID = "com.Miyowi.JokerMod";
        public const string MODNAME = "JokerMod";
        public const string MODVERSION = "1.0.0";

        public static PluginInfo pluginInfo;

        public static ConfigFile config;

        public const string DEVELOPER_PREFIX = "MIYOWI";

        public static JokerPlugin instance;

        public void Awake() {
            instance = this;

            pluginInfo = Info;

            config = Config;

            Log.Init(Logger);

            Options.Init();

            RegisterNetMessages();

            States.Register();

            // used when you want to properly set up language folders
            Modules.Language.Init();

            // character initialization
            new JokerSurvivor().Initialize();

            Asset.PopulateAssets();

            BuffCollection.Init();

            Items.Init();

            RoR2Application.onLoadFinished += OnLoadFinished;

            // make a content pack and add it. this has to be last
            new Modules.ContentPacks().Initialize();
        }

        private void OnLoadFinished() {
            DamageTypeCollection.Init();
            Hooks.AddHooks();
            Asset.AssignDamageTypes();
            Options.OnLoadFinished();
        }

        private void RegisterNetMessages() {
            NetworkingAPI.RegisterMessageType<SyncJokerSP>();
            NetworkingAPI.RegisterMessageType<SyncJokerReceivePersona>();
            NetworkingAPI.RegisterMessageType<SyncJokerDropPersona>();
            NetworkingAPI.RegisterMessageType<SyncJokerAOAHitEvent>();
            NetworkingAPI.RegisterMessageType<SyncJokerAssignPersona>();
            NetworkingAPI.RegisterMessageType<SyncJokerSlashFlurryVFX>();
            NetworkingAPI.RegisterMessageType<SyncJokerKnifeTrailState>();
        }
    }
}