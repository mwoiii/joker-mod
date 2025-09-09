using System;
using JokerMod.Joker.SkillStates;
using JokerMod.Modules;
using JokerMod.Modules.PersonaMasks;
using R2API.Networking;
using R2API.Networking.Interfaces;
using RoR2;
using UnityEngine;
using UnityEngine.Networking;

namespace JokerMod.Joker.Components {
    public enum PersonaSlot {
        Primary,
        Secondary,
        Utility
    }

    /// <summary>
    /// Holds stats related to Joker that need to persist between stages, including
    /// Persona stock and max SP.
    /// </summary>
    /// <remarks>
    /// Also contains methods to handle the aforementioned stats.
    /// </remarks>
    public class JokerStatController : MonoBehaviour {


        public PersonaDef primaryPersona;

        public PersonaDef secondaryPersona;

        public PersonaDef utilityPersona;

        public JokerMaster jokerMaster;

        public PersonaDef overstockPersona;

        public bool isUsingPrimary;

        public VoiceController voiceController;

        private float _maxSP;

        private GenericSkill lastUsedSkill;

        public float maxSP {
            get {
                return _maxSP;
            }
            set {
                _maxSP = value;
                MaxSPUpdate?.Invoke(_maxSP);
            }
        }

        public event Action<float> MaxSPUpdate;

        /// <summary>
        /// Compares the base SP cost to the minimum SP spend - if it is smaller, the minimum
        /// spend is preferred.
        /// </summary>
        /// <param name="baseSPCost">The base cost of the skill being casted.</param>
        /// <returns>The preferred cost, being either the base cost or the minimum spend.</returns>
        public float GetSPCost(float baseSPCost) {
            return Mathf.Max(Mathf.Floor(0.3f * _maxSP), baseSPCost);
        }

        /// <summary>
        /// Gets the final SP cost and checks if current SP is sufficient, subtracting
        /// from the total and returning true if so. Otherwise, just return false.
        /// </summary>
        /// <param name="baseSPCost">The base cost of the skill being casted.</param>
        /// <returns>Bool indicating whether or not the skill execution should proceeed.</returns>
        public bool TryCastSkill(float baseSPCost) {
            float spCost = GetSPCost(baseSPCost);
            if (jokerMaster.spController.currentSP >= spCost) {
                jokerMaster.spController.currentSP -= spCost;
                return true;
            }
            return false;
        }

        private void Awake() {
            SetDefaultStats();
            InitVoiceController();
        }

        private void InitVoiceController() {
            voiceController = gameObject.AddComponent<VoiceController>();

            voiceController.RegisterArray(JokerAssets.primaryVoiceWeakSoundEvents, 0.35f, 6f);

            voiceController.RegisterArray(JokerAssets.primaryVoiceMediumSoundEvents, 1f, 10f);
            voiceController.RegisterSharedStopwatch(JokerAssets.primaryVoiceMediumChargeSoundEvents, JokerAssets.primaryVoiceMediumSoundEvents);

            voiceController.RegisterArray(JokerAssets.primaryVoiceStrongSoundEvents, 1f, 16f);
            voiceController.RegisterSharedStopwatch(JokerAssets.primaryVoiceStrongAltSoundEvents, JokerAssets.primaryVoiceStrongSoundEvents);

            voiceController.RegisterArray(JokerAssets.summonPersonaSoundEvents, 1.5f, 16f);
            voiceController.RegisterSharedStopwatch(JokerAssets.castSkillAttackSoundEvents, JokerAssets.summonPersonaSoundEvents);
            voiceController.RegisterSharedStopwatch(JokerAssets.castSkillSupportSoundEvents, JokerAssets.summonPersonaSoundEvents);
        }

        private void SetDefaultStats() {
            primaryPersona = JokerCatalog.GetPersonaFromNameToken("ARSENE");
            secondaryPersona = JokerCatalog.GetPersonaFromNameToken("EMPTY");
            utilityPersona = JokerCatalog.GetPersonaFromNameToken("EMPTY");
            _maxSP = 8f; // 99999f;
        }

        public void ForceMaxSPUpdate() {
            MaxSPUpdate?.Invoke(_maxSP);
        }

        public PersonaDef GetPersonaFromLastSkill() {
            SkillLocator skillLocator = jokerMaster.GetComponent<SkillLocator>();
            if (lastUsedSkill == skillLocator.primary) {
                return primaryPersona;
            } else if (lastUsedSkill == skillLocator.secondary) {
                return secondaryPersona;
            } else if (lastUsedSkill == skillLocator.utility) {
                return utilityPersona;
            } else {
                return null;
            }
        }

        public void StoreLastSkillUsed(GenericSkill skill) {
            lastUsedSkill = skill;
        }

        public void ReceivePersonaSync(ItemDef itemDef) {
            new SyncJokerReceivePersona(GetComponent<CharacterMaster>().networkIdentity.netId, (int)itemDef.itemIndex).Send(NetworkDestination.Clients);
        }

        public void ReceivePersona(ItemDef itemDef) {
            PersonaDef persona = JokerCatalog.GetPersonaFromItemDef(itemDef);
            if (!TryAssignPersona(persona)) {
                if (overstockPersona != null) {
                    DropAfterOverstock(overstockPersona);
                }
                overstockPersona = persona;
                if (jokerMaster.characterBody.hasEffectiveAuthority) {
                    OverstockMenu nextState = new OverstockMenu();
                    nextState.skillMenuWasActive = jokerMaster.skillMenuActive;
                    EntityStateMachine.FindByCustomName(jokerMaster.gameObject, "Charge").SetNextState(nextState);
                }
            }
        }

        public bool HasPersona(ItemDef itemDef) {
            return primaryPersona.itemDef == itemDef || secondaryPersona.itemDef == itemDef || utilityPersona.itemDef == itemDef;
        }

        public void SwapPersonaWithOverstock(int slot) {
            SkillLocator skillLocator = jokerMaster.GetComponent<SkillLocator>();
            if (overstockPersona != null) {
                PersonaDef droppedPersona = null;
                switch (slot) {
                    case 1:
                        droppedPersona = primaryPersona;
                        AssignPersonaToSlot(PersonaSlot.Primary, overstockPersona, skillLocator.primary);
                        break;
                    case 2:
                        droppedPersona = secondaryPersona;
                        AssignPersonaToSlot(PersonaSlot.Secondary, overstockPersona, skillLocator.secondary);
                        break;
                    case 3:
                        droppedPersona = utilityPersona;
                        AssignPersonaToSlot(PersonaSlot.Utility, overstockPersona, skillLocator.utility);
                        break;
                    default:
                        droppedPersona = overstockPersona;
                        break;
                }
                DropAfterOverstock(droppedPersona);

            } else {
                Log.Error("Tried to swap a Persona when the overstock slot was empty!");
            }
        }

        public void SwapPersonaSlots(int slot1, int slot2) {
            if (slot1 != slot2) {
                if (Mathf.Max(slot1, slot2) > 3 || Mathf.Min(slot1, slot2) < 1) {
                    Log.Warning($"Aborting attempt to swap invalid slots {slot1}, {slot2}");
                    return;
                }

                SkillLocator skillLocator = jokerMaster.GetComponent<SkillLocator>();
                PersonaSlot firstSlot = 0; // dummy
                PersonaDef holdFirstPersona = null;
                GenericSkill firstSlotSkill = null;

                PersonaDef holdSecondPersona = null;

                switch (slot1) {
                    case 1:
                        holdFirstPersona = primaryPersona;
                        firstSlot = PersonaSlot.Primary;
                        firstSlotSkill = skillLocator.primary;
                        break;
                    case 2:
                        holdFirstPersona = secondaryPersona;
                        firstSlot = PersonaSlot.Secondary;
                        firstSlotSkill = skillLocator.secondary;
                        break;
                    case 3:
                        holdFirstPersona = utilityPersona;
                        firstSlot = PersonaSlot.Utility;
                        firstSlotSkill = skillLocator.utility;
                        break;
                }

                switch (slot2) {
                    case 1:
                        holdSecondPersona = primaryPersona;
                        AssignPersonaToSlot(PersonaSlot.Primary, holdFirstPersona, skillLocator.primary);
                        break;
                    case 2:
                        holdSecondPersona = secondaryPersona;
                        AssignPersonaToSlot(PersonaSlot.Secondary, holdFirstPersona, skillLocator.secondary);
                        break;
                    case 3:
                        holdSecondPersona = utilityPersona;
                        AssignPersonaToSlot(PersonaSlot.Utility, holdFirstPersona, skillLocator.utility);
                        break;
                }

                AssignPersonaToSlot(firstSlot, holdSecondPersona, firstSlotSkill);
            }
        }

        public void DropAfterOverstock(PersonaDef personaDef) {
            new SyncJokerDropPersona(GetComponent<CharacterMaster>().netIdentity.netId, personaDef.personaNameToken, jokerMaster.transform.position).Send(NetworkDestination.Clients);
            overstockPersona = null;
        }

        public static void CreatePersonaPickup(PersonaDef personaDef, Vector3 position) {
            GenericPickupController.CreatePickupInfo pickupInfo = default(GenericPickupController.CreatePickupInfo);
            pickupInfo.pickupIndex = PickupCatalog.FindPickupIndex(personaDef.itemDef.itemIndex);
            pickupInfo.position = position;
            PickupDropletController.CreatePickupDroplet(pickupInfo, position, Vector3.zero);
        }

        private bool TryAssignPersona(PersonaDef personaDef) {
            bool assigned = false;
            SkillLocator skillLocator = jokerMaster.GetComponent<SkillLocator>();

            if (primaryPersona.personaNameToken == "EMPTY") {
                AssignPersonaToSlot(PersonaSlot.Primary, personaDef, skillLocator.primary);
                assigned = true;
            } else if (secondaryPersona.personaNameToken == "EMPTY") {
                AssignPersonaToSlot(PersonaSlot.Secondary, personaDef, skillLocator.secondary);
                assigned = true;
            } else if (utilityPersona.personaNameToken == "EMPTY") {
                AssignPersonaToSlot(PersonaSlot.Utility, personaDef, skillLocator.utility);
                assigned = true;
            }

            return assigned;
        }

        private void AssignPersonaToSlot(PersonaSlot personaSlot, PersonaDef personaDef, GenericSkill skill) {
            if (jokerMaster.skillMenuActive) {
                switch (personaSlot) {
                    case PersonaSlot.Primary:
                        skill.UnsetSkillOverride(jokerMaster.gameObject, primaryPersona.skillDef, GenericSkill.SkillOverridePriority.Upgrade);
                        break;
                    case PersonaSlot.Secondary:
                        skill.UnsetSkillOverride(jokerMaster.gameObject, secondaryPersona.skillDef, GenericSkill.SkillOverridePriority.Upgrade);
                        break;
                    case PersonaSlot.Utility:
                        skill.UnsetSkillOverride(jokerMaster.gameObject, utilityPersona.skillDef, GenericSkill.SkillOverridePriority.Upgrade);
                        break;
                }
                skill.SetSkillOverride(jokerMaster.gameObject, personaDef.skillDef, GenericSkill.SkillOverridePriority.Upgrade);
            }
            new SyncJokerAssignPersona(GetComponent<CharacterMaster>().networkIdentity.netId, personaDef.personaNameToken, (int)personaSlot).Send(NetworkDestination.Clients);
        }

        public void UpdateAndDisplaySPCosts() {
            if (jokerMaster.characterBody.hasEffectiveAuthority && jokerMaster.skill1CostController != null) {
                if (primaryPersona != null && primaryPersona.baseSPCost > 0) {
                    jokerMaster.skill1CostController.gameObject.SetActive(true);
                    float skill1Cost = GetSPCost(primaryPersona.baseSPCost);
                    jokerMaster.skill1CostController.SetStat(skill1Cost);
                } else {
                    jokerMaster.skill1CostController.gameObject.SetActive(false);
                }

                if (secondaryPersona != null && secondaryPersona.baseSPCost > 0) {
                    jokerMaster.skill2CostController.gameObject.SetActive(true);
                    float skill2Cost = GetSPCost(secondaryPersona.baseSPCost);
                    jokerMaster.skill2CostController.SetStat(skill2Cost);
                } else {
                    jokerMaster.skill2CostController.gameObject.SetActive(false);
                }

                if (utilityPersona != null && utilityPersona.baseSPCost > 0) {
                    jokerMaster.skill3CostController.gameObject.SetActive(true);
                    float skill3Cost = GetSPCost(utilityPersona.baseSPCost);
                    jokerMaster.skill3CostController.SetStat(skill3Cost);
                } else {
                    jokerMaster.skill3CostController.gameObject.SetActive(false);
                }
            }
        }

        public void HideSPCosts() {
            if (jokerMaster.characterBody.hasEffectiveAuthority && jokerMaster.skill1CostController != null) {
                jokerMaster.skill1CostController.gameObject.SetActive(false);
                jokerMaster.skill2CostController.gameObject.SetActive(false);
                jokerMaster.skill3CostController.gameObject.SetActive(false);
            }
        }
    }

    public class SyncJokerReceivePersona : INetMessage {

        NetworkInstanceId masterNetId;
        int itemIndex;

        public SyncJokerReceivePersona() {
        }

        public SyncJokerReceivePersona(NetworkInstanceId masterNetId, int itemIndex) {
            this.masterNetId = masterNetId;
            this.itemIndex = itemIndex;
        }

        public void Serialize(NetworkWriter writer) {
            writer.Write(masterNetId);
            writer.Write(itemIndex);
        }

        public void Deserialize(NetworkReader reader) {
            masterNetId = reader.ReadNetworkId();
            itemIndex = reader.ReadInt32();
        }

        public void OnReceived() {
            bool isUs = LocalUserManager.GetFirstLocalUser()?.cachedMaster.netIdentity.netId == masterNetId;
            JokerStatController statController = Util.FindNetworkObject(masterNetId)?.GetComponent<JokerStatController>();
            if (isUs && statController != null) {
                statController.ReceivePersona(ItemCatalog.GetItemDef((ItemIndex)itemIndex));
            }
        }
    }

    public class SyncJokerDropPersona : INetMessage {

        NetworkInstanceId masterNetId;
        string personaNameToken;
        Vector3 position;

        public SyncJokerDropPersona() {
        }

        public SyncJokerDropPersona(NetworkInstanceId masterNetId, string personaNameToken, Vector3 position) {
            this.masterNetId = masterNetId;
            this.personaNameToken = personaNameToken;
            this.position = position;
        }

        public void Serialize(NetworkWriter writer) {
            writer.Write(masterNetId);
            writer.Write(personaNameToken);
            writer.Write(position);
        }

        public void Deserialize(NetworkReader reader) {
            masterNetId = reader.ReadNetworkId();
            personaNameToken = reader.ReadString();
            position = reader.ReadVector3();
        }

        public void OnReceived() {
            if (NetworkServer.active) {
                JokerStatController statController = Util.FindNetworkObject(masterNetId)?.GetComponent<JokerStatController>();
                if (statController != null) {
                    statController.overstockPersona = null;
                }
                JokerStatController.CreatePersonaPickup(JokerCatalog.GetPersonaFromNameToken(personaNameToken), position);
            }
        }
    }

    public class SyncJokerAssignPersona : INetMessage {

        NetworkInstanceId masterNetId;
        string personaNameToken;
        int personaSlot;

        public SyncJokerAssignPersona() {
        }

        public SyncJokerAssignPersona(NetworkInstanceId masterNetId, string personaNameToken, int personaSlot) {
            this.masterNetId = masterNetId;
            this.personaNameToken = personaNameToken;
            this.personaSlot = personaSlot;
        }

        public void Serialize(NetworkWriter writer) {
            writer.Write(masterNetId);
            writer.Write(personaNameToken);
            writer.Write(personaSlot);
        }

        public void Deserialize(NetworkReader reader) {
            masterNetId = reader.ReadNetworkId();
            personaNameToken = reader.ReadString();
            personaSlot = reader.ReadInt32();
        }

        public void OnReceived() {
            JokerStatController statController = Util.FindNetworkObject(masterNetId)?.GetComponent<JokerStatController>();
            if (statController != null) {
                switch ((PersonaSlot)personaSlot) {
                    case PersonaSlot.Primary:
                        statController.primaryPersona = JokerCatalog.GetPersonaFromNameToken(personaNameToken);
                        break;
                    case PersonaSlot.Secondary:
                        statController.secondaryPersona = JokerCatalog.GetPersonaFromNameToken(personaNameToken);
                        break;
                    case PersonaSlot.Utility:
                        statController.utilityPersona = JokerCatalog.GetPersonaFromNameToken(personaNameToken);
                        break;
                }
            }
        }
    }
}
