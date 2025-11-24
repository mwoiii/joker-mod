using System;
using JokerMod.Joker.Components;
using JokerMod.Modules.PersonaMasks;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using RoR2;
using UnityEngine;

namespace JokerMod.Modules {
    public static class Items {

        public static void Init() {
            InitTierDefs();
            InitItemDefs();
            InitItemHooks();
        }

        private static void InitTierDefs() {
            ContentPacks.itemTierDefs.Add(Asset.maskTierDef);
        }

        private static void InitItemDefs() {
            new EmptyPersona().Init();

            // Bless
            new AngelPersona().Init();
            new NigiMitamaPersona().Init();
            new MithraPersona().Init();
            new PrincipalityPersona().Init();
            new HorusPersona().Init();
            new DominionPersona().Init();

            // Curse
            new ArsenePersona().Init();
            new NuePersona().Init();
            new LeananSidhePersona().Init();
            new WhiteRiderPersona().Init();
            new BelialPersona().Init();
            new SkadiPersona().Init();

            // Fire
            new JackoLanternPersona().Init();
            new HuaPoPersona().Init();
            new OrthrusPersona().Init();
            new HellBikerPersona().Init();
            new YatagarasuPersona().Init();
            new MolochPersona().Init();

            // Ice
            new ApsarasPersona().Init();
            new JackFrostPersona().Init();
            new LilimPersona().Init();
            new ByakkoPersona().Init();
            new KingFrostPersona().Init();
            new YamataNoOrochiPersona().Init();

            // Wind
            new KelpiePersona().Init();
            new NekomataPersona().Init();
            new SandmanPersona().Init();
            new KurumaTenguPersona().Init();
            new FortunaPersona().Init();
            new QuetzalcoatlPersona().Init();

            // Elec
            new AgathionPersona().Init();
            new AmeNoUzumePersona().Init();
            new NagaPersona().Init();
            new ThunderbirdPersona().Init();
            new RajaNagaPersona().Init();
            new DionysusPersona().Init();

            // Nuke
            new ShiisaaPersona().Init();
            new MakamiPersona().Init();
            new PhoenixPersona().Init();
            new MithrasPersona().Init();
            new TitaniaPersona().Init();
            new LilithPersona().Init();

            // Psy
            new KodamaPersona().Init();
            new MatadorPersona().Init();
            new SudamaPersona().Init();
            new ShikiOujiPersona().Init();
            new ForneusPersona().Init();
            new NebirosPersona().Init();

            // Healing
            new PixiePersona().Init();
            new KushiMitamaPersona().Init();
            new HighPixiePersona().Init();
            new KikuriHimePersona().Init();
            new SarasvatiPersona().Init();
            new LakshmiPersona().Init();
        }

        public static void CreateRandomMaskDroplet(float level, Vector3 position) {
            GenericPickupController.CreatePickupInfo pickupInfo = default(GenericPickupController.CreatePickupInfo);
            pickupInfo.pickupIndex = PickupCatalog.FindPickupIndex(JokerCatalog.RollForMask(level).itemDef.itemIndex);
            pickupInfo.position = position;
            PickupDropletController.CreatePickupDroplet(pickupInfo, position, Vector3.zero);
        }

        private static void InitItemHooks() {
            Hooks.Handle_GenericPickupControllerStart_Actions += AddMaskDecay;
            Hooks.IL_Handle_GenericPickupControllerAttemptGrant_Actions += JokerMaskPickup;
        }

        private static void AddMaskDecay(GenericPickupController self) {
            if (self?.pickupIndex.pickupDef?.itemIndex != null) {
                ItemDef itemDef = ItemCatalog.GetItemDef(self.pickupIndex.pickupDef.itemIndex);
                if (JokerCatalog.CheckIsMask(itemDef)) {
                    DestructionTimer timer = self.gameObject.AddComponent<DestructionTimer>();
                }
            }
        }

        private static void JokerMaskPickup(ILContext il) {

            var continueDelegate = new Func<GenericPickupController, CharacterBody, PickupDef, bool>((GenericPickupController self, CharacterBody body, PickupDef pickupDef) => {
                if (pickupDef.itemTier == Asset.maskTierDef.tier) {

                    // only joker can interact with masks 
                    if ((bool)body.GetComponent<JokerMaster>()) {
                        ItemDef itemDef = ItemCatalog.GetItemDef(pickupDef.itemIndex);

                        // cannot have dupes though
                        if (body.GetComponent<JokerMaster>().statController.HasPersona(itemDef)) {
                            return false;
                        }

                        UserProfile userProfile = body?.master?.playerCharacterMasterController?.networkUser?.localUser?.userProfile;
                        if (userProfile != null) {
                            userProfile.DiscoverPickup(pickupDef.pickupIndex);
                        }
                        body.GetComponent<JokerMaster>().statController.ReceivePersonaSync(itemDef);

                        UnityEngine.Object.Destroy(self.gameObject);
                    }

                    return false;  // false: we should not continue (do not grant as an item)
                }
                return true;  // true: this is a regular item, resume
            });

            ILCursor c = new ILCursor(il);
            // grantContext.rotation = rotation;
            if (c.TryGotoNext(x => x.MatchLdloca(out _)) &&
                c.TryGotoNext(x => x.MatchLdloc(out _)) &&
                c.TryGotoNext(MoveType.After, x => x.MatchStfld<RoR2.PickupDef.GrantContext>("rotation"))) {
                c.Emit(OpCodes.Ldarg_0);
                c.Emit(OpCodes.Ldarg_1);
                c.Emit(OpCodes.Ldloc_2);
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
