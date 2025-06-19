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

        private void Awake() {
            primaryPersona = JokerCatalog.GetPersonaFromNameToken("ARSENE");
            secondaryPersona = JokerCatalog.GetPersonaFromNameToken("EMPTY");
            utilityPersona = JokerCatalog.GetPersonaFromNameToken("EMPTY");
        }

        public void ReceivePersona(ItemDef itemDef) {
            PersonaDef persona = JokerCatalog.GetPersonaFromItemDef(itemDef);
            if (!TryAssignPersona(persona)) {
                return; // enter new skill state: GetNewPersona
            }
        }

        public bool HasPersona(ItemDef itemDef) {
            return primaryPersona.itemDef == itemDef || secondaryPersona.itemDef == itemDef || utilityPersona.itemDef == itemDef;
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

            if (assigned && master.skillMenuActive) {

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
