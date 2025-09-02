using System.Collections.Generic;
using JokerMod.Modules.DamageTypes;
using R2API;
using RoR2;
using RoR2.Projectile;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Networking;
using Path = System.IO.Path;

namespace JokerMod.Modules {
    public static class Asset {

        //cache bundles if multiple characters use the same one
        internal static Dictionary<string, AssetBundle> loadedBundles = new Dictionary<string, AssetBundle>();

        public static AssetBundle mainAssetBundle;

        internal static string assetBundleName = "jokermod";

        public static List<GameObject> projectilePrefabs = new List<GameObject>();

        public static GameObject slashLightPrefab;

        public static GameObject slashHeavyPrefab;

        public static GameObject eihaPrefab;

        public static GameObject eigaPrefab;

        public static GameObject eigaonPrefab;

        public static GameObject garuPrefab;

        public static GameObject garulaPrefab;

        public static GameObject garudynePrefab;

        public static GameObject agiPrefab;

        public static GameObject agiSpitPrefab;

        public static GameObject agilaoPrefab;

        public static GameObject agidynePrefab;

        public static GameObject freiPrefab;

        public static GameObject freiExplosionPrefab;

        public static GameObject freilaPrefab;

        public static GameObject freilaExplosionPrefab;

        public static GameObject freidynePrefab;

        public static GameObject freidyneExplosionPrefab;

        public static GameObject kouhaPrefab;

        public static GameObject kouhaExplosionPrefab;

        public static GameObject kougaPrefab;

        public static GameObject kougaExplosionPrefab;

        public static GameObject kougaonPrefab;

        public static GameObject kougaonExplosionPrefab;

        public static GameObject bufuPrefab;

        public static GameObject bufulaPrefab;

        public static GameObject bufudynePrefab;

        public static ColorCatalog.ColorIndex maskColor;

        public static ColorCatalog.ColorIndex maskDarkColor;

        public static ItemTierDef maskTierDef;

        public static ItemDef maskItemDef;

        public static GameObject maskPrefab;

        public static DamageColorIndex shockColor;

        public static DamageColorIndex sweptColor;

        public static GameObject jokerUIPrefab;

        public static Sprite nukeDebuffIcon;

        public static Sprite elecDebuffIcon;

        public static Sprite windDebuffIcon;

        public static Sprite blessDebuffIcon;

        internal static string assemblyDir {
            get {
                return Path.GetDirectoryName(JokerPlugin.pluginInfo.Location);
            }
        }

        public static void PopulateAssets() {
            slashLightPrefab = Asset.LoadEffect(mainAssetBundle, "JokerKnifeSlashLight");

            slashHeavyPrefab = Asset.LoadEffect(mainAssetBundle, "JokerKnifeSlashHeavy");

            eihaPrefab = Asset.LoadAndAddProjectilePrefab(mainAssetBundle, "EihaProjectile");

            eigaPrefab = Asset.LoadAndAddProjectilePrefab(mainAssetBundle, "EigaProjectile");

            eigaonPrefab = Asset.LoadAndAddProjectilePrefab(mainAssetBundle, "EigaonProjectile");

            garuPrefab = Asset.LoadAndAddProjectilePrefab(mainAssetBundle, "GaruProjectile");

            garulaPrefab = Asset.LoadAndAddProjectilePrefab(mainAssetBundle, "GarulaProjectile");

            garudynePrefab = Asset.LoadAndAddProjectilePrefab(mainAssetBundle, "GarudyneProjectile");

            agiPrefab = Asset.LoadAndAddProjectilePrefab(mainAssetBundle, "AgiProjectile");

            agiSpitPrefab = Asset.LoadAndAddProjectilePrefab(mainAssetBundle, "AgiSpitProjectile");

            agilaoPrefab = Asset.LoadAndAddProjectilePrefab(mainAssetBundle, "AgilaoProjectile");

            agidynePrefab = Asset.LoadAndAddProjectilePrefab(mainAssetBundle, "AgidyneProjectile");

            freiPrefab = Asset.LoadAndAddProjectilePrefab(mainAssetBundle, "FreiProjectile");

            freiExplosionPrefab = Asset.LoadAndAddProjectilePrefab(mainAssetBundle, "FreiExplosionProjectile");

            freilaPrefab = Asset.LoadAndAddProjectilePrefab(mainAssetBundle, "FreilaProjectile");

            freilaExplosionPrefab = Asset.LoadAndAddProjectilePrefab(mainAssetBundle, "FreilaExplosionProjectile");

            freidynePrefab = Asset.LoadAndAddProjectilePrefab(mainAssetBundle, "FreidyneProjectile");

            freidyneExplosionPrefab = Asset.LoadAndAddProjectilePrefab(mainAssetBundle, "FreidyneExplosionProjectile");

            kouhaPrefab = Asset.LoadAndAddProjectilePrefab(mainAssetBundle, "KouhaProjectile");

            kouhaExplosionPrefab = Asset.LoadAndAddProjectilePrefab(mainAssetBundle, "KouhaExplosionProjectile");

            kougaPrefab = Asset.LoadAndAddProjectilePrefab(mainAssetBundle, "KougaProjectile");

            kougaExplosionPrefab = Asset.LoadAndAddProjectilePrefab(mainAssetBundle, "KougaExplosionProjectile");

            kougaonPrefab = Asset.LoadAndAddProjectilePrefab(mainAssetBundle, "KougaonProjectile");

            kougaonExplosionPrefab = Asset.LoadAndAddProjectilePrefab(mainAssetBundle, "KougaonExplosionProjectile");

            bufuPrefab = Asset.LoadAndAddProjectilePrefab(mainAssetBundle, "BufuProjectile");

            bufulaPrefab = Asset.LoadAndAddProjectilePrefab(mainAssetBundle, "BufulaProjectile");

            bufudynePrefab = Asset.LoadAndAddProjectilePrefab(mainAssetBundle, "BufudyneProjectile");

            maskTierDef = mainAssetBundle.LoadAsset<ItemTierDef>("MaskTier");
            maskColor = R2API.ColorsAPI.RegisterColor(new Color(0.41f, 0.94f, 1f));
            maskDarkColor = R2API.ColorsAPI.RegisterColor(new Color(0.08f, 0.29f, 0.85f));
            maskTierDef.colorIndex = maskColor;
            maskTierDef.darkColorIndex = maskDarkColor;
            maskItemDef = mainAssetBundle.LoadAsset<ItemDef>("MaskItemDef");
            maskPrefab = mainAssetBundle.LoadAsset<GameObject>("mask");

            shockColor = R2API.ColorsAPI.RegisterDamageColor(new Color(0.96f, 0.91f, 0f));
            sweptColor = R2API.ColorsAPI.RegisterDamageColor(new Color(0.45f, 0.98f, 0.48f));

            jokerUIPrefab = mainAssetBundle.LoadAsset<GameObject>("JokerUI");

            nukeDebuffIcon = mainAssetBundle.LoadAsset<Sprite>("nukeDebuff.png");
            elecDebuffIcon = mainAssetBundle.LoadAsset<Sprite>("elecDebuff.png");
            windDebuffIcon = mainAssetBundle.LoadAsset<Sprite>("windDebuff.png");
            blessDebuffIcon = mainAssetBundle.LoadAsset<Sprite>("blessDebuff.png");
        }

        public static void AssignDamageTypes() {
            eihaPrefab.GetComponent<ProjectileDamage>().damageType.AddModdedDamageType(CurseLightType.damageType);
            eigaPrefab.GetComponent<ProjectileDamage>().damageType.AddModdedDamageType(CurseMediumType.damageType);
            eigaonPrefab.GetComponent<ProjectileDamage>().damageType.AddModdedDamageType(CurseHeavyType.damageType);

            garuPrefab.GetComponent<ProjectileDamage>().damageType.AddModdedDamageType(WindLightType.damageType);
            garuPrefab.GetComponent<ProjectileDamage>().damageType.AddModdedDamageType(IgnoreMassType.damageType);
            garulaPrefab.GetComponent<ProjectileDamage>().damageType.AddModdedDamageType(IgnoreMassType.damageType);
            garudynePrefab.GetComponent<ProjectileDamage>().damageType.AddModdedDamageType(IgnoreMassType.damageType);

            agiSpitPrefab.GetComponent<ProjectileImpactExplosion>().childrenProjectilePrefab = Addressables.LoadAssetAsync<GameObject>("RoR2/DLC1/Molotov/MolotovProjectileDotZone.prefab").WaitForCompletion();

            freiPrefab.GetComponent<ProjectileDamage>().damageType.AddModdedDamageType(NukeLightWeakType.damageType);
            freiExplosionPrefab.GetComponent<ProjectileDamage>().damageType.AddModdedDamageType(NukeLightType.damageType);
            freilaPrefab.GetComponent<ProjectileDamage>().damageType.AddModdedDamageType(NukeLightWeakType.damageType);
            freilaExplosionPrefab.GetComponent<ProjectileDamage>().damageType.AddModdedDamageType(NukeMediumType.damageType);
            freidynePrefab.GetComponent<ProjectileDamage>().damageType.AddModdedDamageType(NukeHeavyWeakType.damageType);
            freidyneExplosionPrefab.GetComponent<ProjectileDamage>().damageType.AddModdedDamageType(NukeHeavyType.damageType);

            kouhaPrefab.GetComponent<ProjectileDamage>().damageType.AddModdedDamageType(BlessLightWeakType.damageType);
            kouhaExplosionPrefab.GetComponent<ProjectileDamage>().damageType.AddModdedDamageType(BlessLightType.damageType);
            kougaPrefab.GetComponent<ProjectileDamage>().damageType.AddModdedDamageType(BlessMediumWeakType.damageType);
            kougaExplosionPrefab.GetComponent<ProjectileDamage>().damageType.AddModdedDamageType(BlessMediumType.damageType);
            kougaonPrefab.GetComponent<ProjectileDamage>().damageType.AddModdedDamageType(BlessHeavyWeakType.damageType);
            kougaonExplosionPrefab.GetComponent<ProjectileDamage>().damageType.AddModdedDamageType(BlessHeavyType.damageType);

            bufuPrefab.GetComponent<ProjectileDamage>().damageType.AddModdedDamageType(IceLightType.damageType);
            bufulaPrefab.GetComponent<ProjectileDamage>().damageType.AddModdedDamageType(IceMediumType.damageType);
            bufudynePrefab.GetComponent<ProjectileDamage>().damageType.AddModdedDamageType(IceMediumType.damageType);
        }

        internal static AssetBundle LoadAssetBundle(string bundleName) {

            if (bundleName == "myassetbundle") {
                Log.Error($"AssetBundle name hasn't been changed. not loading any assets to avoid conflicts.\nMake sure to rename your assetbundle filename and rename the AssetBundleName field in your character setup code ");
                return null;
            }

            if (loadedBundles.ContainsKey(bundleName)) {
                return loadedBundles[bundleName];
            }

            AssetBundle assetBundle = null;
            try {
                assetBundle = AssetBundle.LoadFromFile(Path.Combine(Path.GetDirectoryName(JokerPlugin.instance.Info.Location), "AssetBundles", bundleName));
            } catch (System.Exception e) {
                Log.Error($"Error loading asset bundle, {bundleName}. Your asset bundle must be in a folder next to your mod dll called 'AssetBundles'. Follow the guide to build and install your mod correctly!\n{e}");
            }

            loadedBundles[bundleName] = assetBundle;

            mainAssetBundle = assetBundle;

            return assetBundle;

        }

        internal static GameObject CloneTracer(string originalTracerName, string newTracerName) {
            if (RoR2.LegacyResourcesAPI.Load<GameObject>("Prefabs/Effects/Tracers/" + originalTracerName) == null)
                return null;

            GameObject newTracer = PrefabAPI.InstantiateClone(RoR2.LegacyResourcesAPI.Load<GameObject>("Prefabs/Effects/Tracers/" + originalTracerName), newTracerName, true);

            if (!newTracer.GetComponent<EffectComponent>()) newTracer.AddComponent<EffectComponent>();
            if (!newTracer.GetComponent<VFXAttributes>()) newTracer.AddComponent<VFXAttributes>();
            if (!newTracer.GetComponent<NetworkIdentity>()) newTracer.AddComponent<NetworkIdentity>();

            newTracer.GetComponent<Tracer>().speed = 250f;
            newTracer.GetComponent<Tracer>().length = 50f;

            Modules.Content.CreateAndAddEffectDef(newTracer);

            return newTracer;
        }

        internal static void ConvertAllRenderersToHopooShader(GameObject objectToConvert) {
            if (!objectToConvert) return;

            foreach (MeshRenderer i in objectToConvert.GetComponentsInChildren<MeshRenderer>()) {
                if (i) {
                    if (i.sharedMaterial) {
                        i.sharedMaterial.ConvertDefaultShaderToHopoo();
                    }
                }
            }

            foreach (SkinnedMeshRenderer i in objectToConvert.GetComponentsInChildren<SkinnedMeshRenderer>()) {
                if (i) {
                    if (i.sharedMaterial) {
                        i.sharedMaterial.ConvertDefaultShaderToHopoo();
                    }
                }
            }
        }

        internal static GameObject LoadCrosshair(string crosshairName) {
            GameObject loadedCrosshair = RoR2.LegacyResourcesAPI.Load<GameObject>("Prefabs/Crosshair/" + crosshairName + "Crosshair");
            if (loadedCrosshair == null) {
                Log.Error($"could not load crosshair with the name {crosshairName}. defaulting to Standard");

                return RoR2.LegacyResourcesAPI.Load<GameObject>("Prefabs/Crosshair/StandardCrosshair");
            }

            return loadedCrosshair;
        }

        internal static GameObject LoadEffect(this AssetBundle assetBundle, string resourceName, bool parentToTransform) => LoadEffect(assetBundle, resourceName, "", parentToTransform);
        internal static GameObject LoadEffect(this AssetBundle assetBundle, string resourceName, string soundName = "", bool parentToTransform = false) {
            GameObject newEffect = assetBundle.LoadAsset<GameObject>(resourceName);

            if (!newEffect) {
                Log.ErrorAssetBundle(resourceName, assetBundle.name);
                return null;
            }

            newEffect.AddComponent<DestroyOnTimer>().duration = 12;
            newEffect.AddComponent<NetworkIdentity>();
            newEffect.AddComponent<VFXAttributes>().vfxPriority = VFXAttributes.VFXPriority.Always;
            EffectComponent effect = newEffect.AddComponent<EffectComponent>();
            effect.applyScale = false;
            effect.effectIndex = EffectIndex.Invalid;
            effect.parentToReferencedTransform = parentToTransform;
            effect.positionAtReferencedTransform = true;
            effect.soundName = soundName;

            Modules.Content.CreateAndAddEffectDef(newEffect);

            return newEffect;
        }

        internal static GameObject CreateProjectileGhostPrefab(this AssetBundle assetBundle, string ghostName) {
            GameObject ghostPrefab = assetBundle.LoadAsset<GameObject>(ghostName);
            if (ghostPrefab == null) {
                Log.Error($"Failed to load ghost prefab {ghostName}");
            }
            if (!ghostPrefab.GetComponent<NetworkIdentity>()) ghostPrefab.AddComponent<NetworkIdentity>();
            if (!ghostPrefab.GetComponent<ProjectileGhostController>()) ghostPrefab.AddComponent<ProjectileGhostController>();

            Modules.Asset.ConvertAllRenderersToHopooShader(ghostPrefab);

            return ghostPrefab;
        }

        internal static GameObject CloneProjectilePrefab(string prefabName, string newPrefabName) {
            GameObject newPrefab = PrefabAPI.InstantiateClone(RoR2.LegacyResourcesAPI.Load<GameObject>("Prefabs/Projectiles/" + prefabName), newPrefabName);
            return newPrefab;
        }

        internal static GameObject LoadAndAddProjectilePrefab(this AssetBundle assetBundle, string newPrefabName) {
            GameObject newPrefab = assetBundle.LoadAsset<GameObject>(newPrefabName);
            if (newPrefab == null) {
                Log.ErrorAssetBundle(newPrefabName, assetBundle.name);
                return null;
            }

            Content.AddProjectilePrefab(newPrefab);
            return newPrefab;
        }
    }
}