using BepInEx;
using EntityStates;
using JokerMod.Joker.Components;
using JokerMod.Modules;
using JokerMod.Modules.Buffs;
using JokerMod.Modules.DamageTypes;
using R2API;
using RoR2;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace JokerMod {
    [BepInDependency(R2API.ContentManagement.R2APIContentManager.PluginGUID)]
    [BepInDependency(LanguageAPI.PluginGUID)]

    [BepInPlugin(
        "com.Miyowi.JokerMod",
        "JokerMod",
        "1.0.0")]
    public class JokerPlugin : BaseUnityPlugin {
        public static PluginInfo pluginInfo;

        public void Awake() {
            pluginInfo = Info;

            Log.Init(Logger);
            Asset.PopulateAssets();
            InitStateMachine();
            BuffCollection.Init();
            States.Register();
            Skills.Init();
            Items.Init();
            new ContentPackProvider().Register();
            RoR2Application.onLoadFinished += OnLoadFinished;
        }

        private void OnLoadFinished() {
            DamageTypeCollection.Init();
            Hooks.AddHooks();
            Asset.AssignDamageTypes();
        }

        private void InitStateMachine() {
            GameObject mercBodyPrefab = Addressables.LoadAssetAsync<GameObject>("RoR2/Base/Merc/MercBody.prefab").WaitForCompletion();

            EntityStateMachine chargeMachine = mercBodyPrefab.AddComponent<EntityStateMachine>();
            chargeMachine.customName = "Charge";
            chargeMachine.mainStateType = new SerializableEntityStateType(typeof(EntityStates.Idle));

            // temporary
            // but also like
            // this entire method is temporary
            mercBodyPrefab.AddComponent<AOAController>();
            mercBodyPrefab.AddComponent<JokerMaster>();
        }
    }
}