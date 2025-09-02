using Mono.Cecil.Cil;
using MonoMod.Cil;
using R2API;
using RoR2;
using UnityEngine;

namespace JokerMod.Modules.Buffs {
    public static class IrradiatedDebuff {

        public static BuffDef buffDef;

        public static DotController.DotIndex dotIndex;

        private static float stackFractionDamage = 0.0005f;

        private static float extraDebuffFractionDamage = 0.001f;

        public static void Init() {
            CreateBuff();
            Hooks.IL_Handle_DotControllerEvaluateDOTStacksForType_Actions += DotMultiplier;
        }

        private static void CreateBuff() {
            buffDef = ScriptableObject.CreateInstance<BuffDef>();
            buffDef.name = "PersonaNukeIrradiated";
            buffDef.iconSprite = Asset.nukeDebuffIcon;
            buffDef.buffColor = new Color(0.04f, 0.97f, 0.98f);
            buffDef.canStack = true;
            buffDef.isDebuff = true;
            buffDef.isDOT = true;

            Content.AddBuffDef(buffDef);

            DotController.DotDef dotDef = new() {
                associatedBuff = buffDef,
                damageColorIndex = DamageColorIndex.Poison,
                interval = 2f,
            };
            dotIndex = DotAPI.RegisterDotDef(dotDef, DotBehaviour);
        }

        private static void DotBehaviour(DotController dotController, DotController.DotStack dotStack) {
            dotStack.damage = dotController.victimHealthComponent.fullCombinedHealth * stackFractionDamage;
        }

        private static void DotMultiplier(ILContext il) {
            int debuffs = 0;

            var countTimedDebuffsDelegate = delegate (DotController dotController, DotController.DotIndex dotIndex) {
                if (dotIndex == IrradiatedDebuff.dotIndex && dotController.victimBody != null && dotController.victimBody.HasBuff(IrradiatedDebuff.buffDef)) {
                    debuffs = 0;
                    foreach (CharacterBody.TimedBuff timedBuff in dotController.victimBody.timedBuffs) {
                        if (BuffCatalog.GetBuffDef(timedBuff.buffIndex).isDebuff) {
                            debuffs++;
                        }
                    }

                    for (int i = 0; i < dotController.victimBody.buffs.Length; i++) {
                        BuffDef buffDef = BuffCatalog.GetBuffDef((BuffIndex)i);
                        if (buffDef != null && buffDef != IrradiatedDebuff.buffDef && buffDef.isDOT) {
                            debuffs += dotController.victimBody.buffs[i];
                        }
                    }
                }
            };

            var calcDamageDelegate = delegate (DotController dotController, DotController.DotStack dotStack) {
                if (dotStack.dotIndex == IrradiatedDebuff.dotIndex) {
                    dotStack.damage = dotController.victimHealthComponent.fullCombinedHealth * (stackFractionDamage + extraDebuffFractionDamage * debuffs);
                }
            };

            ILCursor c = new ILCursor(il);
            // just before: remainingActive = 0;
            // but just anywhere at the start works
            if (c.TryGotoNext(x => x.MatchLdarg(3))) {
                c.Emit(OpCodes.Ldarg_0);
                c.Emit(OpCodes.Ldarg_1);
                c.EmitDelegate(countTimedDebuffsDelegate);
                // after: dotStack.timer -= dt;
                if (c.TryGotoNext(x => x.MatchLdloc(3)) &&
                    c.TryGotoNext(x => x.MatchDup()) &&
                    c.TryGotoNext(x => x.MatchLdfld<DotController.DotStack>("timer")) &&
                    c.TryGotoNext(x => x.MatchLdarg(2)) &&
                    c.TryGotoNext(x => x.MatchSub()) &&
                    c.TryGotoNext(MoveType.After, x => x.MatchStfld<DotController.DotStack>("timer"))) {
                    c.Emit(OpCodes.Ldarg_0);
                    c.Emit(OpCodes.Ldloc_3);
                    c.EmitDelegate(calcDamageDelegate);
                } else {
                    Log.Error("DotMultiplier ILHook failed (2). Irradiated debuff will not scale properly.");
                }
            } else {
                Log.Error("DotMultiplier ILHook failed (1). Irradiated debuff will not scale properly.");
            }
        }
    }
}
