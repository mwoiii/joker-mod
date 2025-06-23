using RoR2;
using UnityEngine;
using UnityEngine.AddressableAssets;
using System.Collections.Generic;
using Path = System.IO.Path;
using RoR2.Projectile;
using R2API;
using JokerMod.Modules.DamageTypes;

namespace JokerMod.Modules {
    public static class Asset {
        public static AssetBundle mainAssetBundle;

        internal static string assetBundleName = "jokermod";

        public static List<GameObject> projectilePrefabs = new List<GameObject>();

        public static GameObject eihaPrefab;

        public static GameObject eigaPrefab;

        public static GameObject eigaonPrefab;

        public static ColorCatalog.ColorIndex maskColor;

        public static ColorCatalog.ColorIndex maskDarkColor;

        public static ItemTierDef maskTierDef;

        public static ItemDef maskItemDef;

        public static GameObject maskPrefab;

        public static DamageColorIndex shockColor;

        public static GameObject jokerUIPrefab;

        // temporary

        public static GameObject mercBodyPrefab;

        internal static string assemblyDir {
            get {
                return Path.GetDirectoryName(JokerPlugin.pluginInfo.Location);
            }
        }

        public static void PopulateAssets() {
            mainAssetBundle = AssetBundle.LoadFromFile(Path.Combine(assemblyDir, assetBundleName));

            eihaPrefab = Asset.mainAssetBundle.LoadAsset<GameObject>("EihaProjectile");
            projectilePrefabs.Add(eihaPrefab);

            eigaPrefab = Asset.mainAssetBundle.LoadAsset<GameObject>("EigaProjectile");
            projectilePrefabs.Add(eigaPrefab);

            eigaonPrefab = Asset.mainAssetBundle.LoadAsset<GameObject>("EigaonProjectile");
            projectilePrefabs.Add(eigaonPrefab);

            maskTierDef = mainAssetBundle.LoadAsset<ItemTierDef>("MaskTier");
            maskColor = R2API.ColorsAPI.RegisterColor(new Color(0.41f, 0.94f, 1f));
            maskDarkColor = R2API.ColorsAPI.RegisterColor(new Color(0.08f, 0.29f, 0.85f));
            maskTierDef.colorIndex = maskColor;
            maskTierDef.darkColorIndex = maskDarkColor;
            maskItemDef = mainAssetBundle.LoadAsset<ItemDef>("MaskItemDef");
            maskPrefab = mainAssetBundle.LoadAsset<GameObject>("mask");

            shockColor = R2API.ColorsAPI.RegisterDamageColor(new Color(0.96f, 0.91f, 0f));

            jokerUIPrefab = mainAssetBundle.LoadAsset<GameObject>("JokerUI");

            mercBodyPrefab = Addressables.LoadAssetAsync<GameObject>("RoR2/Base/Merc/MercBody.prefab").WaitForCompletion();
        }

        public static void AssignDamageTypes() {
            eihaPrefab.GetComponent<ProjectileDamage>().damageType.AddModdedDamageType(CurseLightType.damageType);
            eigaPrefab.GetComponent<ProjectileDamage>().damageType.AddModdedDamageType(CurseMediumType.damageType);
            eigaonPrefab.GetComponent<ProjectileDamage>().damageType.AddModdedDamageType(CurseHeavyType.damageType);
        }
    }
}