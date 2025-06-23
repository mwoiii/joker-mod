using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using RoR2.ContentManagement;

namespace JokerMod.Modules {
    internal class ContentPackProvider : IContentPackProvider {
        readonly ContentPack contentPack = new ContentPack();

        public string identifier => "com.Miyowi.JokerMod";

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
            // contentPack.masterPrefabs.Add(Prefabs.masterPrefabs.ToArray());
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
}
