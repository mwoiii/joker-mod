using System;
using JokerMod.Joker.SkillStates;
using JokerMod.Modules;
using JokerMod.Modules.PersonaMasks;
using RoR2;
using UnityEngine;

namespace JokerMod.Joker.Components {
    public class PersonaStatController : MonoBehaviour {

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

        private void Awake() {
            primaryPersona = JokerCatalog.GetPersonaFromNameToken("ARSENE");
            secondaryPersona = JokerCatalog.GetPersonaFromNameToken("EMPTY");
            utilityPersona = JokerCatalog.GetPersonaFromNameToken("EMPTY");
            _maxSP = 8f;
        }

        public void ForceMaxSPUpdate() {
            MaxSPUpdate?.Invoke(_maxSP);
        }

        public void ReceivePersona(ItemDef itemDef) {
            PersonaDef persona = JokerCatalog.GetPersonaFromItemDef(itemDef);
            if (!TryAssignPersona(persona)) {
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
    }
}
