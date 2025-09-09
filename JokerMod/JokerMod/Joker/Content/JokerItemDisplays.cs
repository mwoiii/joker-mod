using System.Collections.Generic;
using JokerMod.Modules;
using JokerMod.Modules.Characters;
using RoR2;
using UnityEngine;

/* for custom copy format in keb's helper
{childName},
                    {localPos}, 
                    {localAngles},
                    {localScale})
*/

namespace JokerMod.Joker {
    public class JokerItemDisplays : ItemDisplaysBase {
        protected override void SetItemDisplayRules(List<ItemDisplayRuleSet.KeyAssetRuleGroup> itemDisplayRules) {
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["AlienHead"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayAlienHead"),
                    "JacketFront4R",
                    new Vector3(-25.4542F, 5.10469F, 1.96151F),
                    new Vector3(346.7806F, 83.42068F, 183.7236F),
                    new Vector3(41.00205F, 41.00205F, 47.96243F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["ArmorPlate"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayRepulsionArmorPlate"),
                    "UpperArmR",
                    new Vector3(4.26743F, 0.82019F, 3.10405F),
                    new Vector3(5.34107F, 84.09327F, 271.9788F),
                    new Vector3(19.9852F, 19.9852F, 19.9852F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["ArmorReductionOnHit"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayWarhammer"),
                    "Chest",
                    new Vector3(-13.88239F, -18.03486F, 13.27708F),
                    new Vector3(12.55783F, 314.9551F, 0F),
                    new Vector3(14.47166F, 14.47166F, 14.47166F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["AttackSpeedAndMoveSpeed"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayCoffee"),
                    "Pelvis",
                    new Vector3(-4.4187F, 3.89083F, -14.60175F),
                    new Vector3(329.6839F, 201.3691F, 263.679F),
                    new Vector3(9.83212F, 9.83212F, 9.83212F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["AttackSpeedOnCrit"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayWolfPelt"),
                    "Head",
                    new Vector3(-1.42979F, -14.21856F, 0.05849F),
                    new Vector3(12.15205F, 259.7502F, 177.8397F),
                    new Vector3(40.71693F, 40.71693F, 36.05705F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["AutoCastEquipment"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayFossil"),
                    "Chest",
                    new Vector3(-9.38865F, 6.21071F, -2.97228F),
                    new Vector3(22.42488F, 243.673F, 267.0782F),
                    new Vector3(8.36492F, 8.36492F, 8.36492F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Bandolier"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBandolier"),
                    "Chest",
                    new Vector3(-2.21635F, -1.33357F, -0.60476F),
                    new Vector3(4.71713F, 44.98993F, 16.05955F),
                    new Vector3(45.00174F, 44.71182F, 43.07047F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["BarrierOnKill"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBrooch"),
                    "Chest",
                    new Vector3(-11.56249F, 6.33286F, 8.12069F),
                    new Vector3(333.8172F, 95.87048F, 2.07508F),
                    new Vector3(15.55442F, 15.28702F, 15.55442F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["BarrierOnOverHeal"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayAegis"),
                    "LowerArmL",
                    new Vector3(-21.71257F, 7.16968F, -1.35923F),
                    new Vector3(278.1623F, 334.9964F, 215.2458F),
                    new Vector3(20.081F, 20.081F, 20.081F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Bear"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBear"),
                    "Head",
                    new Vector3(-9.57901F, -13.19022F, 3.82093F),
                    new Vector3(359.4054F, 287.8871F, 183.822F),
                    new Vector3(2.57268F, 2.57268F, 2.6331F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["BearVoid"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBearVoid"),
                    "Head",
                    new Vector3(-9.57901F, -13.19022F, 3.82093F),
                    new Vector3(359.4054F, 287.8871F, 183.822F),
                    new Vector3(2.57268F, 2.57268F, 2.6331F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["BeetleGland"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBeetleGland"),
                    "ThighL",
                    new Vector3(5.05281F, -0.56624F, 6.57753F),
                    new Vector3(328.1316F, 183.7782F, 76.97101F),
                    new Vector3(3.61044F, 3.61044F, 3.61044F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Behemoth"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBehemoth"),
                    "Chest",
                    new Vector3(-20.8299F, -1.19914F, 15.07242F),
                    new Vector3(4.04142F, 278.8712F, 352.4765F),
                    new Vector3(2.88149F, 2.88149F, 2.88149F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["BleedOnHit"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayTriTip"),
                    "Chest",
                    new Vector3(-5.00599F, 7.60583F, 7.99995F),
                    new Vector3(359.7426F, 286.6212F, 90.77448F),
                    new Vector3(6.44365F, 6.47033F, 6.49494F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["BleedOnHitAndExplode"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBleedOnHitAndExplode"),
                    "JacketFront4L",
                    new Vector3(1.1614F, 0.14727F, -1.50951F),
                    new Vector3(352.1733F, 359.4104F, 251.3781F),
                    new Vector3(2.47957F, 2.47957F, 2.47957F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["BleedOnHitVoid"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayTriTipVoid"),
                    "Chest",
                    new Vector3(-4.6398F, 7.30512F, 7.77696F),
                    new Vector3(353.0526F, 290.9174F, 331.353F),
                    new Vector3(2.63016F, 1.89106F, 5.23143F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["BonusGoldPackOnKill"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayTome"),
                    "Pelvis",
                    new Vector3(-7.2635F, -9.87426F, 3.64094F),
                    new Vector3(80.18398F, 260.9865F, 16.4595F),
                    new Vector3(2.88704F, 2.88704F, 2.88704F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["BossDamageBonus"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayAPRound"),
                    "JacketSide4R",
                    new Vector3(1.81311F, 0.62842F, -0.05608F),
                    new Vector3(0.00001F, 95.1638F, 27.84073F),
                    new Vector3(45.6902F, 45.6902F, 45.6902F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["BounceNearby"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayHook"),
                    "Pelvis",
                    new Vector3(-16.64211F, -12.39113F, -9.94115F),
                    new Vector3(35.61868F, 202.741F, 54.0302F),
                    new Vector3(0.25431F, 0.25431F, 0.25431F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["ChainLightning"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayUkulele"),
                    "Stomach",
                    new Vector3(-15.54195F, -13.85663F, -0.53058F),
                    new Vector3(80.20996F, 250.8874F, 21.00104F),
                    new Vector3(51.17969F, 51.17969F, 51.17969F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["ChainLightningVoid"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayUkuleleVoid"),
                    "Stomach",
                    new Vector3(-15.54195F, -13.85663F, -0.53058F),
                    new Vector3(80.20996F, 250.8874F, 21.00104F),
                    new Vector3(51.17969F, 51.17969F, 51.17969F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Clover"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayClover"),
                    "Head",
                    new Vector3(-7.96141F, -13.93493F, -6.35149F),
                    new Vector3(5.87069F, 333.3993F, 105.0924F),
                    new Vector3(17.43645F, 17.5871F, 17.43645F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["CloverVoid"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayCloverVoid"),
                    "Head",
                    new Vector3(-7.9F, -13.9F, -6.3F),
                    new Vector3(13.30841F, 316.3018F, 113.3468F),
                    new Vector3(18.89806F, 18.89806F, 18.89806F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["CooldownOnCrit"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplaySkull"),
                    "Knife",
                    new Vector3(-20.87942F, -0.31935F, 0.02664F),
                    new Vector3(17.81671F, 272.4869F, 358.6308F),
                    new Vector3(6.71475F, 6.54005F, 5.64823F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["CritDamage"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayLaserSight"),
                    "Knife",
                    new Vector3(-30.548F, 0.02603F, 0.0069F),
                    new Vector3(357.9214F, 180F, 180F),
                    new Vector3(3.57807F, 3.57807F, 3.57807F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["CritGlasses"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayGlasses"),
                    "Head",
                    new Vector3(-8.48221F, -13.64526F, -0.30111F),
                    new Vector3(25.85071F, 266.4386F, 178.654F),
                    new Vector3(19.49028F, 18.2805F, 19.49028F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["CritGlassesVoid"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayGlassesVoid"),
                    "Head",
                    new Vector3(-9.13086F, -15.80518F, -0.24627F),
                    new Vector3(20.57036F, 266.8219F, 176.7543F),
                    new Vector3(16.79435F, 16.79435F, 16.79435F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Crowbar"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayCrowbar"),
                    "Chest",
                    new Vector3(-1.53506F, -11.79449F, -7.14167F),
                    new Vector3(343.1696F, 172.8969F, 256.3157F),
                    new Vector3(20.44887F, 20.44887F, 20.44887F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Dagger"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayDagger"),
                    "Chest",
                    new Vector3(-11.5469F, -4.52605F, -7.3237F),
                    new Vector3(347.7022F, 269.4128F, 212.2329F),
                    new Vector3(59.39465F, 59.39465F, 59.39465F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["DeathMark"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayDeathMark"),
                    "Knife",
                    new Vector3(3.45959F, 1.94975F, -0.07266F),
                    new Vector3(357.4603F, 268.1921F, 181.157F),
                    new Vector3(1F, 1F, 1F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["ElementalRingVoid"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayVoidRing"),
                    "Knife",
                    new Vector3(-2.18096F, -0.13312F, -0.07957F),
                    new Vector3(0F, 271.3746F, 0F),
                    new Vector3(19.39634F, 19.39634F, 35.5302F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["EmpowerAlways"],
                ItemDisplays.CreateLimbMaskDisplayRule(LimbFlags.Head),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplaySunHeadNeck"),
                    "Chest",
                    new Vector3(-18.49908F, -1.15797F, 1.13597F),
                    new Vector3(356.4258F, 197.9194F, 119.6651F),
                    new Vector3(130.1041F, 130.1041F, 130.1041F)
                    ),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplaySunHead"),
                    "Head",
                    new Vector3(-0.39145F, -9.07053F, 0.62925F),
                    new Vector3(0F, 0F, 0F),
                    new Vector3(83.72363F, 83.72363F, 83.72363F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["EnergizedOnEquipmentUse"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayWarHorn"),
                    "Pelvis",
                    new Vector3(-4.92882F, 9.13328F, -7.46884F),
                    new Vector3(302.9875F, 205.4485F, 173.5795F),
                    new Vector3(15.43039F, 15.43039F, 15.28469F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["EquipmentMagazine"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBattery"),
                    "Stomach",
                    new Vector3(-1.63554F, 1.4416F, -12.289F),
                    new Vector3(335.3121F, 89.81195F, 186.0427F),
                    new Vector3(9.40352F, 9.40352F, 9.40352F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["EquipmentMagazineVoid"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayFuelCellVoid"),
                    "Stomach",
                    new Vector3(-1.63554F, 1.4416F, -12.289F),
                    new Vector3(335.3121F, 89.81195F, 186.0427F),
                    new Vector3(9.40352F, 9.40352F, 9.40352F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["ExecuteLowHealthElite"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayGuillotine"),
                    "UpperArmL",
                    new Vector3(9.70376F, -2.37153F, -5.42614F),
                    new Vector3(353.5845F, 96.81486F, 261.6926F),
                    new Vector3(10.86316F, 10.86316F, 10.86316F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["ExplodeOnDeath"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayWilloWisp"),
                    "JacketSide3L",
                    new Vector3(0.81829F, 5.67929F, 0.00018F),
                    new Vector3(0F, 0F, 274.0509F),
                    new Vector3(3.98819F, 3.98819F, 3.98819F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["ExplodeOnDeathVoid"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayWillowWispVoid"),
                    "JacketSide3L",
                    new Vector3(0.81829F, 5.67929F, 0.00018F),
                    new Vector3(0F, 0F, 274.0509F),
                    new Vector3(3.98819F, 3.98819F, 3.98819F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["ExtraLife"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayHippo"),
                    "Head",
                    new Vector3(-11.48625F, -12.20018F, 0.75961F),
                    new Vector3(346.4193F, 259.2664F, 200.0447F),
                    new Vector3(2.65105F, 2.65105F, 2.65105F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["ExtraLifeVoid"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayHippoVoid"),
                    "Head",
                    new Vector3(-10.82931F, -12.15718F, 0.52185F),
                    new Vector3(312.4065F, 242.5474F, 210.4055F),
                    new Vector3(3.61273F, 3.61273F, 3.61273F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["FallBoots"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayGravBoots"),
                    "FootL",
                    new Vector3(-0.5718F, -2.38346F, -0.28817F),
                    new Vector3(0.14556F, 91.98798F, 184.1988F),
                    new Vector3(15.68748F, 15.68748F, 14.57141F)
                    ),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayGravBoots"),
                    "FootR",
                    new Vector3(0.43818F, -2.91044F, 0.70656F),
                    new Vector3(7.15083F, 271.3499F, 192.3746F),
                    new Vector3(15.68748F, 15.68748F, 15.68748F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Feather"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayFeather"),
                    "Head",
                    new Vector3(2.2705F, -12.45177F, 5.99837F),
                    new Vector3(336.962F, 4.91459F, 167.6077F),
                    new Vector3(1F, 1F, 1F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["FireballsOnHit"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayFireballsOnHit"),
                    "Knife",
                    new Vector3(-22.51862F, 3.37728F, -0.09614F),
                    new Vector3(274.9468F, 180.0004F, 268.5817F),
                    new Vector3(1.42862F, 1.42862F, 1.42862F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["FireRing"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayFireRing"),
                    "Knife",
                    new Vector3(-0.25847F, -0.13753F, -0.12424F),
                    new Vector3(0F, 271.3746F, 0F),
                    new Vector3(19.39634F, 19.39634F, 19.39634F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Firework"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayFirework"),
                    "JacketFront3R",
                    new Vector3(-1.12216F, -0.52576F, 12.54071F),
                    new Vector3(316.5729F, 228.165F, 318.2195F),
                    new Vector3(24.75711F, 24.75711F, 24.75711F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["FlatHealth"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplaySteakCurved"),
                    "Knife",
                    new Vector3(-10.97834F, 2.79398F, 0.02441F),
                    new Vector3(325.7123F, 268.6543F, 6.70766F),
                    new Vector3(5.55091F, 5.55091F, 5.55091F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["FocusConvergence"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayFocusedConvergence"),
                    "JokerBody",
                    new Vector3(-39.23121F, 158.6345F, -3.05905F),
                    new Vector3(0F, 0F, 294.5924F),
                    new Vector3(-0.03307F, -0.03307F, -0.03307F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["FragileDamageBonus"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayDelicateWatch"),
                    "LowerArmL",
                    new Vector3(5.05149F, -0.47162F, -1.01367F),
                    new Vector3(3.53854F, 268.1098F, 89.71661F),
                    new Vector3(41.89759F, 53.49572F, 44.48008F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["FreeChest"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayShippingRequestForm"),
                    "JacketBack1L",
                    new Vector3(-4.60699F, 1.05218F, -5.71699F),
                    new Vector3(355.1207F, 263.233F, 353.3101F),
                    new Vector3(42.22898F, 42.22898F, 42.22898F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["GhostOnKill"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayMask"),
                    "Head",
                    new Vector3(1.26778F, -11.00038F, -7.75968F),
                    new Vector3(359.6794F, 183.2427F, 165.9216F),
                    new Vector3(31.43141F, 31.43141F, 31.43141F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["GoldOnHit"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBoneCrown"),
                    "Head",
                    new Vector3(-0.2633F, -15.27973F, 0.22974F),
                    new Vector3(1.54627F, 264.9861F, 179.3376F),
                    new Vector3(57.84174F, 38.5316F, 53.65193F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["GoldOnHurt"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayRollOfPennies"),
                    "Pelvis",
                    new Vector3(-0.13166F, -4.6496F, 0.28825F),
                    new Vector3(0F, 0F, 252.644F),
                    new Vector3(28.87201F, 28.87201F, 28.87201F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["HalfAttackSpeedHalfCooldowns"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayLunarShoulderNature"),
                    "Head",
                    new Vector3(-5.75855F, 2.15213F, 0.12644F),
                    new Vector3(359.1347F, 178.7551F, 269.2592F),
                    new Vector3(15.89124F, 18.73099F, 15.65746F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["HalfSpeedDoubleHealth"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayLunarShoulderStone"),
                    "Head",
                    new Vector3(-4.33306F, -3.35109F, -0.04819F),
                    new Vector3(357.1317F, 177.8229F, 284.6125F),
                    new Vector3(15.03653F, 15.03653F, 15.03653F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["HeadHunter"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplaySkullcrown"),
                    "CalfL",
                    new Vector3(2.10248F, 0.35032F, -0.37993F),
                    new Vector3(82.44223F, 151.5291F, 61.31905F),
                    new Vector3(15.10143F, 6.04375F, 5.51366F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["HealingPotion"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayHealingPotion"),
                    "Pelvis",
                    new Vector3(-6.14921F, -8.25808F, -10.66626F),
                    new Vector3(3.55514F, 14.5788F, 61.79504F),
                    new Vector3(1.98625F, 1.98625F, 1.98625F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["HealOnCrit"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayScythe"),
                    "Stomach",
                    new Vector3(-9.70876F, -18.4198F, 2.15608F),
                    new Vector3(348.9257F, 311.3049F, 358.73F),
                    new Vector3(26.29395F, 26.29395F, 26.29395F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["HealWhileSafe"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplaySnail"),
                    "LowerArmR",
                    new Vector3(5.76668F, 0.5515F, 0.72437F),
                    new Vector3(0F, 266.3517F, 312.8549F),
                    new Vector3(2.99672F, 2.99672F, 2.99672F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Hoof"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayHoof"),
                    "FootR",
                    new Vector3(-1.34907F, -0.95765F, -3.71603F),
                    new Vector3(78.59948F, 37.79699F, 304.8274F),
                    new Vector3(2.10446F, 2.10446F, 2.10446F)
                    ),
                ItemDisplays.CreateLimbMaskDisplayRule(LimbFlags.RightCalf)
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["IceRing"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayIceRing"),
                    "Knife",
                    new Vector3(-3.09387F, -0.13377F, -0.05876F),
                    new Vector3(0F, 271.3746F, 0F),
                    new Vector3(19.39634F, 19.39634F, 19.39634F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Icicle"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayFrostRelic"),
                    "JokerBody",
                    new Vector3(-30.92027F, 168.3369F, 32.122F),
                    new Vector3(270F, 346.1461F, 0F),
                    new Vector3(1F, 1F, 1F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["IgniteOnKill"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayGasoline"),
                    "JacketFront2R",
                    new Vector3(0.86094F, 3.14399F, 7.21475F),
                    new Vector3(2.41549F, 95.77368F, 303.6886F),
                    new Vector3(34.07166F, 34.07166F, 34.07166F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["ImmuneToDebuff"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayRainCoatBelt"),
                    "ThighL",
                    new Vector3(8.16531F, -1.81553F, 0.65586F),
                    new Vector3(83.02996F, 210.6411F, 120.8278F),
                    new Vector3(44.21687F, 44.21687F, 44.21687F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["IncreaseHealing"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayAntler"),
                    "Head",
                    new Vector3(1.99995F, -15.42353F, 1.99993F),
                    new Vector3(0F, 0F, 180F),
                    new Vector3(-40.5032F, 23.42208F, 23.42208F)
                    ),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayAntler"),
                    "Head",
                    new Vector3(0.62027F, -15.62391F, -2.19776F),
                    new Vector3(0F, 166.8577F, 180F),
                    new Vector3(23.42208F, 23.42208F, 23.42208F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Incubator"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayAncestralIncubator"),
                    "Head",
                    new Vector3(-6.79662F, -3.08632F, -0.02262F),
                    new Vector3(1.50005F, 358.8594F, 82.65799F),
                    new Vector3(1F, 1F, 1F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Infusion"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayInfusion"),
                    "Pelvis",
                    new Vector3(-5.24403F, -10.17073F, -5.91011F),
                    new Vector3(65.73473F, 226.9837F, 307.7979F),
                    new Vector3(21.06733F, 21.06733F, 21.06733F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["JumpBoost"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayWaxBird"),
                    "Chest",
                    new Vector3(7.02585F, -7.71323F, -4.62345F),
                    new Vector3(282.979F, 55.24884F, 34.34792F),
                    new Vector3(37.68986F, 37.68998F, 37.68986F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["KillEliteFrenzy"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBrainstalk"),
                    "Head",
                    new Vector3(-0.57522F, -12.14073F, 2.0059F),
                    new Vector3(0F, 0F, 180F),
                    new Vector3(15.11493F, 15.11493F, 15.11493F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Knurl"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayKnurl"),
                    "JacketSide4R",
                    new Vector3(4.16597F, -6.60145F, 1.79647F),
                    new Vector3(1.70358F, 97.40176F, 18.74604F),
                    new Vector3(3.30146F, 3.30146F, 2.87553F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["LaserTurbine"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayLaserTurbine"),
                    "UpperArmR",
                    new Vector3(9.40547F, -0.69842F, 6.8927F),
                    new Vector3(348.6548F, 355.1645F, 359.8253F),
                    new Vector3(18.59288F, 18.59288F, 18.59288F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["LightningStrikeOnHit"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayChargedPerforator"),
                    "Knife",
                    new Vector3(-21.96888F, -1.92538F, 0.05285F),
                    new Vector3(0F, 266.2179F, 0F),
                    new Vector3(27.97088F, 27.97088F, 27.97088F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["LunarDagger"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayLunarDagger"),
                    "Chest",
                    new Vector3(0.50229F, -14.05796F, -6.42724F),
                    new Vector3(0F, 100.0819F, 0F),
                    new Vector3(59.78941F, 59.78941F, 59.78941F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["LunarPrimaryReplacement"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBirdEye"),
                    "Head",
                    new Vector3(-5.23979F, -7.22718F, 3.23664F),
                    new Vector3(358.5277F, 17.54974F, 262.8459F),
                    new Vector3(10.26042F, 8.49799F, 11.29139F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["LunarSecondaryReplacement"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBirdClaw"),
                    "Chest",
                    new Vector3(-10.71807F, -10.71689F, 7.52671F),
                    new Vector3(343.0182F, 344.7412F, 133.046F),
                    new Vector3(59.10132F, 59.10132F, 59.10132F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["LunarSpecialReplacement"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBirdHeart"),
                    "JokerBody",
                    new Vector3(-57.26558F, 160.8294F, -25.10154F),
                    new Vector3(0F, 0F, 0F),
                    new Vector3(0.25389F, 0.25389F, 0.25389F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["LunarTrinket"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBeads"),
                    "LowerArmR",
                    new Vector3(7.48075F, -0.99712F, 2.16828F),
                    new Vector3(6.33937F, 29.98425F, 36.58395F),
                    new Vector3(57.30468F, 57.30468F, 57.30468F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["LunarUtilityReplacement"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBirdFoot"),
                    "FootL",
                    new Vector3(0.53869F, -12.3433F, 4.37411F),
                    new Vector3(355.1683F, 295.0424F, 241.9719F),
                    new Vector3(45.19257F, 45.19257F, 45.19257F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Medkit"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayMedkit"),
                    "JacketSide4L",
                    new Vector3(-1.10818F, 0.69759F, -7.25469F),
                    new Vector3(348.9539F, 92.87675F, 143.8908F),
                    new Vector3(50.81828F, 50.81828F, 50.81828F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["MinorConstructOnKill"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayDefenseNucleus"),
                    "JokerBody",
                    new Vector3(55.49707F, 171.3454F, -56.62857F),
                    new Vector3(0F, 0F, 0F),
                    new Vector3(0.41429F, 0.41429F, 0.41429F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Missile"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayMissileLauncher"),
                    "Chest",
                    new Vector3(-26.51894F, -14.33908F, -20.35437F),
                    new Vector3(285.8157F, 305.6945F, 115.9653F),
                    new Vector3(5.8477F, 5.8477F, 5.8477F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["MissileVoid"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayMissileLauncherVoid"),
                    "Chest",
                    new Vector3(-26.51894F, -14.33908F, -20.35437F),
                    new Vector3(285.8157F, 305.6945F, 115.9653F),
                    new Vector3(5.8477F, 5.8477F, 5.8477F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["MonstersOnShrineUse"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayMonstersOnShrineUse"),
                    "Head",
                    new Vector3(1.32592F, -10.97278F, 9.4496F),
                    new Vector3(25.50516F, 108.5693F, 12.25103F),
                    new Vector3(2.10512F, 2.10512F, 2.10512F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["MoreMissile"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayICBM"),
                    "Chest",
                    new Vector3(-6.53056F, -14.14417F, -6.5468F),
                    new Vector3(66.38248F, 350.3673F, 91.83273F),
                    new Vector3(4.45322F, 4.45322F, 4.45322F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["MoveSpeedOnKill"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayGrappleHook"),
                    "Knife",
                    new Vector3(-42.33263F, 0.04562F, 0.05215F),
                    new Vector3(286.6773F, 5.21457F, 264.5578F),
                    new Vector3(9.73404F, 9.73404F, 9.73404F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Mushroom"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayMushroom"),
                    "Head",
                    new Vector3(3.31319F, -20.89052F, -0.57893F),
                    new Vector3(359.6208F, 180F, 180F),
                    new Vector3(2.32705F, 2.32705F, 2.32705F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["MushroomVoid"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayMushroomVoid"),
                    "Head",
                    new Vector3(3.31319F, -20.89052F, -0.57893F),
                    new Vector3(359.6208F, 180F, 180F),
                    new Vector3(2.32705F, 2.32705F, 2.32705F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["NearbyDamageBonus"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayDiamond"),
                    "Knife",
                    new Vector3(-6.63242F, 0.00418F, -0.00201F),
                    new Vector3(0F, 0F, 0F),
                    new Vector3(3.01843F, 3.01843F, 3.01843F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["NovaOnHeal"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayDevilHorns"),
                    "Head",
                    new Vector3(-1.57567F, -12.63989F, 2.60709F),
                    new Vector3(331.9337F, 255.0139F, 208.1882F),
                    new Vector3(33.7913F, 33.7913F, 33.7913F)
                    ),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayDevilHorns"),
                    "Head",
                    new Vector3(-0.36319F, -12.83303F, -2.13015F),
                    new Vector3(328.8398F, 274.3755F, 145.7091F),
                    new Vector3(-33.7913F, 33.7913F, 33.7913F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["NovaOnLowHealth"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayJellyGuts"),
                    "Head",
                    new Vector3(1.13858F, 0.85328F, -2.16292F),
                    new Vector3(313.853F, 283.2153F, 336.2427F),
                    new Vector3(5.35249F, 5.35249F, 5.35249F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["OutOfCombatArmor"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayOddlyShapedOpal"),
                    "Chest",
                    new Vector3(-8.40305F, 7.32721F, 7.05476F),
                    new Vector3(74.93392F, 103.838F, 9.00907F),
                    new Vector3(6.72581F, 6.72581F, 6.72581F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["ParentEgg"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayParentEgg"),
                    "JacketBack4R",
                    new Vector3(1.20341F, -7.25048F, 4.84899F),
                    new Vector3(78.72751F, 56.46835F, 326.9803F),
                    new Vector3(4.00403F, 4.00403F, 4.00403F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Pearl"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayPearl"),
                    "Head",
                    new Vector3(0.38356F, -26.4561F, -0.3266F),
                    new Vector3(276.7419F, 237.8582F, 121.886F),
                    new Vector3(2.98172F, 2.98172F, 2.98172F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["PermanentDebuffOnHit"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayScorpion"),
                    "Pelvis",
                    new Vector3(-6.00267F, -10.18952F, -0.61131F),
                    new Vector3(274.5619F, 275.2759F, 179.9996F),
                    new Vector3(41.19806F, 41.19806F, 41.19806F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["PersonalShield"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayShieldGenerator"),
                    "Head",
                    new Vector3(1.02453F, 3.54187F, -1.9747F),
                    new Vector3(77.58783F, 201.2982F, 200.9871F),
                    new Vector3(6.59014F, 6.59014F, 6.59014F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Phasing"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayStealthkit"),
                    "Stomach",
                    new Vector3(-2.38421F, 10.53478F, -0.10649F),
                    new Vector3(1.92944F, 268.8795F, 180.8852F),
                    new Vector3(15.94091F, 15.94091F, 15.94091F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Plant"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayInterstellarDeskPlant"),
                    "Head",
                    new Vector3(6.50622F, -14.2321F, 5.98889F),
                    new Vector3(48.70399F, 49.10394F, 32.82234F),
                    new Vector3(4.43613F, 4.43613F, 4.43613F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["PrimarySkillShuriken"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayShuriken"),
                    "HandL",
                    new Vector3(0.35737F, 0.266F, -4.00648F),
                    new Vector3(0.21916F, 1.05156F, 42.89918F),
                    new Vector3(11.73474F, 11.73474F, 11.73474F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["RandomDamageZone"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayRandomDamageZone"),
                    "UpperArmL",
                    new Vector3(2.84661F, -4.00842F, -5.85828F),
                    new Vector3(300.6602F, 8.46716F, 350.1818F),
                    new Vector3(3.55389F, 2.10374F, 2.82141F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["RandomEquipmentTrigger"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBottledChaos"),
                    "JacketSide1R",
                    new Vector3(1.71341F, 0.66957F, -6.25583F),
                    new Vector3(78.65998F, 310.6628F, 233.2682F),
                    new Vector3(7.72399F, 9.01428F, 7.72399F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["RandomlyLunar"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayDomino"),
                    "JokerBody",
                    new Vector3(30.30711F, 163.9982F, -24.27549F),
                    new Vector3(83.54813F, 165.4415F, 175.1256F),
                    new Vector3(1F, 1F, 1F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["RegeneratingScrap"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayRegeneratingScrap"),
                    "JacketBack4L",
                    new Vector3(1.32278F, 7.22109F, -2.30711F),
                    new Vector3(1.05987F, 91.61841F, 8.28665F),
                    new Vector3(14.02742F, 14.02742F, 14.02742F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["RepeatHeal"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayCorpseflower"),
                    "Chest",
                    new Vector3(-15.66241F, 5.14706F, -5.93521F),
                    new Vector3(0F, 0F, 20.26049F),
                    new Vector3(12.17701F, 12.17701F, 12.17701F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["SecondarySkillMagazine"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayDoubleMag"),
                    "ThighR",
                    new Vector3(-6.29004F, 0.35825F, -6.98837F),
                    new Vector3(72.15121F, 79.43804F, 164.7066F),
                    new Vector3(3.59976F, 3.59976F, 3.59976F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Seed"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplaySeed"),
                    "JacketBack3L",
                    new Vector3(3.84304F, 2.30492F, -5.10989F),
                    new Vector3(355.789F, 21.14361F, 291.7179F),
                    new Vector3(2.71229F, 2.71229F, 2.71229F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["ShieldOnly"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayShieldBug"),
                    "Head",
                    new Vector3(-4.46453F, -17.0886F, -6.29526F),
                    new Vector3(356.4922F, 15.3459F, 158.1956F),
                    new Vector3(9.62993F, 9.62993F, 9.62993F)
                    ),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayShieldBug"),
                    "Head",
                    new Vector3(-4.64289F, -15.8685F, 5.19841F),
                    new Vector3(341.7064F, 31.71989F, 156.9146F),
                    new Vector3(9.62993F, 9.62993F, 9.62993F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["ShinyPearl"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayShinyPearl"),
                    "Head",
                    new Vector3(-0.00026F, -22.62337F, -0.56754F),
                    new Vector3(276.7426F, 237.8582F, 121.886F),
                    new Vector3(6.26835F, 6.26835F, 6.26835F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["ShockNearby"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayTeslaCoil"),
                    "UpperArmL",
                    new Vector3(10.58822F, -2.61325F, -4.69192F),
                    new Vector3(281.1515F, 155.3453F, 213.9124F),
                    new Vector3(17.07123F, 17.07123F, 17.07123F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["SiphonOnLowHealth"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplaySiphonOnLowHealth"),
                    "JacketSide3L",
                    new Vector3(4.16652F, -4.94667F, 1.68731F),
                    new Vector3(79.89489F, 321.7872F, 235.4256F),
                    new Vector3(5.36095F, 5.36095F, 5.36095F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["SlowOnHit"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBauble"),
                    "Stomach",
                    new Vector3(15.54126F, 3.36293F, 12.08679F),
                    new Vector3(10.23676F, 356.0526F, 68.77959F),
                    new Vector3(15.281F, 15.281F, 15.28099F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["SlowOnHitVoid"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBaubleVoid"),
                    "Stomach",
                    new Vector3(15.54126F, 3.36293F, 12.08679F),
                    new Vector3(10.23676F, 356.0526F, 68.77959F),
                    new Vector3(15.281F, 15.281F, 15.28099F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["SprintArmor"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBuckler"),
                    "HandR",
                    new Vector3(1.99903F, 4.24703F, 2.65936F),
                    new Vector3(286.3066F, -0.00003F, 56.74768F),
                    new Vector3(12.30894F, 12.30894F, 12.30894F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["SprintBonus"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplaySoda"),
                    "Pelvis",
                    new Vector3(-5.70158F, -4.43479F, -13.34331F),
                    new Vector3(347.7429F, 282.101F, 220.497F),
                    new Vector3(12.33483F, 12.33483F, 12.33483F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["SprintOutOfCombat"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayWhip"),
                    "JacketSide1L",
                    new Vector3(1.91981F, 0.37095F, 2.14906F),
                    new Vector3(17.03168F, 181.4556F, 92.97981F),
                    new Vector3(24.74896F, 24.74896F, 24.74896F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["SprintWisp"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBrokenMask"),
                    "UpperArmR",
                    new Vector3(14.30189F, -0.6791F, 3.38723F),
                    new Vector3(347.0171F, 6.88405F, 83.22848F),
                    new Vector3(14.05606F, 14.05606F, 14.05606F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Squid"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplaySquidTurret"),
                    "Chest",
                    new Vector3(4.82034F, 3.62963F, -11.12052F),
                    new Vector3(301.0155F, 0F, 3.2539F),
                    new Vector3(2.72093F, 2.72093F, 2.72093F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["StickyBomb"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayStickyBomb"),
                    "Pelvis",
                    new Vector3(4.45179F, 10.37156F, 9.91485F),
                    new Vector3(358.5857F, 347.8308F, 274.3779F),
                    new Vector3(19.04232F, 19.04232F, 19.04232F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["StrengthenBurn"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayGasTank"),
                    "JacketFront2R",
                    new Vector3(8.6769F, -4.81148F, 14.0937F),
                    new Vector3(45.24536F, 2.17471F, 264.382F),
                    new Vector3(10.31243F, 10.31243F, 10.31243F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["StunChanceOnHit"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayStunGrenade"),
                    "Pelvis",
                    new Vector3(-2.8402F, 5.02424F, 12.75565F),
                    new Vector3(6.22731F, 255.8822F, 0F),
                    new Vector3(47.52885F, 47.52882F, 47.52885F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Syringe"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplaySyringeCluster"),
                    "ThighR",
                    new Vector3(4.96774F, -5.7897F, 3.53713F),
                    new Vector3(23.33383F, 263.1628F, 200.4122F),
                    new Vector3(5.77689F, 7.64654F, 5.77689F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Talisman"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayTalisman"),
                    "JokerBody",
                    new Vector3(9.3036F, 195.2878F, -76.75595F),
                    new Vector3(0F, 0F, 0F),
                    new Vector3(0.78457F, 0.78457F, 0.78457F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Thorns"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayRazorwireLeft"),
                    "UpperArmL",
                    new Vector3(2F, 2F, 2F),
                    new Vector3(0F, 0F, 0F),
                    new Vector3(25.53344F, 7.16613F, 26.23322F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["TitanGoldDuringTP"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayGoldHeart"),
                    "Chest",
                    new Vector3(-2.75719F, 10.65416F, -1.84648F),
                    new Vector3(285.7828F, 115.0723F, 267.1728F),
                    new Vector3(9.57925F, 9.57925F, 9.57925F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Tooth"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayToothNecklaceDecal"),
                    "Chest",
                    new Vector3(-11.05769F, 6.70827F, 0.34289F),
                    new Vector3(0F, 0F, 0F),
                    new Vector3(1F, 1F, 1F)
                    ),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayToothMeshLarge"),
                    "Chest",
                    new Vector3(-11.04947F, 6.32646F, 0.69916F),
                    new Vector3(2.40403F, 9.53509F, 114.6021F),
                    new Vector3(113.163F, 113.163F, 113.163F)
                    ),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayToothMeshSmall1"),
                    "Chest",
                    new Vector3(-11.49179F, 5.8167F, 4.01122F),
                    new Vector3(71.33662F, 141.4446F, 252.1358F),
                    new Vector3(113F, 113F, 113F)
                    ),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayToothMeshSmall2"),
                    "Chest",
                    new Vector3(-13.27415F, 4.65485F, 7.0859F),
                    new Vector3(297.3032F, 336.8672F, 65.42717F),
                    new Vector3(113F, 113F, 113F)
                    ),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayToothMeshSmall2"),
                    "Chest",
                    new Vector3(-9.89954F, 5.71467F, -3.88818F),
                    new Vector3(77.20566F, 5.43319F, 208.1734F),
                    new Vector3(113F, 113F, 113F)
                    ),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayToothMeshSmall1"),
                    "Chest",
                    new Vector3(-12.13948F, 4.7786F, -6.73558F),
                    new Vector3(287.1073F, 263.8983F, 216.9844F),
                    new Vector3(113F, 113F, 113F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["TPHealingNova"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayGlowFlower"),
                    "Chest",
                    new Vector3(-11.82849F, 5.54234F, -8.48497F),
                    new Vector3(286.3691F, 291.7928F, 67.37773F),
                    new Vector3(13.39466F, 13.39466F, 13.39466F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["TreasureCache"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayKey"),
                    "Pelvis",
                    new Vector3(-2.32663F, -2.65777F, 13.92998F),
                    new Vector3(277.0757F, 343.2228F, 180.8463F),
                    new Vector3(60.70837F, 60.70837F, 60.70837F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["TreasureCacheVoid"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayKeyVoid"),
                    "Pelvis",
                    new Vector3(-2.32663F, -2.65777F, 13.92998F),
                    new Vector3(277.0757F, 343.2228F, 180.8463F),
                    new Vector3(60.70837F, 60.70837F, 60.70837F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["UtilitySkillMagazine"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayAfterburnerShoulderRing"),
                    "UpperArmL",
                    new Vector3(11.36494F, 0.01266F, 4.75427F),
                    new Vector3(69.36198F, 0.00003F, 17.91384F),
                    new Vector3(36.93153F, 36.93153F, 36.93153F)
                    ),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayAfterburnerShoulderRing"),
                    "UpperArmR",
                    new Vector3(9.16657F, 0.20288F, -4.27592F),
                    new Vector3(358.6469F, 297.2276F, 64.98034F),
                    new Vector3(36.93153F, 36.93153F, 36.93153F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["VoidMegaCrabItem"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayMegaCrabItem"),
                    "Pelvis",
                    new Vector3(1.41266F, 10.35665F, 0.01877F),
                    new Vector3(274.0233F, 297.3878F, 152.9164F),
                    new Vector3(8.77915F, 8.68316F, 8.68316F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["WarCryOnMultiKill"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayPauldron"),
                    "Stomach",
                    new Vector3(7.46115F, 11.31783F, 9.53195F),
                    new Vector3(346.5356F, 265.9339F, 343.3509F),
                    new Vector3(34.99598F, 34.99598F, 34.99598F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["WardOnLevel"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayWarbanner"),
                    "Stomach",
                    new Vector3(1.55515F, -12.96902F, -0.76299F),
                    new Vector3(357.2408F, 303.4605F, 89.41462F),
                    new Vector3(23.48054F, 23.48054F, 23.48054F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["BFG"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBFG"),
                    "Chest",
                    new Vector3(-9.74956F, -9.53249F, 13.70754F),
                    new Vector3(285.006F, 283.1528F, 179.9999F),
                    new Vector3(16.09551F, 16.09551F, 16.09551F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Blackhole"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayGravCube"),
                    "JokerBody",
                    new Vector3(-39.72781F, 180.3199F, -76.24537F),
                    new Vector3(0F, 0F, 0F),
                    new Vector3(0.56409F, 0.56409F, 0.56409F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["BossHunter"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayTricornGhost"),
                    "Head",
                    new Vector3(2.11906F, -20.27664F, -0.29964F),
                    new Vector3(342.3715F, 266.9074F, 182.2037F),
                    new Vector3(59.47373F, 59.47373F, 59.47373F)
                    ),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBlunderbuss"),
                    "JokerBody",
                    new Vector3(39.59658F, 176.4227F, -54.36443F),
                    new Vector3(86.55747F, 177.9578F, 177.2756F),
                    new Vector3(0.57066F, 0.57066F, 0.57066F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["BossHunterConsumed"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayTricornUsed"),
                    "Head",
                    new Vector3(2.11906F, -20.27664F, -0.29964F),
                    new Vector3(342.3715F, 266.9074F, 182.2037F),
                    new Vector3(59.47373F, 59.47373F, 59.47373F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["BurnNearby"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayPotion"),
                    "JacketSide1L",
                    new Vector3(3.62653F, 0.11772F, 0.3307F),
                    new Vector3(301.3438F, 175.0735F, 83.81588F),
                    new Vector3(2.60926F, 2.60926F, 2.60926F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Cleanse"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayWaterPack"),
                    "Chest",
                    new Vector3(1.97626F, -11.66481F, 0.02234F),
                    new Vector3(80.45325F, 0.5136F, 89.63603F),
                    new Vector3(10.9469F, 10.9469F, 10.9469F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["CommandMissile"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayMissileRack"),
                    "Chest",
                    new Vector3(-4.86664F, -13.54789F, 0.11067F),
                    new Vector3(359.7469F, 90.99664F, 179.92F),
                    new Vector3(38.30391F, 38.30391F, 38.30391F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["CrippleWard"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayEffigy"),
                    "Chest",
                    new Vector3(-5.88882F, -12.57252F, 11.98378F),
                    new Vector3(72.12292F, 15.85877F, 108.5878F),
                    new Vector3(40.93906F, 40.93906F, 40.93906F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["CritOnUse"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayNeuralImplant"),
                    "Head",
                    new Vector3(-23.41918F, -6.94736F, 0.13807F),
                    new Vector3(2.73913F, 268.379F, 0.30139F),
                    new Vector3(18.12736F, 18.12736F, 18.12736F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["DeathProjectile"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayDeathProjectile"),
                    "Stomach",
                    new Vector3(-0.10076F, -17.16442F, 2.34486F),
                    new Vector3(73.82604F, 294.2628F, 24.19819F),
                    new Vector3(8.09173F, 8.09173F, 8.09173F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["DroneBackup"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayRadio"),
                    "Chest",
                    new Vector3(-8.34483F, 7.51473F, -6.35468F),
                    new Vector3(292.0207F, 267.3717F, 182.3752F),
                    new Vector3(31.21031F, 31.2103F, 31.21031F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["EliteEarthEquipment"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayEliteMendingAntlers"),
                    "Head",
                    new Vector3(-4.14699F, -13.84864F, -0.8897F),
                    new Vector3(344.9462F, 267.8589F, 180F),
                    new Vector3(33.92074F, 33.92074F, 33.92074F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["EliteFireEquipment"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayEliteHorn"),
                    "Head",
                    new Vector3(-7.44588F, -14.33453F, 3.79831F),
                    new Vector3(329.3028F, 265.843F, 196.4708F),
                    new Vector3(-3F, 3F, 3F)
                    ),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayEliteHorn"),
                    "Head",
                    new Vector3(-8.91431F, -14.53633F, -3.99303F),
                    new Vector3(322.6194F, 273.4708F, 172.8907F),
                    new Vector3(3F, 3F, 3F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["EliteHauntedEquipment"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayEliteStealthCrown"),
                    "Head",
                    new Vector3(0.40275F, -16.20989F, -0.18197F),
                    new Vector3(84.65705F, 276.324F, 185.2692F),
                    new Vector3(3.15797F, 3.15797F, 3.15797F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["EliteIceEquipment"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayEliteIceCrown"),
                    "Head",
                    new Vector3(-0.11137F, -20.95168F, 0.23188F),
                    new Vector3(84.34307F, 254.7887F, 167.8759F),
                    new Vector3(1.68162F, 1.68162F, 1.68162F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["EliteLightningEquipment"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayEliteRhinoHorn"),
                    "Head",
                    new Vector3(-5.44725F, -16.61345F, -0.84951F),
                    new Vector3(36.32001F, 267.9675F, 176.4723F),
                    new Vector3(7.40537F, 7.40537F, 7.40537F)
                    ),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayEliteRhinoHorn"),
                    "Head",
                    new Vector3(-6.77292F, -13.38324F, -0.68865F),
                    new Vector3(23.0299F, 268.8496F, 176.912F),
                    new Vector3(13.23287F, 13.23287F, 13.23288F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["EliteLunarEquipment"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayEliteLunar,Eye"),
                    "Head",
                    new Vector3(-13.89187F, -5.72436F, -0.04218F),
                    new Vector3(352.3182F, 270.3543F, 1.62719F),
                    new Vector3(11.63659F, 11.63659F, 12.55505F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["ElitePoisonEquipment"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayEliteUrchinCrown"),
                    "Head",
                    new Vector3(0.45639F, -17.32718F, 0.02258F),
                    new Vector3(82.54325F, 180.8059F, 194.2676F),
                    new Vector3(2.50655F, 2.50655F, 2.50655F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["EliteVoidEquipment"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayAffixVoid"),
                    "Head",
                    new Vector3(-3.60348F, -5.77297F, 0.25067F),
                    new Vector3(275.8383F, 16.16415F, 68.06355F),
                    new Vector3(15.69772F, 15.69772F, 15.69772F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["FireBallDash"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayEgg"),
                    "Pelvis",
                    new Vector3(-4.64569F, 10.58482F, -6.23847F),
                    new Vector3(6.94574F, 274.101F, 0F),
                    new Vector3(12.62794F, 12.62794F, 12.62794F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Fruit"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayFruit"),
                    "Chest",
                    new Vector3(3.63692F, -3.75905F, 13.95144F),
                    new Vector3(12.63438F, 182.7293F, 286.1338F),
                    new Vector3(15.46241F, 15.46241F, 15.46241F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["GainArmor"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayElephantFigure"),
                    "Pelvis",
                    new Vector3(-4.6F, 10.5F, -6.2F),
                    new Vector3(352.2047F, 0.94222F, 83.0864F),
                    new Vector3(35.72737F, 35.72737F, 35.72737F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Gateway"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayVase"),
                    "Chest",
                    new Vector3(-11.1224F, -12.21211F, -0.04958F),
                    new Vector3(13.92022F, 156.7883F, 203.251F),
                    new Vector3(13.95566F, 13.95566F, 13.95566F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["GoldGat"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayGoldGat"),
                    "Chest",
                    new Vector3(-23.04609F, -20.9414F, 14.84239F),
                    new Vector3(20.50433F, 25.04759F, 147.1024F),
                    new Vector3(-9.18713F, 9.18713F, 9.18713F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["GummyClone"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayGummyClone"),
                    "Knife",
                    new Vector3(-13.32296F, -0.74369F, 0.07522F),
                    new Vector3(275.1781F, 91.94063F, 8.42094F),
                    new Vector3(4.47869F, 4.47869F, 4.47869F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["IrradiatingLaser"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayIrradiatingLaser"),
                    "Chest",
                    new Vector3(-13.83734F, -8.51465F, 13.84182F),
                    new Vector3(289.8229F, 313.8942F, 164.1588F),
                    new Vector3(7.14343F, 7.14343F, 7.14343F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Jetpack"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBugWings"),
                    "Chest",
                    new Vector3(1.70356F, -6.28334F, -1.84096F),
                    new Vector3(297.5647F, 282.3841F, 171.3697F),
                    new Vector3(9.53974F, 9.53974F, 9.53974F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["LifestealOnHit"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayLifestealOnHit"),
                    "Head",
                    new Vector3(-1.40629F, 1.68264F, -4.6383F),
                    new Vector3(20.00149F, 22.62226F, 117.5858F),
                    new Vector3(2.3521F, 2.3521F, 2.3521F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Lightning"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayLightningArmRight"),
                    "Chest",
                    new Vector3(2F, 2F, 2F),
                    new Vector3(0F, 130.5611F, 0F),
                    new Vector3(58.08257F, 58.08257F, 58.08257F)
                    ),
                ItemDisplays.CreateLimbMaskDisplayRule(LimbFlags.RightArm)
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["LunarPortalOnUse"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayLunarPortalOnUse"),
                    "JokerBody",
                    new Vector3(-36.08383F, 187.4711F, -59.8143F),
                    new Vector3(0F, 0F, 0F),
                    new Vector3(0.75608F, 0.75608F, 0.75608F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Meteor"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayMeteor"),
                    "JokerBody",
                    new Vector3(24.95602F, 195.0585F, -47.33228F),
                    new Vector3(0F, 0F, 0F),
                    new Vector3(0.62646F, 0.62646F, 0.62646F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Molotov"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayMolotov"),
                    "Pelvis",
                    new Vector3(2.00042F, 8.70814F, -7.10659F),
                    new Vector3(288.1205F, 147.7679F, 310.6183F),
                    new Vector3(14.06976F, 14.06976F, 14.06976F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["MultiShopCard"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayExecutiveCard"),
                    "LowerArmL",
                    new Vector3(-0.55973F, -9.77036F, -0.11236F),
                    new Vector3(79.48289F, 264.67F, 266.3757F),
                    new Vector3(26.95835F, 26.95835F, 26.95835F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["QuestVolatileBattery"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBatteryArray"),
                    "Stomach",
                    new Vector3(2.00112F, 11.27115F, 0.23327F),
                    new Vector3(280.3816F, 308.3172F, 51.13118F),
                    new Vector3(15.11446F, 15.11446F, 15.11446F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Recycle"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayRecycler"),
                    "JacketSide1R",
                    new Vector3(1.94788F, 1.71836F, -6.12288F),
                    new Vector3(0.56082F, 172.0282F, 100.3881F),
                    new Vector3(6.45233F, 6.45233F, 6.45233F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Saw"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplaySawmerangFollower"),
                    "JokerBody",
                    new Vector3(1.99999F, 179.3955F, -78.45326F),
                    new Vector3(270F, 0F, 0F),
                    new Vector3(8.01633F, 8.01633F, 8.01633F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Scanner"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayScanner"),
                    "Chest",
                    new Vector3(-7.88184F, -5.52101F, 16.93621F),
                    new Vector3(7.25734F, 301.7315F, 169.3815F),
                    new Vector3(20.02166F, 20.02166F, 20.02166F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["TeamWarCry"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayTeamWarCry"),
                    "Stomach",
                    new Vector3(0.92372F, 10.59297F, 0.08115F),
                    new Vector3(275.4987F, 243.6258F, 204.115F),
                    new Vector3(2.46105F, 2.46105F, 2.46105F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Tonic"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayTonic"),
                    "Pelvis",
                    new Vector3(-8.64167F, 9.11157F, -5.81845F),
                    new Vector3(79.10236F, 358.4756F, 83.95306F),
                    new Vector3(12.52142F, 12.52142F, 12.52142F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["VendingMachine"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayVendingMachine"),
                    "Pelvis",
                    new Vector3(-12.85325F, 9.34583F, -6.66698F),
                    new Vector3(293.5293F, 0.95412F, 99.35578F),
                    new Vector3(11.7953F, 11.7953F, 11.7953F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["AttackSpeedPerNearbyAllyOrEnemy"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayRageCrystal"),
                    "Chest",
                    new Vector3(-4.85161F, 6.72269F, 9.48536F),
                    new Vector3(293.4194F, 258.1995F, 187.3631F),
                    new Vector3(62.59543F, 62.59543F, 62.59543F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["BarrageOnBoss"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayTreasuryDividends"),
                    "LowerArmR",
                    new Vector3(5.10035F, 0.11794F, 4.29664F),
                    new Vector3(3.78982F, 3.9757F, 178.5978F),
                    new Vector3(43.91735F, 43.91735F, 43.91735F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["BoostAllStats"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayGrowthNectar"),
                    "Head",
                    new Vector3(4.68398F, -8.95972F, 0.00274F),
                    new Vector3(-0.00001F, 272.1162F, 180F),
                    new Vector3(35.72318F, 35.72318F, 35.72318F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["DelayedDamage"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayDelayedDamage"),
                    "Chest",
                    new Vector3(-8.36546F, -13.90638F, 0.12905F),
                    new Vector3(82.70903F, 272.247F, 325.2231F),
                    new Vector3(10.58396F, 10.58396F, 10.58396F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["ExtraShrineItem"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayChanceDoll"),
                    "ThighL",
                    new Vector3(4.37814F, 8.58625F, -0.84762F),
                    new Vector3(278.457F, 347.507F, 289.6475F),
                    new Vector3(9.48814F, 9.48814F, 9.48814F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["ExtraStatsOnLevelUp"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayPrayerBeads"),
                    "Chest",
                    new Vector3(-20.15645F, -3.47961F, 0.57402F),
                    new Vector3(292.6203F, 267.1365F, 183.2965F),
                    new Vector3(56.23124F, 56.23124F, 27.37552F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["IncreaseDamageOnMultiKill"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayIncreaseDamageOnMultiKill"),
                    "Stomach",
                    new Vector3(2.00047F, -7.43816F, 0.07149F),
                    new Vector3(0F, 270F, 0F),
                    new Vector3(13.04031F, 13.04031F, 13.04031F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["IncreasePrimaryDamage"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayIncreasePrimaryDamage"),
                    "LowerArmR",
                    new Vector3(5.60146F, -5.40609F, 0.57221F),
                    new Vector3(80.64481F, 358.2937F, 92.83957F),
                    new Vector3(40.89397F, 40.89397F, 40.89397F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["ItemDropChanceOnKill"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplaySonorousEcho"),
                    "Pelvis",
                    new Vector3(-3.54497F, 11.45651F, 6.23428F),
                    new Vector3(275.7627F, 276.5534F, 153.048F),
                    new Vector3(30.36032F, 30.36032F, 30.36032F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["KnockBackHitEnemies"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayKnockbackFin"),
                    "Chest",
                    new Vector3(-6.99983F, -11.15158F, 0.05821F),
                    new Vector3(275.9928F, 313.711F, 134.1739F),
                    new Vector3(29.47901F, 29.47901F, 29.47901F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["LowerPricedChests"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayLowerPricedChests"),
                    "JokerBody",
                    new Vector3(67.91295F, 170.5176F, -84.33392F),
                    new Vector3(270.2185F, 2.27943F, 0.00014F),
                    new Vector3(1F, 1F, 1F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["MeteorAttackOnHighDamage"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayMeteorAttackOnHighDamage"),
                    "Chest",
                    new Vector3(-10.99016F, -7.14556F, -15.17933F),
                    new Vector3(291.8557F, 332.4179F, 78.71721F),
                    new Vector3(55.97963F, 55.97963F, 55.97963F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["OnLevelUpFreeUnlock"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayOnLevelUpFreeUnlockTablet"),
                    "Chest",
                    new Vector3(2.98082F, -13.02993F, -0.66997F),
                    new Vector3(66.72035F, 112.4743F, 113.9404F),
                    new Vector3(68.42694F, 68.42694F, 68.42694F)
                    ),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayOnLevelUpFreeUnlock"),
                    "JokerBody",
                    new Vector3(-50.1333F, 161.4217F, -20.16652F),
                    new Vector3(0F, 0F, 0F),
                    new Vector3(0.89893F, 0.89893F, 0.89893F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["SpeedBoostPickup"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayElusiveAntlersLeft"),
                    "Head",
                    new Vector3(-4.40658F, -16.71598F, 2.56883F),
                    new Vector3(15.04291F, 257.6346F, 177.5393F),
                    new Vector3(23.33026F, 23.33026F, 23.33026F)
                    ),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayElusiveAntlersRight"),
                    "Head",
                    new Vector3(-4.49954F, -16.78643F, -2.13689F),
                    new Vector3(13.45252F, 281.3008F, 186.011F),
                    new Vector3(23.33026F, 23.33026F, 23.33026F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["StunAndPierce"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayElectricBoomerang"),
                    "LowerArmL",
                    new Vector3(-7.31515F, 1.04886F, 5.11534F),
                    new Vector3(31.65307F, 270.0658F, 90.16541F),
                    new Vector3(16.91554F, 16.91554F, 16.91554F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["TeleportOnLowHealth"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayTeleportOnLowHealth"),
                    "Stomach",
                    new Vector3(0.4783F, 8.37706F, 3.83652F),
                    new Vector3(280.0341F, 356.7257F, 87.79639F),
                    new Vector3(44.56083F, 44.56083F, 44.56083F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["TriggerEnemyDebuffs"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayNoxiousThorn"),
                    "Head",
                    new Vector3(-3.22662F, -10.45121F, 7.60711F),
                    new Vector3(354.6211F, 175.3422F, 1.46239F),
                    new Vector3(13.59502F, 22.16678F, 13.59502F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["EliteAurelioniteEquipment"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayEliteAurelioniteEquipment"),
                    "Head",
                    new Vector3(-9.78392F, -13.28061F, -0.23741F),
                    new Vector3(359.9649F, 272.6313F, 178.5109F),
                    new Vector3(16.24438F, 16.24438F, 15.9915F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["EliteBeadEquipment"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayEliteBeadSpike"),
                    "Head",
                    new Vector3(-2.00075F, -19.52294F, -0.42369F),
                    new Vector3(4.06533F, 25.97397F, 174.497F),
                    new Vector3(0.83909F, 0.83909F, 0.83909F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["HealAndRevive"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayHealAndRevive"),
                    "CalfR",
                    new Vector3(7.558F, -2.01461F, 4.31348F),
                    new Vector3(71.38712F, 185.9354F, 100.463F),
                    new Vector3(34.81064F, 34.81064F, 34.81064F)
                    )
                ));
        }
    }
}