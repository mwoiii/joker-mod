using System.Collections.Generic;
using JokerMod.Modules.DamageTypes;
using R2API;
using RoR2;
using RoR2.Projectile;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Path = System.IO.Path;

namespace JokerMod.Modules {
    public static class Asset {
        public static AssetBundle mainAssetBundle;

        internal static string assetBundleName = "jokermod";

        public static List<GameObject> projectilePrefabs = new List<GameObject>();

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

        public static ColorCatalog.ColorIndex maskColor;

        public static ColorCatalog.ColorIndex maskDarkColor;

        public static ItemTierDef maskTierDef;

        public static ItemDef maskItemDef;

        public static GameObject maskPrefab;

        public static DamageColorIndex shockColor;

        public static DamageColorIndex sweptColor;

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

            garuPrefab = Asset.mainAssetBundle.LoadAsset<GameObject>("GaruProjectile");
            projectilePrefabs.Add(garuPrefab);

            garulaPrefab = Asset.mainAssetBundle.LoadAsset<GameObject>("GarulaProjectile");
            projectilePrefabs.Add(garuPrefab);

            garudynePrefab = Asset.mainAssetBundle.LoadAsset<GameObject>("GarudyneProjectile");
            projectilePrefabs.Add(garudynePrefab);

            agiPrefab = Asset.mainAssetBundle.LoadAsset<GameObject>("AgiProjectile");
            projectilePrefabs.Add(agiPrefab);

            agiSpitPrefab = Asset.mainAssetBundle.LoadAsset<GameObject>("AgiSpitProjectile");
            projectilePrefabs.Add(agiSpitPrefab);

            agilaoPrefab = Asset.mainAssetBundle.LoadAsset<GameObject>("AgilaoProjectile");
            projectilePrefabs.Add(agilaoPrefab);

            agidynePrefab = Asset.mainAssetBundle.LoadAsset<GameObject>("AgidyneProjectile");
            projectilePrefabs.Add(agidynePrefab);

            freiPrefab = Asset.mainAssetBundle.LoadAsset<GameObject>("FreiProjectile");
            projectilePrefabs.Add(freiPrefab);

            freiExplosionPrefab = Asset.mainAssetBundle.LoadAsset<GameObject>("FreiExplosionProjectile");
            projectilePrefabs.Add(freiExplosionPrefab);

            freilaPrefab = Asset.mainAssetBundle.LoadAsset<GameObject>("FreilaProjectile");
            projectilePrefabs.Add(freilaPrefab);

            freilaExplosionPrefab = Asset.mainAssetBundle.LoadAsset<GameObject>("FreilaExplosionProjectile");
            projectilePrefabs.Add(freilaExplosionPrefab);

            freidynePrefab = Asset.mainAssetBundle.LoadAsset<GameObject>("FreidyneProjectile");
            projectilePrefabs.Add(freidynePrefab);

            freidyneExplosionPrefab = Asset.mainAssetBundle.LoadAsset<GameObject>("FreidyneExplosionProjectile");
            projectilePrefabs.Add(freidyneExplosionPrefab);

            kouhaPrefab = Asset.mainAssetBundle.LoadAsset<GameObject>("KouhaProjectile");
            projectilePrefabs.Add(kouhaPrefab);

            kouhaExplosionPrefab = Asset.mainAssetBundle.LoadAsset<GameObject>("KouhaExplosionProjectile");
            projectilePrefabs.Add(kouhaExplosionPrefab);

            kougaPrefab = Asset.mainAssetBundle.LoadAsset<GameObject>("KougaProjectile");
            projectilePrefabs.Add(kougaPrefab);

            kougaExplosionPrefab = Asset.mainAssetBundle.LoadAsset<GameObject>("KougaExplosionProjectile");
            projectilePrefabs.Add(kougaExplosionPrefab);

            kougaonPrefab = Asset.mainAssetBundle.LoadAsset<GameObject>("KougaonProjectile");
            projectilePrefabs.Add(kougaonPrefab);

            kougaonExplosionPrefab = Asset.mainAssetBundle.LoadAsset<GameObject>("KougaonExplosionProjectile");
            projectilePrefabs.Add(kougaonExplosionPrefab);


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

            mercBodyPrefab = Addressables.LoadAssetAsync<GameObject>("RoR2/Base/Merc/MercBody.prefab").WaitForCompletion();
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
        }
    }
}