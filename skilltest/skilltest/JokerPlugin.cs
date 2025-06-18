using System;
using BepInEx;
using EntityStates;
using R2API;
using RoR2;
using RoR2.Skills;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Networking;
using IL.RoR2.ContentManagement;
using JokerMod.Joker.SkillStates;
using JokerMod.Joker.Components;
using JokerMod.Joker.SkillStates.PersonaStates;
using JokerMod.Modules;
using JokerMod.Modules.DamageTypes;

namespace JokerMod
{
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

            InitDamageTypes();

            Skills.Init();

            Items.Init();

            Hooks.AddHooks();
        }

        private void InitStateMachine() {
            GameObject mercBodyPrefab = Addressables.LoadAssetAsync<GameObject>("RoR2/Base/Merc/MercBody.prefab").WaitForCompletion();

            EntityStateMachine chargeMachine = mercBodyPrefab.AddComponent<EntityStateMachine>();
            chargeMachine.customName = "Charge";
            chargeMachine.mainStateType = new SerializableEntityStateType(typeof(EntityStates.Idle));

            // temporary
            // but also like what isn't
            // this entire method is temporary
            mercBodyPrefab.AddComponent<AOAController>();
            mercBodyPrefab.AddComponent<JokerMaster>();
        }

        private void InitDamageTypes() {
            CurseLight.CreateDamageType();
        }
    }
}