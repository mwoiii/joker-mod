using RoR2;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Path = System.IO.Path;

namespace JokerMod.Modules {
    public static class Asset {
        public static AssetBundle mainAssetBundle;

        internal static string assetBundleName = "jokermod";

        public static ColorCatalog.ColorIndex maskColor;

        public static ColorCatalog.ColorIndex maskDarkColor;

        public static ItemTierDef maskTierDef;

        public static ItemDef maskItemDef;

        public static GameObject maskPrefab;

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

            maskTierDef = mainAssetBundle.LoadAsset<ItemTierDef>("MaskTier");
            maskColor = R2API.ColorsAPI.RegisterColor(new Color(0.41f, 0.94f, 1f));
            maskDarkColor = R2API.ColorsAPI.RegisterColor(new Color(0.08f, 0.29f, 0.85f));
            maskTierDef.colorIndex = maskColor;
            maskTierDef.darkColorIndex = maskDarkColor;
            maskItemDef = mainAssetBundle.LoadAsset<ItemDef>("MaskItemDef");
            maskPrefab = mainAssetBundle.LoadAsset<GameObject>("mask.prefab");

            jokerUIPrefab = mainAssetBundle.LoadAsset<GameObject>("JokerUI");

            mercBodyPrefab = Addressables.LoadAssetAsync<GameObject>("RoR2/Base/Merc/MercBody.prefab").WaitForCompletion();
        }
    }
}