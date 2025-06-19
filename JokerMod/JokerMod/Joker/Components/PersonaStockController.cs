using System.Net.NetworkInformation;
using JokerMod.Joker.SkillStates;
using JokerMod.Modules;
using JokerMod.Modules.Personas;
using RoR2;
using UnityEngine;

namespace JokerMod.Joker.Components {
    public class PersonaStockController : MonoBehaviour {

        public PersonaDef primaryPersona;

        public PersonaDef secondaryPersona;

        public PersonaDef utilityPersona;

        public JokerMaster master;

        public PersonaDef overstockPersona;

        private void Awake() {
            primaryPersona = JokerCatalog.GetPersonaFromNameToken("ARSENE");
            secondaryPersona = JokerCatalog.GetPersonaFromNameToken("EMPTY");
            utilityPersona = JokerCatalog.GetPersonaFromNameToken("EMPTY");
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
                        Log.Info("On my default shit");
                        droppedPersona = overstockPersona;
                        break;                
                }
                DropAfterOverstock(droppedPersona);
                
            } else {
                Log.Error("Tried to swap a Persona when the overstock slot was empty!");
            }
        }

        public void DropAfterOverstock(PersonaDef personaDef) {
            Log.Info(personaDef.personaNameToken);
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
                Log.Info(secondaryPersona.personaNameToken);
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
