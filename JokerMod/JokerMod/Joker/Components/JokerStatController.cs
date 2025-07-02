using System;
using JokerMod.Joker.SkillStates;
using JokerMod.Modules;
using JokerMod.Modules.PersonaMasks;
using RoR2;
using UnityEngine;

namespace JokerMod.Joker.Components {

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

        public JokerMaster master;

        public PersonaDef overstockPersona;

        private float _maxSP;

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
            if (master.spController.currentSP >= spCost) {
                master.spController.currentSP -= spCost;
                return true;
            }
            return false;
        }

        private void Awake() {
            primaryPersona = JokerCatalog.GetPersonaFromNameToken("ARSENE");
            secondaryPersona = JokerCatalog.GetPersonaFromNameToken("EMPTY");
            utilityPersona = JokerCatalog.GetPersonaFromNameToken("EMPTY");
            _maxSP = 8f; // 99999f;
        }

        public void ForceMaxSPUpdate() {
            MaxSPUpdate?.Invoke(_maxSP);
        }

        public void ReceivePersona(ItemDef itemDef) {
            PersonaDef persona = JokerCatalog.GetPersonaFromItemDef(itemDef);
            if (!TryAssignPersona(persona)) {
                if (overstockPersona != null) {
                    DropAfterOverstock(overstockPersona);
                }
                overstockPersona = persona;
                EntityStateMachine.FindByCustomName(master.gameObject, "Charge").SetNextState(new SwapPersonaSkill(master.skillMenuActive));
            }
        }

        public bool HasPersona(ItemDef itemDef) {
            return primaryPersona.itemDef == itemDef || secondaryPersona.itemDef == itemDef || utilityPersona.itemDef == itemDef;
        }

        public void SwapPersona(int slot) {
            SkillLocator skillLocator = master.GetComponent<SkillLocator>();
            if (overstockPersona != null) {
                PersonaDef droppedPersona = null;
                switch (slot) {
                    case 1:
                        droppedPersona = primaryPersona;
                        AssignPersonaToSlot(ref primaryPersona, overstockPersona, skillLocator.primary);
                        break;
                    case 2:
                        droppedPersona = secondaryPersona;
                        AssignPersonaToSlot(ref secondaryPersona, overstockPersona, skillLocator.secondary);
                        break;
                    case 3:
                        droppedPersona = utilityPersona;
                        AssignPersonaToSlot(ref utilityPersona, overstockPersona, skillLocator.utility);
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

        public void DropAfterOverstock(PersonaDef personaDef) {
            GenericPickupController.CreatePickupInfo pickupInfo = default(GenericPickupController.CreatePickupInfo);
            pickupInfo.pickupIndex = PickupCatalog.FindPickupIndex(personaDef.itemDef.itemIndex);
            pickupInfo.position = master.transform.position;
            PickupDropletController.CreatePickupDroplet(pickupInfo, master.transform.position, Vector3.zero);
            overstockPersona = null;
        }

        private bool TryAssignPersona(PersonaDef personaDef) {
            bool assigned = false;
            SkillLocator skillLocator = master.GetComponent<SkillLocator>();

            if (primaryPersona.personaNameToken == "EMPTY") {
                AssignPersonaToSlot(ref primaryPersona, personaDef, skillLocator.primary);
                assigned = true;
            } else if (secondaryPersona.personaNameToken == "EMPTY") {
                AssignPersonaToSlot(ref secondaryPersona, personaDef, skillLocator.secondary);
                assigned = true;
            } else if (utilityPersona.personaNameToken == "EMPTY") {
                AssignPersonaToSlot(ref utilityPersona, personaDef, skillLocator.utility);
                assigned = true;
            }

            return assigned;
        }

        private void AssignPersonaToSlot(ref PersonaDef personaSlot, PersonaDef personaDef, GenericSkill skill) {
            if (master.skillMenuActive) {
                skill.UnsetSkillOverride(master.gameObject, personaSlot.skillDef, GenericSkill.SkillOverridePriority.Upgrade);
                skill.SetSkillOverride(master.gameObject, personaDef.skillDef, GenericSkill.SkillOverridePriority.Upgrade);
            }
            personaSlot = personaDef;
        }

        public void UpdateAndDisplaySPCosts() {
            if (primaryPersona != null && primaryPersona.baseSPCost > 0) {
                master.skill1CostController.gameObject.SetActive(true);
                float skill1Cost = GetSPCost(primaryPersona.baseSPCost);
                master.skill1CostController.SetStat(skill1Cost);
            }

            if (secondaryPersona != null && secondaryPersona.baseSPCost > 0) {
                master.skill2CostController.gameObject.SetActive(true);
                float skill2Cost = GetSPCost(secondaryPersona.baseSPCost);
                master.skill2CostController.SetStat(skill2Cost);
            }

            if (utilityPersona != null && utilityPersona.baseSPCost > 0) {
                master.skill3CostController.gameObject.SetActive(true);
                float skill3Cost = GetSPCost(utilityPersona.baseSPCost);
                master.skill3CostController.SetStat(skill3Cost);
            }
        }

        public void HideSPCosts() {
            master.skill1CostController.gameObject.SetActive(false);
            master.skill2CostController.gameObject.SetActive(false);
            master.skill3CostController.gameObject.SetActive(false);
        }
    }
}
