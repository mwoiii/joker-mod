using System;
using JokerMod.Joker.Components;
using JokerMod.Modules.Personas;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using R2API;
using RoR2;

namespace JokerMod.Modules {
    public static class Items {

        public static void Init() {
            InitTierDefs();
            InitItemDefs();
            InitItemHooks();
        }

        private static void InitTierDefs() {
            ContentAddition.AddItemTierDef(Asset.maskTierDef);
        }

        private static void InitItemDefs() {
            new EmptyPersona().Init();

            new ArsenePersona().Init();
            new PixiePersona().Init();
            new HighPixiePersona().Init();
            new SarasvatiPersona().Init();
        }

        private static void InitItemHooks() {
            Hooks.IL_Handle_GenericPickupControllerAttemptGrant_Actions += JokerMaskPickup;
        }

        private static void JokerMaskPickup(ILContext il) {

            var continueDelegate = new Func<GenericPickupController, CharacterBody, PickupDef, bool>((RoR2.GenericPickupController self, CharacterBody body, PickupDef pickupDef) => {
                if (pickupDef.itemTier == Asset.maskTierDef.tier) {

                    // only joker can interact with masks 
                    if ((bool)body.GetComponent<JokerMaster>()) {
                        ItemDef itemDef = ItemCatalog.GetItemDef(pickupDef.itemIndex);

                        // cannot have dupes though
                        if (body.GetComponent<JokerMaster>().personaStockController.HasPersona(itemDef)) {
                            return false;
                        }

                        UserProfile userProfile = body?.master?.playerCharacterMasterController?.networkUser?.localUser?.userProfile;
                        if (userProfile != null) {
                            userProfile.DiscoverPickup(pickupDef.pickupIndex);
                        }
                        body.GetComponent<JokerMaster>().personaStockController.ReceivePersona(itemDef);

                        UnityEngine.Object.Destroy(self.gameObject);
                    }

                    return false;  // false: we should not continue (do not grant as an item)
                }
                return true;  // true: this is a regular item, resume
            });

            ILCursor c = new ILCursor(il);
            // if ((bool)body.inventory && pickupDef != null) {
            if (c.TryGotoNext(x => x.MatchLdarg(1)) &&
                c.TryGotoNext(x => x.MatchCallOrCallvirt<CharacterBody>("get_inventory")) &&
                c.TryGotoNext(x => x.MatchCallOrCallvirt<UnityEngine.Object>("op_Implicit")) &&
                c.TryGotoNext(x => x.MatchBrfalse(out var _)) &&
                c.TryGotoNext(x => x.MatchLdloc(1)) &&
                c.TryGotoNext(MoveType.After, x => x.MatchBrfalse(out var _))) {
                c.Emit(OpCodes.Ldarg_0);
                c.Emit(OpCodes.Ldarg_1);
                c.Emit(OpCodes.Ldloc_1);
                ILLabel resumeLabel = c.DefineLabel();
                c.EmitDelegate(continueDelegate);
                c.Emit(OpCodes.Brtrue, resumeLabel);
                c.Emit(OpCodes.Ret);
                c.MarkLabel(resumeLabel);
            } else {
                Log.Error("JokerMaskPickup ILHook failed. Mod boned");
            }
        }
    }
}
