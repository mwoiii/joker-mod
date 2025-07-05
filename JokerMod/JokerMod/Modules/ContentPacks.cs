using System;
using System.Collections.Generic;
using RoR2;
using RoR2.ContentManagement;
using RoR2.Skills;
using UnityEngine;

namespace JokerMod.Modules {
    /*
    internal class ContentPacks : IContentPackProvider {
        readonly ContentPack contentPack = new ContentPack();

        public string identifier => "com.Miyowi.JokerMod";

        public static List<GameObject> masterPrefabs = new List<GameObject>();

        // internal ContentPackProvider() {
        // }

        internal void Register() {
            ContentManager.collectContentPackProviders += addContentPackProvider => {
                addContentPackProvider(this);
            };
        }

        public IEnumerator LoadStaticContentAsync(LoadStaticContentAsyncArgs args) {

            contentPack.identifier = identifier;
            // contentPack.bodyPrefabs.Add(Prefabs.bodyPrefabs.ToArray());
            contentPack.buffDefs.Add(BuffCollection.buffDefs.ToArray());
            // contentPack.effectDefs.Add(effectDefs.ToArray());
            contentPack.entityStateTypes.Add(States.entityStates.ToArray());
            contentPack.itemDefs.Add(JokerCatalog.itemDefs.ToArray());
            contentPack.masterPrefabs.Add(Prefabs.masterPrefabs.ToArray());
            // contentPack.networkSoundEventDefs.Add(networkSoundEventDefs.ToArray());
            contentPack.projectilePrefabs.Add(Asset.projectilePrefabs.ToArray());
            contentPack.skillDefs.Add(Skills.skillDefs.ToArray());
            contentPack.itemTierDefs.Add(Items.itemTierDefs.ToArray());
            // contentPack.skillFamilies.Add(Skills.skillFamilies.ToArray());
            // contentPack.survivorDefs.Add(Prefabs.survivorDefinitions.ToArray());
            // contentPack.unlockableDefs.Add(unlockableDefs.ToArray());

            args.ReportProgress(1f);
            yield break;
        }

        public IEnumerator GenerateContentPackAsync(GetContentPackAsyncArgs args) {
            ContentPack.Copy(contentPack, args.output);
            args.ReportProgress(1f);
            yield break;
        }

        public IEnumerator FinalizeAsync(FinalizeAsyncArgs args) {
            args.ReportProgress(1f);
            yield break;
        }
    }
    */
    internal class ContentPacks : IContentPackProvider {
        internal ContentPack contentPack = new ContentPack();
        public string identifier => JokerPlugin.MODUID;

        public static List<GameObject> bodyPrefabs = new List<GameObject>();
        public static List<GameObject> masterPrefabs = new List<GameObject>();
        public static List<GameObject> projectilePrefabs = new List<GameObject>();

        public static List<SurvivorDef> survivorDefs = new List<SurvivorDef>();
        public static List<UnlockableDef> unlockableDefs = new List<UnlockableDef>();

        public static List<SkillFamily> skillFamilies = new List<SkillFamily>();
        public static List<SkillDef> skillDefs = new List<SkillDef>();
        public static List<Type> entityStates = new List<Type>();

        public static List<BuffDef> buffDefs = new List<BuffDef>();
        public static List<EffectDef> effectDefs = new List<EffectDef>();

        public static List<ItemDef> itemDefs = new List<ItemDef>();
        public static List<ItemTierDef> itemTierDefs = new List<ItemTierDef>();

        public static List<NetworkSoundEventDef> networkSoundEventDefs = new List<NetworkSoundEventDef>();

        public void Initialize() {
            ContentManager.collectContentPackProviders += ContentManager_collectContentPackProviders;
        }

        private void ContentManager_collectContentPackProviders(ContentManager.AddContentPackProviderDelegate addContentPackProvider) {
            addContentPackProvider(this);
        }

        public System.Collections.IEnumerator LoadStaticContentAsync(LoadStaticContentAsyncArgs args) {
            this.contentPack.identifier = this.identifier;

            contentPack.bodyPrefabs.Add(bodyPrefabs.ToArray());
            contentPack.masterPrefabs.Add(masterPrefabs.ToArray());
            contentPack.projectilePrefabs.Add(projectilePrefabs.ToArray());

            contentPack.survivorDefs.Add(survivorDefs.ToArray());
            contentPack.unlockableDefs.Add(unlockableDefs.ToArray());

            contentPack.skillDefs.Add(skillDefs.ToArray());
            contentPack.skillFamilies.Add(skillFamilies.ToArray());
            contentPack.entityStateTypes.Add(entityStates.ToArray());

            contentPack.buffDefs.Add(buffDefs.ToArray());
            contentPack.effectDefs.Add(effectDefs.ToArray());

            contentPack.itemDefs.Add(itemDefs.ToArray());
            contentPack.itemTierDefs.Add(itemTierDefs.ToArray());

            contentPack.networkSoundEventDefs.Add(networkSoundEventDefs.ToArray());

            args.ReportProgress(1f);
            yield break;
        }

        public System.Collections.IEnumerator GenerateContentPackAsync(GetContentPackAsyncArgs args) {
            ContentPack.Copy(this.contentPack, args.output);
            args.ReportProgress(1f);
            yield break;
        }

        public System.Collections.IEnumerator FinalizeAsync(FinalizeAsyncArgs args) {
            args.ReportProgress(1f);
            yield break;
        }
    }
}
